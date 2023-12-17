using CruZ.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;

namespace CruZ.Components
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
