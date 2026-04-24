using UnityEngine;
using UnityEngine.UI;

namespace BikeSuperRacing.UI.Popups.Leaderboard
{
    public sealed class LeaderboardPopup : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Button _closeButton;

        private void OnEnable()
        {
            if (_closeButton != null)
            {
                _closeButton.onClick.AddListener(Hide);
            }
        }

        private void OnDisable()
        {
            if (_closeButton != null)
            {
                _closeButton.onClick.RemoveListener(Hide);
            }
        }

        public void Show()
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(true);
        }

        public void Hide()
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(false);
        }
    }
}
