namespace CityBuilder.Core.StateMachine {
    public interface IStateManager {
        void Start(IState state);
        void ChangeState(IState state);
        void Update();
        void Pause();
        void Resume();
        IState CurrentState { get; }
    }
}
