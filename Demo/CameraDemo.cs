using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CruZ.Demos
{
    [DemoName("SpriteBatchTest")]
    public class CameraDemo : CruZ_App
    {   
        public override void Initialize()
        {
            base.Initialize();
            _batch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Content.Load<Texture2D>("image");
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            var effect = Matrix.Identity;

            _batch.Begin();

            _batch.Draw(
                _texture,
                position: Vector3.Zero,
                null, Color.White, 0, Vector3.Zero,
                scale: new Vector2(1, -1),
                SpriteEffects.None, 0);

            _batch.End();
        }

        Texture2D _texture;
        SpriteBatch _batch;
    }
}