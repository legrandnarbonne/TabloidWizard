
using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes;

namespace TabloidWizard
{
    public partial class GridViewForm2 : MetroForm
    {
        DataTable _dt;
        TabloidConfigView _view;
        SqLcommandSet _sqlSet;
        string _connectionString;

        public GridViewForm2(TabloidConfigView view, string connectionString)
        {
            InitializeComponent();
            _view = view;
            _connectionString = connectionString;

            cmbVisibility.DataSource = Enum.GetValues(typeof(Visibilites));

        }

        private void cmbVisibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visibilites v;
            Enum.TryParse<Visibilites>(cmbVisibility.SelectedValue.ToString(), out v);

            var waitingForm = new WaitingForm(update)
            {
                Text = Properties.Resources.Chargement,
                progressBar = { Style = ProgressBarStyle.Marquee }
            };



            waitingForm.Wr.RunWorkerAsync(new object[] { v,_view.Nom,_connectionString });

            waitingForm.ShowDialog();

            dataGrid1.DataSource = _dt;

            dataGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void update(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;

            var v = (Visibilites)args[0];
            var viewName = (string)args[1];
            var cString=(string)args[2];

            var worker = (BackgroundWorker)sender;

            string lastError;

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Chargement,Properties.Resources.DatabaseRead));
            var sqlSet = TableDefinition.DefSql(viewName, v, false, false, null, false, null, null, null);

            _dt = DataTools.Data(sqlSet.Select.Command, cString, out lastError);

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Chargement, Properties.Resources.DataDisplaying));

        }

    }
}
