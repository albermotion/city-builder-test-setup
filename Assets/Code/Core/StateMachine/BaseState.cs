using System;

namespace CityBuilder.Core.StateMachine {
    public class BaseState : IState {

        public event Action OnStateEnter;
        public event Action OnStateExit;
        public event Action OnStateUpdate;
        public event Action<IState> OnStateCompleted;

        public virtual void Enter() {
            OnStateEnter?.Invoke();
        }

        public virtual void Exit() {
            OnStateExit?.Invoke();
        }

        public virtual void CompleteState() {
            OnStateCompleted?.Invoke(this);
        }

        public virtual void Update() {
            OnStateUpdate?.Invoke();
        }
    }
}
