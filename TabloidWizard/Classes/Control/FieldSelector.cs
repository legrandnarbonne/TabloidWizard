using System;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Data;

namespace TabloidWizard.Classes.Control
{
    public partial class FieldSelector : UserControl
    {
        public string ConnectionString { get; set; }

        public FieldSelector()
        {
            InitializeComponent();
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateFieldList();
        }

        private void cmdSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateTableList();
        }

        private void populateFieldList()
        {
            string lastError;

            lstChamp.Items.Clear();

            if (cmbTable.SelectedValue == null) return;

            var dc = DataTools.Data(SqlCommands.SqlGetColums(
                cmbTable.SelectedValue.ToString(),
                cmdSchema.SelectedValue.ToString()), ConnectionString, out lastError);//0
            foreach (DataRow dcr in dc.Rows)
            {
                if (TabloidFields.IstabloidField(dcr[0].ToString()) == -1)
                {
                    lstChamp.Items.Add(dcr[0].ToString());
                }
            }

            if (lstChamp.Items.Count > 0) lstChamp.SelectedIndex = 0;
        }

        private void populateTableList()
        {
            string lastError;

            var dt = DataTools.Data(SqlCommands.SqlGetTable(cmdSchema.SelectedItem.ToString()), ConnectionString, out lastError);

            cmbTable.ValueMember = dt.Columns[0].ColumnName;
            cmbTable.DataSource = dt;
        }
    }
}
