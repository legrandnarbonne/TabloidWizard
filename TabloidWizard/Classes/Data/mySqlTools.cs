﻿/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 19/03/2009
 * Time: 11:11
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace mySqlLib
{
    /// <summary>
    /// Description of mySqlTools.
    /// </summary>
    public static class mySqlTools
    {
        //public static string lastError;

        public static string formatDate(DateTime dt)
        {
            return String.Format("{0:yyyy/MM/dd HH:mm:ss}", dt);
        }

        /// <summary>
        /// retourne une table correstondant au select fourni
        /// </summary>
        /// <param name="sql">requete à executer</param>
        /// <param name="connectionString">Chaine de connection</param>
        public static DataTable data(string sql, string connectionString, out string _lastError)
        {
            _lastError = "";
            MySqlConnection conn = setConnection(connectionString, out _lastError);
            if (conn != null) return data(sql, conn, out _lastError);
            return null;
        }

        /// <summary>
        /// retourne une table correstondant au select fourni
        /// </summary>
        /// <param name="sql">requete à executer</param>
        /// <param name="provider">Connecteur MySql</param>
        public static DataTable data(string sql, MySqlConnection provider, out string _lastError)
        {
            _lastError = "";
            var dt = new DataTable();
            _lastError = "";

            try
            {
                provider.Open();
                var adapter = new MySqlDataAdapter(sql, provider);
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
            _lastError = "";
            MySqlConnection conn = setConnection(connectionString, out _lastError);
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
        public static void data(string sql, string table, MySqlConnection provider, DataSet dset, out string _lastError)
        {//MessageBox.Show(sql);
            _lastError = "";
            try
            {
                provider.Open();
                var adapter = new MySqlDataAdapter(sql, provider);
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
        public static int Command(string sql, string connectionString, out string _lastError)
        {
            _lastError = "";
            MySqlConnection conn = setConnection(connectionString, out _lastError);
            if (conn != null)
            {
                return Command(sql, conn, out _lastError);
            }
            return -1;
        }

        public static object ScalarCommand(string sql, string connectionString, out string _lastError)
        {
            _lastError = "";
            MySqlConnection conn = setConnection(connectionString, out _lastError);
            if (conn != null)
            {
                return ScalarCommand(sql, conn, out _lastError);
            }
            return null;
        }

        /// <summary>
        /// Exécute la commande sql sur le connecteur spécifié
        /// retourne le nombre de ligne modifié ou -1 en cas d'erreur
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connecteur"></param>
        /// <returns></returns>
        public static int Command(string sql, MySqlConnection connecteur, out string _lastError)
        {
            int rowAffected = -1;
            _lastError = "";

            try
            {
                if (connecteur.State != ConnectionState.Open) connecteur.Open();
                var command = new MySqlCommand(sql, connecteur);
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _lastError = e + "\n" + sql;
            }
            finally
            {
                if (connecteur.State == ConnectionState.Open) connecteur.Close();
            }
            return rowAffected;
        }

        public static object ScalarCommand(string sql, MySqlConnection connecteur, out string _lastError)
        {
            _lastError = "";

            try
            {
                if (connecteur.State != ConnectionState.Open) connecteur.Open();
                var command = new MySqlCommand(sql, connecteur);
                object o = command.ExecuteScalar();

                return o;
            }
            catch (Exception e)
            {
                _lastError = e + "\n" + sql;
            }
            finally
            {
                if (connecteur.State == ConnectionState.Open) connecteur.Close();
            }
            return false;
        }

        public static string addInsertCommandKeyOut(string sql, string key)
        {
            return sql + ";select last_insert_id();";
        }

        public static string filtre(string src)
        {
            src = src.Replace("\"", "''");
            return src.Replace("'", "''");
        }

        public static MySqlConnection setConnection(string connectionString, out string _lastError)
        {
            MySqlConnection conn = null;
            _lastError = "";

            try
            {
                conn = new MySqlConnection(connectionString);//
            }
            catch (Exception ex)
            {
                _lastError = ex + "\n" + connectionString;
            }
            return conn;
        }

        public static DbType MySqlTypetoDbType(string t)
        {
            string[] v = t.Split('(');

            if (v.Length > 1) v[1] = v[1].Substring(0, v[1].Length - 1);

            DbType result = DbType.String;

            switch (v[0])
            {
                case "int":
                    result = DbType.Int16;
                    break;

                case "varchar":
                    result = DbType.String;
                    break;

                case "tinyint":
                    result = DbType.Boolean;
                    break;

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