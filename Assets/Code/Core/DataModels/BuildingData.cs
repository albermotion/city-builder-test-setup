using System.Collections.Generic;

namespace CityBuilder.Core.DataModels {
    public class BuildingData : List<Building> {
    }

    public class Building {
        public string Id { get; set; }
        public Resources Cost { get; set; }
        public Production Production { get; set; }
        public bool? RequiresUserInteraction { get; set; }
    }

    public class Resources {
        public int? Gold { get; set; }
        public int? Wood { get; set; }
        public int? Steel { get; set; }
    }

    public class Production {
        public Resources Quantity { get; set; }
        public int Time { get; set; }
    }
}
