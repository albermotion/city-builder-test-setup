using CityBuilder.Core.DataModels;
using CityBuilder.Core.Signals;
using Grogshot.Localization;
using Grogshot.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace CityBuilder.Application.UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GameModeName : MonoBehaviour {

        [SerializeField]
        private string regularModeId;
        [SerializeField]
        private string buildModeId;

        private TextMeshProUGUI visibleText;
        private ISignalBus signalBus;
        private ILocalizationService localizationService;

        private void Awake() {
            visibleText = GetComponent<TextMeshProUGUI>();
        }

        [Inject]
        private void Construct(ISignalBus signalBus, ILocalizationService localizationService) {
            this.signalBus = signalBus;
            this.localizationService = localizationService;

            this.signalBus.Subscribe<SwitchGameModeSignal>(ChangeName);
        }

        private void ChangeName(SwitchGameModeSignal signalData) {
            string modeName = string.Empty;
            switch (signalData.Mode) {
                case Mode.Build:
                    modeName = localizationService[buildModeId];
                    break;
                case Mode.Regular:
                    modeName = localizationService[regularModeId];
                    break;
            }

            visibleText.text = modeName;
        }

        private void OnDestroy() {
            signalBus.Unsubscribe<SwitchGameModeSignal>(ChangeName);
        }
    }
}
