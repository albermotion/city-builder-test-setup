namespace CityBuilder.Core.StateMachine {
    public class StateCompletionSignal : BaseStateSignal {
        public StateCompletionSignal(IState state) : base(state) {
        }
    }
}
