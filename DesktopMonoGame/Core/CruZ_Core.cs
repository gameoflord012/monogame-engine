using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

namespace CruZ
{
    internal partial class CruZ : Game
    {
        public OrthographicCamera Camera { get => _camera; set => _camera = value; }
        public ViewportAdapter ViewportAdapter { get => _viewportAdapter; set => _viewportAdapter = value; }

        private CruZ()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            Initialize_ECS();
            GameInitialize();

            ViewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1280, 720);
            Camera = new OrthographicCamera(_viewportAdapter);
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Input_Update(gameTime);
            ECS_Update(gameTime);

            Camera.ZoomOut(-Input_ScrollDeltaValue() * (float)gameTime.ElapsedGameTime.TotalSeconds * 0.01f);
            if(_keyboardState.IsKeyDown(Keys.A))
            {
                Camera.Position -= Vector2.UnitX;
            }

            base.Update(gameTime);
        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ECS_Draw(gameTime);

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

        private GraphicsDeviceManager _graphics;
        private OrthographicCamera _camera;
        private ViewportAdapter _viewportAdapter;
    }
}
