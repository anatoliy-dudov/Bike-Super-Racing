using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Race;

namespace BikeSuperRacing.Gameplay.RaceFlow
{
    public sealed class RaceResultService : IRaceResultService
    {
        private readonly IPlayerProfileService _playerProfileService;
        private readonly ITimeService _timeService;

        public RaceResultService(IPlayerProfileService playerProfileService, ITimeService timeService)
        {
            _playerProfileService = playerProfileService;
            _timeService = timeService;
        }

        public RaceResult CreateRaceResult(RaceSession raceSession, float finalTimeSeconds)
        {
            var normalizedFinalTimeSeconds = finalTimeSeconds > 0f ? finalTimeSeconds : 0f;
            var hadBest = _playerProfileService != null
                          && _playerProfileService.TryGetBestTimeSeconds(raceSession.MapId, out var previousBestTimeSeconds);

            var isNewBest = _playerProfileService != null
                            && _playerProfileService.TrySetBestTimeSeconds(raceSession.MapId, normalizedFinalTimeSeconds);

            if (isNewBest)
            {
                _playerProfileService.SaveProfile();
            }

            var bestTimeSeconds = normalizedFinalTimeSeconds;

            if (_playerProfileService != null && _playerProfileService.TryGetBestTimeSeconds(raceSession.MapId, out var savedBestTimeSeconds))
            {
                bestTimeSeconds = savedBestTimeSeconds;
            }
            else if (hadBest)
            {
                bestTimeSeconds = previousBestTimeSeconds;
            }

            return new RaceResult
            {
                MapId = raceSession.MapId,
                LeaderboardId = raceSession.LeaderboardId,
                FinalTimeSeconds = normalizedFinalTimeSeconds,
                BestTimeSeconds = bestTimeSeconds,
                IsNewBest = isNewBest || !hadBest,
                CompletedAtUtcTicks = _timeService != null ? _timeService.GetUtcNow().Ticks : 0L,
            };
        }
    }
}
