using CityBuilder.Core.DataModels;

namespace CityBuilder.Core.Game {
    public interface IGameMode {
        Mode CurrentMode { get; }
    }
}
