using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WPFMonoEditor.CsharpControls
{
    public class RectViewport
    {
        Rect _rect;
        public RectViewport(Rect rect)
        {
            _rect = rect;
        }

        public Viewport2DVisual3D GetViewportVisual()
        {
            var material = new DiffuseMaterial(Brushes.White);
            Viewport2DVisual3D.SetIsVisualHostMaterial(material, true);

            var mesh = new MeshGeometry3D();
            mesh.Positions = new Point3DCollection()
            {
                new Point3D(_rect.X                 , _rect.Y               , 0),
                new Point3D(_rect.X + _rect.Width   , _rect.Y               , 0),
                new Point3D(_rect.X + _rect.Width   , _rect.Y - _rect.Height, 0),
                new Point3D(_rect.X                 , _rect.Y - _rect.Height, 0),
            };
            mesh.TextureCoordinates = new PointCollection()
            {
                new Point(0, 0),
                new Point(1, 0),
                new Point(1, 1),
                new Point(0, 1)
            };
            
            mesh.TriangleIndices = new Int32Collection { 0, 3, 2, 0, 2, 1 };

            return new Viewport2DVisual3D()
            {
                Material = material,
                Geometry = mesh
            };
        }
    }
}
