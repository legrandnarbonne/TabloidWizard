using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes.Editor
{
    public partial class TableFieldSelectorForm : Form
    {
        public string Value { get; set; }
        public TableFieldSelectorForm(TabloidConfigView view, string value, string tableName = null)
        {
            Value = value;
            InitializeComponent();

            WizardSQLHelper.displayTable(cmbTable, Program.AppSet.ConnectionString, view.NomTable);

            if (!string.IsNullOrEmpty(tableName)) cmbTable.SelectedIndex = cmbTable.FindStringExact(tableName);
            if (!string.IsNullOrEmpty(value)) cmbChamp.SelectedIndex = cmbChamp.FindStringExact(value);
        }

        private void cmbTable_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            WizardSQLHelper.displayField(cmbChamp, cmbTable.SelectedItem.ToString(), Program.AppSet.ConnectionString);
        }

        private void cmbChamp_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbChamp.SelectedItem != null)
                Value = cmbChamp.SelectedItem.ToString();
        }
    }
}
