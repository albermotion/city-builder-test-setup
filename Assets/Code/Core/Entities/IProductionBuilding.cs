using CityBuilder.Core.DataModels;

namespace CityBuilder.Core.Entities {
    public interface IProductionBuilding {
        void SetData(BuildingData data);
        void Produce();
    }
}
