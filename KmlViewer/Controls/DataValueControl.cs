using System.IO;
using System.Windows.Forms;
using Kml;

namespace KmlViewer.Controls
{
    public partial class DataValueControl : UserControl
    {
        public DataValueControl()
        {
            InitializeComponent();
        }

        public DataValueControl(DataValue dataValue)
        {
            BuildUp(dataValue);
        }

        public void BuildUp(DataValue dataValue)
        {
            if (dataValue.ValueImage == null || !File.Exists(Path.GetFullPath(dataValue.ValueImage.Source)))
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }
            else
            {
                pictureBox1.LoadAsync(Path.GetFullPath(dataValue.ValueImage.Source));
            }
            textBox1.Text = dataValue.Text;

        }
    }
}
