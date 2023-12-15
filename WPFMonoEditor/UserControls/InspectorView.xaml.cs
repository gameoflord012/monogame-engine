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

namespace WPFMonoEditor.UserControls
{
    /// <summary>
    /// Interaction logic for InspectorView.xaml
    /// </summary>
    public partial class InspectorView : UserControl
    {
        public InspectorView()
        {
            InitializeComponent();
            Loaded += InspectorViewLoaded; 
        }

        private void InspectorViewLoaded(object sender, RoutedEventArgs e)
        {
            var myAdornerLayer = AdornerLayer.GetAdornerLayer(property1);
            myAdornerLayer.Add(new SimpleCircleAdorner(property1));
        }
    }
}
