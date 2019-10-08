using CityBuilder.Core.DataModels;
using Grogshot.Signals;

namespace CityBuilder.Core.Signals {
    public class TryAddResourceSignal : ISignal {
        public TryAddResourceSignal(ResourcesData resourcesData) {
            ResourcesData = resourcesData;
        }

        public ResourcesData ResourcesData { get; private set; }
    }
}
