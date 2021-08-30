using Graphql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes.Tools;


namespace TabloidWizard.Classes.Editor
{
    public class GenericPropertySelector : UITypeEditor
    {
        IWindowsFormsEditorService _service;
        ListBox _list;

        List<string> modalPropertiesList = new List<string> {
            "*.Champ","*.ChampLimite","*.Fin","*.Debut","TabloidConfigCalendrier.Titre","*.ChampX","*.ChampY","*.ChampCritere","*.ChampCritere2",
            "*.ChampAffichage","*.ChampValeur","*.ChampClef","*.ChampDeRef","*.ChampDeRef2","*.DbKey","TabloidConfigCalendrier.Couleur","TabloidConfigCalendrier.Tooltip","TabloidConfigCalendrier.ChampGroupe","*.JoinFieldName","*.JoinValueField",
            "*.ColName",
            "*.Select","*.Where","*.GroupBy","*.Distinct","*.WherePeuplement","*.Order","*.Rolels","*.VisibleRole","TabloidConfigEdition.Authorization","*.FieldName"};

        //Graphql.DSHelper.Champ
        List<string> dropDownPropertiesList = new List<string> { "*.Jointure", "*.Table", "*.TableSource", "*.NomTable", "*.TableName", "*.JoinTableName", "TabloidConfigColonne.DSID" };

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null)
            {
                if (dropDownPropertiesList.Contains($"*.{context.PropertyDescriptor.Name}") ||
                    dropDownPropertiesList.Contains($"{context.PropertyDescriptor.ComponentType.Name}.{context.PropertyDescriptor.Name}"))
                    return UITypeEditorEditStyle.DropDown;
                if (modalPropertiesList.Contains($"*.{context.PropertyDescriptor.Name}") ||
                    modalPropertiesList.Contains($"{context.PropertyDescriptor.ComponentType.Name}.{context.PropertyDescriptor.Name}"))
                    return UITypeEditorEditStyle.Modal;

            }

            return base.GetEditStyle(context);
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            switch (context.PropertyDescriptor.Name)
            {
                case "Champ":
                case "ChampLimite":
                case "Fin":
                case "Debut":
                case "Titre":
                case "ChampX":
                case "ChampY":
                case "ChampCritere":
                case "ChampCritere2":
                case "ChampAffichage":
                case "ChampClef":
                case "ChampValeur":
                case "ChampDeRef":
                case "ChampDeRef2":
                case "DbKey":
                case "Champ Limite":
                case "Couleur":
                case "Tooltip":
                case "ChampGroupe":
                case "FieldName":
                case "JoinFieldName":
                case "JoinValueField":
                    string table = null;
                    if (context.PropertyDescriptor.ComponentType.Name == "TabloidConfigEdition" &&//cliqued from edition
                        (context.PropertyDescriptor.Name == "ChampAffichage" ||
                        context.PropertyDescriptor.Name == "ChampCritere" ||
                        context.PropertyDescriptor.Name == "ChampCritere2" ||
                        context.PropertyDescriptor.Name == "ChampClef"))
                    {
                        var j = ((TabloidConfigEdition)context.Instance).Jointure;
                        if (!string.IsNullOrEmpty(j))
                        {
                            var join = CurrentContext.CurrentView.Jointures.GetJointure(j);
                            if (join != null) table = join.NomTable;
                        }
                    }
                    if (context.PropertyDescriptor.ComponentType.Name == "TabloidConfigJointure" &&//cliqued from join
                        (context.PropertyDescriptor.Name == "DbKey"))
                    {
                        var j = ((TabloidConfigJointure)context.Instance);

                        if (!string.IsNullOrEmpty(j.NomTable)) table = j.NomTable;
                    }

                    var frm = new TableFieldSelectorForm(CurrentContext.CurrentView, (string)value, table);
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                        value = frm.Value;
                    break;
                case "Jointure":
                    setJoinList(provider, CurrentContext.CurrentView.Jointures.GetJointures(VisibiliteTools.GetFullVisibilite(), false), value);
                    var v = _list.SelectedItem;
                    value = v == null ? "" :
                        v.ToString() == " " ? "" : ((TabloidConfigJointure)_list.SelectedItem).Nom;

                    if (context.PropertyDescriptor.ComponentType.Name == "TabloidConfigEdition")
                    {
                        var j = (TabloidConfigJointure)_list.SelectedItem;
                        var o = (TabloidConfigEdition)context.Instance;
                        o.ChampClef = setIfEmpty(o.ChampClef, j.DbKey);
                        o.ChampCritere = setIfEmpty(o.ChampCritere, j.DbKey);

                        var cs = CurrentContext.CurrentView.Colonnes.First(c => c.Jointure == j.Nom);
                        if (cs != null)
                            o.ChampAffichage = setIfEmpty(o.ChampAffichage,
                                ((Champ)cs).NomChamp);
                    }
                    break;
                case "Table":
                case "TableSource":
                case "NomTable":
                case "TableName":
                case "JoinTableName":
                    setTableList(provider, value);
                    value = _list.SelectedItem;
                    break;

                case "Select":
                case "Where":
                case "GroupBy":
                case "Distinct":
                case "WherePeuplement":
                case "Order":
                    var sqlEditor = new SqlEditor(value == null ? "" : value.ToString());
                    sqlEditor.ShowDialog();

                    if (sqlEditor.DialogResult == DialogResult.OK)
                        value = sqlEditor.txtSql.Text;
                    break;
                case "Rolels":
                case "VisibleRole":
                case "Authorization":
                    string title = "?";
                    WizardRoles wz = null;

                    if (context.PropertyDescriptor.Name == "Authorization")
                    {
                        title = Properties.Resources.Edition + ((TabloidConfigEdition)context.Instance).ToString();

                        wz = new WizardRoles(title, Properties.Resources.DisplayOnly);
                    }
                    else
                    {
                        title = Properties.Resources.TheField + ((TabloidConfigColonne)context.Instance).ToString();

                        wz = context.PropertyDescriptor.Name == "VisibleRole" ?
                            new WizardRoles(title, Properties.Resources.Hidden) :
                            new WizardRoles(title, Properties.Resources.WithReadOnly);
                    }

                    if (wz.ShowDialog() == DialogResult.OK)
                        value = wz.txtResult.Text;
                    break;
                case "ColName":
                    var frmXLS = new XLSColumnSelector(Program.CurrentXLSStructure, XLSColumnSelector.BehaviourTypes.ColumnSelect);
                    if (frmXLS.ShowDialog() == DialogResult.OK)
                    {
                        Program.CurrentXLSStructure = frmXLS.CurrentXLSStructure;
                        value = frmXLS.cmbField.SelectedItem;
                    }
                    break;
                case "DSID":
                    setDMFieldList(provider, value);
                    break;
            }

