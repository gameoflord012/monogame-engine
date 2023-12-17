using CruZ.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace CruZ
{
    abstract class CruZ_App
    {
        public CruZ_App()
        {
            _core = CruZ.Instance();

            _core.OnInitialize += Initialize;
            _core.OnUpdate += Update;
        }

        public void Run()
        {
            _core.Run();
        }

        public virtual void Initialize()
        {
            _entity = _core.World.CreateTransformEntity();
            _entity.AddComponent(new SpriteRenderer("image"));
        }

        public virtual void Update(GameTime gameTime)
        {
            _entity.Transform.Position -= Vector3.UnitX;
        }

        TransformEntity _entity;
        CruZ _core;
    }
}
