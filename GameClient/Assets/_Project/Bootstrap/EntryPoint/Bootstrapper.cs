using System.Collections;
using BikeSuperRacing.Application.Facades;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Game;
using BikeSuperRacing.Infrastructure.Save.CloudStub;
using BikeSuperRacing.Infrastructure.Save.Local;
using BikeSuperRacing.Infrastructure.Time;
using UnityEngine;

namespace BikeSuperRacing.Bootstrap.EntryPoint
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private GameConfig _gameConfig;

        [Header("Flow")]
        [SerializeField] private bool _loadMainMenuOnStart = true;
        [SerializeField] private bool _verboseLogging = true;

        public static Bootstrapper Instance { get; private set; }
        public static IAppStateService AppStateService { get; private set; }
        public static ISceneLoader SceneLoader { get; private set; }
        public static IConfigService ConfigService { get; private set; }
        public static IPlayerProfileService PlayerProfileService { get; private set; }
        public static ISaveService SaveService { get; private set; }
        public static ITimeService TimeService { get; private set; }
        public static CloudSaveStubService CloudSaveStubService { get; private set; }

        private bool _isInitialized;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("Bootstrapper: duplicate instance detected. Destroying duplicate.");
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            _isInitialized = InitializeServices();
            enabled = _isInitialized;
        }

        private IEnumerator Start()
        {
            if (!_isInitialized)
            {
                yield break;
            }

            if (!_loadMainMenuOnStart)
            {
                yield break;
            }

            var mainMenuSceneName = ConfigService?.GameConfig != null
                ? ConfigService.GameConfig.MainMenuSceneName
                : string.Empty;

            if (string.IsNullOrWhiteSpace(mainMenuSceneName))
            {
                Debug.LogError("Bootstrapper: MainMenuSceneName is empty.");
                yield break;
            }

            if (_verboseLogging)
            {
                Debug.Log($"Bootstrapper: loading scene '{mainMenuSceneName}'.");
            }

            var asyncOperation = SceneLoader?.LoadScene(mainMenuSceneName);

            if (asyncOperation == null)
            {
                yield break;
            }

            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            AppStateService?.MarkBootstrapCompleted();
        }

        private bool InitializeServices()
        {
            if (_gameConfig == null)
            {
                Debug.LogError("Bootstrapper: GameConfig reference is missing.");
                return false;
            }

            if (!_gameConfig.IsValid(out var gameConfigErrorMessage))
            {
                Debug.LogError($"Bootstrapper: {gameConfigErrorMessage}");
                return false;
            }

            TimeService = new TimeService();
            AppStateService = new AppStateService();
            AppStateService.SetCurrentScene(_gameConfig.BootstrapSceneName);

            var configService = new ConfigService();

            if (!configService.Initialize(_gameConfig))
            {
                Debug.LogError("Bootstrapper: failed to initialize ConfigService.");
                return false;
            }

            ConfigService = configService;
            SceneLoader = new SceneLoader(AppStateService);
            SaveService = new LocalSaveService(_gameConfig.SaveFileName);
            CloudSaveStubService = new CloudSaveStubService();

            var playerProfileService = new PlayerProfileService(SaveService, ConfigService, TimeService);

            if (!playerProfileService.InitializeProfile())
            {
                Debug.LogError("Bootstrapper: failed to initialize PlayerProfileService.");
                return false;
            }

            PlayerProfileService = playerProfileService;

            if (_verboseLogging)
            {
                Debug.Log("Bootstrapper: services initialized successfully.");
            }

            return true;
        }

        private void OnDestroy()
        {
            if (Instance != this)
            {
                return;
            }

            Instance = null;
            AppStateService = null;
            SceneLoader = null;
            ConfigService = null;
            PlayerProfileService = null;
            SaveService = null;
            TimeService = null;
            CloudSaveStubService = null;
        }
    }
}
