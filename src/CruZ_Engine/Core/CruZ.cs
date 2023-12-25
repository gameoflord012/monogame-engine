using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.ViewportAdapters;
using System;

namespace CruZ
{
    public delegate void CruZ_UpdateDelegate(GameTime gameTime);
    public delegate void ActionDelegate();
    public delegate void OnExitingDelegate(object sender, EventArgs args);

    public partial class CruZ : Game
    {
        private CruZ()
        {
            Content.RootDirectory = CONTENT_ROOT;
            IsMouseVisible = true;

            _input = new CruZ_Input(this);
            _ecs = new CruZ_ECS(this);
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void EndRun()
        {
            base.EndRun();
            OnEndRun?.Invoke();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
            OnExit.Invoke(sender, args);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            OnLoadContent.Invoke();
        }

        protected override void Initialize()
        {
            base.Initialize();
            OnInitialize?.Invoke();

            ViewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, VIRTUAL_WIDTH, VIRTUAL_HEIGHT);
            Camera = new OrthographicCamera(_viewportAdapter);
            Camera.Position = new(-VIRTUAL_WIDTH / 2f, -VIRTUAL_HEIGHT / 2f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Camera.ZoomOut(-Input.ScrollDeltaValue() * (float)gameTime.ElapsedGameTime.TotalSeconds * 0.01f);
            if (Input.KeyboardState.IsKeyDown(Keys.A))
            {
                Camera.Position -= Vector2.UnitX;
            }

            OnUpdate?.Invoke(gameTime);
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.Blue);
            OnDraw?.Invoke(gameTime);
        }

        public event ActionDelegate OnInitialize;
        public event ActionDelegate OnLoadContent;
        public event ActionDelegate OnEndRun;
        public event OnExitingDelegate OnExit;

        public event CruZ_UpdateDelegate OnUpdate;
        public event CruZ_UpdateDelegate OnDraw;
        public OrthographicCamera Camera { get => _camera; set => _camera = value; }
        public ViewportAdapter ViewportAdapter { get => _viewportAdapter; set => _viewportAdapter = value; }
        public CruZ_Input Input { get => _input; }
        public World World { get => _ecs.World; }
        public Matrix ViewMatrix { get => _camera.GetViewMatrix(); }
        
        private CruZ_ECS _ecs;
        private CruZ_Input _input;
        private GraphicsDeviceManager _graphics;
        private OrthographicCamera _camera;
        private ViewportAdapter _viewportAdapter;
    }
}
