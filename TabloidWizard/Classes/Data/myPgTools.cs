/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 19/03/2009
 * Time: 11:11
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace NpgsqlLib
{
    /// <summary>
    /// Description of mySqlTools.
    /// </summary>
    public static class NpgsqlTools
    {
        //public static string lastError;

        /// <summary>
        /// retourne une table correstondant au select fourni
        /// </summary>
        /// <param name="sql">requete à executer</param>
        /// <param name="connectionString">Chaine de connection</param>
        public static DataTable data(string sql, string connectionString, out string _lastError)
        {
            _lastError = "";
            NpgsqlConnection conn = setConnection(connectionString, out _lastError);
            if (conn != null) return data(sql, conn, out _lastError);
            return null;
        }

        /// <summary>
        /// retourne une table correstondant au select fourni
        /// </summary>
        /// <param name="sql">requete à executer</param>
        /// <param name="provider">Connecteur MySql</param>
        public static DataTable data(string sql, NpgsqlConnection provider, out string _lastError)
        {
            var dt = new DataTable();
            _lastError = "";

            try
            {
                provider.Open();
                var adapter = new NpgsqlDataAdapter(sql, provider);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                _lastError = ex.Message + "\n" + sql;
                return null;
            }
            finally
            {
                if (provider.State == System.Data.ConnectionState.Open) provider.Close();
            }
            return dt;
        }

        /// <summary>
        /// affecte une table dans un dataset
        /// </summary>
        /// <param name="sql">requete à executer</param>
        /// <param name="table">nom de la table</param>
        /// <param name="connectionString">chaine de connection</param>
        /// <param name="dset">dataset devant contenir la table</param>
        public static void data(string sql, string table, string connectionString, DataSet dset, out string _lastError)
        {
            NpgsqlConnection conn = setConnection(connectionString, out _lastError);
            if (conn != null)
            {
                data(sql, table, conn, dset, out _lastError);
            }
        }

        /// <summary>
        /// affecte une table dans un dataset
        /// </summary>
        /// <param name="sql">requete à executer</param>
        /// <param name="table">nom de la table</param>
        /// <param name="provider">Connecteur MySql</param>
        /// <param name="dset">dataset devant contenir la table</param>
        public static void data(string sql, string table, NpgsqlConnection provider, DataSet dset, out string _lastError)
        {//MessageBox.Show(sql);
            _lastError = "";

            try
            {
                provider.Open();
                var adapter = new NpgsqlDataAdapter(sql, provider);
                if (dset.Tables[table] != null) dset.Tables[table].Clear();
                adapter.Fill(dset, table);
            }
            catch (Exception ex)
            {
                _lastError = ex.Message + "\n" + sql;
            }
            finally
            {
                if (provider.State == System.Data.ConnectionState.Open) provider.Close();
            }
            //MessageBox.Show(dset.Tables[table].Rows.Count.ToString());
        }

        /// <summary>
        /// Exécute la commande sql sur le connecteur spécifié
        /// retourne le nombre de ligne modifié ou -1 en cas d'erreur
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Command(string sql, List<Parameter> param, string connectionString, out string _lastError)
        {
            _lastError = "";
            NpgsqlConnection connecteur = NpgsqlTools.setConnection(connectionString, out _lastError);
            if (connecteur != null)
                return NpgsqlTools.Command(sql, param, connecteur, out _lastError);
            else
                return -1;
        }

        public static object ScalarCommand(string sql, List<Parameter> param, string connectionString, out string _lastError)
        {
            _lastError = "";
            NpgsqlConnection connecteur = NpgsqlTools.setConnection(connectionString, out _lastError);
            if (connecteur != null)
                return NpgsqlTools.ScalarCommand(sql, param, connecteur, out _lastError);
            else
                return (object)null;
        }

        /// <summary>
        /// Exécute la commande sql sur le connecteur spécifié
        /// retourne le nombre de ligne modifié ou -1 en cas d'erreur
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connecteur"></param>
        /// <returns></returns>
        public static int Command(string sql, List<Parameter> param, NpgsqlConnection connecteur, out string _lastError)
        {
            int num = -1;
            _lastError = "";
            try
            {
                if (connecteur.State != ConnectionState.Open)
                    connecteur.Open();
                var command = new NpgsqlCommand(sql, connecteur);
                if (param != null)
                    addParamToCommand(param, command);
                num = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _lastError = ((object)ex) + "\n" + sql;
            }
            finally
            {
                if (connecteur.State == ConnectionState.Open)
                    connecteur.Close();
            }
            return num;
        }

        public static object ScalarCommand(string sql, List<Parameter> param, NpgsqlConnection connecteur, out string _lastError)
        {
            _lastError = "";
            try
            {
                if (connecteur.State != ConnectionState.Open)
                    connecteur.Open();
                var command = new NpgsqlCommand(sql, connecteur);
                if (param != null)
                    addParamToCommand(param, command);
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _lastError = ((object)ex) + "\n" + sql;
            }
            finally
            {
                if (connecteur.State == ConnectionState.Open)
                    connecteur.Close();
            }
            return (object)false;
        }

        public static string addInsertCommandKeyOut(string sql, string key)
        {
            return sql + " returning " + key;
        }

        private static void addParamToCommand(List<Parameter> param, NpgsqlCommand command)
        {
            foreach (Parameter parameter in param)
            {
                var npgsqlParameter = new NpgsqlParameter();
                npgsqlParameter.ParameterName = parameter.Name;
                npgsqlParameter.Value = (object)(
                    (parameter.ConvertEmptyStringToNull && parameter.DefaultValue == "") ? null : parameter.DefaultValue);
                npgsqlParameter.DbType = parameter.DbType;
                command.Parameters.Add(npgsqlParameter);
            }
        }

        public static string filtre(string src)
        {
            src = src.Replace("\"", "''");
            return src.Replace("'", "''");
        }

        public static NpgsqlConnection setConnection(string connectionString, out string _lastError)
        {
            NpgsqlConnection conn = null;
            _lastError = "";

            try
            {
                conn = new NpgsqlConnection(connectionString);//
            }
            catch (Exception ex)
            {
                _lastError = ex + "\n" + connectionString;
            }
            return conn;
        }

        public static DbType MyPgTypetoDbType(string t)
        {
            string[] v = t.Split('(');

            if (v.Length > 1) v[1] = v[1].Substring(0, v[1].Length - 1);

            DbType result = DbType.String;

            switch (v[0])
            {
                case "integer":
                case "serial":
                    result = DbType.Int16;
                    break;

                case "character varying":
                    result = DbType.String;
                    break;

                case "boolean":
                    result = DbType.Boolean;
                    break;

                case "timestamp without time zone":
                case "timestamp with time zone":
                case "datetime":
                    result = DbType.DateTime;
                    break;

                case "date":
                    result = DbType.Date;
                    break;
            }

            return result;
        }
    }
}