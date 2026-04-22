using UnityEngine;

namespace BikeSuperRacing.Domain.Bikes
{
    [CreateAssetMenu(
        fileName = "CFG_Bike_Bike01",
        menuName = "Bike Super Racing/Configs/Bike Definition")]
    public sealed class BikeDefinition : ScriptableObject
    {
        [SerializeField] private string _id = "bike_01";
        [SerializeField] private string _displayName = "Bike 01";
        [SerializeField] private float _acceleration = 20f;
        [SerializeField] private float _maxSpeed = 18f;
        [SerializeField] private float _handling = 12f;
        [SerializeField] private bool _isEnabled = true;

        public string Id => _id;
        public string DisplayName => _displayName;
        public float Acceleration => _acceleration;
        public float MaxSpeed => _maxSpeed;
        public float Handling => _handling;
        public bool IsEnabled => _isEnabled;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _id = string.IsNullOrWhiteSpace(_id) ? "bike_01" : _id.Trim();
            _displayName = string.IsNullOrWhiteSpace(_displayName) ? "Bike 01" : _displayName.Trim();
            _acceleration = Mathf.Max(0f, _acceleration);
            _maxSpeed = Mathf.Max(0f, _maxSpeed);
            _handling = Mathf.Max(0f, _handling);
        }
#endif

        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(_id))
            {
                errorMessage = $"{name}: Id is empty.";
                return false;
            }

            if (_maxSpeed <= 0f)
            {
                errorMessage = $"{name}: MaxSpeed must be greater than 0.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
