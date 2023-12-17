﻿using CruZ.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;

namespace CruZ
{
    class CruZ_ECS
    {
        public CruZ_ECS(CruZ core)
        {
            core.OnInitialize += Initialize;
            core.OnUpdate += Update;
            core.OnDraw += Draw;
        }

        private void Initialize()
        {
            _world = new WorldBuilder().
                AddSystem(new RenderSystem()).
                AddSystem(new PhysicSystem()).Build();
        }

        private void Update(GameTime gameTime)
        {
            _world.Update(gameTime);
        }

        private void Draw(GameTime gameTime)
        {
            _world.Draw(gameTime);
        }

        World _world;

        public World World { get => _world; }
    }
}