using System;

namespace Grogshot.Utils {
    public interface ICountdown  {
        void Start(float seconds, bool loop = false);
        void Pause();
        void Resume();
        void Stop();

        Action OnComplete { get; set; }
        float RemainingTime { get; }
        bool IsTicking { get; }
        bool Loop { get; set; }
    }
}
