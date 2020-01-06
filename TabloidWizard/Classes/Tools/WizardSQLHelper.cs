using System;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Objects;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Tabloid.Classes.Controls;
using Tabloid.Classes.Data;
using Tabloid.Classes.Tools;
using TabloidWizard.Properties;
using System.Text;

namespace TabloidWizard.Classes.Tools
{
    static class WizardSQLHelper
    {


        /// <summary>
        /// List existing table in combobox from sql request
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="connectionString"></param>
        /// <param name="selectTableName">Table Name to hide</param>
        /// <param name="allowNull"></param>
        public static void displayTable(ComboBox cmb, string connectionString, string selectTableName = null, bool allowNull = false)
        {
            cmb.Items.Clear();
            string lastError;
            var dc = DataTools.Data(SqlCommands.SqlGetTable(), connectionString, out lastError);
            if (allowNull) cmb.Items.Add("");
            foreach (DataRow dcr in dc.Rows)
            {
                cmb.Items.Add(dcr[0].ToString());
                if (dcr[0].ToString() == selectTableName) cmb.SelectedIndex = cmb.Items.Count - 1;
            }

            if (cmb.SelectedIndex == -1&& cmb.Items.Count>0) cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// Set Schema TO ALL View
        /// </summary>
        /// <param name="schema">schema Name</param>
        public static void SetAllViewSchema(string schema)
        {
            foreach (TabloidConfigView view in TabloidConfig.Config.Views)
            {
                view.Schema = schema;
            }
        }

        /// <summary>
        /// List existing table in combobox from sql request
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="connectionString"></param>
        /// <param name="selectTableName">Table Name to select</param>
        /// <param name="allowNull"></param>
        public static void displayTable(ListBox lst, string connectionString, string selectTableName = null, bool allowNull = false)
        {
            lst.Items.Clear();
            string lastError;
            var dc = DataTools.Data(SqlCommands.SqlGetTable(), connectionString, out lastError);
            if (allowNull) lst.Items.Add(" ");
            foreach (DataRow dcr in dc.Rows)
            {
                lst.Items.Add(dcr[0].ToString());
                if (dcr[0].ToString() == selectTableName) lst.SelectedIndex = lst.Items.Count - 1;
            }

            if (lst.SelectedIndex == -1) lst.SelectedIndex = 0;
        }

        /// <summary>
        /// add field list to combobox from sql request
        /// </summary>
        /// <param name="cmb">Combobox to populate</param>
        /// <param name="table">Table name</param>
        /// <param name="connectionString">connexction string</param>
        /// <param name="DbKeyName">if set field with DbKeyName is not shown</param>
        /// <param name="allowNull">Add selectable null item</param>
        /// <param name="hideTabloidField">if true Tabloid fields are hidden</param>
        public static void displayField(ComboBox cmb, string table, string connectionString, string schema = null, string DbKeyName = "", bool allowNull = false, bool hideTabloidField = true)
        {
            cmb.Items.Clear();
            string lastError;

            if (string.IsNullOrEmpty(schema)) schema = Program.AppSet.Schema;

            var dc = DataTools.Data(SqlCommands.SqlGetColums(table, schema), connectionString, out lastError);//0
            if (allowNull) cmb.Items.Add("");
            foreach (DataRow dcr in dc.Rows)
            {
                if (hideTabloidField || TabloidFields.IstabloidField(dcr[0].ToString()) == -1)
                {
                    cmb.Items.Add(dcr[0].ToString());
                    if (dcr[0].ToString() == DbKeyName) cmb.SelectedIndex = cmb.Items.Count - 1;
                }
            }

            if (cmb.Items.Count > 0) cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// add field list to combobox from sql request
        /// </summary>
        /// <param name="cmb">Combobox to populate</param>
        /// <param name="view">View object</param>
        /// <param name="connectionString">connexction string</param>
        /// <param name="selectKey">Display table dbKey in list if true</param>
        /// <param name="allowNull">Add selectable null item</param>
        /// <param name="hideTabloidField">if true Tabloid fields are hidden</param>
        public static void displayField(ComboBox cmb, TabloidConfigView view, string connectionString, bool selectKey = false, bool allowNull = false, bool hideTabloidField = true)
        {
            displayField(cmb, view.NomTable, connectionString, view.Schema, selectKey ? "" : view.DbKey, allowNull, hideTabloidField);
        }

        /// <summary>
        /// Define visibility using a list of checkbox
        /// </summary>
        /// <param name="clb"></param>
        /// <returns></returns>
        public static Visibilites GetVisibiliteFromCheckedListBox(CheckedListBox clb)
        {
            return clb.CheckedItems.Cast<Visibilites>().Aggregate(Visibilites.None, (current, v) => current | v);
        }

        /// <summary>
        /// add field to main table with constraint
        /// add join to main table collection collection
        /// add new table to table collection
        /// 
        /// return true if job done
        /// </summary>
        /// <param name="complexList"></param>
        /// <param name="schema"></param>
        /// <param name="newtableName"></param>
        /// <param name="sourceView"></param>
        /// <param name="tableSrcFieldRef"></param>
        /// <param name="connectionString"></param>
        /// <param name="provider"></param>
        /// <param name="alias">if not empty buil a new join with given alias</param>
        /// <param name="addFieldOnly">Add field and join but not new table</param>
        /// <param name="useJoin">if not null join is not created and given join is used</param>
        /// <param name="addFieldOnly">Add only join</param>
        /// <returns></returns>
        public static bool SetDataBaseForList(bool complexList, string schema, string newtableName, string newDbKey, string newViewName, bool addToParamMenu, TabloidConfigView sourceView, string tableSrcFieldRef, string connectionString, Provider provider, bool addNameField = true, bool addDistinct = false, string alias = null, bool addFieldOnly = false, string schemaNewtable = null, TabloidConfigJointure useJoin = null, bool addOnlyJoin = false)
        {
            try
            {
                var param = new[] { schema, newtableName.ToLower(), sourceView.Nom, tableSrcFieldRef };
                var complexParam = new[] { schema, newtableName.ToLower(), sourceView.Nom, sourceView.DbKey };
                string select = null;
                string aliasDbKey = null;

                if (!addOnlyJoin)
                    if (addFieldOnly)
                    {
                        // add field to table
                        var sqlType = dataHelper.DbTypeConverter.ConvertFromGenericDbType(DbType.Int16, WizardTools.Tools.ConvertProviderType(Program.AppSet.ProviderType));

                    //    var fieldOnlyParam = new[] {
                    //sourceView.NomTable,
                    //tableSrcFieldRef,
                    //sqlType,
                    //schema };
                        tableSrcFieldRef=addField(sourceView.NomTable, tableSrcFieldRef, sqlType, schema);
                        if (tableSrcFieldRef==null) return false;

                        //var fieldOnlyParam = new[] { schema, newtableName, sourceView.NomTable, tableSrcFieldRef, schemaNewtable ?? schema, newDbKey };//"id_"+ newtableName
                        //if (!ExecuteFromFile("addConstraint.sql", fieldOnlyParam, connectionString)) return false;//TO DO handel duplicate name

                        //add constraint do not stop on error
                        addConstraint(schema, newtableName, sourceView.NomTable, tableSrcFieldRef, schemaNewtable ?? schema, newDbKey); 

                        if (!string.IsNullOrEmpty(alias))
                        {
                            aliasDbKey = "id_" + alias;
                            select = $"{alias}.id_{newtableName} as id_{alias},{alias}.nom_{newtableName} as nom_{alias}";
                        }
                    }
                    else
                    if (!ExecuteFromFile(complexList ? "fieldComplexList.sql" : "fieldList.sql", complexList ? complexParam : param, connectionString))
                    { return false; }

                //add join
                var newJoin = useJoin;

                if (useJoin == null)
                {
                    var j = new TabloidConfigJointure
                    {
                        NomTable = newtableName,
                        DbKey = newDbKey,//"id_" + newtableName,
                        Relation = complexList ? "1:N" : "",
                        AliasTable = alias,
                        Select = select,
                        AliasDbKey = aliasDbKey,
                        ChampDeRef = complexList ? sourceView.Nom + "." + sourceView.DbKey : tableSrcFieldRef,
                        ChampDeRef2 = complexList ? sourceView.Nom + "_id" : "",
                        Order = complexList ? "" : "nom_" + newtableName + " asc"
                    };

                    Classes.WizardTools.Tools.AddWithUniqueName(sourceView.Jointures, j, "J");

                    newJoin = j;
                }

                if (!complexList)
                {//add combo list field
                    var c = new TabloidConfigColonne
                    {
                        Type = DbType.String,
                        Titre = newViewName,
                        Champ = "nom_" + (string.IsNullOrEmpty(alias) ? newtableName : alias),
                        Jointure = newJoin.Nom,
                        Editeur = TemplateType.ComboBoxPlus
                    };

                    WizardTools.Tools.AddWithUniqueName(sourceView.Colonnes, c, "C");
                }
                else
                {//add gridview field
                    AddGridviewField(sourceView, newtableName, newJoin, "nom_" + newtableName, true, addDistinct);
                }

                if (addFieldOnly) return true;

                //add new table
                var t = new TabloidConfigView
                {
                    Schema = schema,
                    Nom = newtableName,
                    Titre = newViewName,
                    DbKey = "id_" + newtableName
                };
                if (!complexList || true)
                {// add field name to the new created table
                    t.Order = "nom_" + newtableName + " asc";

                    var ct = new TabloidConfigColonne
                    {
                        Nom = "C" + t.Colonnes.Count,
                        Type = DbType.String,
                        Titre = "Nom",
                        Champ = "nom_" + newtableName
                    };

                    WizardTools.Tools.AddWithUniqueName(t.Colonnes, ct, "C");
                }
                TabloidConfig.Config.Views.Add(t);

                //add new table in menu
                try
                {

                    if (addToParamMenu) AddToParamMenu(t);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        /// <summary>
        /// Add field to database
        /// Verify if already exist and rename if needed
        /// 
        /// return null on error or new fieldname
        /// </summary>
        public static string addField(string tableName, string fieldName, string sqlType, string schema)
        {
            var cmpt =2;
            while (WizardTools.Tools.isFieldExist(fieldName, tableName, schema))
            {
                fieldName += "_" + cmpt++;
            }

            var fieldParam = new[] {
                    tableName,
                    fieldName,
                    sqlType,
                    schema };

            if (!ExecuteFromFile("addField.sql", fieldParam, Program.AppSet.ConnectionString)) return null;

            return fieldName;
        }

        /// <summary>
        /// Add constraint to database
        /// Verify if already exist and rename if needed
        /// 
        /// return false on error
        /// </summary>
        public static bool addConstraint(string schema, string newtableName, string tableName, string fieldName, string newTableSchema,string newDbKey)
        {
            var constraintName = fieldName + "_fk";

            constraintName=SearchConstraintUniqueName(constraintName, schema);

            var Param = new[] { schema, newtableName, tableName, fieldName, newTableSchema, newDbKey, constraintName };

            return ExecuteFromFile("addConstraint.sql", Param, Program.AppSet.ConnectionString);
        }

        /// <summary>
        /// search for a not used name 
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        static string SearchConstraintUniqueName(string baseName, string schema)
        {
            string error;
            var constraints = DataTools.Data(SqlCommands.SqlGetForeignKey(null, schema), Program.AppSet.ConnectionString, out error);

            var constraintsArray = Common.TableToStringArray(constraints, constraints.Columns[3].ColumnName, false);
            var name = baseName;
            var i = 0;

            while (Array.IndexOf(constraintsArray, name) > -1)
            {
                i++;
                name = baseName + i;
            }

            return name;
        }

        /// <summary>
        /// Add view/gridView field and distinct if required
        /// </summary>
        /// <param name="sourceView">tabloidConfigView containing the list field</param>
        /// <param name="FieldTitle">Title of created field</param>
        /// <param name="join">TabloidConfigJoin used for field</param>
        /// <param name="fieldName">datatable field name</param>
        /// <param name="gridView">true to create gridview false to create view</param>
        /// <param name="addDistinct">add distinct to source view</param>
        public static bool AddGridviewField(TabloidConfigView sourceView, string FieldTitle, TabloidConfigJointure join, string fieldName, bool gridView, bool addDistinct)
        {
            if (!string.IsNullOrEmpty(fieldName))
            {
                var c = new TabloidConfigColonne
                {
                    Type = DbType.String,
                    Titre = FieldTitle,
                    VisibleListe = false,
                    Champ = fieldName,
                    Jointure = join.Nom,
                    Editeur = gridView ? TemplateType.GridView : TemplateType.View
                };

                WizardTools.Tools.AddWithUniqueName(sourceView.Colonnes, c, "C");
            }

            if (addDistinct)
            {
                var newDistinct = sourceView.NomTable + "." + sourceView.DbKey;

                sourceView.Distinct = addIfNotExist(sourceView.Distinct, newDistinct);

                if (string.IsNullOrEmpty(sourceView.Order))
                {
                    sourceView.Order = sourceView.Distinct;
                }
                else
                {
                    var orderParts = sourceView.Order.Split(' ');//remove order asc/desc
                    //orderParts[0] += "," + sourceView.Distinct;
                    addIfNotExist(orderParts[0], newDistinct);
                    sourceView.Order = string.Join(" ", orderParts);//retrieve asc/desc
                }
            }

            sourceView.Detail = true;
            return true;
        }

        /// <summary>
        /// Return primary key column name for a given table
        /// </summary>
        /// <param name="tableName">NAme of table to analyse</param>
        /// <returns></returns>
        public static string GetPrimaryKeyName(string tableName)
        {
            //get primary key
            string lastError;
            var dc = DataTools.Data(SqlCommands.SqlGetColums(tableName), Program.AppSet.ConnectionString, out lastError);
            foreach (DataRow dcr in dc.Rows)
                if (dcr[3].ToString().StartsWith("PRI", StringComparison.InvariantCulture)) return dcr[0].ToString();

            return null;
        }

        /// <summary>
        /// Add param to a separate comma list if is not already present
        /// </summary>
        /// <param name="oldParam"></param>
        /// <param name="newParam"></param>
        /// <returns></returns>
        private static string addIfNotExist(string oldParam, string newParam)
        {
            string Param = oldParam;
            var sep = "";

            if (Array.IndexOf(oldParam.ToLower().Split(','), newParam.ToLower()) == -1)
            {
                sep = string.IsNullOrEmpty(oldParam) ? "" : ",";
                Param = oldParam + sep + newParam;
            }

            return Param;
        }

        /// <summary>
        /// execute sql script from given text file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="param"></param>
        /// <param name="connectionString"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool ExecuteFromFile(string fileName, string[] param, string connectionString)
        {
            var sql = BuildSQLFromFile(fileName, param);

            string lastError;
            var dc = DataTools.Data(sql, connectionString, out lastError);

            if (string.IsNullOrEmpty(lastError)) return true;

            MessageBox.Show(Resources.Base_Modification_error + lastError, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static bool ExecuteSQLString(string sql)
        {
            string lastError;
            var dc = DataTools.Data(sql, Program.AppSet.ConnectionString, out lastError);

            if (string.IsNullOrEmpty(lastError)) return true;

            MessageBox.Show(Resources.Base_Modification_error + lastError, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static string BuildSQLFromFile(string fileName, string[] param)
        {
            var provider = Program.AppSet.ProviderType;

            var fi = new StreamReader(provider == Provider.Postgres ? "sources\\sql\\postgres\\" + fileName : "sources\\sql\\mysql\\" + fileName);

            var sql = fi.ReadToEnd();

            fi.Close();

            if (param != null)
                sql = string.Format(sql, param);

            return sql;
        }

        /// <summary>
        /// Set TabloidConfigColonne visibility using checkboxlist element
        /// </summary>
        /// <param name="c"></param>
        /// <param name="clb"></param>
        public static void SetFieldVisibilityProperties(TabloidConfigColonne c, CheckedListBox clb)
        {
            var checkedItems = clb.CheckedItems;
            foreach (string p in Visibilities.Keys)
            {
                var propertyInfo = c.GetType().GetProperty(Visibilities[p]);
                if (propertyInfo != null) propertyInfo.SetValue(c, checkedItems.Contains(p), null);
            }
        }
        /// <summary>
        /// Create list of visibility to set a checkboxlist
        /// </summary>
        /// <param name="clb"></param>
        public static void SetVisibiliteCheckedBoxList(CheckedListBox clb)
        {
            foreach (Visibilites v in Enum.GetValues(typeof(Visibilites)))
            {
                if (v != Visibilites.None &&
                    v != Visibilites.Undefined) clb.Items.Add(v, true);
            }
        }

        /// <summary>
        /// Search join using constraint for a given table
        /// </summary>
        /// <param name="view">view of the table</param>
        /// <param name="connectionString"></param>
        /// <param name="lastError"></param>
        /// <param name="addToTable">if set to true search for field in table to set field join properties</param>
        /// <returns></returns>
        public static List<TabloidConfigJointure> SetJoinFromConstraint(TabloidConfigView view, string connectionString, ref string lastError, bool addToTable = true)
        {
            var result = new List<TabloidConfigJointure>();

            var dfk = DataTools.Data(SqlCommands.SqlGetForeignKey(view.NomTable, view.Schema), connectionString, out lastError);

            if (!string.IsNullOrEmpty(lastError))
                return null;

            for (var a = 0; a < dfk.Rows.Count; a++)
            {
                var j = new TabloidConfigJointure
                {
                    ChampDeRef = dfk.Rows[a][0].ToString(),
                    NomTable = dfk.Rows[a][1].ToString(),
                    TableSource = view.NomTable,
                    DbKey = dfk.Rows[a][2].ToString()
                };

                result.Add(j);

                if (addToTable)
                {
                    WizardTools.Tools.AddWithUniqueName(view.Jointures, j, "J");

                    foreach (var i in view.Colonnes.FindIndex(j.ChampDeRef))
                    {
                        view.Colonnes[i].Jointure = j.Nom;
                        view.Colonnes[i].Editeur = TemplateType.ComboBoxPlus;
                        view.Colonnes[i].Type = DbType.Int32;
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// Convert combox list to table list
        /// </summary>
        /// <param name="view"></param>
        /// <param name="field"></param>
        /// <param name="newTableName"></param>
        /// <returns></returns>
        public static bool ConvertSimpleList(TabloidConfigView view, TabloidConfigColonne field, string newTableName)
        {
            var join = view.Jointures.GetJointure(field.Jointure);


            //search for a unique constraint name
            var fk1Name = SearchConstraintUniqueName(view.NomTable + "_fk", view.Schema);
            var fk2Name = SearchConstraintUniqueName(join.NomTable + "_fk", view.Schema);



            var param = new[]
            {
                view.Schema,   //0 schema
                view.NomTable, //1 master table
                join.NomTable,  //2 actually joined table
                newTableName,  //3 new intermediate table
                view.DbKey,    //4 master table dbkey
                join.ChampDeRef,   //5 master table foreign key field
                join.DbKey,     //6 actually joined table primary key
                fk1Name,
                fk2Name
            };


            var result = ExecuteFromFile("fieldListTOfieldComplexList.sql", param, Program.AppSet.ConnectionString);
            if (!result) return false;


            SqlCommands.DropColumn(view.NomTable, join.ChampDeRef, view.Schema);

            var joinLst = new TabloidConfigJointure
            {
                Relation = "1:N",
                NomTable = newTableName,
                DbKey = "id_" + newTableName,
                ChampDeRef = view.NomTable + "." + view.DbKey,
                ChampDeRef2 = view.NomTable + "_id"
            };

            var join2 = new TabloidConfigJointure
            {
                NomTable = join.NomTable,
                DbKey = join.DbKey,
                ChampDeRef = join.NomTable + "_id",
                Order = join.Order
            };

            var joinLstRoleID = WizardTools.Tools.AddWithUniqueName(view.Jointures, joinLst, "J");
            WizardTools.Tools.AddWithUniqueName(view.Jointures, join2, "J", joinLst.Jointures);

            view.Detail = true;
            view.Jointures.Remove(join);
            field.Jointure = joinLstRoleID;
            field.Editeur = TemplateType.GridView;
            field.VisibleListe = false;

            var lstView = new TabloidConfigView
            {
                Nom = newTableName,
                Titre = newTableName,
                Schema = view.Schema,
                DbKey = "id_" + newTableName
            };

            var joinLstView = new TabloidConfigJointure
            {
                NomTable = view.NomTable,
                DbKey = view.DbKey,
                ChampDeRef = view.NomTable + "_id"
            };

            var joinLstView2 = new TabloidConfigJointure
            {
                NomTable = join.NomTable,
                DbKey = join.DbKey,
                ChampDeRef = join.NomTable + "_id"
            };

            var j1 = WizardTools.Tools.AddWithUniqueName(lstView.Jointures, joinLstView, "J");
            var j2 = WizardTools.Tools.AddWithUniqueName(lstView.Jointures, joinLstView2, "J");

            //var c1 = new TabloidConfigColonne
            //{
            //    Titre = view.NomTable,
            //    Type = DbType.Int16,
            //    Champ = view.DbKey,
            //    Editeur = TemplateType.ComboBoxPlus,
            //    Jointure = j1
            //};

            var c2 = new TabloidConfigColonne
            {
                Titre = field.Titre,
                Type = DbType.Int16,
                Champ = field.Champ,
                Valideurs = field.Valideurs,
                Obligatoire = field.Obligatoire,
                Information = field.Information,
                Editeur = TemplateType.ComboBoxPlus,
                Jointure = j2
            };

            //WizardTools.addWithUniqueName(lstView.Colonnes, c1, "C");
            WizardTools.Tools.AddWithUniqueName(lstView.Colonnes, c2, "C");

            TabloidConfig.Config.Views.Add(lstView);

            return true;
        }


        public static Dictionary<string, string> Visibilities = new Dictionary<string, string> {
            {Resources.List,"VisibleListe" },
            {Resources.Detail,"VisibleDetail" },
            {Resources.Mailing,"VisiblePublipostage" },
            {Resources.Graphic,"VisibleGraph" },
            {Resources.Export,"VisibleExport" },
        };

        public static TabloidConfigMenuItem getParamMenu()
        {
            var mn = TabloidConfigMenu.ConfigMenu.TopMenu.findFirstFromTitle(Resources.Parameters);
            if (mn == null)
                throw new Exception(Resources.Parameters_menu_not_found);

            return mn;
        }

        public static void AddToParamMenu(TabloidConfigView view)
        {
            var mn = getParamMenu();
            AddToMenu(view, null, TabloidConfigMenuItem.MenuType.Liste, mn);
        }
        public static void AddToParamMenu(TabloidConfigMenuItem newChild, bool silentMode = false)
        {
            var mn = getParamMenu();
            AddToMenu(newChild, mn, silentMode);
        }
        /// <summary>
        /// Add View to menu
        /// </summary>
        /// <param name="mn">menu to use as parent</param>
        public static void AddToMenu(TabloidConfigView view, string title = null, TabloidConfigMenuItem.MenuType mnType = TabloidConfigMenuItem.MenuType.Liste, TabloidConfigMenuItem mn = null)
        {
            var newChild = new TabloidConfigMenuItem
            {
                Titre = title ?? view.Titre,
                Type = mnType,
                Table = view.NomTable,
                Parent = mn
            };

            AddToMenu(newChild, mn);
        }
        /// <summary>
        /// Add Function to menu
        /// </summary>
        /// <param name="mn">menu to use as parent</param>
        public static void AddToMenu(TabloidConfigFunction function,TabloidConfigMenuItem mn = null)
        {
            var newChild = new TabloidConfigMenuItem
            {
                Titre = function.Titre,
                Type = TabloidConfigMenuItem.MenuType.Function,
                Function=function.Nom,
                Parent = mn
            };

            AddToMenu(newChild, mn);
        }
        /// <summary>
        /// Add item menu to menu
        /// </summary>
        /// <param name="mn">menu to use as parent</param>
        public static void AddToMenu(TabloidConfigMenuItem newChild, TabloidConfigMenuItem mn = null, bool silentMode = false)
        {
            if (mn == null)
                WizardTools.Tools.AddWithUniqueName(TabloidConfigMenu.ConfigMenu.TopMenu, newChild, "M", null, 0);
            else
                WizardTools.Tools.AddWithUniqueName(TabloidConfigMenu.ConfigMenu.TopMenu, newChild, "M", mn.SousMenu, 0);

            if (!silentMode) MessageBox.Show(Resources.Menu_creation_success);
        }

        public static void SetMobile(TabloidConfigView view)
        {
            if (!string.IsNullOrEmpty(Program.AppSet.smsBoxPassword) && !string.IsNullOrEmpty(Program.AppSet.smsBoxUser)) return;

            var w = new WizardSMS(view);

            w.ShowDialog();
        }

        /// <summary>
        /// Transform human readable title to Système name
        /// </summary>
        /// <param name="text"></param>
        public static string TitleToSystemName(string text)
        {
            text = text.Replace(' ', '_');
            text = text.Replace('°', '_');
            text = text.Replace('/', '_');
            text = text.Replace('\'', '_');
            text = text.Replace("(", string.Empty);
            text = text.Replace(")", string.Empty);
            text = text.Replace(">", string.Empty);
            text = text.Replace("<", string.Empty);
            text = text.Replace(".", string.Empty);
            return
    System.Web.HttpUtility.UrlDecode(
        System.Web.HttpUtility.UrlEncode(
            text.ToLower(), Encoding.GetEncoding("iso-8859-7")));
        }
    }
}

