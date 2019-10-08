using UnityEngine;

namespace CityBuilder.Core.Entities {
    public interface IDraggable {
        void BeginDrag();
        void Drag(Vector3 eventData);
        void EndDrag();
    }
}
