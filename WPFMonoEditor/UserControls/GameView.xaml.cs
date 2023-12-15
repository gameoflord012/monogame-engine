using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMonoEditor.Adorners;
using System.Windows;
using WPFMonoEditor.CsharpControls;

namespace WPFMonoEditor.UserControls
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        CanvasThumb thumbOne;
        public GameView()
        {
            InitializeComponent();

            //thumbOne = new CanvasThumb(new Vector(
            //    Canvas.GetLeft(myRect),
            //    Canvas.GetTop(myRect)));

            //myCanvas.Children.Add(thumbOne);

            //thumbOne.DragDelta += (sender, delta) =>
            //{
            //    Canvas.SetLeft(myRect, Canvas.GetLeft(myRect) + delta.HorizontalChange);
            //    Canvas.SetTop(myRect, Canvas.GetTop(myRect) + delta.VerticalChange);
            //};
            var viewPort = new RectViewport(new Rect(new Point(0, 0), new Size(20, 20))).GetViewportVisual();
            var myButton = new Button
            {
                Content = "hello rect",
                Width = 200,
                Height = 200,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            viewPort.Visual = myButton;

            viewport3D.Children.Add(viewPort);
        }
    }
}
