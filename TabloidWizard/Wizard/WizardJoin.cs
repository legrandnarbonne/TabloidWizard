using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardJoin : MetroForm
    {
        string _connectionString;
        TabloidConfigView _view;
        TabloidConfigJointure _parentJoin;
        List<TabloidConfigJointure> _autoJoinList;
        TabloidConfigView _srcView;


        public WizardJoin(TabloidConfigView view, TabloidConfigJointure parentJoin, string connectionString)
        {
            _connectionString = connectionString;
            _view = view;
            _parentJoin = parentJoin;

            InitializeComponent();

            wjStart.CloseFromNext += wjRef_CloseFromNext;
            wjRef2.ShowFromNext += Rel_ShowFromNext;
            wjRef2.ShowFromBack += Back_Rel_ShowFromNext;
            Fin.CloseFromBack += Fin_CloseFromBack;

            _srcView = parentJoin == null ? view : TabloidConfig.Config.Views[parentJoin.NomTable];

            upDateList();
            
            WizardSQLHelper.displayTable(cmbTable, Program.AppSet.ConnectionString, _srcView.NomTable, false);

            cmbTable.SelectedIndex = 0;

            lblChampRef.Text = string.Format(lblChampRef.Text, _srcView.NomTable);

            cmbTypeJointure.SelectedIndex = 0;

            cmbOrderType.Items.Add(Properties.Resources.Increasing);
            cmbOrderType.Items.Add(Properties.Resources.Decreasing);
            cmbOrderType.SelectedIndex = 0;

            WizardSQLHelper.SetVisibiliteCheckedBoxList(lstVisibilites);

            string lastError = "";
            // list automatic join
            var searchTable = _parentJoin == null ? _view : TabloidConfig.Config.Views[_parentJoin.NomTable];
            _autoJoinList = WizardSQLHelper.SetJoinFromConstraint(searchTable, Program.AppSet.ConnectionString, ref lastError, false);
            lstAutoJoin.DataSource = _autoJoinList;

            radManu.Checked = _autoJoinList.Count == 0;

        }

        private void Fin_CloseFromBack(object sender, PageEventArgs e)
        {
            if (radAuto.Checked)
            {
                wizard1.NextTo(wjStart);
                e.Cancel = true;
            }
        }

        private void wjRef_CloseFromNext(object sender, PageEventArgs e)
        {
            if (radAuto.Checked)
            {
                e.Cancel = true;
                if (lstAutoJoin.SelectedItems.Count == 0)
                {
                    MetroMessageBox.Show(this,Properties.Resources.ChooseOnAutomaticJoinAtLeast, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //todo verif if already  exist

                wizard1.NextTo(Fin);
            }
        }

        /// <summary>
        /// Next from second page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rel_ShowFromNext(object sender, EventArgs e)
        {

            if (cmbTypeJointure.SelectedItem.ToString() == "N:1") wizard1.NextTo(wjVisibilite);
        }

        private void Back_Rel_ShowFromNext(object sender, EventArgs e)
        {
            if (cmbTypeJointure.SelectedItem.ToString() == "N:1") wizard1.NextTo(wjRef);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_end(object sender, PageEventArgs e)
        {
            if (radAuto.Checked)
            {
                foreach (TabloidConfigJointure Tj in lstAutoJoin.SelectedItems)
                {
                    Tools.AddWithUniqueName(_view.Jointures, Tj, "J", _parentJoin == null ? null : _parentJoin.Jointures);
                }
            }
            else
            {
                var newTable = cmbTable.SelectedItem.ToString();
                var dbKey = WizardSQLHelper.GetPrimaryKeyName(newTable);

                if (dbKey == null)
                {
                    MetroMessageBox.Show(this,Properties.Resources.CantFindPrimaryKey, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var is1N = cmbTypeJointure.SelectedItem.ToString() == "1:N";

                var Tj = new TabloidConfigJointure
                {
                    NomTable = newTable,
                    Relation = cmbTypeJointure.SelectedItem.ToString(),
                    DbKey = dbKey,
                    Parent = _parentJoin,
                    ChampDeRef = is1N ? getJoinParentView().NomTable + "." + cmbChampRef.SelectedItem : cmbChampRef.SelectedItem.ToString(),
                    ChampDeRef2 = is1N ? cmbChampRef2.SelectedItem.ToString() : "",
                };

                if (cmbOrder.SelectedIndex > 0)
                    Tj.Order = cmbOrder.SelectedItem + " " + (cmbOrderType.SelectedIndex == 0 ? "asc" : "desc");


                Tj.Visu = WizardSQLHelper.GetVisibiliteFromCheckedListBox(lstVisibilites);

                Tools.AddWithUniqueName(_view.Jointures, Tj, "J", _parentJoin == null ? null : _parentJoin.Jointures);


            }
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            upDateList();
        }
        /// <summary>
        /// Display field list
        /// </summary>
        void upDateList()
        {
            if (cmbTypeJointure.SelectedItem == null) return;

            var tableToJoin = (string)cmbTable.SelectedItem; //getNewJoinedTable();
            var is1N = cmbTypeJointure.SelectedItem.ToString() == "1:N";//1:N complex list

            if (is1N)
            {
                lblChampRef2.Text = string.Format(Properties.Resources.RefFieldForTable, tableToJoin);
                lblChampRef.Text =  string.Format(Properties.Resources.RefFieldForTable, getJoinParentView()  );

                WizardSQLHelper.displayField(cmbChampRef2, tableToJoin, _connectionString, "");
                WizardSQLHelper.displayField(cmbChampRef, getJoinParentView().NomTable, _connectionString, getJoinParentView().Schema, "", false, !chkCmbChRefHT.Checked);
            }
            else
            {
                lblChampRef.Text =string.Format(Properties.Resources.RefFieldForTable, getJoinParentView());//1:N
                WizardSQLHelper.displayField(cmbChampRef, getJoinParentView().NomTable , _connectionString, getJoinParentView().Schema, "", false, !chkCmbChRefHT.Checked);
            }
            
            WizardSQLHelper.displayField(cmbOrder, tableToJoin, _connectionString, getJoinParentView().Schema, "", true);
            
        }

        TabloidConfigView getNewJoinedTable()
        {
            return (TabloidConfigView)cmbTable.SelectedValue;
        }
        /// <summary>
        /// Return parent view
        /// </summary>
        /// <returns></returns>
        TabloidConfigView getJoinParentView()
        {
            if (_parentJoin == null) return _view;
            return TabloidConfig.Config.Views[_parentJoin.NomTable];
        }

        private void radManu_CheckedChanged(object sender, EventArgs e)
        {
            cmbTable.Enabled = cmbTypeJointure.Enabled = radManu.Checked;
            lstAutoJoin.Enabled = radAuto.Checked;
        }
        /// <summary>
        /// Convert N:1 join to 1:N
        /// </summary>
        /// <param name="joinSource">Join to convert</param>
        /// <param name="recursively"></param>
        public static void joinConverter(TabloidConfigJointure joinSource, bool recursively, TabloidConfigView parentView = null)
        {
            var destView = TabloidConfig.Config.Views[joinSource.NomTable];//todo search with nomtable property
            TabloidConfigJointure result = null;
            bool root = false;

            while (!root)
            {
                result = convertN11N(joinSource, destView, result == null ? destView.Jointures : result.Jointures, parentView);
                root = joinSource.Parent == null || !recursively;
                joinSource = joinSource.Parent;
            }
        }

        /// <summary>
        /// Build a join from an existing one. Add result to hte table. Join must be N:1 type
        /// </summary>
        /// <param name="joinSource">join to convert</param>
        /// <param name="destinationView"></param>
        /// <param name="destinationJoin"></param>
        /// <param name="parentView">new join will be added to parent view id null CurrentContext is used</param>
        /// <returns></returns>
        public static TabloidConfigJointure convertN11N(TabloidConfigJointure joinSource, TabloidConfigView destinationView, TabloidConfigJointureCollection destinationJoin, TabloidConfigView parentView = null)
        {
            if (joinSource.Relation != "N:1" && joinSource.Relation != null) throw new Exception(Properties.Resources.ConvertOnlyN1Join);

            parentView = parentView ?? CurrentContext.CurrentView;
            if (joinSource.Parent != null)
                parentView = TabloidConfig.Config.Views[joinSource.Parent.NomTable];

            TabloidConfigJointure parent = null;
            if (destinationJoin.Count > 0) parent = destinationJoin[0].Parent;

            var result = new TabloidConfigJointure
            {
                Relation = "1:N",
                ChampDeRef = destinationView.NomTable + "." + joinSource.DbKey,
                ChampDeRef2 = ChampTools.RemoveTableName(joinSource.ChampDeRef),
                DbKey = parentView.DbKey,
                NomTable = parentView.NomTable,
                Parent = parent
            };

            Tools.AddWithUniqueName(destinationView.Jointures, result, "J", destinationJoin);

            return result;
        }

        private void cmbTypeJointure_SelectedIndexChanged(object sender, EventArgs e)
        {
            upDateList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            upDateList();
        }
    }
}