using System;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Profile;
using UnityEngine;

namespace BikeSuperRacing.Application.Facades
{
    public sealed class PlayerProfileService : IPlayerProfileService
    {
        private readonly ISaveService _saveService;
        private readonly IConfigService _configService;
        private readonly ITimeService _timeService;

        public PlayerProfileService(ISaveService saveService, IConfigService configService, ITimeService timeService)
        {
            _saveService = saveService;
            _configService = configService;
            _timeService = timeService;
        }

        public PlayerProfile CurrentProfile { get; private set; }
        public bool IsInitialized { get; private set; }

        public bool InitializeProfile()
        {
            IsInitialized = false;

            if (_configService == null || !_configService.IsInitialized)
            {
                Debug.LogError("PlayerProfileService: ConfigService is not initialized.");
                return false;
            }

            if (_saveService != null && _saveService.TryLoad(out var loadedProfile) && loadedProfile != null)
            {
                loadedProfile.ClampAndNormalize(_configService.GameConfig);
                CurrentProfile = loadedProfile;
                IsInitialized = true;
                return true;
            }

            CurrentProfile = new PlayerProfile();
            CurrentProfile.ApplyDefaults(_configService.GameConfig);
            CurrentProfile.ClampAndNormalize(_configService.GameConfig);
            CurrentProfile.MarkUpdated(_timeService != null ? _timeService.GetUtcNow() : DateTime.UtcNow);
            IsInitialized = true;
            return SaveProfile();
        }

        public bool SaveProfile()
        {
            if (CurrentProfile == null)
            {
                Debug.LogError("PlayerProfileService: CurrentProfile is null.");
                return false;
            }

            if (_saveService == null)
            {
                Debug.LogError("PlayerProfileService: SaveService is null.");
                return false;
            }

            CurrentProfile.ClampAndNormalize(_configService != null ? _configService.GameConfig : null);
            CurrentProfile.MarkUpdated(_timeService != null ? _timeService.GetUtcNow() : DateTime.UtcNow);
            return _saveService.Save(CurrentProfile);
        }

        public void SetSelectedBikeId(string bikeId)
        {
            if (CurrentProfile == null)
            {
                return;
            }

            if (_configService == null || !_configService.TryGetBikeDefinition(bikeId, out _))
            {
                return;
            }

            CurrentProfile.SetSelectedBikeId(bikeId);
        }

        public void SetSelectedColorId(string colorId)
        {
            if (CurrentProfile == null)
            {
                return;
            }

            if (_configService == null || !_configService.TryGetBikeColorDefinition(colorId, out _))
            {
                return;
            }

            CurrentProfile.SetSelectedColorId(colorId);
        }

        public void SetMusicVolume(float volume)
        {
            CurrentProfile?.SetMusicVolume(volume);
        }

        public void SetSfxVolume(float volume)
        {
            CurrentProfile?.SetSfxVolume(volume);
        }

        public bool TryGetBestTimeSeconds(string mapId, out float bestTimeSeconds)
        {
            bestTimeSeconds = 0f;
            return CurrentProfile != null && CurrentProfile.TryGetBestTimeSeconds(mapId, out bestTimeSeconds);
        }

        public bool TrySetBestTimeSeconds(string mapId, float bestTimeSeconds)
        {
            if (CurrentProfile == null)
            {
                return false;
            }

            if (_configService == null || !_configService.TryGetMapDefinition(mapId, out _))
            {
                return false;
            }

            return CurrentProfile.TrySetBestTimeSeconds(mapId, bestTimeSeconds);
        }
    }
}
