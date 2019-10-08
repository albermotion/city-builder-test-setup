using CityBuilder.Application.Entities;
using CityBuilder.Core.DataModels;
using CityBuilder.Core.Entities;
using Grogshot.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace CityBuilder.Application.UI {
    public class BuildingSelector : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
        [SerializeField]
        private TextMeshProUGUI buildingName;
        [SerializeField]
        private Image backgroundImage;

        [Header("Production")]
        [SerializeField]
        private TextMeshProUGUI goldPruction;
        [SerializeField]
        private TextMeshProUGUI steelProduction;
        [SerializeField]
        private TextMeshProUGUI woodProduction;

        [Header("Cost")]
        [SerializeField]
        private TextMeshProUGUI goldCost;
        [SerializeField]
        private TextMeshProUGUI steelCost;
        [SerializeField]
        private TextMeshProUGUI woodCost;

        private ILocalizationService localizationService;
        private IDraggable draggableBuilding;
        private IBuilding buildingEntity;
        private BuildingData buildingData;
        private GameObject prefab;
        private bool isInteractable;

        [Inject]
        private void Construct(ILocalizationService localizationService) {
            this.localizationService = localizationService;
        }

        private void Awake() {
            isInteractable = true;
        }

        public void SetBuildingData(BuildingData buildingData, GameObject prefab) {
            this.buildingData = buildingData;
            this.prefab = prefab;

            buildingName.text = localizationService[$"buildings_{buildingData.Id}"];

            if (buildingData.Production != null) {
                if (buildingData.Production.Quantity.Gold != null) {
                    goldPruction.text = buildingData.Production.Quantity.Gold.ToString();
                }
                if (buildingData.Production.Quantity.Steel != null) {
                    steelProduction.text = buildingData.Production.Quantity.Steel.ToString();
                }
                if (buildingData.Production.Quantity.Wood != null) {
                    woodProduction.text = buildingData.Production.Quantity.Wood.ToString();
                }
            }

            goldCost.text = buildingData.Cost.Gold.ToString();
            steelCost.text = buildingData.Cost.Steel.ToString();
            woodCost.text = buildingData.Cost.Wood.ToString();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (isInteractable) {
                var entity = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                draggableBuilding = entity.GetComponent<IDraggable>();
                buildingEntity = entity.GetComponent<IBuilding>();
                var productionBuilding = entity.GetComponent<Entities.IProductionBuilding>();
                productionBuilding?.SetData(buildingData);
                draggableBuilding.BeginDrag();
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (isInteractable) {
                var worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
                var position = new Vector3(worldPosition.x, buildingEntity.YOffset, worldPosition.y);
                draggableBuilding?.Drag(position);
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            draggableBuilding?.EndDrag();
            draggableBuilding = null;
            buildingEntity = null;
            isInteractable = false;
            backgroundImage.color = Color.grey;
        }
    }
}
