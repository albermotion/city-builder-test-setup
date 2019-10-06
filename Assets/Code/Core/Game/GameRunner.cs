using CityBuilder.Core.DataModels;
using CityBuilder.Core.Signals;
using CityBuilder.Core.StateMachine;
using Grogshot.Signals;
using System.Collections.Generic;

namespace CityBuilder.Core.Game {
    public class GameRunner : IGameRunner {

        private readonly IStateManager stateManager;
        private readonly ISignalBus signalBus;
        private readonly BuildGameState buildGameState;
        private readonly RegularGameState regularGameState;
        private Dictionary<Mode, BaseState> gameStates;
        private Dictionary<Mode, SwitchGameModeSignal> gameModeSignals;

        public GameRunner(IStateManager stateManager, ISignalBus signalBus, BuildGameState buildGameState, RegularGameState regularGameState) {
            this.stateManager = stateManager;
            this.signalBus = signalBus;
            this.buildGameState = buildGameState;
            this.regularGameState = regularGameState;

            InitData();
        }

        private void InitData() {
            gameStates = new Dictionary<Mode, BaseState>() {
                { Mode.Build, buildGameState },
                { Mode.Regular, regularGameState }
            };
            gameModeSignals = new Dictionary<Mode, SwitchGameModeSignal>() {
                { Mode.Build, new SwitchGameModeSignal(Mode.Build) },
                { Mode.Regular, new SwitchGameModeSignal(Mode.Regular) }
            };
        }

        public void Run() {
            stateManager.Start(gameStates[Mode.Regular]);
            stateManager.ChangeState(gameStates[Mode.Build]);
            signalBus.Publish<SwitchGameModeSignal>(gameModeSignals[Mode.Build]);
            signalBus.Subscribe<SwitchGameModeSignal>(SwitchMode);
        }

        private void SwitchMode(SwitchGameModeSignal signalData) {
            if (stateManager.CurrentState != gameStates[signalData.Mode]) {
                stateManager.ChangeState(gameStates[signalData.Mode]);
                signalBus.Publish<SwitchGameModeSignal>(gameModeSignals[signalData.Mode]);
            }
        }
    }
}
