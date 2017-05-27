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
            splitContainer1.Panel2.Controls.Clear();
            if (obj.GetType() == typeof(Data))
            {
                splitContainer1.Panel2.Controls.Add(new DataControl((Data)obj) { Dock = DockStyle.Fill });
            }
            else if (obj.GetType() == typeof(Point))
            {
                splitContainer1.Panel2.Controls.Add(new PointControl((Point)obj) { Dock = DockStyle.Fill });
            }
        }

        private void PopulateTreeView()
        {
            var kml = Reader.Read<Kml.Kml>("layer.kml");
            var root = new TreeNode($"{kml.Document.Name} — Document") { Tag = kml.Document };
            var style = root.Nodes.Add("Style");
            style.Nodes.Add(kml.Document.Style.Id);
            style.Tag = kml.Document.Style;
            style.Nodes.Add("LineStyle").Nodes.AddRange(new[]
                                                        {
                                                            new TreeNode($"{kml.Document.Style.LineStyle.ColorString} — ColorString"),
                                                            new TreeNode($"{kml.Document.Style.LineStyle.Width} — Width"),
                                                        }
            );
            style.Nodes.Add("PolyStyle").Nodes.Add(new TreeNode($"{kml.Document.Style.PolyStyle.ColorString} — ColorString"));

            foreach (var placemark in kml.Document.Placemarks)
            {
                var pm = new TreeNode($"Placemark {kml.Document.Placemarks.IndexOf(placemark)}") { Tag = placemark };
                pm.Nodes.Add(new TreeNode(placemark.Point.ToString()) { Tag = placemark.Point });
                root.Nodes.Add(pm);
                foreach (var data in placemark.ExtendedData)
                {
                    pm.Nodes.Add(new TreeNode(data.Name) { Tag = data });
                }
            }
            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
        }
    }
}
