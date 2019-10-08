using CityBuilder.Core.DataModels;
using Grogshot.Signals;

namespace CityBuilder.Core.Signals {
    public class TryRemoveResourceSignal : ISignal {
        public TryRemoveResourceSignal(ResourcesData resourcesData) {
            ResourcesData = resourcesData;
        }

        public ResourcesData ResourcesData { get; private set; }
    }
}
