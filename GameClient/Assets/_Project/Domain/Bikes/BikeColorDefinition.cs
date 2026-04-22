using UnityEngine;

namespace BikeSuperRacing.Domain.Bikes
{
    [CreateAssetMenu(
        fileName = "CFG_Color_Red",
        menuName = "Bike Super Racing/Configs/Bike Color Definition")]
    public sealed class BikeColorDefinition : ScriptableObject
    {
        [SerializeField] private string _id = "color_red";
        [SerializeField] private string _displayName = "Red";
        [SerializeField] private string _colorHex = "#FF0000";
        [SerializeField] private bool _isEnabled = true;

        public string Id => _id;
        public string DisplayName => _displayName;
        public string ColorHex => _colorHex;
        public bool IsEnabled => _isEnabled;

        public bool TryGetColor(out Color color)
        {
            if (string.IsNullOrWhiteSpace(_colorHex))
            {
                color = Color.white;
                return false;
            }

            return ColorUtility.TryParseHtmlString(_colorHex, out color);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _id = string.IsNullOrWhiteSpace(_id) ? "color_red" : _id.Trim();
            _displayName = string.IsNullOrWhiteSpace(_displayName) ? "Red" : _displayName.Trim();

            if (string.IsNullOrWhiteSpace(_colorHex))
            {
                _colorHex = "#FF0000";
                return;
            }

            _colorHex = _colorHex.Trim();

            if (!_colorHex.StartsWith("#"))
            {
                _colorHex = $"#{_colorHex}";
            }

            if (!ColorUtility.TryParseHtmlString(_colorHex, out _))
            {
                _colorHex = "#FF0000";
            }
        }
#endif

        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(_id))
            {
                errorMessage = $"{name}: Id is empty.";
                return false;
            }

            if (!ColorUtility.TryParseHtmlString(_colorHex, out _))
            {
                errorMessage = $"{name}: ColorHex is invalid.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
