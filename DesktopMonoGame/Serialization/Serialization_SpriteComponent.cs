using CruZ.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CruZ.Components
{
    public partial class SpriteComponent : ISerializable
    {
        public void ReadJson(JObject jObject)
        {
            _resourceName = jObject[nameof(_resourceName)].Value<string>();
        }

        public JObject WriteJson()
        {
            JObject jObject = new JObject();
            jObject[nameof(_resourceName)] = _resourceName;
            return jObject;
        }

        ISerializable ISerializable.CreateDefault()
        {
            return new SpriteComponent();
        }
    }
}