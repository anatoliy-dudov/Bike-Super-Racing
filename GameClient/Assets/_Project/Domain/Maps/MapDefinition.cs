using UnityEngine;

namespace BikeSuperRacing.Domain.Maps
{
    [CreateAssetMenu(
        fileName = "CFG_Map_Map01",
        menuName = "Bike Super Racing/Configs/Map Definition")]
    public sealed class MapDefinition : ScriptableObject
    {
        [SerializeField] private string _id = "map_01";
        [SerializeField] private string _displayName = "Map 01";
        [SerializeField] private string _sceneName = "02_Race";
        [SerializeField] private string _leaderboardId = "leaderboard_map_01";
        [SerializeField] private bool _isEnabled = true;

        public string Id => _id;
        public string DisplayName => _displayName;
        public string SceneName => _sceneName;
        public string LeaderboardId => _leaderboardId;
        public bool IsEnabled => _isEnabled;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _id = string.IsNullOrWhiteSpace(_id) ? "map_01" : _id.Trim();
            _displayName = string.IsNullOrWhiteSpace(_displayName) ? "Map 01" : _displayName.Trim();
            _sceneName = string.IsNullOrWhiteSpace(_sceneName) ? "02_Race" : _sceneName.Trim();
            _leaderboardId = string.IsNullOrWhiteSpace(_leaderboardId) ? "leaderboard_map_01" : _leaderboardId.Trim();
        }
#endif

        public bool IsValid(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(_id))
            {
                errorMessage = $"{name}: Id is empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(_sceneName))
            {
                errorMessage = $"{name}: SceneName is empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(_leaderboardId))
            {
                errorMessage = $"{name}: LeaderboardId is empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
