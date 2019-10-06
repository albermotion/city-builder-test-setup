namespace Grogshot.Logger {
    public interface ILogger<T> {
        void Log(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
