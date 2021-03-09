using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tabloid.Classes;
using Tabloid.Classes.Config;
using Tabloid.Classes.Controls;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;
using TabloidWizard.Properties;

namespace TabloidWizard
{
    public partial class WizardField : MetroForm
    {
        private TabloidConfigColonne Tc;
        private TabloidConfigColonne _parentField;
        private IViewFct _iviewFct;
        private string _connectionString;
        private Provider _provider;
        private bool _useDatabaseField = true;

        //flag set to true if join have been created
        public bool JoinListUpdated { get; internal set; }

        //--Editeur-->Champ
        public WizardField(IViewFct view, TabloidConfigColonne parentField, string connectionString, Provider provider)
        {
            _iviewFct = view;
            _parentField = parentField;
            _provider = provider;
            _connectionString = connectionString;

            InitializeComponent();

            Champ.CloseFromNext += validateFieldCreation;
            Champ.CloseFromNext += validateFieldEditorCompliance;
            Champ.CloseFromBack += validateFieldCreation;
            Champ.ShowFromBack += ChampShowCreation;

            Button.ShowFromBack += Button_ShowFromBack;
            Button.ShowFromNext += Button_ShowFromNext;

            Editeur.ShowFromNext += Editeur_ShowFromNext;
            Editeur.CloseFromNext += Editeur_CloseFromNext;
            Editeur.ShowFromBack += Editeur_ShowFromBack;

            Graphique.ShowFromNext += Graphique_ShowFromNext;
            Graphique.ShowFromBack += Graphique_ShowFromBack;

            visibilite.ShowFromBack += Visbile_ShowFromBack;
            visibilite.CloseFromBack += Visbile_CloseFromBack;
            visibilite.Enter += updateVisibilityList;

            if (_iviewFct is TabloidConfigView)
            { cmbGraph.DataSource = ((TabloidConfigView)view).Graphiques; }


            fs.ConnectionString = _connectionString;
            fs.cmdSchema.DataSource = AppSetting.GetSchemaList(_provider);//.Items.Add("finance_subv");
            fs.Enabled = false;
        }

        private void ChampShowCreation(object sender, EventArgs e)
        {
            if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.Graphique)
                wizard1.BackTo(Editeur);
        }

