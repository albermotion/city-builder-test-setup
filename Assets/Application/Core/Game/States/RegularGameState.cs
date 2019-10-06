using CityBuilder.Core.StateMachine;
using Grogshot.Signals;

namespace CityBuilder.Core.Game {
    public class RegularGameState : BaseState {
        public RegularGameState(ISignalBus signalBus) : base(signalBus) {
        }
    }
}
