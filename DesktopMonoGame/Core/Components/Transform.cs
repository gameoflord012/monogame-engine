using Microsoft.Xna.Framework;

namespace CruZ.Components
{
    public class Transform
    {
        public Transform()
        {
            _translateMatrix = Matrix.CreateTranslation(0, 0, 0);
            _scaleMatrix = Matrix.Identity;
        }

        public Vector3 Position
        {
            get
            {
                return _translateMatrix.Translation;
            }
            set
            {
                _translateMatrix = Matrix.CreateTranslation(new Vector3(value.X, value.Y, value.Z));
            }
        }

        public Vector3 Scale
        {
            get
            {
                return new Vector3(_scaleMatrix.M11, _scaleMatrix.M22, _scaleMatrix.M33);
            }
            set
            {
                _scaleMatrix = Matrix.CreateScale(value.X, value.Y, value.Z);
            }
        }

        public Matrix TotalMatrix { get => _scaleMatrix * _translateMatrix; }
        public Matrix TranslateMatrix { get => _translateMatrix; set => _translateMatrix = value; }
        public Matrix RotationMatrix { get => _rotationMatrix; set => _rotationMatrix = value; }
        public Matrix ScaleMatrix { get => _scaleMatrix; set => _scaleMatrix = value; }

        Matrix _translateMatrix;
        Matrix _scaleMatrix;
        Matrix _rotationMatrix;
    }
}
