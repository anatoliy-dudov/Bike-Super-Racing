using System;
using System.Collections.Generic;
using BikeSuperRacing.Domain.Game;
using UnityEngine;

namespace BikeSuperRacing.Domain.Profile
{
    [Serializable]
    public sealed class PlayerProfile
    {
        [SerializeField] private string _selectedBikeId = "bike_01";
        [SerializeField] private string _selectedColorId = "color_red";
        [SerializeField] private List<string> _bestTimeMapIds = new();
        [SerializeField] private List<float> _bestTimeSeconds = new();
        [SerializeField] private float _musicVolume = 0.75f;
        [SerializeField] private float _sfxVolume = 0.75f;
        [SerializeField] private long _updatedAtUtcTicks;

        public string SelectedBikeId => _selectedBikeId;
        public string SelectedColorId => _selectedColorId;
        public IReadOnlyDictionary<string, float> BestTimesByMap => BuildBestTimesByMap();
        public float MusicVolume => _musicVolume;
        public float SfxVolume => _sfxVolume;
        public long UpdatedAtUtcTicks => _updatedAtUtcTicks;

        public void ApplyDefaults(GameConfig gameConfig)
        {
            if (gameConfig == null)
            {
                _selectedBikeId = "bike_01";
                _selectedColorId = "color_red";
                _musicVolume = 0.75f;
                _sfxVolume = 0.75f;
                return;
            }

            _selectedBikeId = gameConfig.DefaultBike != null ? gameConfig.DefaultBike.Id : "bike_01";
            _selectedColorId = gameConfig.DefaultColor != null ? gameConfig.DefaultColor.Id : "color_red";
            _musicVolume = 0.75f;
            _sfxVolume = 0.75f;
        }

        public void SetSelectedBikeId(string bikeId)
        {
            _selectedBikeId = string.IsNullOrWhiteSpace(bikeId) ? _selectedBikeId : bikeId.Trim();
        }

        public void SetSelectedColorId(string colorId)
        {
            _selectedColorId = string.IsNullOrWhiteSpace(colorId) ? _selectedColorId : colorId.Trim();
        }

        public void SetMusicVolume(float volume)
        {
            _musicVolume = Mathf.Clamp01(volume);
        }

        public void SetSfxVolume(float volume)
        {
            _sfxVolume = Mathf.Clamp01(volume);
        }

        public bool TryGetBestTimeSeconds(string mapId, out float bestTimeSeconds)
        {
            bestTimeSeconds = 0f;

            if (string.IsNullOrWhiteSpace(mapId))
            {
                return false;
            }

            var normalizedMapId = mapId.Trim();

            for (var i = 0; i < _bestTimeMapIds.Count; i++)
            {
                if (_bestTimeMapIds[i] != normalizedMapId)
                {
                    continue;
                }

                if (i >= _bestTimeSeconds.Count)
                {
                    return false;
                }

                bestTimeSeconds = _bestTimeSeconds[i];
                return true;
            }

            return false;
        }

        public bool TrySetBestTimeSeconds(string mapId, float bestTimeSeconds)
        {
            if (string.IsNullOrWhiteSpace(mapId) || bestTimeSeconds <= 0f)
            {
                return false;
            }

            var normalizedMapId = mapId.Trim();

            for (var i = 0; i < _bestTimeMapIds.Count; i++)
            {
                if (_bestTimeMapIds[i] != normalizedMapId)
                {
                    continue;
                }

                if (i >= _bestTimeSeconds.Count)
                {
                    _bestTimeSeconds.Add(bestTimeSeconds);
                    return true;
                }

                if (_bestTimeSeconds[i] <= 0f || bestTimeSeconds < _bestTimeSeconds[i])
                {
                    _bestTimeSeconds[i] = bestTimeSeconds;
                    return true;
                }

                return false;
            }

            _bestTimeMapIds.Add(normalizedMapId);
            _bestTimeSeconds.Add(bestTimeSeconds);
            return true;
        }

        public void MarkUpdated(DateTime utcNow)
        {
            _updatedAtUtcTicks = utcNow.Ticks;
        }

        public void ClampAndNormalize(GameConfig gameConfig)
        {
            _selectedBikeId = string.IsNullOrWhiteSpace(_selectedBikeId)
                ? (gameConfig != null && gameConfig.DefaultBike != null ? gameConfig.DefaultBike.Id : "bike_01")
                : _selectedBikeId.Trim();

            _selectedColorId = string.IsNullOrWhiteSpace(_selectedColorId)
                ? (gameConfig != null && gameConfig.DefaultColor != null ? gameConfig.DefaultColor.Id : "color_red")
                : _selectedColorId.Trim();

            _musicVolume = Mathf.Clamp01(_musicVolume);
            _sfxVolume = Mathf.Clamp01(_sfxVolume);

            while (_bestTimeSeconds.Count < _bestTimeMapIds.Count)
            {
                _bestTimeSeconds.Add(0f);
            }

            while (_bestTimeSeconds.Count > _bestTimeMapIds.Count)
            {
                _bestTimeSeconds.RemoveAt(_bestTimeSeconds.Count - 1);
            }

            for (var i = _bestTimeMapIds.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(_bestTimeMapIds[i]))
                {
                    _bestTimeMapIds.RemoveAt(i);
                    _bestTimeSeconds.RemoveAt(i);
                    continue;
                }

                _bestTimeMapIds[i] = _bestTimeMapIds[i].Trim();

                if (_bestTimeSeconds[i] < 0f)
                {
                    _bestTimeSeconds[i] = 0f;
                }
            }
        }

        private IReadOnlyDictionary<string, float> BuildBestTimesByMap()
        {
            var dictionary = new Dictionary<string, float>(_bestTimeMapIds.Count);

            for (var i = 0; i < _bestTimeMapIds.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(_bestTimeMapIds[i]) || i >= _bestTimeSeconds.Count)
                {
                    continue;
                }

                dictionary[_bestTimeMapIds[i]] = _bestTimeSeconds[i];
            }

            return dictionary;
        }
    }
}
