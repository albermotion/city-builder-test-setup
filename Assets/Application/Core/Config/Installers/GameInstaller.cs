using CityBuilder.Core.Game;
using Zenject;

namespace CityBuilder.Core.Config {
    public class GameInstaller : Installer<GameInstaller> {
        public override void InstallBindings() {
            Container.Bind<RegularGameState>().AsSingle();
            Container.Bind<BuildGameState>().AsSingle();
        }
    }
}