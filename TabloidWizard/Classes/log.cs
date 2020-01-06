/*
 * Created by SharpDevelop.
 * User: dapojero
 * Date: 28/02/2014
 * Time: 11:48
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace TabloidWizard.Classes
{
    /// <summary>
    /// Description of log.
    /// </summary>
    public static class Log
    {
        private static readonly string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public static void Write(string text)
        {
            var sw = new StreamWriter(AppPath + "/logs.txt", true);
            sw.WriteLine("{0} {1}", DateTime.Now, text);
            sw.Close();
        }
    }
}