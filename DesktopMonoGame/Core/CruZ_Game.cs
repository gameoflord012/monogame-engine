using CruZ.Components;
using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ
{
    internal partial class CruZ
    {
        private void GameInitialize()
        {
            var entity = _world.CreateTransformEntity();
            entity.AddComponent(new SpriteRenderer("image"));
        }
    }
}
