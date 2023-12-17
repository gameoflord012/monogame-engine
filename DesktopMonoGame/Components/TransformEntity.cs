﻿using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ.Components
{
    public class TransformEntity
    {
        public TransformEntity(Entity e)
        {
            Entity = e;
            Transform = new();
        }

        public TransformEntity AddComponent<T> (T component) where T : class
        {
            Entity.Attach(component);
            _entityDict[component] = this;

            return this;
        }

        public Transform Transform { get => _transform; set => _transform = value; }
        public Entity Entity { get => _entity; set => _entity = value; }

        Entity _entity;
        Transform _transform;

        public static TransformEntity GetEntity(object component)
        {
            if (!_entityDict.ContainsKey(component))
            {
                throw new Exception("Im tired of this shit");
            }
            else
                return _entityDict[component];
        }

        private static Dictionary<object, TransformEntity> _entityDict = new();
    }
}