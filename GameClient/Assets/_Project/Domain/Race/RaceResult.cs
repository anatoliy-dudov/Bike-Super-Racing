using System;

namespace BikeSuperRacing.Domain.Race
{
    [Serializable]
    public sealed class RaceResult
    {
        public string MapId;
        public string LeaderboardId;
        public float FinalTimeSeconds;
        public float BestTimeSeconds;
        public bool IsNewBest;
        public long CompletedAtUtcTicks;
    }
}
