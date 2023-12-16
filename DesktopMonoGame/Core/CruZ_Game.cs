using DesktopMonoGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMonoGame
{
    internal partial class CruZ
    {
        private void GameInitialize()
        {
            var entity = _world.CreateEntity();
            entity.Attach(new SpriteRenderer("image"));
        }
    }
}
