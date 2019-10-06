using CityBuilder.Core.DataModels;
using CityBuilder.Core.Signals;
using Grogshot.Signals;

namespace CityBuilder.Core.Game {
    public class GameMode : IGameMode {

        public GameMode(ISignalBus signalBus) {
            signalBus.Subscribe<SwitchGameModeSignal>(SwitchGameMode);
        }

        private void SwitchGameMode(SwitchGameModeSignal signalData) {
            CurrentMode = signalData.Mode;
        }

        public Mode CurrentMode { get; private set; }
    }
}
