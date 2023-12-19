using System.Numerics;

namespace CruZ.Components
{
    public class Transform
    {
        public Transform()
        {
            _translateMatrix = Matrix4x4.CreateTranslation(0, 0, 0);
        }

        public Microsoft.Xna.Framework.Vector3 Position
        {
            get
            {
                return _translateMatrix.Translation;
            }
            set
            {
                _translateMatrix = Matrix4x4.CreateTranslation(new Vector3(value.X, value.Y, value.Z));
            }
        }

        Matrix4x4 _translateMatrix;
        Matrix4x4 _rotationMatrix;
    }
}
