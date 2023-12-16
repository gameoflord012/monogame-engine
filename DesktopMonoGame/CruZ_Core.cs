using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopMonoGame
{
    internal partial class CruZ : Game
    {
        private GraphicsDeviceManager _graphics;

        private CruZ()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            Initialize_ECS();
            GameInitialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Update_ECS(gameTime);
            base.Update(gameTime);
        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Draw_ECS(gameTime);

            #region comment
            //Matrix view = Matrix.Identity;

            //int width = GraphicsDevice.Viewport.Width;
            //int height = GraphicsDevice.Viewport.Height;
            //Matrix projection = Matrix.CreateOrthographicOffCenter(0, width, height, 0, 0, 1);

            //_firstShader.Parameters["view_projection"].SetValue(view * projection);

            //_spriteBatch.Begin(effect: _firstShader);
            //_spriteBatch.Draw(_image, new Vector2(0, 0), Color.White);
            //_spriteBatch.End();

            //base.Draw(gameTime);
            #endregion
        }
    }
}
