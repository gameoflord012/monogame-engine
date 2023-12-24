using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CruZ.Components;

namespace MonoGame.Extended.Entities
{
    public static class Mono_ECSExtension
    {
        public static TransformEntity CreateTransformEntity(this World world)
        {
            var e = world.CreateEntity();
            TransformEntity t_e = new(e);
            return t_e;
        }
    }
}
