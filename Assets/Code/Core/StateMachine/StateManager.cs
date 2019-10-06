using System;

namespace CityBuilder.Core.StateMachine {
    public class StateManager : IStateManager {

        private bool isActive = false;

        public void Start(IState state) {
            if (state == null) {
                throw new Exception("State passed is null");
            }

            ChangeState(state);
            Resume();
        }

        public void ChangeState(IState state) {
            if (state == null) {
                throw new Exception(string.Format("State {0} does not exist", state));
            }

            if (state == CurrentState) {
                return;
            }

            if (CurrentState != null) {
                CurrentState.Exit();
            }

            CurrentState = state;

            if (CurrentState != null) {
                CurrentState.Enter();
            }
        }

        public void Update() {
            if (isActive) {
                CurrentState?.Update();
            }
        }

        public void Pause() {
            isActive = false;
        }

        public void Resume() {
            isActive = true;
        }

        public IState CurrentState { get; private set; }
    }
}
