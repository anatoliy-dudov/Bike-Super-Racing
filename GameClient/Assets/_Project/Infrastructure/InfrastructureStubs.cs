using System;
using System.IO;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain;
using UnityEngine;

namespace BikeSuperRacing.Infrastructure
{
    public sealed class LocalSaveService : ISaveService
    {
        private readonly string _savePath = Path.Combine(Application.persistentDataPath, "player-profile.json");

        public PlayerProfile Load()
        {
            if (!HasSave())
            {
                return new PlayerProfile();
            }

            var json = File.ReadAllText(_savePath);
            return JsonUtility.FromJson<PlayerProfile>(json) ?? new PlayerProfile();
        }

        public void Save(PlayerProfile profile)
        {
            var json = JsonUtility.ToJson(profile ?? new PlayerProfile(), true);
            File.WriteAllText(_savePath, json);
        }

        public bool HasSave()
        {
            return File.Exists(_savePath);
        }
    }

    public sealed class CloudSaveStubService : ISaveService
    {
        public PlayerProfile Load()
        {
            Debug.LogWarning("CloudSaveStubService.Load called. Cloud save is not implemented in MVP.");
            return new PlayerProfile();
        }

        public void Save(PlayerProfile profile)
        {
            Debug.LogWarning("CloudSaveStubService.Save called. Cloud save is not implemented in MVP.");
        }

        public bool HasSave()
        {
            return false;
        }
    }

    public sealed class TimeService : ITimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }

    public sealed class LocalLeaderboardService : ILeaderboardService
    {
        private readonly System.Collections.Generic.Dictionary<string, long> _scores = new System.Collections.Generic.Dictionary<string, long>();

        public void SubmitScore(string leaderboardId, long score)
        {
            if (!_scores.TryGetValue(leaderboardId, out var currentBest) || currentBest <= 0 || score < currentBest)
            {
                _scores[leaderboardId] = score;
            }
        }

        public long? GetBestLocalScore(string leaderboardId)
        {
            return _scores.TryGetValue(leaderboardId, out var value) ? value : null;
        }
    }

    public sealed class AudioSettingsService : IAudioSettingsService
    {
        public float MusicVolume { get; private set; } = 1f;
        public float SfxVolume { get; private set; } = 1f;

        public void SetMusicVolume(float value)
        {
            MusicVolume = Mathf.Clamp01(value);
        }

        public void SetSfxVolume(float value)
        {
            SfxVolume = Mathf.Clamp01(value);
        }
    }

    public sealed class LocalizationService : ILocalizationService
    {
        public string Get(string key)
        {
            return key;
        }
    }
}
