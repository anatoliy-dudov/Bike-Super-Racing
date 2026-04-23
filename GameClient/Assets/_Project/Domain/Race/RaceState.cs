namespace BikeSuperRacing.Domain.Race
{
    public enum RaceState
    {
        EnterRaceScene = 0,
        PreStart = 1,
        Countdown = 2,
        RaceActive = 3,
        RaceFinished = 4,
        ResultPresentation = 5,
        RestartRequested = 6,
        Pause = 7,
    }
}
