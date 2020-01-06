using Gui.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Controls;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardComplexList : Form
    {
        TabloidConfigView _view;
        string _connectionString;
        Provider _provider;
        TemplateType _ctrl;
        bool init;

        public WizardComplexList(TabloidConfigView v, string title, TemplateType ctrl)
        {
            Init(v);
            txtViewName.Text = title;
            _ctrl = ctrl;
        }

        public WizardComplexList(TabloidConfigView v)
        {
            init = true;
            Init(v);
            init = false;
        }

        private void Init(TabloidConfigView v)
        {
            if (v == null) this.Close();

            _provider = Program.AppSet.ProviderType;
            InitializeComponent();
            _view = v;
            _connectionString = Program.AppSet.ConnectionString;
            cmbJoin.DataSource = get1NJoin();
            cmbTable.DataSource = TabloidConfig.Config.Views;//.Where(x => x.NomTable != v.NomTable).ToList();
        }

        private List<TabloidConfigJointure> get1NJoin()
        {
            var result = _view.Jointures.GetJointures(VisibiliteTools.GetFullVisibilite(), false);

            return result.Where(x => x.Relation == "1:N").ToList();
        }

        void Button_end(object sender, PageEventArgs e)
        {//e.Cancel = !WizardSQLHelper.SetDataBaseForList(true, _view.Schema, txtTable.Text, txtViewName.Text, "id_"+ txtViewName.Text, false, _view, null, _connectionString, _provider, chkName.Checked, chkDistinct.Checked); JD 2/9/19
            if (radioCrea.Checked)
                e.Cancel = !WizardSQLHelper.SetDataBaseForList(true, _view.Schema, txtTable.Text, "id_" + txtTable.Text, txtViewName.Text, false, _view, null, _connectionString, _provider, chkName.Checked, chkDistinct.Checked);
            else
                e.Cancel =
                    !WizardSQLHelper.AddGridviewField(_view, txtViewName.Text, (TabloidConfigJointure)cmbJoin.SelectedValue, cmbChamp.SelectedItem.ToString(), _ctrl == TemplateType.GridView, chkDistinct.Checked);

        }

        private void txtViewName_TextChanged(object sender, EventArgs e)
        {
            txtTable.Text = WizardSQLHelper.TitleToSystemName(txtViewName.Text);
        }


        private void radioCrea_CheckedChanged(object sender, EventArgs e)
        {
            var crea = radioCrea.Checked;

            cmbTable.Enabled = cmbChamp.Enabled = cmbJoin.Enabled = !crea;
            chkName.Enabled = txtViewName.Enabled = txtTable.Enabled = crea;
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            WizardSQLHelper.displayField(cmbChamp, ((TabloidConfigView)cmbTable.SelectedValue).NomTable, _connectionString);

            if (init) return;

            if (cmbJoin.SelectedIndex == -1 || ((TabloidConfigView)cmbTable.SelectedItem).NomTable != ((TabloidConfigJointure)cmbJoin.SelectedItem).NomTable)//no selection look for an interesting join in current list
            {
                cmbJoin.SelectedItem = null;

                selectJoinFromTableName();

                if (cmbJoin.SelectedIndex == -1)//no interesting join in current list try to create one from joins in joined table list
                {
                    var joinedTable = (TabloidConfigView)cmbTable.SelectedItem;

                    foreach (TabloidConfigJointure j in joinedTable.Jointures)
                    {
                        if (j.NomTable == _view.NomTable)
                        {
                            var dr = MessageBox.Show(Properties.Resources.NoJoinCreate, Properties.Resources.CreateJoin, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.No) break;

                            WizardJoin.joinConverter(j, true, joinedTable);

                            cmbJoin.DataSource = get1NJoin();

                            selectJoinFromTableName();
                        }
                    }
                }
            }
        }
        private void selectJoinFromTableName()
        {
            foreach (TabloidConfigJointure j in cmbJoin.Items)
            {
                if (j.NomTable == ((TabloidConfigView)cmbTable.SelectedItem).NomTable)
                    cmbJoin.SelectedItem = j;
            }
        }

        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            if (cmbJoin.SelectedItem != null || radioCrea.Checked) return;

            MessageBox.Show(Properties.Resources.SelectJoin, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }

        private void cmbJoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var i in cmbTable.Items)
                if (((TabloidConfigView)i).NomTable == ((TabloidConfigJointure)cmbJoin.SelectedItem).NomTable)
                    cmbTable.SelectedItem = i;
        }
    }
}