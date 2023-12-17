using CruZ.Components;
using Microsoft.Xna.Framework;
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
        private void Game_Initialize()
        {
            _entity = _world.CreateTransformEntity();
            _entity.AddComponent(new SpriteRenderer("image"));
        }

        private void Game_Update(GameTime gameTime)
        {
            _entity.Transform.Position -= System.Numerics.Vector3.UnitX;
        }

        TransformEntity _entity;
    }
}
