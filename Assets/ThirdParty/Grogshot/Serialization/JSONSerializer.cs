using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System;
using UnityEngine;

namespace Grogshot.Serialization {
    public class JSONSerializer : ISerializer {
        private readonly JsonSerializerSettings settings;
        private readonly IList<JsonConverter> converters = new List<JsonConverter>() {};

        public string MimeType => "application/json";

        public JSONSerializer() {
            settings = new JsonSerializerSettings() { Converters = converters };
        }

        public T Deserialize<T>(string path) {
            byte[] data = File.ReadAllBytes(path);
            using (Stream stream = new MemoryStream(data)) {
                byte[] result = new byte[stream.Length];

                if (stream.Position != 0) {
                    stream.Seek(0, SeekOrigin.Begin);
                }

                stream.Read(result, 0, result.Length);
                stream.Seek(0, SeekOrigin.Begin);

                string value = Encoding.UTF8.GetString(result); 
                return (T)JsonConvert.DeserializeObject(value, typeof(T), settings);
            }
        }

        public T Deserialize<T>(TextAsset asset) {
            return (T)JsonConvert.DeserializeObject(asset.text, typeof(T), settings);
        }

        public void Serialize<T>(T data, string path) {
            File.WriteAllText(path, JsonConvert.SerializeObject(data, settings));
        }
    }
}