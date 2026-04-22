using BikeSuperRacing.Core.Interfaces;
using UnityEngine.SceneManagement;

namespace BikeSuperRacing.Application.Facades
{
    public sealed class AppStateService : IAppStateService
    {
        public string CurrentSceneName { get; private set; } = string.Empty;
        public bool IsBootstrapCompleted { get; private set; }

        public void SetCurrentScene(string sceneName)
        {
            CurrentSceneName = string.IsNullOrWhiteSpace(sceneName) ? string.Empty : sceneName.Trim();
        }

        public void MarkBootstrapCompleted()
        {
            IsBootstrapCompleted = true;
        }

        public void SyncWithActiveScene()
        {
            var activeScene = SceneManager.GetActiveScene();
            CurrentSceneName = activeScene.IsValid() ? activeScene.name : string.Empty;
        }
    }
}
