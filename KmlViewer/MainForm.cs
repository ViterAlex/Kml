using System.Windows.Forms;
using Kml;
using KmlViewer.Controls;

namespace KmlViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += (sender, args) => PopulateTreeView();
            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var obj = e.Node.Tag;
            if (obj == null)
            {
                return;
            }
            splitContainer1.Panel2.Controls.Clear();
            if (obj.GetType() == typeof(Data))
            {
                splitContainer1.Panel2.Controls.Add(new DataControl((Data)obj) { Dock = DockStyle.Fill });
            }
            else if (obj.GetType() == typeof(Placemark))
            {
                splitContainer1.Panel2.Controls.Add(new PointControl(((Placemark)obj).Point) { Dock = DockStyle.Fill });
            }
            else if (obj.GetType() == typeof(Style))
            {
                splitContainer1.Panel2.Controls.Add(new StyleControl((Style)obj) { Dock = DockStyle.Fill });
            }
        }

        private void PopulateTreeView()
        {
            var kml = Reader.Read<Kml.Kml>("layer.kml");
            var root = new TreeNode($"{kml.Document.Name} — Document") { Tag = kml.Document };
            root.Nodes.Add(new TreeNode("Style") { Tag = kml.Document.Style });
            foreach (var placemark in kml.Document.Placemarks)
            {
                var pm = new TreeNode($"Placemark {kml.Document.Placemarks.IndexOf(placemark)}") { Tag = placemark };
                root.Nodes.Add(pm);
                foreach (var data in placemark.ExtendedData)
                {
                    pm.Nodes.Add(new TreeNode(data.Name) { Tag = data });
                }
            }
            treeView1.Nodes.Add(root);
            //treeView1.ExpandAll();
        }
    }
}
