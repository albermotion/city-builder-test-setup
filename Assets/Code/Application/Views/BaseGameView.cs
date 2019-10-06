using CityBuilder.Core.StateMachine;
using FSM;
using UnityEngine;
using Zenject;

namespace CityBuilder.Application.Views {
    public abstract class BaseGameView<T> : MonoBehaviour, IStateReceiver where T : BaseState {

        [Inject]
        public void Construct(T state) {
            State = state;
            State.OnStateEnter += OnStateEnter;
            State.OnStateExit += OnStateExit;
            Init();
        }

        private void OnDestroy() {
            if (State != null) {
                State.OnStateEnter -= OnStateEnter;
                State.OnStateExit -= OnStateExit;
            }
        }

        protected virtual void Start() { }
        protected virtual void Init() { }
        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}

        protected T State { get; set; }
    }
}
