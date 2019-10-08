using CityBuilder.Application.Entities;
using UnityEngine;

public abstract class Building : MonoBehaviour, IBuilding {
    public abstract string Id { get; }
    public abstract float YOffset { get; }
    public GameObject GameObject => gameObject;
}
