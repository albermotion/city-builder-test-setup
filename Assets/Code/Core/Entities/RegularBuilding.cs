using System;
using CityBuilder.Core.DataModels;

namespace CityBuilder.Core.Entities {
    public class RegularBuilding : IRegularBuilding {

        private BuildingData data;

        public void SetData(BuildingData data) {
            this.data = data;
        }

        public void Produce() {
            if (data != null) {
                OnProductionComplete?.Invoke();
            }
        }

        public Action OnProductionComplete { get; private set; }
    }
}
