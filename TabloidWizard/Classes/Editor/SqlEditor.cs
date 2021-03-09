
using MetroFramework.Forms;

namespace TabloidWizard.Classes.Editor
{
    public partial class SqlEditor : MetroForm
    {
        public SqlEditor(string value)
        {
            InitializeComponent();

            txtSql.Text = value;
            fs.ConnectionString = Program.AppSet.ConnectionString;
            fs.cmdSchema.DataSource = AppSetting.GetSchemaList(Program.AppSet.ProviderType);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            txtSql.Text =insertText(txtSql.SelectionStart, txtSql.SelectionLength, txtSql.Text, 
                " " + fs.lstChamp.SelectedItem);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            txtSql.Text =insertText(txtSql.SelectionStart, txtSql.SelectionLength,txtSql.Text,
                        " " + fs.cmbTable.SelectedValue + "." + fs.lstChamp.SelectedItem);
        }

        private string insertText(int cursorPos,int selectionLength,string text,string textToInsert)
        {
            var firstPart = text.Substring(0, cursorPos);

            var endPart = txtSql.Text.Substring(cursorPos + selectionLength, text.Length - cursorPos - selectionLength);

            return firstPart + textToInsert + endPart;
        }
    }
}
