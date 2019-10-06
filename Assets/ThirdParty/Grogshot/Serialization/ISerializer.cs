using UnityEngine;

namespace Grogshot.Serialization {
    public interface ISerializer {
        string MimeType {get;}
        T Deserialize<T>(string path);
        T Deserialize<T>(TextAsset asset);
        void Serialize<T>(T data, string path);
    }

}