using CityBuilder.Core.StateMachine;
using Grogshot.Localization;
using Grogshot.Logger;
using Grogshot.Serialization;
using Grogshot.Signals;
using Grogshot.Utils;
using Zenject;

namespace CityBuilder.Core.Config {
    public class CoreInstaller : Installer<CoreInstaller> {
        public override void InstallBindings() {
            Container.Bind<ISerializer>().To<JSONSerializer>().AsSingle();
            Container.Bind(typeof(ILogger<>)).To(typeof(UnityLogger<>)).AsSingle();
            Container.Bind<ISignalBus>().To<SignalBus>().AsSingle();
            Container.Bind<ILocalizationDataProvider>().To<LocalizationDataProvider>().AsSingle();
            Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
            Container.Bind<ICountdown>().To<Countdown>().AsTransient();

            Container.Bind<IStateManager>().To<StateManager>().AsTransient();
        }
    }
}