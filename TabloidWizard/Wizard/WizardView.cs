using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Controls;
using Tabloid.Classes.Data;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardTable : MetroForm
    {
        string _connectionString;
        Provider _provider;

        public TabloidConfigView CreatedView { get; set; }

        public WizardTable(string connectionString, Provider provider)
        {
            _provider = provider;
            InitializeComponent();
            _connectionString = connectionString;
            txtSchema.Text = Program.AppSet.Schema;

            string lastError;

            var dt = DataTools.Data(SqlCommands.SqlGetTable(), connectionString, out lastError);
            cmbTable.DataSource = dt;
            cmbTable.DisplayMember = dt.Columns[0].ColumnName;

            chkDefaultView.Checked = TabloidConfig.Config.Views.Count == 0;

            setVisibility();
        }

        private void Button_end(object sender, PageEventArgs e)
        {

            var param = new string[] { txtSchema.Text, txtTable.Text, TxtRef.Text };

            if (radUseExistingTable.Checked)
            {
                string lastError;
                //find db key
                var dc = DataTools.Data(SqlCommands.SqlGetColums(cmbTable.Text), _connectionString, out lastError);//3

                param = new string[] { Program.AppSet.Schema, cmbTable.Text, dc.Select(dc.Columns[3].ColumnName + " like 'PRI%'")[0][0].ToString() };
            }

            var viewName = String.IsNullOrEmpty(txtNomVue.Text) ? param[1] : txtNomVue.Text;

            if (TabloidConfig.Config.Views.Contains(viewName))
            {
                MetroMessageBox.Show(this,TabloidWizard.Properties.Resources.ViewNameAlreadyExist, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }


            //add new View
            CreatedView = new TabloidConfigView
            {
                Schema = param[0],
                Nom = viewName,
                Titre = txtInititView.Text,
                NomTable = param[1],// String.IsNullOrEmpty(txtNomVue.Text) ? "" : txtNomVue.Text,                
                DbKey = param[2]
            };

            if (radUseExistingTable.Checked)
            {
                TabloidConfig.Config.Views.Add(CreatedView);

                //set as default view
                setAsDefaultView(viewName);

                //add to menu
                addToMenu(CreatedView);

                return;
            }

            e.Cancel = !WizardSQLHelper.ExecuteFromFile("table.sql", param, _connectionString,this);
            if (e.Cancel) return;

            var Tc = new TabloidConfigColonne
            {
                Champ = "nom_" + param[1],
                Titre = "Nom",
                Editeur = TemplateType.TextBox,
                Type = DbType.String
            };

            Tools.AddWithUniqueName(CreatedView.Colonnes, Tc, "C");

            TabloidConfig.Config.Views.Add(CreatedView);

            //set as default view
            setAsDefaultView(viewName);

            //add to menu
            addToMenu(CreatedView);
        }

        private void setAsDefaultView(string viewName)
        {
            if (chkDefaultView.Checked)
                AppSetting.setDefaultPage(viewName);
            //Program.AppSet.pageDefaut = TabloidPages.BSRelativeUrl[TabloidPages.Type.Liste] + "?table=" + viewName;            
        }

        private void addToMenu(TabloidConfigView t)
        {
            if (!chkAjMenu.Checked) return;

            if (radMnMain.Checked)
                WizardSQLHelper.AddToMenu(this,t);
            else
                WizardSQLHelper.AddToParamMenu(t,this);
        }


        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            TxtRef.Text = "id_" + txtTable.Text;
            //txtInititView.Text = txtTable.Text;
        }

        private void radUseExistingTable_CheckedChanged(object sender, EventArgs e)
        {
            setVisibility();
        }

        private void setVisibility()
        {
            cmbTable.Enabled = radUseExistingTable.Checked;
            txtSchema.Enabled = txtTable.Enabled = TxtRef.Enabled = radAddTable.Checked;
            //txtInititView.Enabled=radMnMain.Enabled = radMnParam.Enabled = chkAjMenu.Checked && radAddTable.Checked;

        }

        private void txtNomVue_TextChanged(object sender, EventArgs e)
        {
            txtTable.Text = txtNomVue.Text;
        }

        private void chkAjMenu_CheckedChanged(object sender, EventArgs e)
        {
            radMnMain.Enabled = radMnParam.Enabled = chkAjMenu.Checked && radAddTable.Checked;
        }

        private void txtInititView_TextChanged(object sender, EventArgs e)
        {
            txtNomVue.Text = WizardSQLHelper.TitleToSystemName(txtInititView.Text);
        }
    }
}