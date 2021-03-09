using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Tools;
using TabloidWizard.Classes;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class GraphForm : MetroForm
    {
        readonly TabloidConfigGraph _currentGraph;
        readonly TabloidConfigGraph _parentGraph;
        readonly TabloidConfigView _view;
        readonly bool _update;

        public GraphForm(TabloidConfigView view, TabloidConfigGraph graph = null, TabloidConfigGraph parent = null)
        {
            InitializeComponent();

            _currentGraph = graph;
            _view = view;
            _update = _currentGraph != null;
            _parentGraph = parent;

            if (!_update)//new
                _currentGraph = new TabloidConfigGraph();
            else//edit existing
                UpdatewizardView();

            SetFieldLists();
            propertyGrid1.SelectedObject = _currentGraph;
            UpdateGraph();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateGraph();            
        }

        void UpdatewizardView()
        {
            radChDef.Checked = _view.Colonnes.Contains(_currentGraph.ChampX);

            if (radChDef.Checked)
            {
                cmbChView.SelectedItem = _view.Colonnes[_currentGraph.ChampX];
            }

            var chY = _currentGraph.ChampY.Split('.');

            if (chY.Length>1)
            {
                cmbTable.SelectedValue = cmbChamp.FindStringExact(chY[0]);
                cmbChamp.SelectedValue = cmbChamp.FindStringExact(chY[1]);
            }
            else
                cmbChamp.SelectedIndex = cmbChamp.FindStringExact(chY[0]);

            txtId.Enabled = true;// _currentGraph.GraphiqueDetail;
        }

        void SetFieldLists()
        {
            string lastError;
            cmbChView.DataSource = _view.Colonnes;
            var dc = DataTools.Data(SqlCommands.SqlGetColums(_view.NomTable), Program.AppSet.ConnectionString, out lastError);//c0
            cmbChTable.DisplayMember = cmbChTable.ValueMember="column_name";
            cmbChTable.DataSource = dc;

            var dt= DataTools.Data(SqlCommands.SqlGetTable(), Program.AppSet.ConnectionString, out lastError);
            cmbTable.DisplayMember = cmbTable.ValueMember = dt.Columns[0].ColumnName;
            cmbTable.DataSource = dt;
        }
        void UpdateGraph()
        {
            toolStripStatusLabel1.Text = "";

            if (string.IsNullOrEmpty(_currentGraph.ChampX) || string.IsNullOrEmpty(_currentGraph.ChampY)) return;

            var where = string.IsNullOrEmpty(txtId.Text)?"":_view.DbKey + "=" + txtId.Text;

            var sqlSet = TabloidGraphHelper.GetSQL(_view, _currentGraph, where,null);//find sql

            txtSql.Text = sqlSet.Select.Command;

            DataView data;

            try
            {
                data = TabloidGraphHelper.GetData(_currentGraph, _view, sqlSet.Select.Command, Program.AppSet.ConnectionString);
            }
            catch (Exception e)
            {
                toolStripStatusLabel1.Text = e.Message;
                return;
            }


            //chart.Width = 500;
            //chart.Height = 300;
            string champX="";

            chart.BackColor = System.Drawing.Color.Transparent;
            //chart.TextAntiAliasingQuality = TextAntiAliasingQuality.SystemDefault;
            //chart.AntiAliasing = AntiAliasingStyles.Graphics;
            getChartSeries(_view, _currentGraph, chart, ref champX);

            var chartArea = new ChartArea
            {
                Name = "ChartArea1",
                BorderColor = System.Drawing.Color.Transparent,
                BackColor = System.Drawing.Color.Transparent,
            };


            chartArea.Area3DStyle.Enable3D = _currentGraph.volume;
            chartArea.Area3DStyle.Inclination = 30;
            //chartArea.Area3DStyle.PointDepth = 999;

            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(chartArea);

            chart.DataSource = data;
            dataGridView1.DataSource = data;
            chart.DataBind();

            //chart.ChartAreas[0].AxisX.LabelStyle.Interval = data.Count / 20;
            UpdatewizardView();
        }

        private static void getChartSeries(TabloidConfigView table, TabloidConfigGraph graph, Chart chart, ref string champX)
        {
            chart.Series.Clear();

            setSerieFromChart(table, graph, chart, true, ref champX);

            foreach (TabloidConfigGraph g in graph.Graphiques) setSerieFromChart(table, g, chart, false, ref champX);
        }

        private static void setSerieFromChart(TabloidConfigView table, TabloidConfigGraph graph, Chart chart, bool main, ref string champX)
        {

            if (main)
            {

                champX = table.Colonnes.Contains(graph.ChampX)
                        ? table.Colonnes[graph.ChampX].Titre
                        : ChampTools.RemoveTableName(graph.ChampX);
            }


            var serieName = string.IsNullOrEmpty(graph.Serie) ? "g" + chart.Series.Count : graph.Serie;

            var g = chart.Series.Add(serieName);

            g.ChartType = (SeriesChartType)graph.Type;
            g.XValueMember = champX; // TODO use dbkey
            g.YValueMembers = "Valeur" + chart.Series.Count;
            g.LabelForeColor = graph.CouleurEtiquette;

            g["PieLabelStyle"] = "Outside";
            g.Label = graph.Etiquette;
        }


        void btnOk_Click_1(object sender, EventArgs e)
        {
            if (!_update)
            {
                var parent = _parentGraph==null? _view.Graphiques : _parentGraph.Graphiques;
                Tools.AddWithUniqueName(_view.Graphiques, _currentGraph, "G", parent);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        void radChDef_CheckedChanged(object sender, EventArgs e)
        {
            cmbChTable.Enabled = !radChDef.Checked;
            cmbChView.Enabled = radChDef.Checked;
        }

        void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lastError;

            var dc = DataTools.Data(SqlCommands.SqlGetColums(cmbTable.Text), Program.AppSet.ConnectionString, out lastError);//c0
            cmbChamp.DisplayMember = cmbChamp.ValueMember="column_name";
            cmbChamp.DataSource = dc;
        }

        void button1_Click(object sender, EventArgs e)
        {
            _currentGraph.ChampX = radChDef.Checked ? ((TabloidConfigColonne)cmbChView.SelectedItem).Nom : cmbChTable.SelectedValue.ToString();
            _currentGraph.ChampY = cmbChamp.Text;

            UpdateGraph();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }
    }
}


