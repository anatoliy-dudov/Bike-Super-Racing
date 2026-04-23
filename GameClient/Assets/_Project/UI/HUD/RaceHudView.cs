using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BikeSuperRacing.UI.HUD
{
    public sealed class RaceHudView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _root;

        public event Action PauseRequested;

        private void OnEnable()
        {
            if (_pauseButton != null)
            {
                _pauseButton.onClick.AddListener(HandlePauseButtonClicked);
            }
        }

        private void OnDisable()
        {
            if (_pauseButton != null)
            {
                _pauseButton.onClick.RemoveListener(HandlePauseButtonClicked);
            }
        }

        public void SetVisible(bool isVisible)
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(isVisible);
        }

        public void SetTimer(float elapsedTimeSeconds)
        {
            if (_timerText == null)
            {
                return;
            }

            _timerText.text = FormatTime(elapsedTimeSeconds);
        }

        private void HandlePauseButtonClicked()
        {
            PauseRequested?.Invoke();
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
