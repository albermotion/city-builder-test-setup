using Grogshot.Localization;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizableText : MonoBehaviour {

    [SerializeField]
    private string localizationId;

    [Inject]
    private void Construct(ILocalizationService localizationService) {
        GetComponent<TextMeshProUGUI>().text = localizationService[localizationId];
    }
}
