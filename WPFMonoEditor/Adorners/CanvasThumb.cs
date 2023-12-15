using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace WPFMonoEditor.Adorners
{
    public delegate void CanvasThumbDragDelegate(Vector delta);
    public class CanvasThumb : Thumb
    {
        public event CanvasThumbDragDelegate? DragEvent;

        public CanvasThumb(Vector thumbPosition) : base()
        {
            Width = 10;
            Height = 10;
            Cursor = Cursors.SizeAll;

            Canvas.SetLeft(this, thumbPosition.X - Width / 2);
            Canvas.SetTop(this, thumbPosition.Y - Height / 2);

            DragDelta += DragDeltaEventHand;
        }

        private void DragDeltaEventHand(object sender, DragDeltaEventArgs e)
        {
            DragEvent?.Invoke(new Vector(e.VerticalChange, e.HorizontalChange));
            Canvas.SetLeft(this, Canvas.GetLeft(this) + e.HorizontalChange);
            Canvas.SetTop(this, Canvas.GetTop(this) + e.VerticalChange);
        }
    }
}
