using MetroFramework.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes.Editor
{
    public partial class TableFieldSelectorForm : MetroForm
    {
        public string Value { get; set; }
        public TableFieldSelectorForm(TabloidConfigView view, string value, string tableName = null)
        {
            Value = value;
            InitializeComponent();

            WizardSQLHelper.displayTable(fieldSelector1.cmbTable, Program.AppSet.ConnectionString, view.NomTable);

            fieldSelector1.ConnectionString = Program.AppSet.ConnectionString;
            fieldSelector1.cmdSchema.DataSource = AppSetting.GetSchemaList(Program.AppSet.ProviderType);

            fieldSelector1.lstChamp.SelectedIndexChanged += cmbChamp_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(tableName)) fieldSelector1.cmbTable.SelectedIndex = fieldSelector1.cmbTable.FindStringExact(tableName);
            if (!string.IsNullOrEmpty(value)) fieldSelector1.lstChamp.SelectedIndex = fieldSelector1.lstChamp.FindStringExact(value);
        }

        private void cmbTable_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            WizardSQLHelper.displayField(fieldSelector1.lstChamp, fieldSelector1.cmbTable.SelectedItem.ToString(), Program.AppSet.ConnectionString);
        }

        private void cmbChamp_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (fieldSelector1.lstChamp.SelectedItem != null)
                Value = fieldSelector1.lstChamp.SelectedItem.ToString();
        }

    }
}
