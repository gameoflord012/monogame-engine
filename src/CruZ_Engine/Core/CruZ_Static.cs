using CruZ.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ
{
    public partial class CruZ
    {
        private static CruZ _instance;
        public static CruZ Instance()
        {
            if (_instance == null)
                _instance = new CruZ();
            return _instance;
        }

        public static readonly int VIRTUAL_WIDTH = 1920;
        public static readonly int VIRTUAL_HEIGHT = 1080;
        public static readonly string CONTENT_ROOT = "Content";

        public static Viewport Viewport { get => Instance().GraphicsDevice.Viewport; }

        public static Vector2 PointToCoordinate(Point p)
        {
            var normalize_x = (2f * p.X / Viewport.Width) - 1f;
            var normalize_y = 1f - (2f * p.Y / Viewport.Height);

            return new(normalize_x * VIRTUAL_WIDTH, normalize_y * VIRTUAL_HEIGHT);
        }

        public static Point CoordinateToPoint(Vector2 coord)
        {
            var normalize_x = 1f + coord.X / VIRTUAL_WIDTH;
            var normalize_y = 1f - coord.Y / VIRTUAL_HEIGHT;

            return new(
                FunMath.RoundInt(normalize_x * Viewport.Width),
                FunMath.RoundInt(normalize_y * Viewport.Height));
        }
    }
}
