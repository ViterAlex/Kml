using System.Windows.Forms;
using Point = Kml.Point;

namespace KmlViewer.Controls
{
    public partial class PointControl : UserControl
    {
        private PointControl()
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
            lonLabel.Text = point.ToString("lon");
            latLabel.Text = point.ToString("lat");
        }
    }
}
