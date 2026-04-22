using BikeSuperRacing.Domain.Bikes;
using BikeSuperRacing.Domain.Game;
using BikeSuperRacing.Domain.Maps;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface IConfigService
    {
        bool IsInitialized { get; }
        GameConfig GameConfig { get; }
        MapDefinition DefaultMap { get; }
        BikeDefinition DefaultBike { get; }
        BikeColorDefinition DefaultColor { get; }

        bool Initialize(GameConfig gameConfig);
        bool TryGetMapDefinition(string id, out MapDefinition mapDefinition);
        bool TryGetBikeDefinition(string id, out BikeDefinition bikeDefinition);
        bool TryGetBikeColorDefinition(string id, out BikeColorDefinition bikeColorDefinition);
    }
}
