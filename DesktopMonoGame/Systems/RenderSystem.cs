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
        }

        public override void Draw(GameTime gameTime)
        {
            OrthographicCamera cam = CruZ.Instance().Camera;
            ViewportAdapter adapter = CruZ.Instance().ViewportAdapter;

            Matrix transformMat =
                Matrix.CreateTranslation(adapter.VirtualWidth / 2, adapter.VirtualHeight / 2, 0) *
                cam.GetViewMatrix();

            _spriteBatch.Begin(transformMatrix: transformMat);
            foreach (var entityId in ActiveEntities)
            {
                var spriteRenderer = _spriteRendererMapper.Get(entityId);
                _spriteBatch.Draw(spriteRenderer.Texture, new Rectangle(0, 0, 1280, 720), Color.White);
            }
            _spriteBatch.End();
        }

        SpriteBatch _spriteBatch;
        ComponentMapper<SpriteRenderer> _spriteRendererMapper;
    }
}
