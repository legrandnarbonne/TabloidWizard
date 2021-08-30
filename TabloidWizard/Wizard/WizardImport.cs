using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tabloid.Classes;
using Tabloid.Classes.Config;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Editor;

namespace TabloidWizard
{
    public partial class WizardImport : MetroForm
    {

        public TabloidConfigImport ImportResult { get; set; }


        BindingList<ColumnFieldLink> _linkList = new BindingList<ColumnFieldLink>();
        TabloidConfigView _currentView;
        DataGridViewComboBoxColumn _ExcelColumnDDL;

        public WizardImport(TabloidConfigImport i, TabloidConfigView view)
        {
            ImportResult = i ?? new TabloidConfigImport();
            _linkList = new BindingList<ColumnFieldLink>();
            _currentView = view;

            InitializeComponent();

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = _linkList;
            dgv.AllowUserToAddRows = false;

            dgv.AutoResizeColumns();

            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = _currentView.Colonnes;
            col.DisplayMember = "CompleteName";
            col.ValueMember = "Self";
            col.DataPropertyName = "field";
            col.HeaderText = "Champ de votre projet";
            col.Width = 200;

            _ExcelColumnDDL = new DataGridViewComboBoxColumn();
            _ExcelColumnDDL.DataPropertyName = "columnTitle";
            _ExcelColumnDDL.HeaderText = "Colonne Excel";
            _ExcelColumnDDL.Width = 200;

            dgv.Columns.Add(col);
            dgv.Columns.Add(_ExcelColumnDDL);

        }

        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            ImportResult = new TabloidConfigImport
            {
                WorkSheetNumber = Program.CurrentXLSStructure.CurrentWorkBookNum+1,
                Title = txtTitreImport.Text,
                LineToSkip= Program.CurrentXLSStructure.IgnoreLine
            };

            var mainTable = new TabloidConfigDestinationTable
            {
                TableName = _currentView.NomTable,
                Nom = "T0"
            };

            ImportResult.DestinatrionTable.Add(mainTable);

            foreach (ColumnFieldLink link in _linkList)
            {
                if (link.columnTitle != null || link.field != null)
                {
                    var ctrl = TabloidControl.TabloidControlList[link.field.Editeur];
                    TabloidConfigImpField importField = null;

                    if (ctrl.isSingleObjectSelector)
                    {
                        if (!string.IsNullOrEmpty(link.field.Jointure))
                        {
                            var join = _currentView.Jointures[link.field.Jointure];

                            // Add table to import list of values
                            var newImportTable = new TabloidConfigDestinationTable
                            {
                                TableName = join.NomTable
                            };

                            var newImportTableField = new TabloidConfigImpField
                            {
                                Deduplicate = true,
                                FieldName = link.field.Champ,
                                ColName = link.columnTitle
                            };

                            Classes.WizardTools.Tools.AddWithUniqueName(newImportTable.Fields, newImportTableField, "C");
                            Classes.WizardTools.Tools.AddWithUniqueName(ImportResult.DestinatrionTable, newImportTable, "T",null,0);

                            // add field to main table
                            importField = new TabloidConfigImpField
                            {
                                ColName = link.columnTitle,
                                FieldName = join.ChampDeRef,
                                JoinFieldName = link.field.Champ,
                                JoinValueField = join.CalculatedKeyName,
                                JoinTableName = join.NomTable
                            };
                        }
                    }
                    else if (ctrl.isArrayObjectSelector)
                    {

                    }
                    else
                    {
                        importField = new TabloidConfigImpField
                        {
                            ColName = link.columnTitle,
                            FieldName = link.field.Champ
                        };
                    }


                    if (importField != null)
                        Classes.WizardTools.Tools.AddWithUniqueName(mainTable.Fields, importField, "C");
                }
                else
                {
                    MetroMessageBox.Show(this, Properties.Resources.ImportIncorrectExcelLine, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmXLS = new XLSColumnSelector(Program.CurrentXLSStructure, XLSColumnSelector.BehaviourTypes.SheetSelect);
            if (frmXLS.ShowDialog() == DialogResult.OK)
            {
                Program.CurrentXLSStructure = frmXLS.CurrentXLSStructure;
                txtRef.Text = Program.CurrentXLSStructure.FileName;
                lblOnglet.Text = ((XLSStructure.WorkBook)frmXLS.cmbSheet.SelectedItem).ToString();

                dgv.AllowUserToAddRows = true;
                _ExcelColumnDDL.DataSource = Program.CurrentXLSStructure.CurrentWorkBook.Columns;
            }
        }

        class ColumnFieldLink
        {
            public string columnTitle { get; set; }
            public TabloidConfigColonne field { get; set; }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TabloidConfigColonne f in _currentView.Colonnes)
            {
                _linkList.Add(new ColumnFieldLink { field = f});
            }
        }

        private void btnAjoutExcelCol_Click(object sender, EventArgs e)
        {
            foreach (string c in Program.CurrentXLSStructure.CurrentWorkBook.Columns)
            {
                _linkList.Add(new ColumnFieldLink {columnTitle= c });
            }
        }

        private void WizardImport_Load(object sender, EventArgs e)
        {

        }
    }
}