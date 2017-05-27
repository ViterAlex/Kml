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

            if (string.IsNullOrEmpty(dataValue.Text)) return;

            textBox1.Text = dataValue.Text.Replace("\n", "\r\n");

        }
    }
}
