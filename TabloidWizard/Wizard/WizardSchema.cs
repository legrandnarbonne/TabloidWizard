using Gui.Wizard;
using System;
using System.Windows.Forms;
using TabloidWizard.Classes.WizardTools;
using TabloidWizard.Classes;
using TabloidWizard.Properties;
using Tabloid.Classes.Data;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardSchema : Form
    {
        ConfigFilesCollection _configFiles;
        /// <summary>
        /// Build new empty project in database
        /// </summary>
        /// <param name="configFiles"></param>
        public WizardSchema(ConfigFilesCollection configFiles)
        {
            InitializeComponent();
            _configFiles = configFiles;
            cmbType.SelectedIndex = 0;
        }

        void Button_end(object sender, PageEventArgs e)
        {
            var schema = txtSchema.Text == "" ? "public" : txtSchema.Text;

            string[] param = { txtHote.Text, txtUtil.Text, txtMdp.Text, txtBase.Text, schema };

            var connectionString = cmbType.SelectedIndex == 0
                ? string.Format("Datasource={0};uid={1};pwd={2};", param)
                : string.Format("User ID={1};Password={2};Host={0};Port=5432;Database={3};SearchPath={4},public;", param);



            if (Program.AppSet == null) Program.AppSet = new AppSetting();//if no default properties

            //set app setting parameter

            Program.AppSet.ConnectionString = connectionString;
            Program.AppSet.ProviderType = cmbType.SelectedIndex == 0 ? Provider.MySql : Provider.Postgres;
            Program.AppSet.Titre = txtBase.Text;
            Program.AppSet.identParam = cmbType.SelectedIndex == 0 ? "?" : "@";
            Program.AppSet.sqlDebug = "oui";

            Tools.SetDefaultProviderFromAppSet();


            //Add schema to database

            SqlCommands.Provider = cmbType.SelectedIndex == 0 ? Provider.MySql : Provider.Postgres;

            if (Program.AppSet.ProviderType == Provider.Postgres && schemaExist(schema))
            {
                string err;

                if (MessageBox.Show(Resources.SchemaAlreadyExist, Resources.Erreur, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)
                    != DialogResult.Yes)
                    return;

                if (MessageBox.Show(Resources.ConfirmDelete, Resources.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes)
                    return;

                DataTools.Command($"DROP SCHEMA {schema} CASCADE;", null, Program.AppSet.ConnectionString, out err);

                if (!string.IsNullOrEmpty(err))
                {
                    MessageBox.Show(string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Program.AppSet.Schema = schema;

            if (Program.AppSet.ProviderType == Provider.Postgres)
            {//postgres
                param = new string[] { txtSchema.Text };
                e.Cancel = !WizardSQLHelper.ExecuteFromFile("schema.sql", param, connectionString);
                if (e.Cancel) return;// stop on sql error
            }
            else
            {//mysql
                param = new string[] { txtBase.Text };
                e.Cancel = !WizardSQLHelper.ExecuteFromFile("schema.sql", param, connectionString);
                if (e.Cancel) return;// stop on sql error
                connectionString += "Database=" + txtBase.Text + ";";
                Program.AppSet.ConnectionString = connectionString;
            }

            // add tabloid table to database
            try
            {
                if (!TabloidTables.CreateTable(TabloidTables.TabloidTablesArray, connectionString))//create tabloid table in base
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //add table to config
            Tools.EditSetting(_configFiles);
        }
        /// <summary>
        /// Verify for postgres database schema existance
        /// </summary>
        /// <returns></returns>
        private bool schemaExist(string schema)
        {
            string err;

            var sql = "SELECT count(schema_name) FROM information_schema.schemata WHERE schema_name = '{0}';";
            sql = string.Format(sql, schema);

            var cmpt = DataTools.ScalarCommand(sql, null, Program.AppSet.ConnectionString, out err);

            if (!string.IsNullOrEmpty(err))
                MessageBox.Show(string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return Convert.ToInt32(cmpt) > 0;
        }
    }
}