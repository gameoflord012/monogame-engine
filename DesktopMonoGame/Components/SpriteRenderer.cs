using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public Vector3 GetRenderPosition()
        {
            var e = TransformEntity.GetEntity(this);
            return e.Transform.Position;
        }

        private Texture2D _texture;
    }
}
