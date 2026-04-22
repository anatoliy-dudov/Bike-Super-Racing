using System.Collections.Generic;
using BikeSuperRacing.Domain.Bikes;
using BikeSuperRacing.Domain.Maps;
using UnityEngine;

namespace BikeSuperRacing.Domain.Game
{
    [CreateAssetMenu(
        fileName = "CFG_Game_Main",
        menuName = "Bike Super Racing/Configs/Game Config")]
    public sealed class GameConfig : ScriptableObject
    {
        [Header("Scene Names")]
        [SerializeField] private string _bootstrapSceneName = "00_Bootstrap";
        [SerializeField] private string _mainMenuSceneName = "01_MainMenu";
        [SerializeField] private string _raceSceneName = "02_Race";

        [Header("Defaults")]
        [SerializeField] private MapDefinition _defaultMap;
        [SerializeField] private BikeDefinition _defaultBike;
        [SerializeField] private BikeColorDefinition _defaultColor;

        [Header("Catalogs")]
        [SerializeField] private List<MapDefinition> _maps = new();
        [SerializeField] private List<BikeDefinition> _bikes = new();
        [SerializeField] private List<BikeColorDefinition> _bikeColors = new();

        [Header("Save")]
        [SerializeField] private string _saveFileName = "bike_super_racing_profile.json";

        public string BootstrapSceneName => _bootstrapSceneName;
        public string MainMenuSceneName => _mainMenuSceneName;
        public string RaceSceneName => _raceSceneName;
        public MapDefinition DefaultMap => _defaultMap;
        public BikeDefinition DefaultBike => _defaultBike;
        public BikeColorDefinition DefaultColor => _defaultColor;
        public IReadOnlyList<MapDefinition> Maps => _maps;
        public IReadOnlyList<BikeDefinition> Bikes => _bikes;
        public IReadOnlyList<BikeColorDefinition> BikeColors => _bikeColors;
        public string SaveFileName => _saveFileName;

#if UNITY_EDITOR
        private void OnValidate()
        {
            _bootstrapSceneName = string.IsNullOrWhiteSpace(_bootstrapSceneName) ? "00_Bootstrap" : _bootstrapSceneName.Trim();
            _mainMenuSceneName = string.IsNullOrWhiteSpace(_mainMenuSceneName) ? "01_MainMenu" : _mainMenuSceneName.Trim();
            _raceSceneName = string.IsNullOrWhiteSpace(_raceSceneName) ? "02_Race" : _raceSceneName.Trim();
            _saveFileName = string.IsNullOrWhiteSpace(_saveFileName) ? "bike_super_racing_profile.json" : _saveFileName.Trim();
        }
#endif

        public bool IsValid(out string errorMessage)
        {
            if (_defaultMap == null)
            {
                errorMessage = $"{name}: DefaultMap is not assigned.";
                return false;
            }

            if (_defaultBike == null)
            {
                errorMessage = $"{name}: DefaultBike is not assigned.";
                return false;
            }

            if (_defaultColor == null)
            {
                errorMessage = $"{name}: DefaultColor is not assigned.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(_mainMenuSceneName))
            {
                errorMessage = $"{name}: MainMenuSceneName is empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(_saveFileName))
            {
                errorMessage = $"{name}: SaveFileName is empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
