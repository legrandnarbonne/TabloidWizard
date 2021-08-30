using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes.Control;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard.Classes.WizardTools
{
    static class Tools
    {
        /// <summary>
        /// Open edit setting form and set default config files values
        /// </summary>
        /// <param name="configFiles">Config files to edit</param>
        public static void EditSetting(ConfigFilesCollection configFiles)
        {
            var sf = new SettingForm(false);

            var temp = Program.AppSet;

            sf.propertyGrid1.SelectedObject = temp;

            sf.ShowDialog();

            if (sf.DialogResult == DialogResult.OK)
            {
                Program.AppSet = temp;
                InitNewConfigMenu();

                foreach (XmlFile.ConfigFilesTypes ft in Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)))
                {
                    configFiles.ConfigFiles[(int)ft] = new XmlFile("sources/" + ft + ".config", ft); //get generic .config
                }
            }
        }
        /// <summary>
        /// Make zip file from with file in a specified path
        /// </summary>
        /// <param name="sourcePath">Folder to save</param>
        public static void makeZipSite(string sourcePath, IWin32Window own)
        {
            var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Fichier Zip|*zip";
            saveFileDialog1.Title = "Sauvegarde";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                if (Path.GetExtension(saveFileDialog1.FileName) == "") saveFileDialog1.FileName += ".zip";

                try
                {
                    var _wf = new WaitingForm(makeZipSiteWorker)
                    {
                        Text = TabloidWizard.Properties.Resources.Saving,
                        progressBar = { Style = ProgressBarStyle.Marquee }
                    };

                    _wf.Wr.RunWorkerAsync(new string[] { saveFileDialog1.FileName, sourcePath });
                    _wf.ShowDialog();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(own, Properties.Resources.SavingError + ex, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        /// <summary>
        /// Make zip file of the spécified path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void makeZipSiteWorker(object sender, DoWorkEventArgs e)
        {
            var paths = (string[])e.Argument;
            ZipFile.CreateFromDirectory(paths[1], paths[0]);
        }

        /// <summary>
        /// Copie tabloid engine files
        /// on update (maj=true)
        /// on first save (forceKeepConfig=true)
        /// on click on publish (maj=false, forcekeepConfig=false)
        /// </summary>
        /// <param name="config"></param>
        /// <param name="maj"></param>
        /// <param name="forceKeepConfig"></param>
        public static void publication(ConfigFilesCollection config, IWin32Window own, bool maj = false, bool forceKeepConfig = false)
        {

            var cfg = new publishConfig();


            if (maj)
            {
                //use path from config file
                var path = config.ConfigFiles[0].ConfigFilePath;
                cfg.DestinationPath = path.Substring(0, path.IndexOf("config", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                var fbd = new FolderBrowserDialog();

                DialogResult result = fbd.ShowDialog();

                if (result != DialogResult.OK) return;

                cfg.DestinationPath = fbd.SelectedPath;
            }


            string[] files = Directory.GetFiles(cfg.DestinationPath);

            cfg.KeepWebConfig = forceKeepConfig;

            if (!forceKeepConfig && (files.Length > 0 || Directory.GetDirectories(cfg.DestinationPath).Length > 0))
            {
                var majFrm = new maj(cfg.DestinationPath);

                if (majFrm.ShowDialog() == DialogResult.OK)
                {
                    if (majFrm.chkSAV.Checked) makeZipSite(cfg.DestinationPath, own);
                    cfg.KeepOpenJs = majFrm.chkOpenJs.Checked;
                    cfg.KeepUpload = majFrm.chkUpload.Checked;
                    cfg.KeepWebConfig = majFrm.chkWebConfig.Checked;
                    cfg.KeepImages = majFrm.chkImg.Checked;

                }
                else
                    return;
            }

            Tools.publication(config, cfg, own);
        }

        /// <summary>
        /// Copy tabloid engine to selected path
        /// </summary>
        /// <param name="destinationPath">destination path</param>
        static void publication(ConfigFilesCollection config, publishConfig cfg, IWin32Window own)
        {
            //var wf = new WaitingForm(wrPublication);
            //wf.sho();
            //Thread.Sleep(2000);
            try
            {
                var _wf = new WaitingForm(wrPublication)
                {
                    Text = Properties.Resources.Publishing,
                    progressBar = { Style = ProgressBarStyle.Marquee }
                };

                _wf.Wr.RunWorkerAsync(new object[] { config, cfg, own });
                _wf.ShowDialog();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(own, Properties.Resources.SavingError + ex, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static void wrPublication(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;

            var worker = (BackgroundWorker)sender;
            var cfg = (publishConfig)args[1];
            var configs = (ConfigFilesCollection)args[0];
            var di = new DirectoryInfo(cfg.DestinationPath);

            //verify before deleting if tabloid and config folder exist
            var subFolder = di.GetDirectories();
            if (subFolder.Length > 0)
                if (!subFolder.Any(r => r.FullName.Equals(Path.Combine(di.FullName, "tabloid"), StringComparison.InvariantCultureIgnoreCase)) &&
                    !subFolder.Any(r => r.FullName.Equals(Path.Combine(di.FullName, "configs"), StringComparison.InvariantCultureIgnoreCase)))
                {//if exist warn user before deleting
                    if (MetroMessageBox.Show((IWin32Window)args[2], Properties.Resources.NotTabloidFolderConfirm, Properties.Resources.Information, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No)
                        return;
                }

            //delete file in selected folder
            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Publication, Properties.Resources.RemovingFolderFiles));
            foreach (FileInfo file in di.GetFiles())
            {
                if (!string.Equals(file.Name, "web.config", StringComparison.OrdinalIgnoreCase) || !cfg.KeepWebConfig)
                    file.Delete();
            }

            //delete unnecessary sub-folders in future folder
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                if (!string.Equals(dir.Name, "Uploads", StringComparison.OrdinalIgnoreCase) || !cfg.KeepUpload)
                    if (!string.Equals(dir.Name, "Scripts", StringComparison.OrdinalIgnoreCase) || !cfg.KeepOpenJs)
                        if (!string.Equals(dir.Name, "images", StringComparison.OrdinalIgnoreCase) || !cfg.KeepImages)
                            if (!string.Equals(dir.Name, "Configs", StringComparison.OrdinalIgnoreCase) || !cfg.KeepOpenJs)
                                dir.Delete(true);
            }

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Publication, Properties.Resources.TabloidFileCopy));

            List<String> exclude = new List<String>();


            if (cfg.KeepWebConfig)
                exclude.Add("Web.config");

            try
            {
                DirectoryTool.Copy(@"sources\Tabloid\TabloidProject", cfg.DestinationPath, exclude.ToArray());
                DirectoryTool.Copy(@"sources\Tabloid\Tabloid", cfg.DestinationPath + @"\Tabloid");
                DirectoryTool.Copy(@"sources\Tabloid\Tabloid\bin", cfg.DestinationPath + @"\bin");
            }

            catch
            {
                MetroMessageBox.Show((IWin32Window)args[2], Properties.Resources.SourceFileCopyError, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!cfg.KeepWebConfig)
            {
                worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Publication, Properties.Resources.CustomingConfig));
                ConnManager.personalizeDbProvider(cfg.DestinationPath + @"\web.config");
            }

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Publication, Properties.Resources.Cleanning));
            var v = new DirectoryInfo(cfg.DestinationPath + @"\Tabloid\bin");
            v.Delete(true);

            worker.ReportProgress(0, new WaitingFormProperties(Properties.Resources.Publication, Properties.Resources.SavingConfig));
            configs.updateXML();
            configs.ChangeConfigFilesPath(cfg.DestinationPath);
            configs.SaveConfigFiles(false, (IWin32Window)args[2]);

            //if not exist create dir scripts and upload
            Directory.CreateDirectory(cfg.DestinationPath + @"\uploads");
            Directory.CreateDirectory(cfg.DestinationPath + @"\scripts");
            
            AddDirectorySecurity(cfg.DestinationPath + @"\uploads", "IIS_IUSRS", FileSystemRights.FullControl, AccessControlType.Allow);

            //set authentication mode
            AuthenticationHandler.Set(Program.AppSet.ModeAuthentification);

        }

        /// <summary>
        /// Generate new TabloidConfigMenu
        /// </summary>
        public static void InitNewConfigMenu()
        {
            TabloidConfigMenu.ConfigMenu = new TabloidConfigMenu();
            var mn = new TabloidConfigMenuItem
            {
                Nom = "mn0",
                Titre = "Paramètres",
                Type = TabloidConfigMenuItem.MenuType.Simple
            };

            var mn01 = new TabloidConfigMenuItem
            {
                Nom = "mn01",
                Titre = "Admin. Util.",
                Type = TabloidConfigMenuItem.MenuType.Utilisateur
            };

            mn.SousMenu.Add(mn01);
            TabloidConfigMenu.ConfigMenu.TopMenu.Add(mn);
        }
        /// <summary>
        /// Convert provider type to provider name
        /// </summary>
        public static string ConvertProviderType(Provider p)
        {
            switch (p)
            {
                case Provider.MySql:
                    return "MySql.Data.MySqlClient";
                case Provider.Postgres:
                    return "Npgsql";
            }

            return null;
        }

        /// <summary>
        /// Set listbox datasource from configuration element collection
        /// </summary>
        /// <param name="lst">ListBox to set</param>
        /// <param name="col">Collection to display</param>
        public static void setListBoxFromCollection(ListBox lst, ConfigurationElementCollection col)
        {
            string current = null;

            if (lst.SelectedItem != null) current = lst.SelectedItem.ToString();
            ConfigurationElement[] lsta = new ConfigurationElement[col.Count];
            col.CopyTo(lsta, 0);

            lst.DataSource = null;
            lst.DataSource = lsta;

            if (lst.Items.Count > 0) lst.SelectedIndex = 0;

            if (current != null)
            {
                var i = lst.FindStringExact(current);
                lst.SelectedIndex = i;
            }

            //else propGraph.SelectedObject = null;
        }

        /// <summary>
        /// Set listbox datasource from configuration element collection
        /// </summary>
        /// <param name="lst">ListBox to set</param>
        /// <param name="col">Collection to display</param>
        public static void setGListBoxFromCollection(ListBox lst, ConfigurationElementCollection col, string DoNotDisplayOnProperty = null)
        {
            string current = null;

            if (lst.SelectedItem != null) current = lst.SelectedItem.ToString();

            lst.Items.Clear();

            var usePropertyReflexion = !string.IsNullOrEmpty(DoNotDisplayOnProperty);

            foreach (ConfigurationElement item in col)
            {
                if (!usePropertyReflexion ||
                    !(bool)item.GetType().GetProperty("AutomaticCreation").GetValue(item, null))
                    lst.Items.Add(new GListBoxItem(item));
            }

            if (lst.Items.Count > 0) lst.SelectedIndex = 0;

            if (current != null)
            {
                var i = lst.FindStringExact(current);
                if (i > -1) lst.SelectedIndex = i;
            }


            //else propGraph.SelectedObject = null;
        }

        public static void setTreeViewFromCollection(TreeView tree, ConfigurationElementCollection col, string subCollection, IWin32Window own)
        {


            string current = null;

            if (tree.SelectedNode != null) current = tree.SelectedNode.Name;

            TreeViewHelper.LoadTreeFromCollection(tree, col, "Nom", null, subCollection, own);


            if (current != null && tree.Nodes != null)
            {
                var r = tree.Nodes.Find(current, true);
                if (r.Length > 0)
                    tree.SelectedNode = tree.Nodes.Find(current, true)[0];
            }
            else if (tree.Nodes.Count > 0) tree.SelectedNode = tree.Nodes[0];
        }

        public static void SetDefaultProviderFromAppSet()
        {
            //DataTools.DefaultProviderName = Program.AppSet.ConnectionString
            switch (Program.AppSet.ProviderType)
            {
                case Provider.Postgres:
                    DataTools.DefaultFactory = Npgsql.NpgsqlFactory.Instance;
                    break;
                case Provider.MySql:
                    DataTools.DefaultFactory = MySql.Data.MySqlClient.MySqlClientFactory.Instance;
                    break;
            }
        }

        public static bool isTableExist(string tableName)
        {
            string lastError = "";
            var result = DataTools.Data(SqlCommands.SqlGetTable(), Program.AppSet.ConnectionString, out lastError);

            foreach (DataRow dr in result.Rows)
            {
                if (dr[0].ToString().ToLower() == tableName.ToLower()) return true;
            }

            return false;
        }
        /// <summary>
        /// Search for a field name for a given table
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        /// <returns>true if exist</returns>
        public static bool isFieldExist(string fieldName, string tableName, string schema)
        {
            string lastError;
            var tableColumnsList = DataTools.Data(SqlCommands.SqlGetColums(tableName, schema), Program.AppSet.ConnectionString, out lastError);//c0
            if (!string.IsNullOrEmpty(lastError)) throw new Exception(lastError);

            var fieldColumnName = tableColumnsList.Columns[0].ColumnName;

            fieldName = DataTools.StringToSql(fieldName);

            return tableColumnsList.Select($"{fieldColumnName} like '{fieldName}'").Length > 0;//warning request with .net engine non need to convert like
        }

        /// <summary>
        /// Search for a field name for a given table
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        /// <returns>true if exist</returns>
        public static bool isConstraintExist(string constraintName, string schema)
        {
            string lastError;
            var ConstraintList = DataTools.Data(SqlCommands.SqlGetForeignKey(null, schema), Program.AppSet.ConnectionString, out lastError);//c0
            if (!string.IsNullOrEmpty(lastError)) throw new Exception(lastError);

            var constraintColumnName = ConstraintList.Columns[3].ColumnName;

            return ConstraintList.Select($"{constraintColumnName} {SqlConverter.GetSql(SqlConverter.SqlType.Ilike)} '{constraintName}'").Length > 0;
        }

        /// <summary>
        /// Build schema list from connection string
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static string[] GetSearchPath(string connectionString)
        {
            var connectionPart = connectionString.Split(';');

            var searchPath = connectionPart.FirstOrDefault(s => s.StartsWith("SearchPath=", StringComparison.InvariantCultureIgnoreCase));

            if (string.IsNullOrEmpty(searchPath)) return null;

            var searchPathPart = searchPath.Split('=');

            if (searchPathPart.Length == 0) return null;

            return searchPathPart[1].Split(',');
        }

        /// <summary>
        /// Add configuration element to a collection and set unique name.
        /// Warning do not scan for child element in the collection
        /// </summary>
        /// <param name="globalCollection">collection</param>
        /// <param name="e">element to add</param>
        /// <param name="prefix">prefix to use in name</param>
        /// <param name="prefix">Collection to add new item if null item is added on globalCollection</param>
        public static string AddWithUniqueName(ConfigurationElementCollection globalCollection, ConfigurationElement e, string prefix, ConfigurationElementCollection parentCollection = null, int position = -1)
        {
            var i = 0;
            var propertyInfo = e.GetType().GetProperty("Nom");

            while (true)
            {
                i++;
                var name = prefix + i;

                var type = globalCollection.GetType();

                if ((bool)type.GetMethod("Contains", new[] { typeof(string) }).Invoke(globalCollection, new object[] { name })) continue;

                propertyInfo.SetValue(e, name, null);

                var method = position == -1 ? "Add" : "Insert";
                var types = position == -1 ? new[] { typeof(ConfigurationElement) } : new[] { typeof(int), typeof(ConfigurationElement) };
                var objects = position == -1 ? new object[] { e } : new object[] { 0, e };


                if (parentCollection == null)
                    type.GetMethod(method, types).Invoke(globalCollection, objects);
                else
                {
                    var parentType = parentCollection.GetType();
                    parentType.GetMethod(method, types).Invoke(parentCollection, objects);
                }

                return name;
            }
        }

        public static void copyFile(string sourceName, string sourcePath, string destPath)
        {

            var file = new FileInfo(sourcePath + "\\" + sourceName);

            if (file.Exists)
                file.CopyTo(destPath + "\\" + sourceName, true);

        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, string[] excludedSubFolders = null, string[] contentExcludedSubFolders = null)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    if (!isExcludedFolder(tempPath, excludedSubFolders))
                        DirectoryCopy(subdir.FullName, tempPath, copySubDirs, excludedSubFolders);
                }
            }
        }

        private static bool isExcludedFolder(string path, string[] excludedSubFolders)
        {
            if (excludedSubFolders == null) return false;

            foreach (string excludedFolder in excludedSubFolders)
            {
                if (path.EndsWith(excludedFolder, StringComparison.InvariantCultureIgnoreCase)) return true;
            }

            return false;
        }

        /// <summary>
        /// set folder permission
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Account"></param>
        /// <param name="Rights"></param>
        /// <param name="ControlType"></param>
        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            dSecurity.AddAccessRule(
                new FileSystemAccessRule(
                    Account,
                    Rights,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    ControlType));
            dInfo.SetAccessControl(dSecurity);
        }

        class publishConfig
        {
            public bool KeepWebConfig { get; set; }

            public bool KeepImages { get; set; }
            public bool KeepOpenJs { get; set; }
            public bool KeepUpload { get; set; }

            public string DestinationPath { get; set; }
        }
    }
}
