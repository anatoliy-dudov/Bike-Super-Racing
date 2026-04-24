using BikeSuperRacing.Bootstrap.EntryPoint;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Race;
using BikeSuperRacing.Gameplay.Bike.Controllers;
using BikeSuperRacing.Gameplay.Bike.View;
using BikeSuperRacing.Gameplay.Countdown;
using BikeSuperRacing.Gameplay.Finish;
using BikeSuperRacing.Gameplay.Timer;
using BikeSuperRacing.UI.HUD;
using BikeSuperRacing.UI.Screens.Result;
using BikeSuperRacing.UI.Widgets;
using UnityEngine;

namespace BikeSuperRacing.Gameplay.RaceFlow
{
    public sealed class RaceFlowController : MonoBehaviour
    {
        [Header("Bike")]
        [SerializeField] private Transform _bikeTransform;
        [SerializeField] private Rigidbody2D _bikeRigidbody2D;
        [SerializeField] private BikeController2D _bikeController2D;
        [SerializeField] private BikeColorApplier _bikeColorApplier;
        [SerializeField] private Behaviour[] _controlBehaviours;
        [SerializeField] private Transform _startPoint;

        [Header("Race References")]
        [SerializeField] private FinishTrigger _finishTrigger;
        [SerializeField] private string _mapIdOverride = string.Empty;
        [SerializeField] private float _countdownDurationSeconds = 5f;
        [SerializeField] private bool _autoStartCountdownOnStart = true;

        [Header("UI")]
        [SerializeField] private RaceHudView _raceHudView;
        [SerializeField] private CountdownWidget _countdownWidget;
        [SerializeField] private ResultPanel _resultPanel;

        private IConfigService _configService;
        private IPlayerProfileService _playerProfileService;
        private ITimeService _timeService;
        private ISceneLoader _sceneLoader;
        private IRaceSessionService _raceSessionService;
        private IRaceTimerService _raceTimerService;
        private ICountdownService _countdownService;
        private IRaceResultService _raceResultService;
        private bool _isInitialized;

        private void Awake()
        {
            InitializeServices();
        }

        private void OnEnable()
        {
            if (_raceHudView != null)
            {
                _raceHudView.PauseRequested += HandlePauseRequested;
            }

            if (_resultPanel != null)
            {
                _resultPanel.RestartRequested += HandleRestartRequested;
                _resultPanel.ExitRequested += HandleExitRequested;
            }
        }

        private void OnDisable()
        {
            if (_raceHudView != null)
            {
                _raceHudView.PauseRequested -= HandlePauseRequested;
            }

            if (_resultPanel != null)
            {
                _resultPanel.RestartRequested -= HandleRestartRequested;
                _resultPanel.ExitRequested -= HandleExitRequested;
            }
        }

        private void Start()
        {
            if (!_isInitialized)
            {
                return;
            }

            if (_finishTrigger != null)
            {
                _finishTrigger.RegisterTargetBike(_bikeRigidbody2D);
            }

            StartNewAttempt();
        }

        private void Update()
        {
            if (!_isInitialized || _raceSessionService == null || !_raceSessionService.HasActiveSession)
            {
                return;
            }

            switch (_raceSessionService.CurrentRaceSession.RaceState)
            {
                case RaceState.Countdown:
                    UpdateCountdown();
                    break;
                case RaceState.RaceActive:
                    UpdateRaceTimer();
                    break;
            }
        }

        public void HandleFinishTriggered()
        {
            if (!_isInitialized || _raceSessionService?.CurrentRaceSession == null)
            {
                return;
            }

            if (_raceSessionService.CurrentRaceSession.RaceState != RaceState.RaceActive)
            {
                return;
            }

            DisableBikeControl();
            _raceTimerService.StopTimer();
            _raceSessionService.SetRaceState(RaceState.RaceFinished);
            var raceResult = _raceResultService.CreateRaceResult(_raceSessionService.CurrentRaceSession, _raceTimerService.ElapsedTimeSeconds);
            _raceSessionService.SetRaceState(RaceState.ResultPresentation);

            if (_resultPanel != null)
            {
                _resultPanel.Show(raceResult);
            }
        }

        private void InitializeServices()
        {
            _configService = Bootstrapper.ConfigService;
            _playerProfileService = Bootstrapper.PlayerProfileService;
            _timeService = Bootstrapper.TimeService;
            _sceneLoader = Bootstrapper.SceneLoader;

            if (_configService == null || !_configService.IsInitialized || _playerProfileService == null || !_playerProfileService.IsInitialized)
            {
                Debug.LogError("RaceFlowController: required bootstrap services are not initialized.");
                _isInitialized = false;
                return;
            }

            _raceSessionService = new RaceSessionService(_timeService);
            _raceTimerService = new RaceTimerService();
            _countdownService = new CountdownService();
            _raceResultService = new RaceResultService(_playerProfileService, _timeService);
            _isInitialized = true;
        }

