using CruZ.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Entities;
using System;

namespace CruZ
{
    public abstract class CruZ_App
    {
        public CruZ_App()
        {
            _core = CruZ.Instance();

            _core.OnInitialize += Initialize;
            _core.OnUpdate += Update;
            _core.OnLoadContent += LoadContent;
            _core.OnEndRun += EndRun;
            _core.OnExit += OnExit;
        }

        protected virtual void OnExit(object sender, EventArgs args) { }

        protected virtual void EndRun() { }

        protected virtual void LoadContent() { }

        public void Run()
        {
            _core.Run();
        }

        public virtual void Initialize() { }

        public virtual void Update(GameTime gameTime) { }
        CruZ _core;

        public CruZ Core { get => _core; }
        public World World { get => _core.World; }
        public ContentManager Content { get => _core.Content; }
    }
}
