using BikeSuperRacing.Domain.Profile;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface IPlayerProfileService
    {
        PlayerProfile CurrentProfile { get; }
        bool IsInitialized { get; }

        bool InitializeProfile();
        bool SaveProfile();

        void SetSelectedBikeId(string bikeId);
        void SetSelectedColorId(string colorId);
        void SetMusicVolume(float volume);
        void SetSfxVolume(float volume);

        bool TryGetBestTimeSeconds(string mapId, out float bestTimeSeconds);
        bool TrySetBestTimeSeconds(string mapId, float bestTimeSeconds);
    }
}
