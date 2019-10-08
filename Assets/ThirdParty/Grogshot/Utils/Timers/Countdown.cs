using System;
using UnityEngine;
using Zenject;

namespace Grogshot.Utils {
    public class Countdown : ICountdown, ITickable {

        private float originalTime;

        public Countdown(TickableManager tickableManager) {
            tickableManager.Add(this);
            tickableManager.Initialize();
        }

        public void Start(float seconds, bool loop = false) {
            originalTime = seconds;
            RemainingTime = seconds;
            IsTicking = true;
            Loop = loop;
        }

        public void Pause() {
            IsTicking = false;
        }

        public void Resume() {
            IsTicking = true;
        }

        public void Stop() {
            RemainingTime = 0f;
            IsTicking = false;
        }

        public void Tick() {
            if (IsTicking) {
                RemainingTime -= Time.deltaTime;

                if (RemainingTime <= 0f) {
                    if (!Loop) {
                        Stop();
                    }
                    else {
                        RemainingTime = originalTime;
                    }

                    OnComplete?.Invoke();
                }
            }
        }

        public float RemainingTime { get; private set; } = 0;
        public bool IsTicking { get; private set; }
        public bool Loop { get; set; }
        public Action OnComplete { get; set; }
    }
}
