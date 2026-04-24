using System;
using BikeSuperRacing.Core.Common;
using BikeSuperRacing.Domain;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface IAppStateService
    {
        AppState Current { get; }
        void Enter(AppState state);
    }

    public interface ISceneLoader
    {
        void Load(string sceneName);
    }

    public interface IConfigService
    {
        GameConfig GameConfig { get; }
        MapDefinition GetDefaultMap();
        BikeDefinition GetDefaultBike();
        BikeColorDefinition GetDefaultColor();
    }

    public interface IPlayerProfileService
    {
        PlayerProfile Current { get; }
        void Load(PlayerProfile profile);
        void SetSelectedBike(string bikeId);
        void SetSelectedColor(string colorId);
        void SetBestTime(string mapId, long timeMs);
    }

    public interface ISaveService
    {
        PlayerProfile Load();
        void Save(PlayerProfile profile);
        bool HasSave();
    }

    public interface ILeaderboardService
    {
        void SubmitScore(string leaderboardId, long score);
        long? GetBestLocalScore(string leaderboardId);
    }

    public interface IRaceSessionService
    {
        RaceSession Current { get; }
        void Create(RaceSession session);
        void Clear();
    }

    public interface IRaceTimerService
    {
        void Start();
        void Stop();
        long CurrentTimeMs { get; }
        bool IsRunning { get; }
    }

    public interface ICountdownService
    {
        void StartCountdown(int seconds);
        bool IsFinished { get; }
    }

    public interface IRaceResultService
    {
        RaceResult Complete(string mapId, long timeMs);
    }

    public interface IAudioSettingsService
    {
        float MusicVolume { get; }
        float SfxVolume { get; }
        void SetMusicVolume(float value);
        void SetSfxVolume(float value);
    }

    public interface ILocalizationService
    {
        string Get(string key);
    }

    public interface ITimeService
    {
        DateTime UtcNow { get; }
    }
}
