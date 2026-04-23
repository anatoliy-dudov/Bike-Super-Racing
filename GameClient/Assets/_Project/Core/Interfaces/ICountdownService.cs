namespace BikeSuperRacing.Core.Interfaces
{
    public interface ICountdownService
    {
        bool IsRunning { get; }
        float RemainingTimeSeconds { get; }
        int CurrentDisplayValue { get; }

        void StartCountdown(float durationSeconds);
        void CancelCountdown();
        bool Tick(float deltaTime);
    }
}
