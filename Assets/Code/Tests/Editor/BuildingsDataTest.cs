using CityBuilder.Core.Config;
using CityBuilder.Core.DataModels;
using Grogshot.Logger;
using Grogshot.Serialization;
using NUnit.Framework;
using System.Linq;
using UnityEngine;
using Zenject;

[TestFixture]
public class BuildingsDataTest : ZenjectUnitTestFixture {

    [Inject] private ILogger<BuildingsDataTest> logger;
    [Inject] private ISerializer serializer;

    [SetUp]
    public override void Setup() {
        base.Setup();
        CoreInstaller.Install(Container);
        Container.Bind<BuildingData>()
            .FromResolveGetter<ISerializer>(f => f.Deserialize<BuildingData>($"{Application.dataPath}/Files/buildings.json"))
            .AsSingle();
        Container.Inject(this);
    }

    private BuildingData LoadBuildingsData() {
        BuildingData buildingData = serializer.Deserialize<BuildingData>($"{Application.dataPath}/Files/buildings.json");
        Assert.IsNotNull(buildingData);

        foreach (var building in buildingData) {
            Assert.IsFalse(string.IsNullOrEmpty(building.Id));
            Assert.IsNotNull(building.Cost);
        }

        return buildingData;
    }

    [Test]
    public void ResidenceDataIsCorrect() {
        var buildingData = LoadBuildingsData();
        var residence = buildingData.Where(b => b.Id == "residence").FirstOrDefault();

        Assert.IsNotNull(residence);

        Assert.AreEqual(residence.Cost.Gold, 100);
        Assert.IsNull(residence.Cost.Steel);
        Assert.IsNull(residence.Cost.Wood);

        Assert.AreEqual(residence.Production.Quantity.Gold, 100);
        Assert.IsNull(residence.Production.Quantity.Steel);
        Assert.IsNull(residence.Production.Quantity.Wood);
        Assert.AreEqual(residence.Production.Time, 10);

        Assert.IsNotNull(residence.RequiresUserInteraction);
        Assert.IsFalse(residence.RequiresUserInteraction);
    }

    [Test]
    public void WoodProductionDataIsCorrect() {
        var buildingData = LoadBuildingsData();
        var woodProduction = buildingData.Where(b => b.Id == "woodproduction").FirstOrDefault();

        Assert.IsNotNull(woodProduction);

        Assert.AreEqual(woodProduction.Cost.Gold, 150);
        Assert.IsNull(woodProduction.Cost.Steel);
        Assert.IsNull(woodProduction.Cost.Wood);

        Assert.AreEqual(woodProduction.Production.Quantity.Wood, 50);
        Assert.IsNull(woodProduction.Production.Quantity.Steel);
        Assert.IsNull(woodProduction.Production.Quantity.Gold);
        Assert.AreEqual(woodProduction.Production.Time, 10);

        Assert.IsNotNull(woodProduction.RequiresUserInteraction);
        Assert.IsTrue(woodProduction.RequiresUserInteraction);
    }

    [Test]
    public void SteelProductionDataIsCorrect() {
        var buildingData = LoadBuildingsData();
        var steelProduction = buildingData.Where(b => b.Id == "steelproduction").FirstOrDefault();

        Assert.IsNotNull(steelProduction);

        Assert.AreEqual(steelProduction.Cost.Gold, 150);
        Assert.AreEqual(steelProduction.Cost.Wood, 100);
        Assert.IsNull(steelProduction.Cost.Steel);

        Assert.AreEqual(steelProduction.Production.Quantity.Steel, 50);
        Assert.IsNull(steelProduction.Production.Quantity.Gold);
        Assert.IsNull(steelProduction.Production.Quantity.Wood);
        Assert.AreEqual(steelProduction.Production.Time, 10);

        Assert.IsNotNull(steelProduction.RequiresUserInteraction);
        Assert.IsTrue(steelProduction.RequiresUserInteraction);
    }

    [Test]
    public void BenchDataIsCorrect() {
        var buildingData = LoadBuildingsData();
        var bench = buildingData.Where(b => b.Id == "bench").FirstOrDefault();

        Assert.IsNotNull(bench);

        Assert.AreEqual(bench.Cost.Gold, 150);
        Assert.AreEqual(bench.Cost.Steel, 50);
        Assert.IsNull(bench.Cost.Wood);

        Assert.IsNull(bench.Production);
        Assert.IsNull(bench.RequiresUserInteraction);
    }

    [Test]
    public void TreeDataIsCorrect() {
        var buildingData = LoadBuildingsData();
        var tree = buildingData.Where(b => b.Id == "tree").FirstOrDefault();

        Assert.IsNotNull(tree);

        Assert.AreEqual(tree.Cost.Gold, 50);
        Assert.AreEqual(tree.Cost.Wood, 200);
        Assert.IsNull(tree.Cost.Steel);

        Assert.IsNull(tree.Production);
        Assert.IsNull(tree.RequiresUserInteraction);
    }
}