using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Properties;

namespace TabloidWizard.Classes.Tools
{
    public static class BuildFromBase
    {
        /// <summary>
        /// verify tabloid table aviability
        /// </summary>
        /// <param name="tableName">table to search</param>
        /// <param name="schema"></param>
        /// <param name="tableConfig"></param>
        /// <param name="avt"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static bool GetTable(string tableName, string schema, ref TabloidConfigView tableConfig, ref ArrayVerify avt, BaseImporterConfig config)
        {
            var indexTable = TabloidTables.IsTabloidTable(tableName, ref avt);
            var toShow = indexTable == -1;

            if (!toShow)//this is a tabloid table
                toShow = !TabloidTables.TabloidTablesArray[indexTable].Hidden; //for tabloid table verify hidden propertie

            if (toShow)//this is not a tabloid table
            {
                tableConfig = new TabloidConfigView();
                tableConfig.Nom = tableConfig.Titre = tableName;
                tableConfig.Titre = ModifyTitle(tableConfig.Titre, tableName,config);
                tableConfig.Schema = schema;

                string lastError;

                var dc = DataTools.Data(SqlCommands.SqlGetColums(tableName), config.ConnectionString, out lastError);//013

                if (!string.IsNullOrEmpty(lastError))
                {
                    throw new Exception(lastError);
                    //lblState.Text = lastError;
                    return false;
                }
                //read Fields
                var avc = new ArrayVerify();
                var cmpt = 0;

                foreach (DataRow dcr in dc.Rows)
                {
                    cmpt++;

                    if (TabloidFields.IstabloidField(dcr[0].ToString(), ref avc) == -1)
                    {
                        var colonneConfig = new TabloidConfigColonne();

                        if (dcr[3].ToString().StartsWith("PRI", StringComparison.InvariantCulture)) tableConfig.DbKey = dcr[0].ToString();
                        else
                        {
                            colonneConfig.Nom = "C" + cmpt;
                            colonneConfig.Champ = colonneConfig.Titre = dcr[0].ToString();

                            colonneConfig.Titre = ModifyTitle(colonneConfig.Titre, tableName,config);



                            colonneConfig.Type = dataHelper.DbTypeConverter.Convert(dcr[1].ToString(), SqlCommands.Provider.ToString());

                            tableConfig.Colonnes.Add(colonneConfig);
                        }
                    }
                }

                if (!avc.IsThereAll(TabloidFields.TabloidFieldsArray.Count()))//is all tabloid field there?
                {
                    var l = avc.NotInIndex(TabloidFields.TabloidFieldsArray.Count()); //list unaviable fields
                    var r = DialogResult.Yes;

                    if (!config.CreateAuto)
                    {
                        //Show message
                        var strCh = string.Join("\n\t- ",
                            TabloidFields.TabloidFieldsArray
                                .Where((f, index) => l.Any(i => i == index))
                                .Select((x, index) => x.Name + "_" + tableName).ToArray());

                        r = MessageBox.Show(
                            string.Format(
                                Resources.NewFromBaseForm_GetTable_,
                                tableName, strCh),
                            Resources.Information,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                    }

                    if (r == DialogResult.Yes)
                    {
                        TabloidFields.CreateField(
                            TabloidFields.TabloidFieldsArray
                                .Where((f, index) => l.Any(i => i == index))
                                .ToList(), tableName, schema, config.ConnectionString);
                    }
                }

                var jr = WizardSQLHelper.SetJoinFromConstraint(tableConfig, config.ConnectionString, ref lastError); //getting join

                if (jr != null&&!string.IsNullOrEmpty(lastError)) throw new Exception(lastError); //lblState.Text = lastError;

                return jr != null;
            }

            return false;
        }

        static string ModifyTitle(string txt, string tableName,BaseImporterConfig config)
        {
            if (config.RemoveTableName) txt = WizardStringTools.RemoveTableName(txt, tableName);
            if (config.ReplaceUnderscrore) txt = WizardStringTools.ReplaceUnderscrore(txt);
            if (config.ToUpperCase) txt = WizardStringTools.ToUpperCase(txt);
            return txt;
        }

        public class BaseImporterConfig
        {
            public bool RemoveTableName { get; set; }
            public bool ReplaceUnderscrore { get; set; }
            public bool ToUpperCase { get; set; }
            /// <summary>
            /// Build automaticaly tabloidfield without prompt
            /// </summary>
            public bool CreateAuto { get; set; }

            public string ConnectionString { get; set; }
        }

    }
}
