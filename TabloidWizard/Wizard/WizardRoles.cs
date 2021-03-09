using Gui.Wizard;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Data;

namespace TabloidWizard
{
    public partial class WizardRoles : MetroForm
    {
        private DataTable _dt;
        private string _concerned;
        private string _property;

        public WizardRoles(string concerned,string property)
        {
            _concerned = concerned;
            _property = property;

            InitializeComponent();

            UpdateTxt();
        }


        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            
        }

        private void update(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;
            var worker = (BackgroundWorker)sender;
            var dtGrid = (MetroGrid)args[0];

            string lastError;

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Chargement, Properties.Resources.DatabaseRead));

            _dt = DataTools.Data("Select id_role as id,titre_role as titre from roles", Program.AppSet.ConnectionString, out lastError);

            _dt.Columns.Add("Select.", typeof(bool));

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Chargement, Properties.Resources.DataDisplaying));


        }

        private void Info_Paint(object sender, PaintEventArgs e)
        {
            var waitingForm = new WaitingForm(update)
            {
                Text = TabloidWizard.Properties.Resources.Chargement,
                progressBar = { Style = ProgressBarStyle.Marquee }
            };

            waitingForm.Wr.RunWorkerAsync(new object[] { metroGrid1 });

            waitingForm.ShowDialog();

            metroGrid1.DataSource = _dt;
            metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            metroGrid1.Columns[2].Width = 50;
        }


        private void metroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTxt();
        }

        private void UpdateTxt()
        {
            // calc value
            var result = chkInv.Checked ? "!" : "";
            var sep = "";

            foreach (DataGridViewRow r in metroGrid1.Rows)
            {
                if (r.Cells[2].Value != DBNull.Value && (bool)r.Cells[2].Value)
                {
                    result += sep + r.Cells[0].Value;
                    sep = ",";
                }
            }

            txtResult.Text = result;
            
            txtDesc.Text=chkInv.Checked?
                 $"{_concerned} sera {_property} pour les roles qui ne sont pas sélectionné(s) :":
                $"{_concerned} sera {_property} pour les roles sélectionné(s) suivant(s) :";
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            metroGrid1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void chkInv_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTxt();
        }
    }
}