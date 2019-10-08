using CityBuilder.Core.Entities;
using CityBuilder.Core.Game;
using Zenject;

namespace CityBuilder.Core.Config {
    public class GameInstaller : Installer<GameInstaller> {
        public override void InstallBindings() {
            Container.Bind<RegularGameState>().AsSingle();
            Container.Bind<BuildGameState>().AsSingle();
            Container.Bind<IResourcesManager>().To<ResourcesManager>().AsSingle().NonLazy();
            Container.Bind<IRegularBuilding>().To<RegularBuilding>().AsTransient();
            Container.Bind<IAutomaticBuilding>().To<AutomaticBuilding>().AsTransient();
            Container.Bind<IGameMode>().To<GameMode>().AsSingle();
        }
    }
}