using CityBuilder.Core.DataModels;
using Grogshot.Signals;

namespace CityBuilder.Core.Signals {
    public class UpdateResourcesSignal : ISignal {
        public UpdateResourcesSignal(ResourcesData resourcesData) {
            ResourcesData = resourcesData;
        }

        public ResourcesData ResourcesData { get; private set; }
    }
}
