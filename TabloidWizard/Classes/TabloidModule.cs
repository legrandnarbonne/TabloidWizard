
using System.Collections.Generic;
using System.Windows.Forms;
using Tabloid.Classes.Data;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes
{
    /// <summary>
    /// Handle table for spécific module SMS, Messenger
    /// </summary>
    static class TabloidModule
    {
        /// <summary>
        /// Module type
        /// </summary>
        public enum ModuleTableType
        {
            SMS,
            Messenger,
            Phototheque
        };

        /// <summary>
        /// Table dictionnary
        /// </summary>
        public static Dictionary<ModuleTableType, string[]> TableList = new Dictionary<ModuleTableType, string[]>
        {
            {ModuleTableType.SMS,new string[] { "tracesenvois","textes" }},
            {ModuleTableType.Messenger,new string[] { "message" } },
            {ModuleTableType.Phototheque,new string[] { "photos" }}
        };

        /// <summary>
        /// Enable or disable module
        /// </summary>
        /// <param name="enable">set if true or disable module if false</param>
        /// <returns></returns>
        public static bool SetModuleState(bool enable, ModuleTableType moduleType, IWin32Window own)
        {
            return enable ? Activate(moduleType,own) : Remove(moduleType,own);
        }

        public static bool IsModuleActivated(ModuleTableType moduleType)
        {
            string error;

            foreach (string tableName in TableList[moduleType])
            {
                if (!BindingHelper.ToBool(DataTools.ScalarCommand(
                string.Format("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '{1}');", Program.AppSet.Schema, "photos"),
                null, Program.AppSet.ConnectionString, out error))) return false;
            }

            return true;
        }

        /// <summary>
        /// Build Module base table
        /// </summary>
        public static bool Activate(ModuleTableType moduleType, IWin32Window own)
        {
            foreach (string tableName in TableList[moduleType])
            {
                WizardSQLHelper.ExecuteFromFile(tableName + ".sql", null, Program.AppSet.ConnectionString,own);
            }
            return true;
        }

        /// <summary>
        /// Remove Module base table
        /// </summary>
        public static bool Remove(ModuleTableType moduleType, IWin32Window own)
        {
            foreach (string tableName in TableList[moduleType])
            {
                var competedTableName = tableName;
                if (Program.AppSet.ProviderType == Provider.Postgres)
                    competedTableName = CurrentContext.CurrentView.Schema + "." + tableName;

                WizardSQLHelper.ExecuteFromFile("supTable.sql", new string[] { competedTableName }, Program.AppSet.ConnectionString,own);
            }
            return true;
        }
    }
}
