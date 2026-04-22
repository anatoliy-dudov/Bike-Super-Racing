using UnityEngine;
using UnityEngine.SceneManagement;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface ISceneLoader
    {
        AsyncOperation LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
    }
}