        private void StartNewAttempt()
        {
            var mapId = !string.IsNullOrWhiteSpace(_mapIdOverride) ? _mapIdOverride.Trim() : _configService.DefaultMap.Id;

            if (!_configService.TryGetMapDefinition(mapId, out var mapDefinition))
            {
                Debug.LogError($"RaceFlowController: map '{mapId}' is not registered.");
                return;
            }

            var bikeId = _playerProfileService.CurrentProfile != null ? _playerProfileService.CurrentProfile.SelectedBikeId : _configService.DefaultBike.Id;
            if (!_configService.TryGetBikeDefinition(bikeId, out var bikeDefinition))
            {
                bikeDefinition = _configService.DefaultBike;
                bikeId = bikeDefinition.Id;
            }

            var colorId = _playerProfileService.CurrentProfile != null ? _playerProfileService.CurrentProfile.SelectedColorId : _configService.DefaultColor.Id;
            if (!_configService.TryGetBikeColorDefinition(colorId, out var bikeColorDefinition))
            {
                bikeColorDefinition = _configService.DefaultColor;
                colorId = bikeColorDefinition.Id;
            }

            _raceSessionService.CreateRaceSession(mapDefinition.Id, bikeId, colorId, mapDefinition.LeaderboardId);
            _raceSessionService.SetRaceState(RaceState.EnterRaceScene);

            if (_bikeController2D != null)
            {
                _bikeController2D.ApplyBikeDefinition(bikeDefinition);
            }

            if (_bikeColorApplier != null)
            {
                _bikeColorApplier.ApplyBikeColorDefinition(bikeColorDefinition);
            }

            ResetBikeRuntime();
            _raceTimerService.ResetTimer();
            _countdownService.CancelCountdown();

            if (_raceHudView != null)
            {
                _raceHudView.SetVisible(true);
                _raceHudView.SetTimer(0f);
            }

            if (_resultPanel != null)
            {
                _resultPanel.Hide();
                _resultPanel.SetInteractable(true);
            }

            if (_countdownWidget != null)
            {
                _countdownWidget.Hide();
            }

            DisableBikeControl();
            _raceSessionService.SetRaceState(RaceState.PreStart);

            if (_autoStartCountdownOnStart)
            {
                BeginCountdown();
            }
        }

        private void BeginCountdown()
        {
            if (_raceSessionService?.CurrentRaceSession == null)
            {
                return;
            }

            _raceSessionService.SetRaceState(RaceState.Countdown);
            _countdownService.StartCountdown(_countdownDurationSeconds);

            if (_countdownWidget != null)
            {
                _countdownWidget.ShowValue(_countdownService.CurrentDisplayValue);
            }
        }

        private void BeginRaceActive()
        {
            EnableBikeControl();
            _raceTimerService.ResetTimer();
            _raceTimerService.StartTimer();
            _raceSessionService.SetRaceState(RaceState.RaceActive);

            if (_countdownWidget != null)
            {
                _countdownWidget.Hide();
            }
        }

        private void UpdateCountdown()
        {
            var completed = _countdownService.Tick(Time.deltaTime);

            if (_countdownWidget != null)
            {
                if (_countdownService.IsRunning)
                {
                    _countdownWidget.ShowValue(_countdownService.CurrentDisplayValue);
                }
                else
                {
                    _countdownWidget.Hide();
                }
            }

            if (completed)
            {
                BeginRaceActive();
            }
        }

        private void UpdateRaceTimer()
        {
            _raceTimerService.Tick(Time.deltaTime);

            if (_raceHudView != null)
            {
                _raceHudView.SetTimer(_raceTimerService.ElapsedTimeSeconds);
            }
        }

        private void HandleRestartRequested()
        {
            if (_raceSessionService?.CurrentRaceSession == null)
            {
                return;
            }

            _raceSessionService.SetRaceState(RaceState.RestartRequested);

            if (_resultPanel != null)
            {
                _resultPanel.SetInteractable(false);
            }

            StartNewAttempt();
        }

        private void HandleExitRequested()
        {
            var mainMenuSceneName = _configService != null && _configService.GameConfig != null ? _configService.GameConfig.MainMenuSceneName : string.Empty;

            if (string.IsNullOrWhiteSpace(mainMenuSceneName))
            {
                Debug.LogError("RaceFlowController: MainMenuSceneName is empty.");
                return;
            }

            _sceneLoader?.LoadScene(mainMenuSceneName);
        }

        private void HandlePauseRequested()
        {
            if (_raceSessionService?.CurrentRaceSession == null)
            {
                return;
            }

            if (_raceSessionService.CurrentRaceSession.RaceState == RaceState.RaceActive)
            {
                _raceSessionService.SetRaceState(RaceState.Pause);
                _raceTimerService.StopTimer();
                DisableBikeControl();
                return;
            }

            if (_raceSessionService.CurrentRaceSession.RaceState == RaceState.Pause)
            {
                _raceSessionService.SetRaceState(RaceState.RaceActive);
                _raceTimerService.StartTimer();
                EnableBikeControl();
            }
        }

        private void ResetBikeRuntime()
        {
            if (_bikeTransform != null && _startPoint != null)
            {
                _bikeTransform.SetPositionAndRotation(_startPoint.position, _startPoint.rotation);
            }

            if (_bikeController2D != null)
            {
                _bikeController2D.ResetRuntimeState();
                return;
            }

            if (_bikeRigidbody2D != null)
            {
                _bikeRigidbody2D.linearVelocity = Vector2.zero;
                _bikeRigidbody2D.angularVelocity = 0f;
                _bikeRigidbody2D.Sleep();
                _bikeRigidbody2D.WakeUp();
            }
        }

        private void EnableBikeControl()
        {
            if (_controlBehaviours == null)
            {
                return;
            }

            for (var i = 0; i < _controlBehaviours.Length; i++)
            {
                if (_controlBehaviours[i] != null)
                {
                    _controlBehaviours[i].enabled = true;
                }
            }
        }

        private void DisableBikeControl()
        {
            if (_controlBehaviours == null)
            {
                return;
            }

            for (var i = 0; i < _controlBehaviours.Length; i++)
            {
                if (_controlBehaviours[i] != null)
                {
                    _controlBehaviours[i].enabled = false;
                }
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _countdownDurationSeconds = Mathf.Max(0f, _countdownDurationSeconds);
        }
#endif
    }
}
