using System.Windows.Forms;
using Kml;

namespace KmlViewer.Controls
{
    public partial class DataControl : UserControl
    {
        public DataControl()
        {
            InitializeComponent();
        }

        public DataControl(Data data)
            :this()
        {
            BuildUp(data);
        }

        public void BuildUp(Data data)
        {
            label1.Text = data.Name;
            dataValueControl1.BuildUp(data.Value);
        }
    }
}
