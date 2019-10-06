using CityBuilder.Core.StateMachine;
using Grogshot.Localization;
using Grogshot.Logger;
using Grogshot.Serialization;
using Grogshot.Signals;
using Zenject;

namespace CityBuilder.Core.Config {
    public class CoreInstaller : Installer<CoreInstaller> {
        public override void InstallBindings() {
            Container.Bind<ISerializer>().To<JSONSerializer>().AsSingle();
            Container.Bind(typeof(ILogger<>)).To(typeof(UnityLogger<>)).AsSingle();
            Container.Bind<ISignalBus>().To<SignalBus>().AsSingle();
            Container.Bind<ILocalizationDataProvider>().To<LocalizationDataProvider>().AsSingle();
            Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();

            Container.Bind<IStateManager>().To<StateManager>().AsTransient();
            Container.Bind<StateEnterSignal>().AsTransient();
            Container.Bind<StateExitSignal>().AsTransient();
            Container.Bind<StateUpdateSignal>().AsTransient();
            Container.Bind<StateCompletionSignal>().AsTransient();
        }
    }
}