namespace FSM {
    public interface IStateReceiver {
        void OnStateEnter();
        void OnStateExit();
    }
}
