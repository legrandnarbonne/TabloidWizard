
using System;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes;

namespace TabloidWizard
{
    public partial class GridViewForm2 : Form
    {
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
            string lastError;

            Visibilites v;
            Enum.TryParse<Visibilites>(cmbVisibility.SelectedValue.ToString(), out v);

            _sqlSet = TableDefinition.DefSql(_view.Nom, v, false, false, null, false, null, null,null);

            var dt = DataTools.Data(_sqlSet.Select.Command, _connectionString, out lastError);
            dataGrid1.DataSource = dt;

            dataGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

    }
}
