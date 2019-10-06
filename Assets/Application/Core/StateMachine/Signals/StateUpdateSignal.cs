namespace CityBuilder.Core.StateMachine {
    public class StateUpdateSignal : BaseStateSignal {
        public StateUpdateSignal(IState state) : base(state) {
        }
    }
}
