using DesktopMonoGame.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMonoGame
{
    internal partial class CruZ
    {
        private void Initialize_ECS()
        {
            _world = new WorldBuilder().AddSystem(new RenderSystem()).Build();
        }

        private void ECS_Update(GameTime gameTime)
        {
            _world.Update(gameTime);
        }

        private void ECS_Draw(GameTime gameTime)
        {
            _world.Draw(gameTime);
        }

        World _world;
    }
}
