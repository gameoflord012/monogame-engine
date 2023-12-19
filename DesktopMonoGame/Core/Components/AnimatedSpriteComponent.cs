using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;

namespace CruZ.Components
{
    public class AnimatedSpriteComponent : ISpriteBatchDrawable, IUpdateable
    {
        public AnimatedSpriteComponent(SpriteSheet spriteShit)
        {
            _spriteSheet = spriteShit;
            _animatedSprite = new AnimatedSprite(_spriteSheet);
        }

        private Vector3 GetRenderPosition()
        {
            var e = TransformEntity.GetEntity(this);
            return e.Transform.Position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 renderPosition = new(GetRenderPosition().X, GetRenderPosition().Y);
            spriteBatch.Draw(_animatedSprite, renderPosition);
        }

        public void Update(GameTime gameTime)
        {
            _animatedSprite.Update(gameTime);
        }

        MonoGame.Extended.Sprites.AnimatedSprite _animatedSprite;
        SpriteSheet _spriteSheet;
        public SpriteSheet SpriteSheed { get => _spriteSheet; set => _spriteSheet = value; }
        public AnimatedSprite AnimatedSprite { get => _animatedSprite; }
    }
}