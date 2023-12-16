using DesktopMonoGame.Singletons;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMonoGame.Components
{
    internal class SpriteRenderer
    {
        public SpriteRenderer() { }
        public SpriteRenderer(string resourceName) { LoadTexture(resourceName); }
        public Texture2D Texture { get => _texture; set => _texture = value; }

        public void LoadTexture(string resourceName)
        {
            Texture = Resource.Instance().LoadResource<Texture2D>(resourceName);
        }

        private Texture2D _texture;
    }
}
