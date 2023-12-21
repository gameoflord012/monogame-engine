﻿using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ.Components
{
    public partial class TransformEntity
    {
        public TransformEntity(Entity e)
        {
            Entity = e;
            Transform = new();
        }

        public TransformEntity AddComponent<T> (T component) where T : class
        {
            AddComponent(component, typeof(T));

            return this;
        }

        public TransformEntity AddComponent(object component, Type ty)
        {
            Entity.Attach(component, ty);
            _entityDict[component] = this;
            _addedComponents.Add(ty, component);

            if (component is IComponentAddedCallback)
            {
                var callback = component as IComponentAddedCallback;
                callback.OnComponentAdded(this);
            }

            return this;
        }

        public Transform Transform { get => _transform; set => _transform = value; }
        public Entity Entity { get => _entity; set => _entity = value; }

        Entity _entity;
        Transform _transform;
        Dictionary<Type, object> _addedComponents = new();

        public static TransformEntity GetEntity(object component)
        {
            if (!_entityDict.ContainsKey(component))
            {
                throw new Exception("Im tired of this shit");
            }
            else
                return _entityDict[component];
        }

        public static KeyValuePair<Type, object>[] GetAllComponents(TransformEntity e)
        {
            return e._addedComponents.ToArray();
        }

        private static Dictionary<object, TransformEntity> _entityDict = new();
    }
}
