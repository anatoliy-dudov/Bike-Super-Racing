using BikeSuperRacing.Domain.Profile;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface ISaveService
    {
        bool Exists();
        bool TryLoad(out PlayerProfile playerProfile);
        bool Save(PlayerProfile playerProfile);
        bool Delete();
    }
}
