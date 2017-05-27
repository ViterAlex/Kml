using System.Windows.Forms;
using Kml;

namespace KmlViewer.Controls
{
    public partial class StyleControl : UserControl
    {
        public StyleControl()
        {
            InitializeComponent();
        }

        public StyleControl(Style style)
            :this()
        {
            BuildUp(style);
        }

        private void BuildUp(Style style)
        {
            lineStyleColorPanel.BackColor = style.LineStyle.Color;
            lineWidthLabel.Text = $"Ширина: {style.LineStyle.Width}";
            lineStyleColorLabel.Text = $"#{style.LineStyle.ColorString}";
            polyStyleColorPanel.BackColor = style.PolyStyle.Color;
            polyStyleColorLabel.Text = $"#{style.PolyStyle.ColorString}";
            //polyWidthLabel.Text = $"Ширина: {style.PolyStyle.Width}";
        }
    }
}
