namespace BikeSuperRacing.Core.Interfaces
{
    public interface IRaceTimerService
    {
        bool IsRunning { get; }
        float ElapsedTimeSeconds { get; }

        void ResetTimer();
        void StartTimer();
        void StopTimer();
        void Tick(float deltaTime);
    }
}
