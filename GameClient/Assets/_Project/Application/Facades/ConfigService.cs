using System.Collections.Generic;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Bikes;
using BikeSuperRacing.Domain.Game;
using BikeSuperRacing.Domain.Maps;
using UnityEngine;

namespace BikeSuperRacing.Application.Facades
{
    public sealed class ConfigService : IConfigService
    {
        private readonly Dictionary<string, MapDefinition> _mapDefinitionsById = new();
        private readonly Dictionary<string, BikeDefinition> _bikeDefinitionsById = new();
        private readonly Dictionary<string, BikeColorDefinition> _bikeColorDefinitionsById = new();

        public bool IsInitialized { get; private set; }
        public GameConfig GameConfig { get; private set; }
        public MapDefinition DefaultMap { get; private set; }
        public BikeDefinition DefaultBike { get; private set; }
        public BikeColorDefinition DefaultColor { get; private set; }

        public bool Initialize(GameConfig gameConfig)
        {
            IsInitialized = false;
            GameConfig = null;
            DefaultMap = null;
            DefaultBike = null;
            DefaultColor = null;

            _mapDefinitionsById.Clear();
            _bikeDefinitionsById.Clear();
            _bikeColorDefinitionsById.Clear();

            if (gameConfig == null)
            {
                Debug.LogError("ConfigService: GameConfig is null.");
                return false;
            }

            if (!gameConfig.IsValid(out var configErrorMessage))
            {
                Debug.LogError(configErrorMessage);
                return false;
            }

            GameConfig = gameConfig;
            DefaultMap = gameConfig.DefaultMap;
            DefaultBike = gameConfig.DefaultBike;
            DefaultColor = gameConfig.DefaultColor;

            RegisterMaps(gameConfig.Maps);
            RegisterBikes(gameConfig.Bikes);
            RegisterBikeColors(gameConfig.BikeColors);

            if (!TryGetMapDefinition(DefaultMap.Id, out _))
            {
                Debug.LogError($"ConfigService: default map '{DefaultMap.Id}' is missing in catalog.");
                return false;
            }

            if (!TryGetBikeDefinition(DefaultBike.Id, out _))
            {
                Debug.LogError($"ConfigService: default bike '{DefaultBike.Id}' is missing in catalog.");
                return false;
            }

            if (!TryGetBikeColorDefinition(DefaultColor.Id, out _))
            {
                Debug.LogError($"ConfigService: default color '{DefaultColor.Id}' is missing in catalog.");
                return false;
            }

            IsInitialized = true;
            return true;
        }

        public bool TryGetMapDefinition(string id, out MapDefinition mapDefinition)
        {
            mapDefinition = null;
            return !string.IsNullOrWhiteSpace(id)
                   && _mapDefinitionsById.TryGetValue(id.Trim(), out mapDefinition)
                   && mapDefinition != null;
        }

        public bool TryGetBikeDefinition(string id, out BikeDefinition bikeDefinition)
        {
            bikeDefinition = null;
            return !string.IsNullOrWhiteSpace(id)
                   && _bikeDefinitionsById.TryGetValue(id.Trim(), out bikeDefinition)
                   && bikeDefinition != null;
        }

        public bool TryGetBikeColorDefinition(string id, out BikeColorDefinition bikeColorDefinition)
        {
            bikeColorDefinition = null;
            return !string.IsNullOrWhiteSpace(id)
                   && _bikeColorDefinitionsById.TryGetValue(id.Trim(), out bikeColorDefinition)
                   && bikeColorDefinition != null;
        }

        private void RegisterMaps(IReadOnlyList<MapDefinition> maps)
        {
            if (maps == null)
            {
                return;
            }

            for (var i = 0; i < maps.Count; i++)
            {
                var mapDefinition = maps[i];

                if (mapDefinition == null)
                {
                    continue;
                }

                if (!mapDefinition.IsEnabled)
                {
                    continue;
                }

                if (!mapDefinition.IsValid(out var errorMessage))
                {
                    Debug.LogError(errorMessage);
                    continue;
                }

                if (_mapDefinitionsById.ContainsKey(mapDefinition.Id))
                {
                    Debug.LogError($"ConfigService: duplicate map id '{mapDefinition.Id}'.");
                    continue;
                }

                _mapDefinitionsById.Add(mapDefinition.Id, mapDefinition);
            }
        }

        private void RegisterBikes(IReadOnlyList<BikeDefinition> bikes)
        {
            if (bikes == null)
            {
                return;
            }

            for (var i = 0; i < bikes.Count; i++)
            {
                var bikeDefinition = bikes[i];

                if (bikeDefinition == null)
                {
                    continue;
                }

                if (!bikeDefinition.IsEnabled)
                {
                    continue;
                }

                if (!bikeDefinition.IsValid(out var errorMessage))
                {
                    Debug.LogError(errorMessage);
                    continue;
                }

                if (_bikeDefinitionsById.ContainsKey(bikeDefinition.Id))
                {
                    Debug.LogError($"ConfigService: duplicate bike id '{bikeDefinition.Id}'.");
                    continue;
                }

                _bikeDefinitionsById.Add(bikeDefinition.Id, bikeDefinition);
            }
        }

        private void RegisterBikeColors(IReadOnlyList<BikeColorDefinition> bikeColors)
        {
            if (bikeColors == null)
            {
                return;
            }

            for (var i = 0; i < bikeColors.Count; i++)
            {
                var bikeColorDefinition = bikeColors[i];

                if (bikeColorDefinition == null)
                {
                    continue;
                }

                if (!bikeColorDefinition.IsEnabled)
                {
                    continue;
                }

                if (!bikeColorDefinition.IsValid(out var errorMessage))
                {
                    Debug.LogError(errorMessage);
                    continue;
                }

                if (_bikeColorDefinitionsById.ContainsKey(bikeColorDefinition.Id))
                {
                    Debug.LogError($"ConfigService: duplicate bike color id '{bikeColorDefinition.Id}'.");
                    continue;
                }

                _bikeColorDefinitionsById.Add(bikeColorDefinition.Id, bikeColorDefinition);
            }
        }
    }
}
