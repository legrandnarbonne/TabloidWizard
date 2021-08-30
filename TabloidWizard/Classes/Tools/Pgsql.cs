using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TabloidWizard.Classes.Tools
{
    class Pgsql
    {
        //thanks to https://stackoverflow.com/questions/23026949/how-to-backup-restore-postgresql-using-code
        string Set = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "set " : "export ";

        public async Task<string> SqlRestore(
                   string inputFile,
                   string host,
                   string port,
                   string database,
                   string user,
                   string password)
        {
            string dumpCommand = $"{Set}PGPASSWORD={password}\n" +
                                 //$"psql -h {host} -p {port} -U {user} -d {database} -c \"select pg_terminate_backend(pid) from pg_stat_activity where datname = '{database}'\"\n" +
                                 //$"dropdb -h " + host + " -p " + port + " -U " + user + $" {database}\n" +
                                 //$"createdb -h " + host + " -p " + port + " -U " + user + $" {database}\n" +
                                 "pg_restore -h " + host + " -p " + port + " -d " + database + " -U " + user + " --no-acl --no-owner";

            //psql command disconnect database
            //dropdb and createdb  remove database and create.
            //pg_restore restore database with file create with pg_dump command
            dumpCommand = $"{dumpCommand} {inputFile}";

            var error=await Execute(dumpCommand);

            return error;
        }

        private Task<string> Execute(string dumpCommand)
        {
            Task<string> t = Task.Run(() =>
            {

                string batFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}." + (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bat" : "sh"));
                string error = "";
                try
                {
                    string batchContent = "";
                    batchContent += "pushd \"" + AppDomain.CurrentDomain.BaseDirectory + "sources\\pgsql\"\r\n";//allow working from network drive
                    batchContent += $"{dumpCommand}";

                    File.WriteAllText(batFilePath, batchContent, Encoding.ASCII);

                    ProcessStartInfo info = ProcessInfoByOS(batFilePath);

                    Process proc = Process.Start(info);
                    
                    error = proc.StandardError.ReadToEnd();

                    proc.WaitForExit();

                    var exit = proc.ExitCode;

                    proc.Close();
                }
                catch (Exception e)
                {
                    StreamWriter sw = new StreamWriter("C:\\Erreur.txt");
                    sw.WriteLine(e);
                    sw.Close();
                }
                finally
                {
                    if (File.Exists(batFilePath)) File.Delete(batFilePath);
                    
                }

                return error;
            });

            return t;
        }
        private static ProcessStartInfo ProcessInfoByOS(string batFilePath)
        {
            ProcessStartInfo info;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                info = new ProcessStartInfo(batFilePath)
                {
                };
            }
            else
            {
                info = new ProcessStartInfo("sh")
                {
                    Arguments = $"{batFilePath}"
                };
            }

            info.CreateNoWindow = true;
            info.UseShellExecute = false;
            info.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory+@"sources\pgsql";
            info.RedirectStandardError = true;
            //info.RedirectStandardOutput = true;

            return info;
        }
        public async Task SqlDump(
              string outFile,
              string host,
              string port,
              string database,
              string user,
              string password,
              string schema,
              string extraparam = "")
        {
            string dumpCommand =
                 $"{Set}PGPASSWORD={password}\n" +
                 $"pg_dump" +$" --file \"{outFile}\""+ " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user + " -n "+ schema + " --no-owner --no-privileges --verbose"+ extraparam;

            string batchContent = "" + dumpCommand;// + "  > " + "\"" + outFile + "\"" + "\n";
            if (File.Exists(outFile)) File.Delete(outFile);

            await Execute(batchContent);
        }

    }
}
