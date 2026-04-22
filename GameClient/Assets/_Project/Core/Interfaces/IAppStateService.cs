using UnityEngine.SceneManagement;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface IAppStateService
    {
        string CurrentSceneName { get; }
        bool IsBootstrapCompleted { get; }

        void SetCurrentScene(string sceneName);
        void MarkBootstrapCompleted();
        void SyncWithActiveScene();
    }
}
