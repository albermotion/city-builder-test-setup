using CityBuilder.Core.DataModels;
using CityBuilder.Core.Signals;
using Grogshot.Signals;
using Grogshot.Utils;

namespace CityBuilder.Core.Entities {
    public class AutomaticBuilding : IAutomaticBuilding {
        private readonly ISignalBus signalBus;
        private readonly ICountdown countdown;
        private BuildingData data;

        public AutomaticBuilding(ISignalBus signalBus,ICountdown countdown) {
            this.signalBus = signalBus;
            this.countdown = countdown;
            this.countdown.OnComplete += AddResources;
        }

        public void SetData(BuildingData data) {
            this.data = data;
        }

        public void Produce() {
            if (data != null) {
                countdown.Start(data.Production.Time, true);
            }
        }

        private void AddResources() {
            signalBus.Publish<TryAddResourceSignal>(new TryAddResourceSignal(data.Production.Quantity));
        }
    }
}
