/*
 * Created by SharpDevelop.
 * User: dapojero
 * Date: 18/08/2014
 * Time: 14:53
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TabloidWizard.Classes
{
    /// <summary>
    ///     Description of wizardStringTools.
    /// </summary>
    public static class WizardStringTools
    {
        /// <summary>
        ///     remove at the end of text the name of the table if present
        /// </summary>
        /// <param name="txt">text to modify</param>
        /// <param name="tableName">table name</param>
        /// <returns></returns>
        public static string RemoveTableName(string txt, string tableName)
        {
            return txt.ToLower().Replace("_" + tableName, "");
        }

        /// <summary>
        ///     return string in lower case with first character in upper case
        /// </summary>
        /// <param name="txt">text to transform</param>
        /// <returns></returns>
        public static string ToUpperCase(string txt)
        {
            txt = txt.ToLower();
            return txt.Substring(0, 1).ToUpper() + txt.Substring(1);
        }

        /// <summary>
        ///     replace underscore by space
        /// </summary>
        /// <param name="txt">text to transform</param>
        /// <returns></returns>
        public static string ReplaceUnderscrore(string txt)
        {
            txt = txt.ToLower();
            return txt.ToLower().Replace("_", " ");
        }
    }
}