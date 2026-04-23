using BikeSuperRacing.Core.Interfaces;
using UnityEngine;

namespace BikeSuperRacing.Gameplay.Timer
{
    public sealed class RaceTimerService : IRaceTimerService
    {
        public bool IsRunning { get; private set; }
        public float ElapsedTimeSeconds { get; private set; }

        public void ResetTimer()
        {
            IsRunning = false;
            ElapsedTimeSeconds = 0f;
        }

        public void StartTimer()
        {
            IsRunning = true;
        }

        public void StopTimer()
        {
            IsRunning = false;
        }

        public void Tick(float deltaTime)
        {
            if (!IsRunning)
            {
                return;
            }

            if (deltaTime <= 0f)
            {
                return;
            }

            ElapsedTimeSeconds += deltaTime;

            if (ElapsedTimeSeconds < 0f)
            {
                ElapsedTimeSeconds = 0f;
            }
        }
    }
}
