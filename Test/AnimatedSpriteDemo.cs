using CruZ.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System.Windows;

namespace CruZ.Tests
{
    [TestClass]
    [TestCategory("hipapa")]
    public class AnimatedSpriteTest : CruZ_App
    {
        public AnimatedSpriteTest() : base()
        {
            Core.Run();
        }

        public override void Initialize()
        {
            base.Initialize();

            _entity = World.CreateTransformEntity();
            _spriteRenderer = new SpriteComponent();
            _entity.AddComponent(_spriteRenderer);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            var spriteSheet = Content.Load<SpriteSheet>("player.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);

            sprite.Play("attack");
            _motwSprite = sprite;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _motwSprite.Update(gameTime);
            _spriteRenderer.Texture = _motwSprite.TextureRegion.Texture;
        }

        [TestMethod]
        public void test1()
        {
            Assert.IsTrue(false);
        }

        private AnimatedSprite _motwSprite;
        private TransformEntity _entity;
        private SpriteComponent _spriteRenderer;
    }
}