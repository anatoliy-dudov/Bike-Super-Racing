using BikeSuperRacing.Bootstrap.EntryPoint;
using UnityEngine;
using UnityEngine.UI;

namespace BikeSuperRacing.UI.Screens.MainMenu
{
    public sealed class MainMenuScreen : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _leaderboardButton;

        [Header("Popups")]
        [SerializeField] private GameObject _settingsPopupRoot;
        [SerializeField] private GameObject _leaderboardPopupRoot;

        private void OnEnable()
        {
            if (_playButton != null)
            {
                _playButton.onClick.AddListener(HandlePlayButtonClicked);
            }

            if (_settingsButton != null)
            {
                _settingsButton.onClick.AddListener(HandleSettingsButtonClicked);
            }

            if (_leaderboardButton != null)
            {
                _leaderboardButton.onClick.AddListener(HandleLeaderboardButtonClicked);
            }
        }

        private void OnDisable()
        {
            if (_playButton != null)
            {
                _playButton.onClick.RemoveListener(HandlePlayButtonClicked);
            }

            if (_settingsButton != null)
            {
                _settingsButton.onClick.RemoveListener(HandleSettingsButtonClicked);
            }

            if (_leaderboardButton != null)
            {
                _leaderboardButton.onClick.RemoveListener(HandleLeaderboardButtonClicked);
            }
        }

        private void Start()
        {
            SetPopupVisible(_settingsPopupRoot, false);
            SetPopupVisible(_leaderboardPopupRoot, false);
        }

        private void HandlePlayButtonClicked()
        {
            var raceSceneName = Bootstrapper.ConfigService != null && Bootstrapper.ConfigService.GameConfig != null
                ? Bootstrapper.ConfigService.GameConfig.RaceSceneName
                : string.Empty;

            if (string.IsNullOrWhiteSpace(raceSceneName))
            {
                Debug.LogError("MainMenuScreen: RaceSceneName is empty.");
                return;
            }

            Bootstrapper.SceneLoader?.LoadScene(raceSceneName);
        }

        private void HandleSettingsButtonClicked()
        {
            TogglePopup(_settingsPopupRoot);
        }

        private void HandleLeaderboardButtonClicked()
        {
            TogglePopup(_leaderboardPopupRoot);
        }

        private static void TogglePopup(GameObject popupRoot)
        {
            if (popupRoot == null)
            {
                return;
            }

            popupRoot.SetActive(!popupRoot.activeSelf);
        }

        private static void SetPopupVisible(GameObject popupRoot, bool isVisible)
        {
            if (popupRoot == null)
            {
                return;
            }

            popupRoot.SetActive(isVisible);
        }
    }
}
