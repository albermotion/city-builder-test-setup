using CityBuilder.Core.DataModels;
using Grogshot.Signals;

namespace CityBuilder.Core.Signals {
    public class SwitchGameModeSignal : ISignal {
        public SwitchGameModeSignal(Mode gameMode) {
            Mode = gameMode;
        }

        public Mode Mode { get; private set; }
    }
}
