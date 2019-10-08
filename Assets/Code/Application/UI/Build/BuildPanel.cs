using CityBuilder.Application.Entities;
using CityBuilder.Core.DataModels;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace CityBuilder.Application.UI {
    public class BuildPanel : MonoBehaviour {

        [SerializeField]
        private GameObject buildingSelectorPrefab;
        [SerializeField]
        private Transform selectorsContainer;
        [SerializeField]
        private Building[] buildingsPrefabs;

        private BuildingsData buildingsData;
        private List<GameObject> availableBuildings;

        [Inject]
        private void Construct(BuildingsData buildingsData) {
            this.buildingsData = buildingsData;
        }

        private void Awake() {
            availableBuildings = new List<GameObject>();
        }

        private void Start() {
            CreateSelectors();
        }

        private void CreateSelectors() {
            foreach (var building in buildingsData) {
                var prefab = buildingsPrefabs.Where(b => b.Id == building.Id).FirstOrDefault().GameObject;
                var instance = Instantiate(buildingSelectorPrefab, selectorsContainer);
                instance.GetComponent<BuildingSelector>().SetBuildingData(building, prefab);
                availableBuildings.Add(instance);
            }
        }
    }
}
