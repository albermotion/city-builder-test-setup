using CityBuilder.Core.Game;
using CityBuilder.Core.StateMachine;

namespace CityBuilder.Core.Config {
    public class AppStartup {

        public AppStartup(IStateManager stateManager, RegularGameState regularGameState) {
            stateManager.Start(regularGameState);
        }
    }
}
