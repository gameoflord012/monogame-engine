using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CruZ.Serialization
{
    interface ISerializable
    {
        public ISerializable CreateDefault();
        public void ReadJson(JObject jObject);
        public JObject WriteJson();

    }
}