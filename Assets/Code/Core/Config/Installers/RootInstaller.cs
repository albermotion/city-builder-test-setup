using CityBuilder.Core.Game;
using Zenject;

namespace CityBuilder.Core.Config {
    public class RootInstaller : MonoInstaller<RootInstaller> {
        public override void InstallBindings() {
            CoreInstaller.Install(Container);
            GameInstaller.Install(Container);
            Container.Bind<IGameRunner>().To<GameRunner>().AsSingle();
        }

        public override void Start() {
            Container.Resolve<IGameRunner>().Run();
        }
    }
}