            return base.EditValue(context, provider, value);
        }

        private async void getDSField()
        {
            var dem = new DSHelper();
            
            GraphQL.GraphQLResponse<DSHelper.DemarcheResponse> response = await dem.getDescriptor(Program.AppSet.DSURL, Program.AppSet.DSKey, "19");//CurrentContext.CurrentView.DSNum
            if (response.Errors == null)
                graphqlCache = response.Data.demarche.champDescriptors;
        }

        private List<DSHelper.ChampDescriptor> graphqlCache { get; set; }

        private string setIfEmpty(string prop, string value)
        {
            return string.IsNullOrEmpty(prop) ? value : prop;
        }

        public void setJoinList(IServiceProvider provider, List<TabloidConfigJointure> joinCollection, object value)
        {
            if (provider != null)
            {
                // This service is in charge of popping our ListBox.
                _service = ((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)));
                _list = new ListBox();

                if (_service != null && value is string)
                {

                    _list.Click += ListBox_Click;

                    _list.Items.Add(" ");

                    foreach (TabloidConfigJointure j in joinCollection)
                    {
                        var i = _list.Items.Add(j);
                        if (j.Nom == value.ToString()) _list.SelectedIndex = i;
                    }

                    _service.DropDownControl(_list);


                }
            }
        }

        public void setDMFieldList(IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                if (!string.IsNullOrEmpty(CurrentContext.CurrentView.DSNum))
                    if (graphqlCache == null)
                    {
                        getDSField();
                    }
                // This service is in charge of popping our ListBox.
                _service = ((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)));
                _list = new ListBox();

                if (_service != null)
                {
                    _list.Click += ListBox_Click;
                    _list.DataSource = graphqlCache;

                    _service.DropDownControl(_list);
                }
            }
        }

        public void setTableList(IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                // This service is in charge of popping our ListBox.
                _service = ((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)));
                _list = new ListBox();

                if (_service != null)
                {
                    _list.Click += ListBox_Click;
                    WizardSQLHelper.displayTable(_list, Program.AppSet.ConnectionString, (string)value, true);

                    _service.DropDownControl(_list);
                }
            }
        }

        private void ListBox_Click(object sender, EventArgs e)
        {
            if (_service != null)
                _service.CloseDropDown();
        }
    }
}
