//using mySqlLib;
//using NpgsqlLib;
using System;
using System.Data;
using System.IO;
using System.Linq;
using Tabloid.Classes.Data;
using Tabloid.Classes.Tools;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes
{
    internal static class SqlCommands
    {
        /// <summary>
        ///     Define provider to use
        /// </summary>
        public static Provider Provider;

        /// <summary>
        ///     Return Sql command to list all Table
        /// </summary>
        public static string SqlGetTable(string schema=null)
        {
            return Provider == Provider.MySql
                ? "SHOW TABLES"
                : string.Format(
                    "SELECT tablename FROM pg_tables WHERE schemaname='{0}' and tablename<>'spatial_ref_sys' and tablename<>'geometry_columns' order by tablename",
                string.IsNullOrEmpty(schema)?Program.AppSet.Schema:schema);
        }

        /// <summary>
        ///     Return columns list from table
        /// </summary>
        /// <param name="table">Table name</param>
        /// <param name="schema">schema name</param>
        /// <returns>Sql command 0 column name,1 column dbtype,2 always null,3 constraint type (start with pri if primarykey)</returns>
        public static string SqlGetColums(string table,string schema)
        {
            var sql = Provider == Provider.MySql
                ? "SHOW COLUMNS FROM {0}"
                : "select distinct(isc.column_name), isc.data_type,null,constraint_type from information_schema.COLUMNS as isc " +
                    "left join information_schema.table_constraints tc " +
                    "join information_schema.constraint_column_usage AS ccu " +
                    "on tc.constraint_schema = ccu.constraint_schema and tc.constraint_name = ccu.constraint_name and tc.table_name = '{0}' and tc.constraint_schema = '{1}' " +
                    "on isc.table_name = tc.table_name and ccu.constraint_schema = '{1}' and ccu.table_name = '{0}' and isc.column_name = ccu.column_name " +
                    "where isc.table_name = '{0}' AND isc.table_schema = '{1}'";

            return string.Format(sql, table, schema);
        }
        /// <summary>
        ///     Return columns list from table
        /// </summary>
        /// <param name="table">Table name</param>
        /// <returns>Sql command 0 column name,1 column dbtype,2 always null,3 constraint type (start with pri if primarykey)</returns>
        public static string SqlGetColums(string table)
        {
            return SqlGetColums(table, Program.AppSet.Schema);
        }

        /// <summary>
        /// Delete column in table
        /// Remove constraint if exist
        /// </summary>
        /// <param name="table">Field table name without schema</param>
        /// <param name="schema"></param>
        public static void DropColumn(string table, string column, string schema)
        {
            string error;
            var constraints = DataTools.Data(SqlCommands.SqlGetForeignKey(table, schema), Program.AppSet.ConnectionString, out error);

            var columnConstraints = new DataView(constraints,
                constraints.Columns[0].ColumnName + " like '" + column + "'",
                "", DataViewRowState.Unchanged);

            foreach (DataRowView dr in columnConstraints)
            {
                var param1 = new string[] { schema, dr[3].ToString(), table };
                WizardSQLHelper.ExecuteFromFile("DropForeignKey.sql", param1, Program.AppSet.ConnectionString);
            }

            var param = new string[] { schema+"."+table, ChampTools.RemoveTableName(column)};
            WizardSQLHelper.ExecuteFromFile("supField.sql", param, Program.AppSet.ConnectionString);
        }
        /// <summary>
        ///     Return Sql command to list ForeignKey
        ///     column 0 Column Name
        ///     column 1 Referenced Table Name
        ///     column 2 Referenced Column Name
        ///     column 3 foreignKey Name 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string SqlGetForeignKey(string table, string schema)
        {
            var sql = table != null ?
                (Provider == Provider.MySql
                ? "SELECT COLUMN_NAME,referenced_table_name, referenced_column_name,CONSTRAINT_NAME FROM information_schema.key_column_usage " +
                "WHERE TABLE_SCHEMA='{1}' and referenced_table_name IS NOT NULL AND TABLE_NAME='{0}';"
                : "SELECT distinct(kcu.COLUMN_NAME),ccu.TABLE_NAME,ccu.column_name,ccu.constraint_name FROM " +
                  " information_schema.table_constraints AS tc " +
                  " JOIN information_schema.key_column_usage AS kcu ON (tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME and kcu.table_schema='{1}')" +
                  " JOIN information_schema.constraint_column_usage AS ccu ON (ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME and ccu.table_schema='{1}')" +
                  " WHERE constraint_type = 'FOREIGN KEY' AND tc.TABLE_NAME='{0}';") :
                 (Provider == Provider.MySql ? "SELECT COLUMN_NAME,referenced_table_name, referenced_column_name,CONSTRAINT_NAME FROM information_schema.key_column_usage " +
                "WHERE TABLE_SCHEMA='{1}';"
                : "SELECT distinct(kcu.COLUMN_NAME),ccu.TABLE_NAME,ccu.column_name,ccu.constraint_name FROM " +
                  " information_schema.table_constraints AS tc " +
                  " JOIN information_schema.key_column_usage AS kcu ON (tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME and kcu.table_schema='{1}')" +
                  " JOIN information_schema.constraint_column_usage AS ccu ON (ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME and ccu.table_schema='{1}')" +
                  " WHERE constraint_type = 'FOREIGN KEY';");

            return string.Format(sql, table, schema);
        }


        /// <summary>
        ///     Return Sql command to create new tabloid field with prefix
        /// </summary>
        /// <param name="table"></param>
        /// <param name="schema"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static string SqlSetColumn(string table, string schema, Field f)
        {
            var sql = Provider == Provider.MySql
                ? "ALTER TABLE {0} ADD {1} {2}"
                : "ALTER TABLE {4}.{0} ADD COLUMN  {1} {2}";

            if (f.DefaultValue != null) sql += " DEFAULT " + f.DefaultValue;
            //sql += (Provider == Provider.MySql ? " DEFAULT " : " DEFAULT ") + f.DefaultValue;

            if (f.Primary) sql += " NOT NULL";

            return string.Format(sql,
                table,
                f.AsPrefixe ? f.Name + "_" + table : f.Name,
                Provider == Provider.MySql ? f.MySqlType : f.PostgresType,
                f.DefaultValue,
                schema);
        }

        /// <summary>
        ///     Return Sql command to create new table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string SqlSetTable(Table table)
        {
            const string field = "";
            var primary = "";

            foreach (var f in table.Fields.Where(f => f.Primary))
            {
                primary = string.Format(" primary key({0}),unique({0}))", f.Name);
            }
            var sql = Provider == Provider.MySql
                ? "CREATE TABLE {0} ({1}) TYPE=InnoDB CHARACTER SET utf8 COLLATE utf8_general_ci"
                : "CREATE TABLE \"public\".\"{0}\" ({1})";
            return string.Format(sql, table, field, primary);
        }

        /// <summary>
        ///     play sql script from file
        /// </summary>
        /// <param name="file">file path</param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static void SqlFromFile(string file, string connectionString, bool silentMode = true)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            path += "sources\\sql\\";
            path += (Provider == Provider.MySql ? "mySql\\" : "Postgres\\") + file;

            var sr = new StreamReader(path);
            var sql = sr.ReadToEnd().Split(';');

            foreach (var cmd in sql)
            {
                var cmd2 = cmd.TrimEnd(new char[] { '\r', '\n' });
                if (!string.IsNullOrEmpty(cmd2))
                {
                    string lastError;
                    DataTools.Command(cmd2,null, connectionString, out lastError);
                    if (!silentMode & !string.IsNullOrEmpty(lastError)) throw new Exception(lastError);
                    if (!string.IsNullOrEmpty(lastError)) break;
                }
            }

            sr.Close();
        }

    }
}