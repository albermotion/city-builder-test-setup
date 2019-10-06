using Grogshot.Signals;

namespace CityBuilder.Core.StateMachine {
    public class BaseState : IState {

        private readonly ISignalBus signalBus;
        private readonly StateEnterSignal stateEnterSignal;
        private readonly StateExitSignal stateExitSignal;
        private readonly StateUpdateSignal stateUpdateSignal;
        private readonly StateCompletionSignal stateCompletionSignal;

        public BaseState(ISignalBus signalBus) {
            this.signalBus = signalBus;

            stateEnterSignal = new StateEnterSignal(this);
            stateExitSignal = new StateExitSignal(this);
            stateUpdateSignal = new StateUpdateSignal(this);
            stateCompletionSignal = new StateCompletionSignal(this);
        }

        public virtual void Enter() {
            signalBus.Publish<StateEnterSignal>(stateEnterSignal);
        }

        public virtual void Exit() {
            signalBus.Publish<StateExitSignal>(stateExitSignal);
        }

        public virtual void CompleteState() {
            signalBus.Publish<StateCompletionSignal>(stateCompletionSignal);
        }

        public virtual void Update() {
            signalBus.Publish<StateUpdateSignal>(stateUpdateSignal);
        }
    }
}
