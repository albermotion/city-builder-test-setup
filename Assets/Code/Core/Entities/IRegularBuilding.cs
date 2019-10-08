using System;

namespace CityBuilder.Core.Entities {
    public interface IRegularBuilding : IProductionBuilding {
        Action OnProductionComplete { get; }
    }
}
