using System;
using System.IO;
using BikeSuperRacing.Core.Interfaces;
using BikeSuperRacing.Domain.Profile;
using UnityEngine;

namespace BikeSuperRacing.Infrastructure.Save.Local
{
    public sealed class LocalSaveService : ISaveService
    {
        private readonly string _saveFilePath;

        public LocalSaveService(string saveFileName)
        {
            var normalizedSaveFileName = string.IsNullOrWhiteSpace(saveFileName)
                ? "bike_super_racing_profile.json"
                : saveFileName.Trim();

            _saveFilePath = Path.Combine(Application.persistentDataPath, normalizedSaveFileName);
        }

        public bool Exists()
        {
            try
            {
                return File.Exists(_saveFilePath);
            }
            catch (Exception exception)
            {
                Debug.LogError($"LocalSaveService.Exists failed: {exception}");
                return false;
            }
        }

        public bool TryLoad(out PlayerProfile playerProfile)
        {
            playerProfile = null;

            try
            {
                if (!File.Exists(_saveFilePath))
                {
                    return false;
                }

                var json = File.ReadAllText(_saveFilePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return false;
                }

                playerProfile = JsonUtility.FromJson<PlayerProfile>(json);
                return playerProfile != null;
            }
            catch (Exception exception)
            {
                Debug.LogError($"LocalSaveService.TryLoad failed: {exception}");
                playerProfile = null;
                return false;
            }
        }

        public bool Save(PlayerProfile playerProfile)
        {
            if (playerProfile == null)
            {
                Debug.LogError("LocalSaveService.Save failed: playerProfile is null.");
                return false;
            }

            try
            {
                var directoryPath = Path.GetDirectoryName(_saveFilePath);

                if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var json = JsonUtility.ToJson(playerProfile, true);
                File.WriteAllText(_saveFilePath, json);
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"LocalSaveService.Save failed: {exception}");
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                if (!File.Exists(_saveFilePath))
                {
                    return true;
                }

                File.Delete(_saveFilePath);
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"LocalSaveService.Delete failed: {exception}");
                return false;
            }
        }
    }
}
