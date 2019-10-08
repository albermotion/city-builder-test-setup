using UnityEngine;

namespace CityBuilder.Application.Entities {
    public interface IBuilding {
        string Id { get; }
        float YOffset { get; }
        GameObject GameObject { get; }
    }
}
