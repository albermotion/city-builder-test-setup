using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Grogshot.Scenes {
    public class SceneLoaderService : ISceneLoaderService {
        public async Task LoadSceneAsync(int sceneIndex, LoadSceneMode mode) {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex, mode);
            await CheckProgress(op);
        }

        public async Task LoadSceneAsync(string sceneName, LoadSceneMode mode) {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, mode);
            await CheckProgress(op);
        }

        public async Task UnloadSceneAsync(int sceneIndex) {
            AsyncOperation op = SceneManager.UnloadSceneAsync(sceneIndex);
            await CheckProgress(op);
        }

        public async Task UnloadSceneAsync(string sceneName) {
            AsyncOperation op = SceneManager.UnloadSceneAsync(sceneName);
            await CheckProgress(op);
        }

        private IEnumerator CheckProgress(AsyncOperation op) {
            while (!op.isDone) {
                yield return null;
            }
        }
    }
}
