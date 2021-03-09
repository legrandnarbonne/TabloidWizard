using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TabloidWizard.Classes.Tools
{
    public static class PgAdmin
    {
        private static string psqlPath = @"C:\Program Files\pgAdmin 4\v4\runtime\";

        public enum ScriptType { psql, pg_dump, pg_restore }

        public static bool IsPgAdminInstalled()
        {
            String command = "-V";
            return executePgProg(command, "", ScriptType.psql).StartsWith("psql (PostgreSQL)");
        }

        public static string BackupDatabase(
            string server,
            string user,
            string password,
            string dbname,
            string backupdir,
            string backupFileName,
            string port = "5432")
        {

            string backupFile = backupdir + backupFileName + "_" + DateTime.Now.ToString("yyyy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + ".backup";

            string command = " -h " + server +" -p " + port + " -n tab_fablab"+ " -f \"" + backupFile + "\" -F c" +
               " -U " + user +  " -b " + dbname;

            return executePgProg(command, password, ScriptType.pg_dump);
        }

        public static string RestoreDatabase(
            string server,
            string user,
            string password,
            string dbname,
            string backupdir,
            string backupFileName,
            string port = "5432")
        {

            string command = " -h " + server + " -p " + port + " -n tab_fablab" + " -f \"" + backupFileName + "\" -F c" +
               " -U " + user + " -b " + dbname;

            return executePgProg(command, password, ScriptType.pg_restore);
        }

        public static string executePgProg(string command, string password, ScriptType scriptType)
        {
            try
            {
                //Environment.SetEnvironmentVariable("PGPASSWORD", password);

                //SET PGPASSWORD=fBd8s*OwnxR-tDNxM0qg&"C:\Program Files\pgAdmin 4\v4\runtime\pg_dump.exe" -h CAN13 -p 5432 -n tab_fablab -f "c:\\test.sql_2021_02_22.backup" -F c -U tabloidadmin -p 5432 -b bdd_gn

                Process proc = new Process();
                //proc.StartInfo.EnvironmentVariables.Add("PGPASSWORD", password);
                proc.StartInfo.FileName =  psqlPath + getCommand(scriptType);

                proc.StartInfo.Arguments = command;

                proc.StartInfo.RedirectStandardOutput = true;//for error checks BackupString
                proc.StartInfo.RedirectStandardError = true;

                proc.StartInfo.Verb = "runas";
                proc.StartInfo.UseShellExecute = false;//use for not opening cmd screen
                proc.StartInfo.CreateNoWindow = true;//use for not opening cmd screen

                proc.Start();
                StreamReader reader = proc.StandardOutput;
                string output =  reader.ReadToEnd();

                proc.WaitForExit();
                proc.Close();

                return output;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private static string getCommand(ScriptType s)
        {
            return s.ToString() + ".exe";
        }


        public static string BackupDatabase_old(
            string server,
            string user,
            string password,
            string dbname,
            string backupdir,
            string backupFileName,
            string backupCommandDir,
            string port = "5432")
        {
            try
            {
                Environment.SetEnvironmentVariable("PGPASSWORD", password);

                string backupFile = backupdir + backupFileName + "_" + DateTime.Now.ToString("yyyy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + ".backup";

                string BackupString = " -f \"" + backupFile + "\" -F c" +
                  " -h " + server + " -U " + user + " -p " + port + " -d " + dbname;


                Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = backupCommandDir + "\\pg_dump.exe";

                proc.StartInfo.Arguments = BackupString;

                proc.StartInfo.RedirectStandardOutput = true;//for error checks BackupString
                proc.StartInfo.RedirectStandardError = true;


                proc.StartInfo.UseShellExecute = false;//use for not opening cmd screen
                proc.StartInfo.CreateNoWindow = true;//use for not opening cmd screen


                proc.Start();
                proc.WaitForExit();
                proc.Close();

                return backupFile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static void PgDump(string strServer, string strPort, string strDatabaseName, string destinationPath, string strPG_dumpPath)
        {
            try
            {

                StreamWriter sw = new StreamWriter("DBBackup.bat");
                // Do not change lines / spaces b/w words.
                StringBuilder strSB = new StringBuilder(strPG_dumpPath);

                if (strSB.Length != 0)
                {
                    strSB.Append("pg_dump.exe --host " + strServer + " --port " + strPort +
                      " --username postgres --format custom --blobs --verbose --file ");
                    strSB.Append("\"" + destinationPath + "\"");
                    strSB.Append(" \"" + strDatabaseName + "\r\n\r\n");
                    sw.WriteLine(strSB);
                    sw.Dispose();
                    sw.Close();
                    Process processDB = Process.Start("DBBackup.bat");
                    do
                    {//dont perform anything
                    }
                    while (!processDB.HasExited);
                    {
                        MessageBox.Show(strDatabaseName + " Successfully Backed up at " + destinationPath);
                    }
                }
                else
                {
                    MessageBox.Show("Please Provide the Location to take Backup!");
                }
            }
            catch (Exception ex)
            { }

        }

        public static void PgRestore(string strServer, string strPort, string strDatabaseName, string BackupFilePath, string strPG_dumpPath)
        {
            try
            {

                //check for the pre-requisites before restoring the database.*********
                if (strDatabaseName != "")
                {
                    if (BackupFilePath != "")
                    {
                        StreamWriter sw = new StreamWriter("DBRestore.bat");
                        // Do not change lines / spaces b/w words.
                        StringBuilder strSB = new StringBuilder(strPG_dumpPath);
                        if (strSB.Length != 0)
                        {
                            //checkDBExists(strDatabaseName);
                            strSB.Append("pg_restore.exe --host " + strServer +
                               " --port " + strPort + " --username postgres --dbname");
                            strSB.Append(" \"" + strDatabaseName + "\"");
                            strSB.Append(" --verbose ");
                            strSB.Append("\"" + BackupFilePath + "\"");
                            sw.WriteLine(strSB);
                            sw.Dispose();
                            sw.Close();
                            Process processDB = Process.Start("DBRestore.bat");
                            do
                            {//dont perform anything
                            }
                            while (!processDB.HasExited);
                            {
                                MessageBox.Show("Successfully restored " +
                                   strDatabaseName + " Database from " + BackupFilePath);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the save path to get the backup!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Database name to Restore!");
                }
            }
            catch (Exception ex)
            { }
        }


    }
}
