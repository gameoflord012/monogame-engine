using CruZ.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.ViewportAdapters;

namespace CruZ.Systems
{
    internal class RenderSystem : EntityDrawSystem
    {
        public RenderSystem() : base(Aspect.All(typeof(SpriteRenderer)))
        {
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _spriteRendererMapper = mapperService.GetMapper<SpriteRenderer>();
            _spriteBatch = new SpriteBatch(CruZ.Instance().GraphicsDevice);
            _core = CruZ.Instance();
        }

        public override void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin(transformMatrix: _core.RenderMatrix);
            foreach (var entityId in ActiveEntities)
            {
                var spriteRenderer = _spriteRendererMapper.Get(entityId);

                Vector2 renderPosition = new Vector2(
                    spriteRenderer.GetRenderPosition().X, 
                    spriteRenderer.GetRenderPosition().Y);

                _spriteBatch.Draw(spriteRenderer.Texture, renderPosition, Color.White);
            }
            _spriteBatch.End();
        }

        SpriteBatch _spriteBatch;
        ComponentMapper<SpriteRenderer> _spriteRendererMapper;
        CruZ _core;
    }
}
