using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ.Components
{
    internal class Component
    {

        Transform _transform;
        public Entity Entity { get => _entity; set => _entity = value; }
        Entity _entity;
    }
}
