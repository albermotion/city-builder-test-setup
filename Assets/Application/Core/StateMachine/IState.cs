namespace CityBuilder.Core.StateMachine {
    public interface IState {
        void Enter();
        void Update();
        void Exit();
    }
}
