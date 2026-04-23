using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Race;

namespace BikeSuperRacing.Gameplay.RaceFlow
{
    public sealed class RaceSessionService : IRaceSessionService
    {
        private readonly ITimeService _timeService;
        private int _attemptIndex;

        public RaceSessionService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public RaceSession CurrentRaceSession { get; private set; }
        public bool HasActiveSession => CurrentRaceSession != null;

        public RaceSession CreateRaceSession(string mapId, string bikeId, string colorId, string leaderboardId)
        {
            _attemptIndex++;

            CurrentRaceSession = new RaceSession
            {
                MapId = mapId,
                BikeId = bikeId,
                ColorId = colorId,
                LeaderboardId = leaderboardId,
                RaceState = RaceState.EnterRaceScene,
                AttemptIndex = _attemptIndex,
                StartedAtUtcTicks = _timeService != null ? _timeService.GetUtcNow().Ticks : 0L,
            };

            return CurrentRaceSession;
        }

        public void SetRaceState(RaceState raceState)
        {
            CurrentRaceSession?.SetRaceState(raceState);
        }

        public void ClearRaceSession()
        {
            CurrentRaceSession = null;
        }
    }
}
