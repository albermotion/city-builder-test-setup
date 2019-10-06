using Grogshot.Signals;

namespace CityBuilder.Core.StateMachine {
    public abstract class BaseStateSignal : ISignal {
        public BaseStateSignal(IState state) {
        }

        public IState State { get; private set; }
    }
}
