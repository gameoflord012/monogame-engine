using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CruZ.Components
{
    public class SpriteComponent : ISpriteBatchDrawable
    {
        public SpriteComponent() { }
        public SpriteComponent(string resourceName) { LoadTexture(resourceName); }
        public Texture2D Texture { get => _texture; set => _texture = value; }

        public void LoadTexture(string resourceName)
        {
            Texture = Resource.Instance().LoadResource<Texture2D>(resourceName);
        }

        private Vector3 GetRenderPosition()
        {
            var e = TransformEntity.GetEntity(this);
            return e.Transform.Position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Vector2 renderPosition = new(GetRenderPosition().X, GetRenderPosition().Y);
            spriteBatch.Draw(Texture, renderPosition, Color.White);
        }

        private Texture2D _texture;
    }
}
