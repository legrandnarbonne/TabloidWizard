using System;
using System.Collections.Generic;
using System.Linq;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes
{
    internal static class TabloidTables
    {
        public static readonly Table[] TabloidTablesArray =
        {
            new Table("roles", "roles.sql", true, true),
            new Table("utilisateurs", "utilisateurs.sql", true, true),
            new Table("lstroles", "lstroles.sql", true, true),
            new Table("textes", "textes.sql"),
            new Table("tracesenvois", "tracesenvois.sql", true),
            new Table("cart", "cart.sql", true, true),
            new Table("tabchat", "tabchat.sql", true, true)
        };

        /// <summary>
        ///     Verify in the tabloid table list
        /// </summary>
        /// <param name="tableName">table name to verify</param>
        /// <param name="state">state array to define</param>
        /// <returns>-1 if not or the indes in the array</returns>
        public static int IsTabloidTable(string tableName, ref ArrayVerify state)
        {
            var i = TabloidTablesArray.FindIndex(x => x.Name == tableName.ToLower());

            if (state != null)
                state.SetState(i);

            return i;
        }

        /// <summary>
        ///     Create table in base from a list
        /// </summary>
        /// <param name="tl"></param>
        /// <param name="connectionString"></param>
        public static bool CreateTable(IEnumerable<Table> tl, string connectionString)
        {
            foreach (var t in tl)
            {
                if (string.Equals(t.Name, "utilisateurs", StringComparison.InvariantCultureIgnoreCase))
                {
                    var utilFrm = new UtilEditor();
                    utilFrm.btnCancel.Enabled = false;
                    if (utilFrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)//for user table need to ask for user 0
                    {
                        Program.AppSet.grainDeSable = Classes.WizardEvents.GetUniqueKey(7);
                        var param = new string[] { utilFrm.txtLogin.Text, utilFrm.txtNom.Text, utilFrm.txtPrenom.Text, utilFrm.txtMail.Text, Tabloid.Classes.Tools.SecurityHelper.EncryptPassword(utilFrm.txtMdp1.Text) };
                        WizardSQLHelper.ExecuteFromFile(t.SqlFile, param, connectionString);

                        Program.AppSet.ModeAuthentification = utilFrm.cmbAuth.SelectedIndex == 0 ? AuthenticationHandler.AuthenticationType.Formulaire : AuthenticationHandler.AuthenticationType.Windows;
                    }
                    else
                        return false;
                }
                else
                    SqlCommands.SqlFromFile(t.SqlFile, connectionString, false);
                
            }
            return true;
        }
    }

    internal static class TabloidFields
    {
        private static readonly List<Field> fullTabloidFieldsArray = new List<Field>
        {
            new Field("datemaj", "datetime", "timestamp", null, true),
            new Field("auteur", "integer", "integer", null, true),
            new Field("deleted", "tinyint", "smallint", "0", true),
            new Field("verrou", "tinyint", "int2", null, true),
            new Field("dateverrou", "datetime", "timestamp", null, true)
        };

        private static Field[] currentTabloidFieldArray;

        public static Field[] TabloidFieldsArray
        {
            get
            {
                if (currentTabloidFieldArray == null)
                {
                    currentTabloidFieldArray = new Field[TabloidConfig.Config.TabloidConfigApp.UseLockDatabaseField ? 5 : 3];
                    fullTabloidFieldsArray.CopyTo(0, currentTabloidFieldArray, 0, TabloidConfig.Config.TabloidConfigApp.UseLockDatabaseField ? 5 : 3);
                }
                return currentTabloidFieldArray;
            }

            set
            {
                currentTabloidFieldArray = value;
            }
        }

        public static int IstabloidField(string fieldName, ref ArrayVerify state)
        {
            var part = fieldName.Split('_');
            var i = TabloidFieldsArray.FindIndex(x => x.Name == part[0].ToLower());

            if (state != null)
                state.SetState(i);

            return i;
        }

        public static int IstabloidField(string fieldName)
        {
            var part = fieldName.Split('_');
            var i = TabloidFieldsArray.FindIndex(x => x.Name == part[0].ToLower());

            return i;
        }

        /// <summary>
        ///     Create field in base from a list
        /// </summary>
        /// <param name="fl"></param>
        /// <param name="table"></param>
        /// <param name="schema"></param>
        /// <param name="connectionString"></param>
        public static void CreateField(IEnumerable<Field> fl, string table, string schema, string connectionString)
        {
            foreach (var f in fl)
            {
                Log.Write(string.Format("Ajout de la colone {0} à la table {1}", f.Name, table));
                string lastError;
                DataTools.Command(SqlCommands.SqlSetColumn(table, schema, f),null, connectionString, out lastError);
                if (!string.IsNullOrEmpty(lastError))
                    Log.Write("Erreur:" + lastError);
            }
        }
    }

    public class ArrayVerify
    {
        private int _state;

        /// <summary>
        ///     Return true if all object have been found
        /// </summary>
        /// <param name="arrayLength">Number total of member</param>
        /// <returns>true if all object have been found</returns>
        public bool IsThereAll(int arrayLength)
        {
            var b = (1 << arrayLength) - 1;
            return _state == b;
        }

        /// <summary>
        ///     List of index wich haven't been found
        /// </summary>
        /// <param name="arrayLength">Number total of member</param>
        /// <returns>List of index</returns>
        public List<int> NotInIndex(int arrayLength)
        {
            var masq = 1;
            var result = new List<int>();

            for (var a = 0; a < arrayLength; a++)
            {
                if ((_state & masq) == 0) result.Add(a);
                masq = masq << 1;
            }

            return result;
        }

        public void SetState(int i)
        {
            if (i != -1) _state = _state | +(1 << i);
        }
    }

    internal class Table
    {
        public readonly Field[] Fields;
        public readonly bool Hidden;
        public readonly bool ImportFormSource;
        public readonly string Name;
        public readonly string SqlFile;


        public Table(string name, string sqlFile)
        {
            Name = name;
            SqlFile = sqlFile;
        }

        public Table(string name, string sqlFile, bool hidden)
        {
            Name = name;
            SqlFile = sqlFile;
            Hidden = hidden;
        }

        public Table(string name, string sqlFile, bool hidden, bool importFromSource)
        {
            Name = name;
            SqlFile = sqlFile;
            Hidden = hidden;
            ImportFormSource = importFromSource;
        }
    }

    internal class Field
    {
        public bool AsPrefixe;
        public string DefaultValue;
        public string MySqlType;
        public string Name;
        public string PostgresType;
        public bool Primary;


        public Field(string name, string mySqlType, string postgresType, string defaultValue, bool asPrefixe)
        {
            Set(name, mySqlType, postgresType, defaultValue, asPrefixe, false);
        }


        private void Set(string name, string mySqlType, string postgresType, string defaultValue, bool asPrefixe,
            bool primary)
        {
            Name = name;
            MySqlType = mySqlType;
            PostgresType = postgresType;
            DefaultValue = defaultValue;
            Primary = primary;
            AsPrefixe = asPrefixe;
        }
    }

    public static class EnumerableExtensions
    {
        // find the index of an item in the collection similar to List<T>.FindIndex()
        public static int FindIndex<T>(this IEnumerable<T> list, Predicate<T> finder)
        {
            return list.ToList().FindIndex(finder);
        }
    }
}