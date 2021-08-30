using Gui.Wizard;
using System;
using System.Windows.Forms;
using TabloidWizard.Classes.WizardTools;
using TabloidWizard.Classes;
using TabloidWizard.Properties;
using Tabloid.Classes.Data;
using TabloidWizard.Classes.Tools;
using MetroFramework.Forms;
using MetroFramework;
using System.ComponentModel;
using System.IO;
using Ionic.Zip;
using Tabloid.Classes.Config;
using System.Data;
using System.Threading;

namespace TabloidWizard
{
    public partial class WizardSchema : MetroForm
    {
        ConfigFilesCollection _configFiles;
        bool _fromImport;
        WaitingForm _waitingForm;

        /// <summary>
        /// Build new empty project in database
        /// </summary>
        /// <param name="configFiles"></param>
        public WizardSchema(ConfigFilesCollection configFiles, bool fromImport = false)
        {
            InitializeComponent();
            _configFiles = configFiles;
            _fromImport = fromImport;
            cmbType.SelectedIndex = 0;

            txtSchema.Enabled = !fromImport;
        }

        void Button_end(object sender, PageEventArgs e)
        {
            var schema = txtSchema.Text == "" ? "public" : txtSchema.Text;
            var importdestinationPath = "";
            var isMySql = cmbType.SelectedIndex == 0;

            string[] param = { txtHote.Text, txtUtil.Text, txtMdp.Text, txtBase.Text, schema };

            var mainConn = new ConnectionProperties
            {
                Host = txtHote.Text,
                User = txtUtil.Text,
                Password = txtMdp.Text,
                Database = txtBase.Text,
                SearchPath = new string[] { schema, "public" }
            };

            //var connectionString = cmbType.SelectedIndex == 0
            //    ? string.Format("Datasource={0};uid={1};pwd={2};", param)
            //    : string.Format("User ID={1};Password={2};Host={0};Port=5432;Database={3};SearchPath={4},public;", param);

            var tempPath = Path.GetTempPath() + Guid.NewGuid();// used for import only



            if (Program.AppSet == null) Program.AppSet = new AppSetting();//if no default properties

            if (_fromImport)//unzip file to temp file and load exported config
            {
                // select file to import
                var fd = new OpenFileDialog
                {
                    Title = Resources.SelectImportFile,

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "twz",
                    Filter = "twz files (*.twz)|*.twz",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                var result = fd.ShowDialog();
                if (result != DialogResult.OK) return;

                // select destination folder

                var folderDlg = new FolderBrowserDialog
                {
                    Description = "Selectionnez le répertoire de destination du sit web",
                    ShowNewFolderButton = true
                };

                result = folderDlg.ShowDialog();
                if (result != DialogResult.OK) return;

                importdestinationPath = folderDlg.SelectedPath;


                _waitingForm = new WaitingForm(PrepareImportWorker)
                {
                    Text = Resources.ImportPrepare,
                    progressBar = { Style = ProgressBarStyle.Marquee }
                };

                _waitingForm.Wr.RunWorkerAsync(new object[] { fd.FileName, tempPath });

                _waitingForm.ShowDialog();

                mainConn.SearchPath = new string[] { Program.AppSet.Schema, "public" };
            }

            //set app setting parameter

            if (!_fromImport) Program.AppSet.Titre = cmbType.SelectedIndex == 0 ? txtBase.Text : schema;

            Program.AppSet.ConnectionString = mainConn.GetConnectionString(isMySql);//connectionString;
            Program.AppSet.ProviderType = cmbType.SelectedIndex == 0 ? Provider.MySql : Provider.Postgres;

            Program.AppSet.identParam = cmbType.SelectedIndex == 0 ? "?" : "@";
            Program.AppSet.sqlDebug = "oui";

            Tools.SetDefaultProviderFromAppSet();

            SqlCommands.Provider = cmbType.SelectedIndex == 0 ? Provider.MySql : Provider.Postgres;

            //for postgres verify database exist if not create
            if (Program.AppSet.ProviderType == Provider.Postgres)
            {
                var cs = string.Format("User ID={1};Password={2};Host={0};Port=5432;", param);
                if (!dbExist(txtBase.Text, cs))
                {
                    if (MetroMessageBox.Show(this, Resources.DataBaseNotExist, Resources.Erreur, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)
                        != DialogResult.Yes)
                        return;
                    dbCreate(txtBase.Text, cs);
                }
            }


            //Add schema to database

            if (!_fromImport && (Program.AppSet.ProviderType == Provider.Postgres && schemaExist(schema)))
            {
                string err;

                if (MetroMessageBox.Show(this, Resources.SchemaAlreadyExist, Resources.Erreur, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error)
                    != DialogResult.Yes)
                    return;

                if (MetroMessageBox.Show(this, Resources.ConfirmDelete, Resources.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes)
                    return;

                DataTools.Command($"DROP SCHEMA {schema} CASCADE;", null, Program.AppSet.ConnectionString, out err);

                if (!string.IsNullOrEmpty(err))
                {
                    MetroMessageBox.Show(this, string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var connectionString = mainConn.GetConnectionString(isMySql);

            if (!_fromImport) Program.AppSet.Schema = schema;

            if (Program.AppSet.ProviderType == Provider.Postgres)
            {//postgres
                param = new string[] { txtSchema.Text };
                e.Cancel = !WizardSQLHelper.ExecuteFromFile("schema.sql", param, connectionString, this);
                if (e.Cancel) return;// stop on sql error
            }
            else
            {//mysql
                param = new string[] { txtBase.Text };
                e.Cancel = !WizardSQLHelper.ExecuteFromFile("schema.sql", param, mainConn.GetConnectionString(isMySql), this);
                if (e.Cancel) return;// stop on sql error
                Program.AppSet.ConnectionString = connectionString + "Database=" + txtBase.Text + ";"; ;
            }

            // add tabloid table to database
            try
            {
                if (_fromImport)//unzip file to temp file and load exported config
                {
                    _waitingForm = new WaitingForm(ImportWorker)
                    {
                        Text = Resources.dbImport,
                        progressBar = { Style = ProgressBarStyle.Marquee }
                    };

                    var conn = new ConnectionProperties
                    {
                        Host = txtHote.Text,
                        Port = "5432",
                        User = txtUtil.Text,
                        Password = txtMdp.Text,
                        Database = txtBase.Text
                    };

                    _waitingForm.Wr.RunWorkerAsync(new object[] { tempPath, conn, importdestinationPath });

                    _waitingForm.ShowDialog();

                }
                else
                if (!TabloidTables.CreateTable(TabloidTables.TabloidTablesArray, connectionString, this))//create tabloid table in base
                    return;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //add user
            if (_fromImport)
            {
                var utilFrm = new UtilEditor();

                utilFrm.btnCancel.Enabled = false;
                utilFrm.cmbAuth.SelectedIndex = 1;
                utilFrm.cmbAuth.Enabled = false;

                if (utilFrm.ShowDialog() == DialogResult.OK)//for user table need to ask for user 0
                {
                    TabloidConfig.Config.updateCurrentKey(Program.AppSet.grainDeSable);
                    var keyParam = GenericParameter.Get("id_utilisateur", DbType.Int32, null);
                    var sql = $"INSERT INTO utilisateurs(logon, nom, prenom, mail, password, auteur_utilisateurs, datemaj_utilisateurs, deleted_utilisateurs, debutsession, finsession) VALUES('{utilFrm.txtLogin.Text}', '{utilFrm.txtNom.Text}', '{utilFrm.txtPrenom.Text}', '{utilFrm.txtMail.Text}', '{Tabloid.Classes.Tools.SecurityHelper.EncryptPassword(utilFrm.txtMdp1.Text)}', NULL, NULL, 0, now(), NULL)";
                    sql = sql + string.Format(SqlConverter.GetSql(SqlConverter.SqlType.InsertCommandKeyOut), "id_utilisateur");

                    var id = DataTools.ScalarCommand(sql, new[] { keyParam }, mainConn.GetConnectionString(isMySql));

                    sql = $"INSERT INTO lst_roles(utilisateurs_id, roles_id) VALUES({id}, 1);";

                    DataTools.Command(sql, null, mainConn.GetConnectionString(isMySql));
                }
            }
            else
            {
                //open project properties form
                Tools.EditSetting(_configFiles);
            }
        }
        /// <summary>
        /// Verify for postgres database schema existance
        /// </summary>
        /// <returns></returns>
        private bool schemaExist(string schema)
        {
            string err;

            var sql = "SELECT count(schema_name) FROM information_schema.schemata WHERE schema_name = '{0}';";
            sql = string.Format(sql, schema);

            var cmpt = DataTools.ScalarCommand(sql, null, Program.AppSet.ConnectionString, out err);

            if (!string.IsNullOrEmpty(err))
                MetroMessageBox.Show(this, string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return Convert.ToInt32(cmpt) > 0;
        }
        /// <summary>
        /// Verify for postgres if database exist
        /// </summary>
        /// <returns></returns>
        private bool dbExist(string dbName, string cs)
        {
            string err;

            var sql = "SELECT count(datname) FROM pg_catalog.pg_database WHERE lower(datname) = lower('{0}');";
            sql = string.Format(sql, dbName);

            var cmpt = DataTools.ScalarCommand(sql, null, cs, out err);

            if (!string.IsNullOrEmpty(err))
                MetroMessageBox.Show(this, string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return Convert.ToInt32(cmpt) > 0;
        }

        /// <summary>
        /// Verify for postgres if database exist
        /// </summary>
        /// <returns></returns>
        private void dbCreate(string dbName, string cs)
        {
            string err;

            var sql = "Create database {0};";
            sql = string.Format(sql, dbName);

            DataTools.Command(sql, null, cs, out err);

            if (!string.IsNullOrEmpty(err))
                MetroMessageBox.Show(this, string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 1 && string.IsNullOrEmpty(txtUtil.Text))
                txtUtil.Text = "postgres";
        }

        /// <summary>
        /// Unzip file to import in temporary file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>temporary file path</returns>
        private void PrepareImportWorker(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;
            var worker = (BackgroundWorker)sender;

            var fileName = (string)args[0];
            var path = (string)args[1];

            worker.ReportProgress(0, new WaitingFormProperties(Resources.ImportPrepare, Resources.ImportExtractFile));
            Directory.CreateDirectory(path);

            using (var zipFile = new ZipFile(fileName))
            {
                zipFile.ExtractAll(path);
            }

            worker.ReportProgress(0, new WaitingFormProperties(Resources.ImportPrepare, Resources.LoadingConfig));

            _configFiles.ReadConfig(path, Program.AppSet, worker, this);
        }
        /// <summary>
        /// import database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>temporary file path</returns>
        private void ImportWorker(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;
            var worker = (BackgroundWorker)sender;

            var pathtmp = (string)args[0];
            var connection = (ConnectionProperties)args[1];
            var importDestinationPath = (string)args[2];

            worker.ReportProgress(0, new WaitingFormProperties(Resources.dbImport, Resources.ImportRestauration));
            Directory.CreateDirectory(pathtmp);

            var pgsql = new Pgsql();
            var result = pgsql.SqlRestore(pathtmp + @"\base.dmp",
                                connection.Host,
                                connection.Port,
                                connection.Database,
                                connection.User,
                                connection.Password);

            result.Wait();

            if (!string.IsNullOrEmpty(result.Result))
            {
                var wLog = new LogViewer();
                wLog.Message = Resources.ImportReport;
                wLog.MessageColor = System.Drawing.Color.Red;
                wLog.Log = result.Result;

                wLog.ShowDialog();
            }

            worker.ReportProgress(0, new WaitingFormProperties(Resources.GeneratingWebSite, Resources.ImportBuildEngine));



            _configFiles.ChangeConfigFilesPath(importDestinationPath);

            Tools.publication(_configFiles, this, true);//save config file and engine

            worker.ReportProgress(0, new WaitingFormProperties(Resources.GeneratingWebSite, Resources.ImportFilesCopying));


            Directory.CreateDirectory(importDestinationPath + @"\tabloid\testxxx");

            Thread.Sleep(3000);

            StreamWriter sw = new StreamWriter("C:\\Test1.txt", true);
            //close the file
            sw.WriteLine(DateTime.Now);

            try
            {
                sw.WriteLine("copy scripts");

                //copy openlayer style
                var scriptPath = pathtmp + @"\scripts";
                Tools.copyFile(@"OpenLayersStyles.js", scriptPath, importDestinationPath + @"\Scripts");
                Tools.copyFile(@"wizstyles.js", scriptPath, importDestinationPath + @"\Scripts");

                //copy uploads files
                sw.WriteLine("copy uploads folder");
                Tools.DirectoryCopy(pathtmp + @"\uploads", importDestinationPath + @"\uploads", true);

                worker.ReportProgress(0, new WaitingFormProperties(Resources.dbImport, Resources.Cleaning));

                Directory.Delete(pathtmp, true);

            }

            catch (Exception ex)
            {
                sw.WriteLine(ex.ToString());
            }
            finally
            {
                sw.Close();
            }

            
        }

    }
}