using BikeSuperRacing.Domain.Race;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface IRaceResultService
    {
        RaceResult CreateRaceResult(RaceSession raceSession, float finalTimeSeconds);
    }
}
