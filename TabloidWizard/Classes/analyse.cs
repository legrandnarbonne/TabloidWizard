using dataHelper;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Config.Helper;
using Tabloid.Classes.Data;
using System;
using TabloidWizard.Classes.Control;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes
{
    static class WizardEvents
    {
        /// <summary>
        /// Analyse current config
        /// 
        /// Detect roles/utilisateur/perso définition
        /// Detect old role implementation
        /// </summary>
        public static void OnDeserialize()
        {

        }


        public static void onConfigLoaded(string schema)
        {
            //for mysql verify if default schema is database name
            if (Program.AppSet.ProviderType == Provider.MySql && Program.AppSet.Schema != getDataBaseNameFromConnectionString(Program.AppSet.ConnectionString))
            {
                if (MessageBox.Show(Properties.Resources.MySQLDifferentBaseName, Properties.Resources.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var connectionDataBaseName = getDataBaseNameFromConnectionString(Program.AppSet.ConnectionString);
                    WizardSQLHelper.SetAllViewSchema(connectionDataBaseName);
                    Program.AppSet.Schema = connectionDataBaseName;
                }
            }

            //verify role columun existance
            var tableColumns = new Dictionary<string, Dictionary<string, FieldDescriptionType>>{
                {"roles",new Dictionary<string,FieldDescriptionType> {
                    {"droits_limiteecr", new FieldDescriptionType {type=DbType.Int64,extra="(20) DEFAULT 0"} },//"numeric(20,0) DEFAULT 0"
                    {"droits_limite", new FieldDescriptionType {type=DbType.Int64,extra="(20) DEFAULT 1"} } } },
                {"utilisateurs",new Dictionary<string,FieldDescriptionType> {
                    {"theme", new FieldDescriptionType {type=DbType.String,extra="(100)"}},
                    {"lastchatid", new FieldDescriptionType {type=DbType.Int64,extra="(11) DEFAULT 0"}},
                    {"password",new FieldDescriptionType {type=DbType.String,extra="(100)"}},
                    {"token",new FieldDescriptionType {type=DbType.String,extra="(40)"}},
                    {"ref",new FieldDescriptionType {type=DbType.Boolean}}
                } }
            };

            foreach (var t in tableColumns)
            {
                string lastError;

                DataTable tableColumnsList = null;

                if (Program.AppSet.ProviderType == Provider.Postgres)
                {
                    foreach (var cschema in WizardTools.Tools.GetSearchPath(Program.AppSet.ConnectionString))
                    {
                        tableColumnsList = DataTools.Data(SqlCommands.SqlGetColums(t.Key, cschema), Program.AppSet.ConnectionString, out lastError);//c0
                        if (!string.IsNullOrEmpty(lastError)) throw new Exception(lastError);
                        if (tableColumnsList.Rows.Count > 0) break;
                    }
                }
                else
                {
                    tableColumnsList = DataTools.Data(SqlCommands.SqlGetColums(t.Key, null), Program.AppSet.ConnectionString, out lastError);//c0
                    if (!string.IsNullOrEmpty(lastError)) throw new Exception(lastError);
                }

                var fieldColumnName = tableColumnsList.Columns[0].ColumnName;

                foreach (var c in t.Value)
                {
                    if (tableColumnsList.Select(fieldColumnName + "='" + c.Key + "'").Length == 0)//field doesn't exist
                    {
                        var param = new[] { t.Key, c.Key, c.Value.ToString(), Program.AppSet.Schema };

                        var result = WizardSQLHelper.ExecuteFromFile("addField.sql", param, Program.AppSet.ConnectionString);
                    }
                }

            }
            //Detect old role implementation
            if (!WizardTools.Tools.isTableExist("lst_roles"))
            {
                var result = MessageBox.Show(Properties.Resources.WrongConfigVersion, Properties.Resources.Information, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    AutomaticViewBuilder.setOldUtilisateurs(schema);//.SetTable(schema);

                    var view = TabloidConfig.Config.Views["utilisateurs"];//Todo role field could not be c4 on manual déclaration

                    WizardSQLHelper.ConvertSimpleList(view, view.Colonnes["c4"], "lst_roles");

                    removeView("utilisateurs");
                    removeView("roles");
                    removeView("lst_roles");
                    removeView("perso");
                }
            }

            //Detect roles/utilisateur/perso définition
            if (!TabloidConfig.Config.Views["roles"].AutomaticCreation ||
                !TabloidConfig.Config.Views["utilisateurs"].AutomaticCreation ||
                !TabloidConfig.Config.Views["perso"].AutomaticCreation)
            {
                var dr = MessageBox.Show(Properties.Resources.CustumRoleUsed,
                     Properties.Resources.Information, MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dr == DialogResult.Yes)
                {
                    removeView("roles");
                    removeView("utilisateurs");
                    removeView("perso");
                }
            }
            //Detect empty salt grain
            if (string.IsNullOrEmpty(Program.AppSet.grainDeSable))
            {
                Program.AppSet.grainDeSable = GetUniqueKey(7);
            }
        }

        /// <summary>
        /// Find value of database property in connection string
        /// </summary>
        /// <param name="connectionString">string to search into</param>
        /// <returns></returns>
        private static string getDataBaseNameFromConnectionString(string connectionString)
        {
            var property = "database=";

            foreach (string p in connectionString.Split(';'))
            {
                if (p.StartsWith(property,StringComparison.InvariantCultureIgnoreCase))
                {
                    var part = p.Split('=');
                    return part.Length==2?part[1]:"";
                }
            }

            return "";

        }

        /// <summary>
        /// Return a random string thanks to https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        /// </summary>
        /// <param name="size">Size of the result string</param>
        /// <returns></returns>
        public static string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private static void removeView(string viewName)
        {
            if (TabloidConfig.Config.Views.Contains(viewName))
            {
                TabloidConfig.Config.Views.Remove(TabloidConfig.Config.Views[viewName]);
            }
        }

        class FieldDescriptionType
        {
            public DbType type { get; set; }

            public string extra { get; set; }

            public override string ToString()
            {
                return DbTypeConverter.ConvertFromGenericDbType(type, Program.AppSet.ProviderType.ToString()) + extra;
            }
        }

        /// <summary>
        /// Fire after field added to view
        /// </summary>
        /// <param name="v"></param>
        internal static void afterFieldAdded(TabloidConfigView v)
        {
            afterViewModified(CurrentContext.CurrentView);
        }

        internal static void afterViewModified(TabloidConfigView v)
        {
            if (v.AutomaticCreation)
                v.AutomaticCreation = false;
        }

        internal static void afterViewPropertyChange(object s, PropertyValueChangedEventArgs e)
        {
            switch (e.ChangedItem.PropertyDescriptor.Name)
            {
                case "Corbeille":
                    if (!(bool)e.ChangedItem.Value)//disable trash requested
                    {
                        var result = MessageBox.Show(Properties.Resources.EmptyTrash, Properties.Resources.Information, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            DataTools.Command(
                                $"Delete from {CurrentContext.CurrentView.Schema}.{CurrentContext.CurrentView.NomTable} where deleted_{CurrentContext.CurrentView.NomTable}=1",
                                null,
                                Program.AppSet.ConnectionString);
                        }
                    }
                    break;
            }

            afterViewModified(CurrentContext.CurrentView);
        }

        internal static void afterFieldPropertyChange(object s, PropertyValueChangedEventArgs e)
        {
            if (e != null)
            {
                switch (e.ChangedItem.PropertyDescriptor.Name)
                {
                    case "VisiblePublipostage":
                        if ((bool)e.ChangedItem.Value)//set to visible in pub
                        {
                            var viewer = (GenericPropertiesViewer<TabloidConfigColonneCollection, TabloidConfigColonne>)s;
                            var c = viewer.SelectedObject;
                            if (!string.IsNullOrEmpty(c.Jointure))
                            {
                                var join = CurrentContext.CurrentView.Jointures.GetJointure(c.Jointure);

                                if (!join.VisiblePublipostage)
                                {
                                    var result = MessageBox.Show(Properties.Resources.alignJoinVisibility, Properties.Resources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                        setPublipostageVisibility(join);
                                }
                            }
                        }
                        break;
                }
            }
            afterViewModified(CurrentContext.CurrentView);
        }

        internal static void setPublipostageVisibility(TabloidConfigJointure j)
        {
            j.VisiblePublipostage = true;

            foreach (TabloidConfigJointure sj in j.Jointures)
            {
                sj.VisiblePublipostage = true;
                if (sj.Jointures.Count > 0)
                    setPublipostageVisibility(sj);
            }
        }

    }
}
