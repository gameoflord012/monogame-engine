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
        }

        protected virtual void LoadContent()
        {
        }

        public void Run()
        {
            _core.Run();
        }

        public virtual void Initialize()
        {
            _entity = _core.World.CreateTransformEntity();
            _entity.AddComponent(new SpriteComponent("image"));
        }

        public virtual void Update(GameTime gameTime)
        {
            _entity.Transform.Position -= Vector3.UnitX;
        }

        TransformEntity _entity;
        CruZ _core;

        public CruZ Core { get => _core; }
        public World World { get => _core.World; }
        public ContentManager Content { get => _core.Content; }
    }
}
