using System.Windows.Forms;
using Point = Kml.Point;

namespace KmlViewer
{
    public partial class PointControl : UserControl
    {
        public PointControl()
        {
            InitializeComponent();
        }

        public PointControl(Point point)
            :this()
        {
            BuildUp(point);
        }

        private void BuildUp(Point point)
        {
            lonTextBox.Text = point.ToString("lon");
            latTextBox.Text = point.ToString("lat");
        }
    }
}
