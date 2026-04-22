using BikeSuperRacing.Core.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BikeSuperRacing.Application.Facades
{
    public sealed class SceneLoader : ISceneLoader
    {
        private readonly IAppStateService _appStateService;

        public SceneLoader(IAppStateService appStateService)
        {
            _appStateService = appStateService;
        }

        public AsyncOperation LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            if (string.IsNullOrWhiteSpace(sceneName))
            {
                Debug.LogError("SceneLoader: sceneName is empty.");
                return null;
            }

            var normalizedSceneName = sceneName.Trim();
            var asyncOperation = SceneManager.LoadSceneAsync(normalizedSceneName, loadSceneMode);

            if (asyncOperation == null)
            {
                Debug.LogError($"SceneLoader: failed to start loading scene '{normalizedSceneName}'.");
                return null;
            }

            _appStateService?.SetCurrentScene(normalizedSceneName);
            return asyncOperation;
        }
    }
}
