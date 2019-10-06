using System;

namespace CityBuilder.Core.StateMachine {
    public interface IState {
        void Enter();
        void Exit();
        void CompleteState();
        void Update();

        event Action OnStateEnter;
        event Action OnStateExit;
        event Action OnStateUpdate;
        event Action<IState> OnStateCompleted;
    }
}
