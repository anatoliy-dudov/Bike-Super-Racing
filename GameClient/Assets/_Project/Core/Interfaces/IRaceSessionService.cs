using BikeSuperRacing.Domain.Race;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface IRaceSessionService
    {
        RaceSession CurrentRaceSession { get; }
        bool HasActiveSession { get; }

        RaceSession CreateRaceSession(string mapId, string bikeId, string colorId, string leaderboardId);
        void SetRaceState(RaceState raceState);
        void ClearRaceSession();
    }
}
