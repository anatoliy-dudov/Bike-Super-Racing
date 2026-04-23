using BikeSuperRacing.Core.Interfaces;
using UnityEngine;

namespace BikeSuperRacing.Gameplay.Countdown
{
    public sealed class CountdownService : ICountdownService
    {
        public bool IsRunning { get; private set; }
        public float RemainingTimeSeconds { get; private set; }
        public int CurrentDisplayValue { get; private set; }

        public void StartCountdown(float durationSeconds)
        {
            RemainingTimeSeconds = Mathf.Max(0f, durationSeconds);
            CurrentDisplayValue = Mathf.CeilToInt(RemainingTimeSeconds);
            IsRunning = RemainingTimeSeconds > 0f;
        }

        public void CancelCountdown()
        {
            IsRunning = false;
            RemainingTimeSeconds = 0f;
            CurrentDisplayValue = 0;
        }

        public bool Tick(float deltaTime)
        {
            if (!IsRunning)
            {
                return false;
            }

            if (deltaTime <= 0f)
            {
                return false;
            }

            RemainingTimeSeconds -= deltaTime;

            if (RemainingTimeSeconds <= 0f)
            {
                RemainingTimeSeconds = 0f;
                CurrentDisplayValue = 0;
                IsRunning = false;
                return true;
            }

            CurrentDisplayValue = Mathf.CeilToInt(RemainingTimeSeconds);
            return false;
        }
    }
}
