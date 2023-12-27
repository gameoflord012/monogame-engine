using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CruZ
{
    public class Camera
    {
        public Camera(Viewport viewport)
        {
            _viewport = viewport;
        }

        private static Camera _mainCamera;

        public static Camera GetMain()
        {
            if (_mainCamera == null)
            {
                _mainCamera = new(CruZ.Viewport);
            }
            return _mainCamera;
        }

        public static Camera Main
        {
            get => GetMain();
            set => _mainCamera = value;
        }

        public Matrix ViewMatrix()
        {
            return
                Matrix.CreateScale(
                    _viewport.Width / VirtualWidth,
                    _viewport.Height / VirtualHeight, 1);
        }

        public float VirtualWidth = 1980;
        public float VirtualHeight = 1080;

        Viewport _viewport;
    }
}