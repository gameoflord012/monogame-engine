using CruZ.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Content;

namespace CruZ.Demos
{
    [DemoName("demo1")]
    public class AnimatedSpriteDemo : CruZ_App
    {
        public AnimatedSpriteDemo() : base()
        {
            Core.Run();
        }

        public override void Initialize()
        {
            base.Initialize();

            _entity = World.CreateTransformEntity();
            _animatedSprite = new AnimatedSpriteComponent(_spriteSheet);
            _entity.AddComponent(_animatedSprite);

            _animatedSprite.AnimatedSprite.Play("attack");

            _entity.Transform.Position = Vector3.One;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _entity.Transform.Position -= Vector3.UnitX;
            _entity.Transform.Scale += Vector3.One * 0.01f;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _spriteSheet = Content.Load<SpriteSheet>("player.sf", new JsonContentLoader());
        }

        private TransformEntity _entity;
        SpriteSheet _spriteSheet;
        AnimatedSpriteComponent _animatedSprite;
    }
}