using CityBuilder.Core.DataModels;
using Grogshot.Localization;
using Grogshot.Serialization;
using UnityEngine;
using Zenject;

public class FilesInstaller : MonoInstaller<FilesInstaller> {

    [SerializeField]
    private TextAsset localizedTexts;
    [SerializeField]
    private TextAsset buildings;

    public override void InstallBindings() {
        Container.Bind<LocalizationDataStructure>()
            .FromResolveGetter<ISerializer>(f => f.Deserialize<LocalizationDataStructure>(localizedTexts))
            .AsSingle();
        Container.Bind<BuildingsData>()
            .FromResolveGetter<ISerializer>(f => f.Deserialize<BuildingsData>(buildings))
            .AsSingle();
    }
}