        private void Editeur_ShowFromBack(object sender, EventArgs e)
        {
            if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.Graphique)
                wizard1.BackTo(Editeur);
        }

        private void Graphique_ShowFromBack(object sender, EventArgs e)
        {
            if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type != TemplateType.Graphique)
                wizard1.BackTo(Champ);
        }


        private void Graphique_ShowFromNext(object sender, EventArgs e)
        {
            if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type != TemplateType.Graphique)
                wizard1.NextTo(visibilite);
        }

        private void validateFieldEditorCompliance(object sender, PageEventArgs e)
        {
            if (wzCmbEditeur.SelectedItem != null)
                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.AutoCompleteTextBox && radioCrea.Checked)
                {
                    MetroMessageBox.Show(this, Resources.AutocompleteNeedExistingFieldUse, Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
        }


        //verify if name and type are filled

        //Jump over editeur
        private void Visbile_ShowFromBack(object sender, EventArgs e)
        {
            if (radbutton.Checked) wizard1.BackTo(type);
        }

        private void Visbile_CloseFromBack(object sender, PageEventArgs e)
        {
            if (!_useDatabaseField)
            {
                e.Cancel = true;
                wizard1.BackTo(Editeur);
            }
        }

        private void Editeur_ShowFromNext(object sender, EventArgs e)
        {
            if (radbutton.Checked) wizard1.NextTo(Button);

        }
        //Jump over button
        private void Button_ShowFromNext(object sender, EventArgs e)
        {
            if (radField.Checked) wizard1.NextTo(Fin);
        }

        private void Button_ShowFromBack(object sender, EventArgs e)
        {
            if (radField.Checked) wizard1.BackTo(visibilite);
        }

        private void updateVisibilityList(object sender, EventArgs e)
        {
            lstVisibilites.Items.Clear();

            foreach (var s in WizardSQLHelper.Visibilities.Keys)
            {
                bool display = radField.Checked || s == "Détail" || s == "Liste";
                if (display)
                {
                    var i = lstVisibilites.Items.Add(s);
                    lstVisibilites.SetItemChecked(i, true);
                }
            }
        }

        void Button_end(object sender, PageEventArgs e)
        {
            e.Cancel = addField();
        }


        void radioExist_CheckedChanged(object sender, EventArgs e)
        {
            txtNomCrea.Enabled = lstTypeCrea.Enabled = txtLong.Enabled = txtDec.Enabled = radioCrea.Checked;
            //fs.lstChamp.Enabled = fs.cmbTable.Enabled = 
            fs.Enabled = radioExist.Checked;
            validateFieldCreation(null, null);
        }

        private void validateFieldCreation(object sender, EventArgs e)
        {
            var fixedSizeType = new string[] { "Date", "DateTime", "Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64", "Boolean" };

            txtLong.Enabled = txtDec.Enabled = true;

            //Date and Datetime no length and decimal
            if (fixedSizeType.Contains(lstTypeCrea.SelectedItem.ToString()))
            {
                txtLong.Text = txtDec.Text = "";
                txtLong.Enabled = txtDec.Enabled = false;
            }

            //disable Next on field page if field name is empty
            if (radioCrea.Checked & wizard1.Page == Champ && _iviewFct is TabloidConfigView)
            {
                var view = (TabloidConfigView)_iviewFct;
                wizard1.NextEnabled = txtNomCrea.Text != "" && lstTypeCrea.SelectedItem != null;

                if (txtNomCrea.Text != "" && wizard1.Page == Champ)//page champ verify if field exist
                {
                    if (Tools.isFieldExist(txtNomCrea.Text, view.NomTable, view.Schema))
                    {
                        MetroMessageBox.Show(this, Resources.FieldAlreadyExist, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        wizard1.NextEnabled = false;
                    }
                }
            }
            else
            {
                wizard1.NextEnabled = true;
            }

            if (lstTypeCrea.SelectedItem.ToString() == "Decimal")
            {
                txtLong.Text = "10";
                txtDec.Text = "2";
            }
        }


        // Editeur page validation
        private void Editeur_CloseFromNext(object sender, PageEventArgs e)
        {
            if (string.IsNullOrEmpty(WzTxtTitre.Text))
            {
                MetroMessageBox.Show(this, Resources.SetFieldTitle, Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (_iviewFct is TabloidConfigView)
            {
                var view = (TabloidConfigView)_iviewFct;
                // grid control selected
                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).isArrayObjectSelector)
                {
                    e.Cancel = true;
                    var wz = new WizardComplexList(view, WzTxtTitre.Text, ((TabloidBaseControl)wzCmbEditeur.SelectedItem).type);
                    if (wz.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }

                // combo control selected
                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).isSingleObjectSelector)
                {
                    e.Cancel = true;
                    var wz = new WizardList(view, WzTxtTitre.Text);
                    if (wz.ShowDialog() == DialogResult.OK)
                    {
                        JoinListUpdated = wz.JoinListUpdated;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                //Label ask to know if database field is needed
                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.Label)
                {
                    var dlg = MetroMessageBox.Show(this, Resources.CreateOrUseField, Resources.Information, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    switch (dlg)
                    {
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        case DialogResult.Yes:
                            _useDatabaseField = true;
                            break;
                        case DialogResult.No:
                            e.Cancel = true;
                            _useDatabaseField = false;
                            wizard1.NextTo(visibilite);
                            break;
                    }
                }

                //Label ask to know if database field is needed
                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.Constant)
                {

                    e.Cancel = true;
                    _useDatabaseField = false;
                    wizard1.NextTo(visibilite);
                }


                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.Picture)
                {
                    e.Cancel = false;
                    radioExist.Checked = true;
                    fs.lstChamp.SelectedItem = fs.lstChamp.FindStringExact(view.DbKey);
                }

                if (((TabloidBaseControl)wzCmbEditeur.SelectedItem).type == TemplateType.Graphique)
                {
                    e.Cancel = true;
                    wizard1.NextTo(Graphique);
                }
            }
        }

        private void WzTxtTitre_TextChanged(object sender, EventArgs e)
        {
            txtNomCrea.Text = WizardSQLHelper.TitleToSystemName(WzTxtTitre.Text);
        }

        private void wzCmbEditeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            var editeurType = (TabloidBaseControl)wzCmbEditeur.SelectedItem;
            lstTypeCrea.SelectedIndex = lstTypeCrea.FindStringExact(editeurType.DefaultFieldType.ToString());
            txtLong.Text = editeurType.DefaultFieldLength.ToString();
            txtDec.Text = editeurType.DefaultFieldDecimal.ToString();

            txtDescription.Text = editeurType.Description;
        }


        private void Wizard_Load(object sender, EventArgs e)
        {
            string lastError;

            try
            {
                if (_iviewFct is TabloidConfigView)
                {
                    var view = (TabloidConfigView)_iviewFct;
                    //populate table list
                    var poss = fs.cmdSchema.FindStringExact(view.Schema);
                    fs.cmdSchema.SelectedIndex = poss;


                    var pos = fs.cmbTable.FindStringExact(view.NomTable);
                    if (pos > -1) fs.cmbTable.SelectedIndex = pos;
                    else
                    {
                        MetroMessageBox.Show(this, string.Format(Resources.tableNotExist, view.NomTable), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }

                //populate field type
                foreach (var t in Enum.GetNames(typeof(DbType)))
                {
                    lstTypeCrea.Items.Add(t);
                }
                lstTypeCrea.SelectedItem = "String";


                //populate editor list
                var lst = TabloidControl.TabloidControlList
                    .Where(p => !p.Value.isButton && p.Value.isUserAviable)
                    .Select(v => v.Value)
                    .OrderBy(v => v.ToString())
                    .ToList();

                wzCmbEditeur.DataSource = lst;
                wzCmbEditeur.DisplayMember = "type";

                wzCmbEditeur.SelectedIndex = wzCmbEditeur.FindStringExact("Defaut");
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Resources.Erreur, ex.ToString());
            }
        }

        /// <summary>
        /// Build required task on wizard end
        /// </summary>
        /// <returns></returns>
        bool addField()
        {
            var useJoinName = "";

            if (_iviewFct is TabloidConfigView&&!radbutton.Checked)
            {
                var view = (TabloidConfigView)_iviewFct;

                if (_useDatabaseField //handel label with no database field
                    && ((TabloidBaseControl)wzCmbEditeur.SelectedItem).type != TemplateType.Graphique)//no database field for graphic
                    if (radioCrea.Checked)//field must be created in database
                    {
                        var t = (DbType)Enum.Parse(typeof(DbType), lstTypeCrea.SelectedItem.ToString());
                        var sqlType = dataHelper.DbTypeConverter.ConvertFromGenericDbType(t, Tools.ConvertProviderType(_provider));

                        var fieldArg = txtLong.Text;
                        if (txtDec.Text != "") fieldArg = fieldArg + "," + txtDec.Text;
                        if (fieldArg != "") fieldArg = "(" + fieldArg + ")";

                        var param = new string[] { view.NomTable, txtNomCrea.Text, sqlType + fieldArg, view.Schema };

                        if (!WizardSQLHelper.ExecuteFromFile("addField.sql", param, _connectionString, this)) return true;

                    }
                    else//use existing field
                    {
                        if (fs.cmbTable.SelectedValue.ToString() != view.NomTable &&
                            ((TabloidBaseControl)wzCmbEditeur.SelectedItem).type != TemplateType.Graphique)//verify if field is in current table
                        {
                            var useJoin = view.Jointures.GetJoinFromTableName(fs.cmbTable.SelectedValue.ToString());
                            if (useJoin == null)//verify if table is in joined table list
                            {
                                if (MetroMessageBox.Show(this, Resources.add_join, Resources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    var w = new WizardJoin(
                                        view,
                                        null,
                                        Program.AppSet.ConnectionString);

                                    w.ShowDialog();

                                    useJoin = view.Jointures.GetJoinFromTableName(fs.cmbTable.SelectedValue.ToString());
                                    if (useJoin != null) useJoinName = useJoin.Nom;
                                }
                            }
                            else
                                useJoinName = useJoin.Nom;

                        }
                    }
            }

            if (radbutton.Checked)//add button
                Tc = new TabloidConfigColonne
                {
                    Champ = fs.lstChamp.Text,
                    Titre = WzTxtTitre.Text,
                    Editeur = TemplateType.Btn,
                    Type = DbType.String,
                    EditeurParam2 = txtIcoBtn.Text,
                    EditeurParam3 = txtUrlBtn.Text,
                    EditeurParam4 = txtToolTipBtn.Text,
                    VisibleDetail=true,
                    Parent = _parentField,
                    Nom = "btn"
                };
            else//add other type field
            {
                Tc = new TabloidConfigColonne
                {
                    Champ = radioCrea.Checked ? txtNomCrea.Text : fs.lstChamp.Text,
                    Titre = WzTxtTitre.Text,
                    Editeur = ((TabloidBaseControl)wzCmbEditeur.SelectedItem).type,
                    Type = radioCrea.Checked ?
                        (DbType)Enum.Parse(typeof(DbType), lstTypeCrea.SelectedItem.ToString()) :
                        DbType.String,
                    EditeurParam1 = txtUrlBtn.Text,
                    Parent = _parentField,
                    Jointure = useJoinName,
                    Nom = "C"
                };

                if (Tc.Editeur == TemplateType.Picture)
                {
                    Tc.EditeurParam1 = "144x200";
                    Tc.EditeurParam2 = "/Tabloid/images/inconnu.png";
                    Tc.EditeurParam3 = "jpg";
                    Tc.EditeurParam4 = "4";
                }

                if (Tc.Editeur == TemplateType.Graphique)
                {
                    Tc.EditeurParam1 = ((TabloidConfigGraph)cmbGraph.SelectedItem).Nom;
                }

                if (_iviewFct is TabloidConfigView)
                {
                    var view = (TabloidConfigView)_iviewFct;

                    if (Tc.Editeur == TemplateType.Mobile)
                    {
                        view.Recherche.ChampMobile = radioCrea.Checked ? txtNomCrea.Text : fs.lstChamp.Text;
                        WizardSQLHelper.SetMobile(view);
                    }
                    if (Tc.Editeur == TemplateType.Mail)
                        view.Recherche.ChampMail = radioCrea.Checked ? txtNomCrea.Text : fs.lstChamp.Text;
                }
            }

            WizardSQLHelper.SetFieldVisibilityProperties(Tc, lstVisibilites);

            var parent = _iviewFct.Colonnes;

            if (_parentField != null) parent = _parentField.Colonnes;

            Tools.AddWithUniqueName(_iviewFct.Colonnes, Tc, "C", parent);

            return false;
        }

    }
}