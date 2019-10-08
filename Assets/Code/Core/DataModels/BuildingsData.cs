using System.Collections.Generic;

namespace CityBuilder.Core.DataModels {
    public class BuildingsData : List<BuildingData> {
    }

    public class BuildingData {
        public string Id { get; set; }
        public ResourcesData Cost { get; set; }
        public ProductionData Production { get; set; }
        public bool? RequiresUserInteraction { get; set; }
    }

    public class ResourcesData {
        public uint? Gold { get; set; }
        public uint? Wood { get; set; }
        public uint? Steel { get; set; }
    }

    public class ProductionData {
        public ResourcesData Quantity { get; set; }
        public uint Time { get; set; }
    }
}
