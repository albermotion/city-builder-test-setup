using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Grogshot.Scenes {
    public interface ISceneLoaderService {
        Task LoadSceneAsync(int sceneIndex, LoadSceneMode mode);
        Task LoadSceneAsync(string sceneName, LoadSceneMode mode);

        Task UnloadSceneAsync(int sceneIndex);
        Task UnloadSceneAsync(string sceneName);
    }
}
