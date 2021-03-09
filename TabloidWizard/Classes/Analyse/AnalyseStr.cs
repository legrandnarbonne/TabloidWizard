using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Analyse;

namespace TabloidWizard
{
    public partial class AnalyseStr : MetroForm
    {
        private List<TableAnalysisResult> _results;

        public AnalyseStr()
        {
            InitializeComponent();
        }

        private void AnalyseStr_Load(object sender, EventArgs e)
        {
            Analyse();
        }

        private void Analyse()
        {
            try
            {
                var _wf = new WaitingForm(Analyse)
                {
                    Text = Properties.Resources.Analysing ,
                    progressBar = { Style = ProgressBarStyle.Marquee }
                };

                _results = new List<TableAnalysisResult>();
                _wf.Wr.RunWorkerAsync(_results);
                _wf.ShowDialog();

                displayResult();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this,Properties.Resources.AnalyseError, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayResult()
        {
            treeView1.Nodes.Clear();
            var root = treeView1.Nodes.Add("Analyse");

            int[] l = new int[4];

            foreach (TableAnalysisResult r in _results)
            {
                TreeNode n = r;
                l[n.ImageIndex]++;
                if (chkFullDisplay.Checked || n.ImageIndex < 3) root.Nodes.Add(n);
            }

            lbl1.Text = l[1].ToString();
            lbl2.Text = l[2].ToString();
            lbl3.Text = l[3].ToString();

            root.Expand();
        }

        private void Analyse(object sender, DoWorkEventArgs e)
        {
            string lastError;

            var dc = DataTools.Data(SqlCommands.SqlGetTable(), Program.AppSet.ConnectionString, out lastError);
            List<string> tableList = new List<string>();

            //search in table list and attach corresponding view
            foreach (DataRow dcr in dc.Rows)
            {
                var attachedView = TabloidConfig.Config.Views.Where(c => c.NomTable == dcr[0].ToString()).ToList();
                tableList.Add(dcr[0].ToString());

                var result = new TableAnalysisResult
                {
                    TableName = dcr[0].ToString(),
                    Views = attachedView
                };

                if (attachedView.Count == 0)
                    result.Results.Add(new TableWithNoView(result,this));
                _results.Add(result);
            }


            foreach (TabloidConfigView v in TabloidConfig.Config.Views)
            {
                var result = new TableAnalysisResult
                {
                    TableName = null
                };
                result.Views.Add(v);

                if (!tableList.Contains(v.NomTable))//search view with no table
                    result.Results.Add(new ViewWithNoTable(result,this));


                var joinList = v.Jointures.GetJointures(VisibiliteTools.GetFullVisibilite(), true);
                if (joinList.Count > 0)
                {
                    var dfk = DataTools.Data(SqlCommands.SqlGetForeignKey(v.NomTable, v.Schema), Program.AppSet.ConnectionString, out lastError);

                    foreach (TabloidConfigJointure j in joinList)
                    {
                        if (j.Relation == "N:1" || string.IsNullOrEmpty(j.Relation))
                        {
                            var sql = $"{dfk.Columns[0].ColumnName}='{j.ChampDeRef}' and {dfk.Columns[1].ColumnName}='{j.NomTable}' and {dfk.Columns[2].ColumnName}='{j.DbKey}'";
                            if (dfk.Select(sql).Count() == 0)
                                result.Results.Add(new JoinWithNoConstraint(j, v,this));
                        }
                    }
                }

                if (result.Results.Count > 0) _results.Add(result);
            }


        }

        internal class TableAnalysisResult
        {
            public List<TabloidConfigView> Views { get; set; }

            public string TableName { get; set; }
            public List<AnalyseResult> Results { get; set; }

            public TableAnalysisResult()
            {
                Results = new List<AnalyseResult>();
                Views = new List<TabloidConfigView>();
            }

            public IEnumerable<T> GetListOf<T>()
            {
                return Results.OfType<T>();
            }
            
            // User-defined conversion from TableAnalysisResult to TreeNode
            public static implicit operator TreeNode(TableAnalysisResult d)
            {
                var node = new TreeNode
                {
                    Tag = d,
                    Text = d.Views.Count == 0 ? d.TableName : getViewsName(d.Views) + $"({d.Results.Count()})",
                    ImageIndex = 3
                };

                foreach (AnalyseResult ar in d.Results)
                {
                    node.ImageIndex = Math.Min(node.ImageIndex, ar.Level);
                    node.Nodes.Add(ar);
                }

                node.SelectedImageIndex = node.ImageIndex;

                return node;
            }

            /// <summary>
            /// Combine list view name
            /// </summary>
            /// <param name="views"></param>
            /// <returns></returns>
            private static string getViewsName(List<TabloidConfigView> views)
            {
                var results = new List<string>();

                foreach (TabloidConfigView v in views)
                    results.Add(v.Titre);

                return string.Join("/", results);
            }


        }

        private void chkFullDisplay_CheckedChanged(object sender, EventArgs e)
        {
            displayResult();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null) return;
            treeView1.SelectedNode.Expand();

            if (treeView1.SelectedNode.Parent==null|| treeView1.SelectedNode.Parent.Tag ==null) return;//first level

            pnlBtn.Controls.Clear();
            lbView.Text = lbTable.Text = txtRes.Text = txtdesc.Text = "";

            var selectedItem = (IAnalyseResult)treeView1.SelectedNode.Tag;
            var selectedView = (TableAnalysisResult)treeView1.SelectedNode.Parent.Tag;

            if (selectedView.Views.Count > 0)
            {
                lbView.Text = $"Vue :{selectedView.Views[0].Titre}";// Todo
                lbTable.Text = $"Table :{selectedView.Views[0].NomTable}";

            }
            txtRes.Text = selectedItem.Title;
            txtdesc.Text = selectedItem.Description;

            foreach (var b in selectedItem.AnalyseActions)
            {
                Button btn = new Button
                {
                    Dock = DockStyle.Bottom,
                    Text = b.Caption
                };

                b.Results = _results;

                btn.Click += b.OnClick;
                btn.Click += afterClick;

                pnlBtn.Controls.Add(btn);
            }
        }

        private void afterClick(object sender, EventArgs e)
        {
            Analyse();
        }
    }


}
