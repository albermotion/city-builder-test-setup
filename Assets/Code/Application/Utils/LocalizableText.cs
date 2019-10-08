using Grogshot.Localization;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizableText : MonoBehaviour {

    [SerializeField]
    private string localizationId;
    [SerializeField]
    private string preffix;
    [SerializeField]
    private string suffix;

    [Inject]
    private void Construct(ILocalizationService localizationService) {
        GetComponent<TextMeshProUGUI>().text = $"{preffix}{localizationService[localizationId]}{suffix}";
    }
}
