﻿using Box2D.NetStandard.Dynamics.World;
using CruZ.Serialization;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace CruZ.Components
{
    public partial class TransformEntity : ISerializable
    {
        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            Transform.Position = jObject["position"].ToObject<Vector3>(serializer);
            Transform.Scale = jObject["scale"].ToObject<Vector3>(serializer);

            foreach (var comObj in jObject["components"].Cast<JObject>())
            {
                var comProp = comObj.Properties().First();
                var comTy = Type.GetType(comProp.Name);
                var comValue = comProp.Value.ToObject(comTy, serializer);

                AddComponent(comValue, comTy);
            }
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            {
                writer.WritePropertyName("position");
                serializer.Serialize(writer, Transform.Position);

                writer.WritePropertyName("scale");
                serializer.Serialize(writer, Transform.Scale);

                writer.WritePropertyName("components");
                writer.WriteStartArray();
                {
                    foreach (var pair in GetAllComponents(this))
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName(pair.Key.AssemblyQualifiedName);
                        serializer.Serialize(writer, pair.Value, pair.Key);
                        writer.WriteEnd();
                    }
                }
                writer.WriteEnd();
            }
            writer.WriteEnd();
        }

        ISerializable ISerializable.CreateDefault()
        {
            return new TransformEntity(CruZ.Instance().World.CreateEntity());
        }
    }
}