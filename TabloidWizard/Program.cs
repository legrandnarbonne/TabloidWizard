/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 23/02/2013
 * Time: 16:09
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using TabloidWizard.Classes;

namespace TabloidWizard
{
    /// <summary>
    ///     Class with program entry point.
    /// </summary>
    internal static class Program
    {
        public static AppSetting AppSet { get; set; }

        /// <summary>
        /// Current project folder
        /// </summary>
        public static string CurrentWizardFolder { get; set; }

        /// <summary>
        /// Current wizard folder
        /// </summary>
        public static string CurrentProjectFolder { get; set; }
        public static XLSStructure CurrentXLSStructure { get; internal set; }

        /// <summary>
        ///     Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            CurrentWizardFolder= System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}