
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects.OlObjects;

using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;
using TabloidWizard.Properties;

namespace TabloidWizard
{
    public partial class NewFromBaseForm : Form
    {
        public NewFromBaseForm()
        {
            InitializeComponent();

            cmbType.SelectedIndex = 0;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var error = false;

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            var schema = txtSchema.Text == "" ? "public" : txtSchema.Text;

            object[] param = { txtHote.Text, txtUtil.Text, txtMdp.Text, txtBase.Text, schema };

            var connectionString = cmbType.SelectedIndex == 0
                ? string.Format("Datasource={0};Database={3};uid={1};pwd={2};", param)
                : string.Format("User ID={1};Password={2};Host={0};Port=5432;Database={3};SearchPath={4},public;", param);

            Program.AppSet = new AppSetting
            {
                ConnectionString = connectionString,
                ProviderType = cmbType.SelectedIndex == 0 ? Provider.MySql : Provider.Postgres,
                Titre = txtBase.Text,
                identParam = cmbType.SelectedIndex == 0 ? "?" : "@",
                sqlDebug = "oui"
            };

            Tools.SetDefaultProviderFromAppSet();

            lblState.Text = Resources.NewFromBaseForm_btn_Click_Récupération_des_Tables;
            lblState.Refresh();

            SqlCommands.Provider = cmbType.SelectedIndex == 0 ? Provider.MySql : Provider.Postgres;
            Program.AppSet.Schema = schema;

            string lastError;

            var dt = DataTools.Data(SqlCommands.SqlGetTable(), connectionString, out lastError);

            if (dt == null)
            {
                MessageBox.Show(Resources.NewFromBaseForm_btn_Click_ + lastError, Resources.Erreur,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(lastError))
            {
                lblState.Text = lastError;
                error = true;
            }
            else
            {
                TabloidConfig.Config = new TabloidConfig();

                TabloidConfig.Config.TabloidConfigApp.UseLockDatabaseField = chkLockInDB.Checked;

                var avt = new ArrayVerify();

                var config = new BuildFromBase.BaseImporterConfig
                {
                    RemoveTableName = chkSuppNomTable.Checked,
                    ToUpperCase = chkCasse.Checked,
                    ReplaceUnderscrore = chkUnderscrore.Checked,

                    ConnectionString = connectionString
                };

                if (dt.Rows.Count > 0)
                {


                    TabloidFields.TabloidFieldsArray = null;
                    //Program.AppSet.pageDefaut = "/tabloid/BSliste.aspx?table=" + 
                    AppSetting.setDefaultPage(dt.Rows[0][0].ToString());
                    var delta = 100 / dt.Rows.Count;

                    //read Tables
                    foreach (DataRow dtr in dt.Rows)
                    {
                        progressBar1.Value += delta;
                        progressBar1.Refresh();

                        var dtName = dtr[0].ToString();

                        var tableConfig = new TabloidConfigView();

                        try
                        {
                            BuildFromBase.GetTable(dtName, schema, ref tableConfig, ref avt, config);
                            TabloidConfig.Config.Views.Add(tableConfig);
                        }
                        catch(Exception ex)
                        {
                            lblState.Text = ex.ToString();
                        }
                    }

                    if (error) return;

                }

                //verify tabloid table existance
                if (!avt.IsThereAll(TabloidTables.TabloidTablesArray.Count()))
                {
                    var l = avt.NotInIndex(TabloidTables.TabloidTablesArray.Count()); //list unaviable tables
                    var r = DialogResult.Yes;

                    if (!chkAutoTable.Checked)
                    {
                        //Show message
                        var strCh = string.Join("\n\t- ",
                            TabloidTables.TabloidTablesArray
                                .Where((f, index) => l.Any(i => i == index))
                                .Select((x, index) => x.Name).ToArray());

                        r = MessageBox.Show(
                            string.Format(
                                Resources.NewFromBaseForm_tables_inutiles,
                                strCh),
                            Resources.Information,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                    }

                    if (r == DialogResult.Yes)
                    {
                        var toCreate = TabloidTables.TabloidTablesArray
                            .Where((f, index) => l.Any(i => i == index))
                            .ToList();

                        TabloidTables.CreateTable(
                            toCreate, connectionString);

                        foreach (var t in toCreate)// table to config
                        {
                            var tableConfig = new TabloidConfigView();
                            try {
                                BuildFromBase.GetTable(t.Name, schema, ref tableConfig, ref avt, config);
                                TabloidConfig.Config.Views.Add(tableConfig);
                            }
                            catch (Exception ex)
                            {
                                lblState.Text = ex.ToString();
                            }
                        }
                    }
                }

                OlStyleCollection.olStyles = new List<OlStyle>();

                DialogResult = DialogResult.OK;
                Close();
            }
        }



        private void CmbTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            txtSchema.Enabled = cmbType.SelectedIndex == 1;
        }


    }
}