using CityBuilder.Core.DataModels;
using CityBuilder.Core.Signals;
using Grogshot.Signals;

namespace CityBuilder.Core.Game {
    public class ResourcesManager : IResourcesManager {
        private readonly ISignalBus signalBus;

        public ResourcesManager(ISignalBus signalBus) {
            this.signalBus = signalBus;
            this.signalBus.Subscribe<TryAddResourceSignal>(AddResources);
            this.signalBus.Subscribe<TryRemoveResourceSignal>(RemoveResources);
        }

        private void AddResources(TryAddResourceSignal signalData) {
            Gold += signalData.ResourcesData.Gold ?? 0;
            Steel += signalData.ResourcesData.Steel ?? 0;
            Wood += signalData.ResourcesData.Wood ?? 0;
            SendUpdateSignal();
        }

        private void RemoveResources(TryRemoveResourceSignal signalData) {
            Gold -= signalData.ResourcesData.Gold ?? 0;
            Steel -= signalData.ResourcesData.Steel ?? 0;
            Wood -= signalData.ResourcesData.Wood ?? 0;
            SendUpdateSignal();
        }

        private void SendUpdateSignal() {
            var resources = new ResourcesData() {
                Gold = Gold,
                Steel = Steel,
                Wood = Wood
            };
            signalBus.Publish<UpdateResourcesSignal>(new UpdateResourcesSignal(resources));
        }

        public uint Gold { get; private set; } = 0;
        public uint Wood { get; private set; } = 0;
        public uint Steel { get; private set; } = 0;
    }
}
