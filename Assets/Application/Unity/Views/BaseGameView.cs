using CityBuilder.Core.StateMachine;
using Grogshot.Signals;
using UnityEngine;
using Zenject;

public abstract class BaseGameView<T> : MonoBehaviour where T: BaseState {

    protected ISignalBus signalBus;

    [Inject]
    public void Construct(ISignalBus signalBus) {
        this.signalBus = signalBus;
        this.signalBus.Subscribe<StateEnterSignal>(OnStateEnter);
        this.signalBus.Subscribe<StateExitSignal>(OnStateExit);
        Init();
    }

    protected virtual void Init() { }

    public virtual void OnStateEnter(StateEnterSignal signalData) {
        if (!typeof(T).IsAssignableFrom(signalData.State.GetType())) {
            return;
        }

        gameObject.SetActive(true);
    }

    public virtual void OnStateExit(StateExitSignal signalData) {
        if (!typeof(T).IsAssignableFrom(signalData.State.GetType())) {
            return;
        }

        gameObject.SetActive(false);
    }
}
