using CityBuilder.Core.DataModels;
using CityBuilder.Core.Entities;
using Grogshot.Logger;
using UnityEngine;
using Zenject;

namespace CityBuilder.Application.Entities {
    public class AutomaticBuilding : Building, IDraggable, IProductionBuilding {

        [SerializeField]
        private string id;
        [SerializeField]
        private float yOffset;

        private BuildingData buildingData;
        private IAutomaticBuilding building;
        private ILogger<AutomaticBuilding> logger;

        [Inject]
        private void Construct(IAutomaticBuilding building, ILogger<AutomaticBuilding> logger) {
            this.building = building;
            this.logger = logger;
        }

        public void SetData(BuildingData buildingData) {
            this.buildingData = buildingData;
            building.SetData(this.buildingData);
        }

        public void BeginDrag() {
            logger.Log("Begin Drag");
        }

        public void Drag(Vector3 position) {
            transform.position = position;
        }

        public void EndDrag() {
            logger.Log("End Drag");
            building.Produce();
        }

        public override string Id => id;
        public override float YOffset => yOffset;
    }
}
