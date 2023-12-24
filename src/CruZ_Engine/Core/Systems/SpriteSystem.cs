﻿using CruZ.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace CruZ.Systems
{
    internal class SpriteSystem : EntitySystem, IUpdateSystem, IDrawSystem
    {
        public SpriteSystem() : base(Aspect.All(typeof(SpriteComponent)))
        {
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _spriteRendererMapper = mapperService.GetMapper<SpriteComponent>();
            _spriteBatch = new SpriteBatch(CruZ.Instance().GraphicsDevice);
            _core = CruZ.Instance();
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var entityId in ActiveEntities)
            {
                var spriteRenderer = _spriteRendererMapper.Get(entityId);
                spriteRenderer.Draw(_spriteBatch, _core.TotalMatrix);
            }
        }

        public virtual void Update(GameTime gameTime) {}

        SpriteBatch _spriteBatch;
        ComponentMapper<SpriteComponent> _spriteRendererMapper;
        CruZ _core;
    }
}
