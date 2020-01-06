using Gui.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tabloid.Classes.Config;

using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardList : Form
    {
        TabloidConfigView _view;
        string _connectionString;
        Provider _provider;
        bool aliasUse;
        //flag set to true if join have been created
        public bool JoinListUpdated { get; internal set; }

        /// <summary>
        /// store list of join pointing selected table
        /// </summary>
        List<TabloidConfigJointure> existingJoin;

        public WizardList(TabloidConfigView v, string title)
        {
            Init(v);
            txtViewName.Text = title;
            WizardSQLHelper.displayField(cmbExistingField, _view, Program.AppSet.ConnectionString);
        }

        public WizardList(TabloidConfigView v)
        {
            Init(v);
            WizardSQLHelper.displayField(cmbExistingField, _view, Program.AppSet.ConnectionString);
        }
        public void Init(TabloidConfigView v)
        {

            if (v == null) this.Close();

            _provider = Program.AppSet.ProviderType;
            InitializeComponent();
            _view = v;
            _connectionString = Program.AppSet.ConnectionString;

            Info.CloseFromNext += infoFromNext;
            Fin.CloseFromBack += finFromBack;

            cmbView.DataSource = TabloidConfig.Config.Views
                .Where(x => x.Nom != _view.Nom)
                .OrderBy(x=>x.Nom).ToList();
        }

        private void infoFromNext(object sender, PageEventArgs e)
        {
            //when using an existing table we must verify existing join
            if (radUseTable.Checked)
            {
                existingJoin = _view.Jointures.GetJointures().Where(
                    x => string.Equals(x.NomTable, ((TabloidConfigView)cmbView.SelectedItem).NomTable, StringComparison.OrdinalIgnoreCase)).ToList();
                aliasUse = existingJoin.Count > 0;
            }

            if (aliasUse) return;
            wizard1.NextTo(Fin);
            e.Cancel = true;
        }

        private void finFromBack(object sender, PageEventArgs e)
        {
            if (aliasUse) return;
            wizard1.BackTo(Info);
            e.Cancel = true;
        }

        private void Button_end(object sender, PageEventArgs e)
        {
            var table = radNewTable.Checked ? txtTable.Text.ToLower() : ((TabloidConfigView)cmbView.SelectedItem).NomTable;
            var schemaNewTable = radNewTable.Checked ? null : ((TabloidConfigView)cmbView.SelectedItem).Schema;
            var newDbKey = radNewTable.Checked ? "id_" + txtTable.Text.ToLower() : ((TabloidConfigView)cmbView.SelectedItem).DbKey;

            var refField = radExistingField.Checked ? cmbExistingField.SelectedItem.ToString() : TxtRef.Text;
            var alias = radUseAlias.Checked ? txtalias.Text : "";
            var useJoin = radUseAlias.Checked ? null : existingJoin[0];

            JoinListUpdated = useJoin == null;

            e.Cancel = !WizardSQLHelper.SetDataBaseForList(
                false,
                _view.Schema,
                table,
                newDbKey,
                txtViewName.Text,
                chkAddToparamMenu.Checked,
                _view,
                refField,
                _connectionString,
                _provider,
                true,
                false,
                alias,
                radUseTable.Checked,
                schemaNewTable,
                useJoin,
                radExistingField.Checked);
        }


        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            TxtRef.Text = txtTable.Text + "_id";
            //txtViewName.Text = txtTable.Text;
        }


        private void radNewTable_CheckedChanged(object sender, EventArgs e)
        {
            cmbView.Enabled = radUseTable.Checked;
            txtTable.Enabled = radNewTable.Checked;

            txtViewName.Text = radUseTable.Checked ?
                ((TabloidConfigView)cmbView.SelectedItem).NomTable :
                "";
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtRef.Text = ((TabloidConfigView)cmbView.SelectedItem).NomTable + "_id";

            //if (string.IsNullOrEmpty(txtViewName.Text))
            txtViewName.Text = radUseTable.Checked ?
                ((TabloidConfigView)cmbView.SelectedItem).NomTable :
                "";
        }

        private void txtViewName_TextChanged(object sender, EventArgs e)
        {
            txtTable.Text = WizardSQLHelper.TitleToSystemName(txtViewName.Text);
        }

        private void radExistingField_CheckedChanged(object sender, EventArgs e)
        {
            TxtRef.Enabled = !radExistingField.Checked;
            cmbExistingField.Enabled = radExistingField.Checked;
        }

        private void radUseAlias_CheckedChanged(object sender, EventArgs e)
        {
            txtalias.Enabled = radUseAlias.Checked;
        }
    }
}