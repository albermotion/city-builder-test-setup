using CityBuilder.Core.StateMachine;
using Grogshot.Signals;

namespace CityBuilder.Core.Game {
    public class BuildGameState : BaseState {
        public BuildGameState(ISignalBus signalBus) : base(signalBus) {
        }
    }
}
