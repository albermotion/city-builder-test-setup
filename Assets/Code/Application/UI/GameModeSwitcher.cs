using CityBuilder.Core.DataModels;
using CityBuilder.Core.Game;
using CityBuilder.Core.Signals;
using Grogshot.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CityBuilder.Application.UI {
    public class GameModeSwitcher : MonoBehaviour {

        [SerializeField] private Button switchButton;

        private readonly SwitchGameModeSignal regularGameSignal = new SwitchGameModeSignal(Mode.Regular);
        private readonly SwitchGameModeSignal buildGameSignal = new SwitchGameModeSignal(Mode.Build);
        private ISignalBus signalBus;
        private IGameMode gameMode;

        [Inject]
        private void Construct(ISignalBus signalBus, IGameMode gameMode) {
            this.signalBus = signalBus;
            this.gameMode = gameMode;
            switchButton.onClick.AddListener(SwitchMode);
        }

        private void SwitchMode() {
            switch (gameMode.CurrentMode) {
                case Mode.Build:
                    signalBus.Publish<SwitchGameModeSignal>(regularGameSignal);
                    break;
                case Mode.Regular:
                    signalBus.Publish<SwitchGameModeSignal>(buildGameSignal);
                    break;
            }
        }
    }
}
