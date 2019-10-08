using CityBuilder.Core.Game;
using CityBuilder.Core.Signals;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CityBuilder.Application.Views {
    public class RegularGameView : BaseGameView<RegularGameState> {

        [SerializeField]
        private CanvasGroup resourcesCanvasGroup;
        [SerializeField]
        private TextMeshProUGUI goldQuantity;
        [SerializeField]
        private TextMeshProUGUI steelQuantity;
        [SerializeField]
        private TextMeshProUGUI woodQuantity;

        protected override void Init() {
            signalBus.Subscribe<UpdateResourcesSignal>(UpdateResourcesTexts);
        }

        public override void OnStateEnter() {
            gameObject.SetActive(true);
            resourcesCanvasGroup.DOFade(1, 0.2f);
        }

        public override void OnStateExit() {
            resourcesCanvasGroup.DOFade(0, 0.2f).OnComplete(() => gameObject.SetActive(false));
        }

        private void UpdateResourcesTexts(UpdateResourcesSignal signalData) {
            goldQuantity.text = signalData.ResourcesData.Gold.ToString();
            steelQuantity.text = signalData.ResourcesData.Steel.ToString();
            woodQuantity.text = signalData.ResourcesData.Wood.ToString();
        }
    }
}
