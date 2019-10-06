using CityBuilder.Core.Game;
using Grogshot.Signals;

namespace CityBuilder.Core.Signals {
    public class SwitchGameModeSignal : ISignal {
        public SwitchGameModeSignal(GameMode gameMode) {
            GameMode = gameMode;
        }

        public GameMode GameMode { get; private set; }
    }
}
