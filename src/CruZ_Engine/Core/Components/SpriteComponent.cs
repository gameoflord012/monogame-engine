using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace CruZ.Components
{
    public partial class SpriteComponent : ISpriteBatchDrawable, IComponentAddedCallback
    {
        public SpriteComponent() { }
        public SpriteComponent(string resourceName) { LoadTexture(resourceName); }

        public Texture2D Texture { get => _texture; set => _texture = value; }

        public void LoadTexture(string resourceName)
        {
            _resourceName = resourceName;
            Texture = Resource.Instance().LoadResource<Texture2D>(resourceName);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Matrix transformMatrix)
        {
            if(Texture == null)
            {
                Trace.TraceWarning("Texture is unloaded, draw will not execute");
                return;
            }

            spriteBatch.Begin(transformMatrix: _e.Transform.TotalMatrix * transformMatrix);
            spriteBatch.Draw(Texture, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        public void OnComponentAdded(TransformEntity entity)
        {
            _e = entity;
        }

        private Texture2D _texture;
        private string _resourceName;
        private TransformEntity _e;
    }
}
