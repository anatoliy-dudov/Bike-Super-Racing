using System.Collections.Generic;
using BikeSuperRacing.Core.Common;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain;
using UnityEngine.SceneManagement;

namespace BikeSuperRacing.Application.Facades
{
    public sealed class AppStateService : IAppStateService
    {
        public AppState Current { get; private set; } = AppState.Bootstrap;

        public void Enter(AppState state)
        {
            Current = state;
        }
    }

    public sealed class SceneLoader : ISceneLoader
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public sealed class ConfigService : IConfigService
    {
        public GameConfig GameConfig { get; private set; }

        public void Configure(GameConfig gameConfig)
        {
            GameConfig = gameConfig;
        }

        public MapDefinition GetDefaultMap() => GameConfig != null ? GameConfig.DefaultMap : null;
        public BikeDefinition GetDefaultBike() => GameConfig != null ? GameConfig.DefaultBike : null;
        public BikeColorDefinition GetDefaultColor() => GameConfig != null ? GameConfig.DefaultColor : null;
    }

    public sealed class PlayerProfileService : IPlayerProfileService
    {
        public PlayerProfile Current { get; private set; } = new PlayerProfile();

        public void Load(PlayerProfile profile)
        {
            Current = profile ?? new PlayerProfile();
        }

        public void SetSelectedBike(string bikeId)
        {
            Current.SelectedBikeId = bikeId;
        }

        public void SetSelectedColor(string colorId)
        {
            Current.SelectedColorId = colorId;
        }

        public void SetBestTime(string mapId, long timeMs)
        {
            var existing = Current.BestTimesByMap.Find(entry => entry.MapId == mapId);
            if (existing == null)
            {
                Current.BestTimesByMap.Add(new MapBestTimeEntry { MapId = mapId, BestTimeMs = timeMs });
                return;
            }

            if (existing.BestTimeMs <= 0 || timeMs < existing.BestTimeMs)
            {
                existing.BestTimeMs = timeMs;
            }
        }

        public long? GetBestTime(string mapId)
        {
            var existing = Current.BestTimesByMap.Find(entry => entry.MapId == mapId);
            return existing != null ? existing.BestTimeMs : null;
        }
    }
}
