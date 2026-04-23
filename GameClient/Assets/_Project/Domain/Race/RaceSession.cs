using System;

namespace BikeSuperRacing.Domain.Race
{
    [Serializable]
    public sealed class RaceSession
    {
        public string MapId;
        public string BikeId;
        public string ColorId;
        public string LeaderboardId;
        public RaceState RaceState;
        public int AttemptIndex;
        public long StartedAtUtcTicks;

        public void SetRaceState(RaceState raceState)
        {
            RaceState = raceState;
        }
    }
}
