using Zenject;

namespace CityBuilder.Core.Config {
    public class RootInstaller : MonoInstaller<RootInstaller> {
        public override void InstallBindings() {
            CoreInstaller.Install(Container);
            GameInstaller.Install(Container);
            Container.Bind<AppStartup>().AsSingle().NonLazy();
        }
    }
}
