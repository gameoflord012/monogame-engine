using System.Numerics;

namespace CruZ.Components
{
    public class Transform
    {
        public Vector3 Position
        {
            get
            {
                return _translateMatrix.Translation;
            }
            set
            {
                _translateMatrix = Matrix4x4.CreateTranslation(value);
            }
        }

        Matrix4x4 _translateMatrix;
        Matrix4x4 _rotationMatrix;
    }
}
