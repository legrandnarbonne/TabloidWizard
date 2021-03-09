using Gui.Wizard;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardCalendrier : MetroForm
    {
        string _connectionString;
        Provider _provider;
        TabloidConfigView _view;

        public WizardCalendrier(TabloidConfigView view, string connectionString, Provider provider)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _provider = provider;
            _view = view;

            string lastError;
            var dt = DataTools.Data(SqlCommands.SqlGetColums(view.NomTable), connectionString, out lastError);//01

            //is there 2 timestamp
            cmbDeb.DataSource = new DataView(dt, dt.Columns[1].ColumnName + " like 'timestamp%'", null, DataViewRowState.CurrentRows);
            cmbFin.DataSource = new DataView(dt, dt.Columns[1].ColumnName + " like 'timestamp%'", null, DataViewRowState.CurrentRows);
            cmbDeb.DisplayMember = cmbFin.DisplayMember = dt.Columns[0].ColumnName;

            chkUtilDeb.Enabled = chkUtilFin.Enabled = cmbDeb.Items.Count != 0;//no timestamp field couldn't use existing fields          

            //is there 1 or more character varying
            cmbTitre.DataSource = dt;
            cmbTitre.ValueMember = dt.Columns[0].ColumnName;

            var nameField = cmbTitre.FindStringExact("nom_" + _view.NomTable);
            if (nameField > -1)
            {
                cmbTitre.SelectedIndex = nameField;
                chkExistTitre.Checked = true;
            }

            ///create new field
            txtTitre.Text = "eve_" + view.NomTable;
            txtDebut.Text = "deb_" + view.NomTable;
            txtFin.Text = "fin_" + view.NomTable;

        }

        private void selectNextFromFieldDef(object sender, PageEventArgs e)
        {
            wizard1.NextTo(Fin);
            e.Cancel = true;
        }

        private void Button_end(object sender, PageEventArgs e)
        {
            string sql = "";

            var titre = buildField(chkCreaTitre, cmbTitre, txtTitre, ref sql);
            var deb = buildField(chkCreaDeb, cmbDeb, txtDebut, ref sql);
            var fin = buildField(chkCreaFin, cmbFin, txtFin, ref sql);

            if (sql != "")
            {
                sql += "commit;";
                e.Cancel = !WizardSQLHelper.ExecuteSQLString(sql,this);
                if (e.Cancel) return;
            }

            var cal = new TabloidConfigCalendrier
            {
                Titre = titre,
                Debut = deb,
                Fin = fin
            };

            var cTitre = new TabloidConfigColonne
            {
                Titre = "Titre",
                Champ = titre,
                Type = DbType.String
            };

            var cDebut = new TabloidConfigColonne
            {
                Titre = "Début",
                Champ = deb,
                Type = DbType.DateTime
            };

            var cFin = new TabloidConfigColonne
            {
                Titre = "Fin",
                Champ = fin,
                Type = DbType.DateTime
            };

            if (chkCreaTitre.Checked) Tools.AddWithUniqueName(_view.Colonnes, cTitre, "C");
            if (chkCreaDeb.Checked) Tools.AddWithUniqueName(_view.Colonnes, cDebut, "C");
            if (chkCreaFin.Checked) Tools.AddWithUniqueName(_view.Colonnes, cFin, "C");

            _view.Calendrier = cal;

            if (chkAddToMenu.Checked)
            {
                var mn = radMnParam.Checked ? WizardSQLHelper.getParamMenu() : null;

                WizardSQLHelper.AddToMenu(this,_view, null, TabloidConfigMenuItem.MenuType.Calendrier, mn);
            }
        }

        /// <summary>
        /// create sql command if necessary 
        /// </summary>
        /// <param name="chkNewField"></param>
        /// <param name="cmbField"></param>
        /// <param name="txtField"></param>
        /// <returns></returns>
        private string buildField(RadioButton chkNewField, ComboBox cmbField, TextBox txtField, ref string sql)
        {

            if (chkNewField.Checked)
            {
                var param = new string[] { _view.NomTable, txtField.Text, "timestamp", _view.Schema };

                sql += WizardSQLHelper.BuildSQLFromFile("addField.sql", param);

                return txtField.Text;
            }

            return cmbField.Text;
        }

        private void Titre_CheckedChanged(object sender, EventArgs e)
        {
            txtTitre.Enabled = chkCreaTitre.Checked;
            cmbTitre.Enabled = chkExistTitre.Checked;
        }

        private void chkCreaDeb_CheckedChanged(object sender, EventArgs e)
        {
            txtDebut.Enabled = chkCreaTitre.Checked;
            cmbDeb.Enabled = chkUtilDeb.Checked;
        }

        private void chkCreaFin_CheckedChanged(object sender, EventArgs e)
        {
            txtFin.Enabled = chkCreaFin.Checked;
            cmbFin.Enabled = chkUtilFin.Checked;
        }

        private void chkAddToMenu_CheckedChanged(object sender, EventArgs e)
        {
            radMnPrincipal.Enabled = radMnParam.Enabled = chkAddToMenu.Checked;
        }
    }
}