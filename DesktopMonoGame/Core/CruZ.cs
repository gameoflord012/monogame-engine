using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.ViewportAdapters;
using System.Diagnostics;

namespace CruZ
{
    public delegate void CruZ_InitializeDelegate();
    public delegate void CruZ_UpdateDelegate(GameTime gameTime);
    public delegate void CruZ_LoadContentDelegate();

    public partial class CruZ : Game
    {
        private CruZ()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

            _input = new CruZ_Input(this);
            _ecs = new CruZ_ECS(this);
            _graphics = new GraphicsDeviceManager(this);
            
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

            ViewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1280, 720);
            Camera = new OrthographicCamera(_viewportAdapter);
            Debug.Write(Camera.Center);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            OnDraw?.Invoke(gameTime);
        }

        public event CruZ_InitializeDelegate OnInitialize;
        public event CruZ_UpdateDelegate OnUpdate;
        public event CruZ_UpdateDelegate OnDraw;
        public event CruZ_LoadContentDelegate OnLoadContent;
        public OrthographicCamera Camera { get => _camera; set => _camera = value; }
        public ViewportAdapter ViewportAdapter { get => _viewportAdapter; set => _viewportAdapter = value; }
        public CruZ_Input Input { get => _input; }
        public World World { get => _ecs.World; }
        public Matrix RenderMatrix { 
            get => 
                Matrix.CreateTranslation(_viewportAdapter.VirtualWidth / 2, _viewportAdapter.VirtualHeight / 2, 0) * 
                _camera.GetViewMatrix(); 
        }

        private CruZ_ECS _ecs;
        private CruZ_Input _input;
        private GraphicsDeviceManager _graphics;
        private OrthographicCamera _camera;
        private ViewportAdapter _viewportAdapter;
    }
}
