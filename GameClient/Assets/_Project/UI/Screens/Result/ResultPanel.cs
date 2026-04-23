using System;
using BikeSuperRacing.Domain.Race;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BikeSuperRacing.UI.Screens.Result
{
    public sealed class ResultPanel : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _currentTimeText;
        [SerializeField] private TMP_Text _bestTimeText;
        [SerializeField] private GameObject _newBestRoot;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private GameObject _root;

        public event Action RestartRequested;
        public event Action ExitRequested;

        private void OnEnable()
        {
            if (_restartButton != null)
            {
                _restartButton.onClick.AddListener(HandleRestartButtonClicked);
            }

            if (_backButton != null)
            {
                _backButton.onClick.AddListener(HandleBackButtonClicked);
            }
        }

        private void OnDisable()
        {
            if (_restartButton != null)
            {
                _restartButton.onClick.RemoveListener(HandleRestartButtonClicked);
            }

            if (_backButton != null)
            {
                _backButton.onClick.RemoveListener(HandleBackButtonClicked);
            }
        }

        public void Show(RaceResult raceResult)
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(true);

            if (raceResult == null)
            {
                if (_currentTimeText != null)
                {
                    _currentTimeText.text = "00:00.000";
                }

                if (_bestTimeText != null)
                {
                    _bestTimeText.text = "00:00.000";
                }

                if (_newBestRoot != null)
                {
                    _newBestRoot.SetActive(false);
                }

                SetInteractable(true);
                return;
            }

            if (_currentTimeText != null)
            {
                _currentTimeText.text = FormatTime(raceResult.FinalTimeSeconds);
            }

            if (_bestTimeText != null)
            {
                _bestTimeText.text = FormatTime(raceResult.BestTimeSeconds);
            }

            if (_newBestRoot != null)
            {
                _newBestRoot.SetActive(raceResult.IsNewBest);
            }

            SetInteractable(true);
        }

        public void Hide()
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(false);

            if (_newBestRoot != null)
            {
                _newBestRoot.SetActive(false);
            }
        }

        public void SetInteractable(bool isInteractable)
        {
            if (_restartButton != null)
            {
                _restartButton.interactable = isInteractable;
            }

            if (_backButton != null)
            {
                _backButton.interactable = isInteractable;
            }
        }

        private void HandleRestartButtonClicked()
        {
            RestartRequested?.Invoke();
        }

        private void HandleBackButtonClicked()
        {
            ExitRequested?.Invoke();
        }

        private static string FormatTime(float timeSeconds)
        {
            var clampedTimeSeconds = timeSeconds < 0f ? 0f : timeSeconds;
            var minutes = Mathf.FloorToInt(clampedTimeSeconds / 60f);
            var seconds = Mathf.FloorToInt(clampedTimeSeconds % 60f);
            var milliseconds = Mathf.FloorToInt((clampedTimeSeconds - Mathf.Floor(clampedTimeSeconds)) * 1000f);
            return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
        }
    }
}
