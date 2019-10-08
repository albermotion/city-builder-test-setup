using CityBuilder.Core.StateMachine;
using FSM;
using Grogshot.Signals;
using UnityEngine;
using Zenject;

namespace CityBuilder.Application.Views {
    public abstract class BaseGameView<T> : MonoBehaviour, IStateReceiver where T : BaseState {

        protected ISignalBus signalBus;

        [Inject]
        public void Construct(T state, ISignalBus signalBus) {
            this.signalBus = signalBus;
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
