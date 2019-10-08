using CityBuilder.Core.Entities;
using Grogshot.Logger;
using UnityEngine;
using Zenject;

namespace CityBuilder.Application.Entities {
    public class DecoratorBuilding : Building, IDraggable {

        [SerializeField]
        private string id;
        [SerializeField]
        private float yOffset;

        private ILogger<DecoratorBuilding> logger;

        [Inject]
        private void Construct(ILogger<DecoratorBuilding> logger) {
            this.logger = logger;
        }

        public void BeginDrag() {
            logger.Log("Begin Drag");
        }

        public void Drag(Vector3 position) {
            transform.position = position;
        }

        public void EndDrag() {
            logger.Log("End Drag");
        }

        public override string Id => id;
        public override float YOffset => yOffset;
    }
}
