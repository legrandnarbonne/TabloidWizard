
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard.Classes.Editor
{
    public partial class GraphicFormEditor : Form
    {
        TabloidConfigGraphCollection _tgc;
        TabloidConfigView _view;
        bool init;//prevent event fire during init

        public GraphicFormEditor(TabloidConfigView view,TabloidConfigGraphCollection tgc)
        {
            init = true;
            InitializeComponent();
            _tgc = tgc;
            lstGraphic.DataSource = tgc;
            _view = view;
            init = false;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            TabloidWizard.Classes.WizardTools.Tools.AddWithUniqueName(_tgc, new TabloidConfigGraph(), "G",_view.Graphiques);
            updateGraphicList();
        }

        private void updateGraphicList()
        {
            lstGraphic.DataSource = null;
            lstGraphic.DataSource = _tgc;
        }

        private void btnSupp_Click(object sender, System.EventArgs e)
        {
            if (lstGraphic.SelectedItem == null) return;

            _tgc.Remove(((TabloidConfigGraph)lstGraphic.SelectedItem).Nom);
            updateGraphicList();
        }

        private void lstGraphic_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = (TabloidConfigGraph)lstGraphic.SelectedItem;
            if (chkPreview.Checked&&!init) setPreview();
        }

        private void btnVisu_Click(object sender, EventArgs e)
        {
            setPreview();
        }

        void setPreview()
        {
            if (lstGraphic.SelectedItem == null) return;
            try
            {
                var graph = (TabloidConfigGraph)lstGraphic.SelectedItem;
                var sqlSet = TabloidGraphHelper.GetSQL(_view, graph,"",null);//find sql


                sqlSet.Select.Where = string.Format("deleted_{0}=0", _view);

                var data = TabloidGraphHelper.GetData(graph, _view, sqlSet.Select.Command, Program.AppSet.ConnectionString);
                var chart = new System.Web.UI.DataVisualization.Charting.Chart();
                chart.Width = imgGraphic.Width;
                chart.Height = imgGraphic.Height;
                string champX = sqlSet.Select.GroupBy;
                TabloidGraphHelper.GetChart(_view, graph, ref champX, chart, data);

                using (MemoryStream stream = new MemoryStream())
                {
                    chart.SaveImage(stream, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
                    imgGraphic.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GraphicFormEditor_Load(object sender, EventArgs e)
        {
            if (chkPreview.Checked) setPreview();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (chkPreview.Checked) setPreview();
        }

        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreview.Checked) setPreview();
        }
    }
}
