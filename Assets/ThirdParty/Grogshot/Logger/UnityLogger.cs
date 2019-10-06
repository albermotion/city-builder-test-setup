using UnityEngine;

namespace Grogshot.Logger {
    public class UnityLogger<T> : ILogger<T> where T : class {
        public void Log(string message, params object[] args) {
            Debug.LogFormat(string.Format("[{0}] {1}", typeof(T).Name, message), args);
        }

        public void LogError(string message, params object[] args) {
            Debug.LogErrorFormat(string.Format("[{0}] {1}", typeof(T).Name, message), args);
        }

        public void LogWarning(string message, params object[] args) {
            Debug.LogWarningFormat(string.Format("[{0}] {1}", typeof(T).Name, message), args);
        }
    }
}