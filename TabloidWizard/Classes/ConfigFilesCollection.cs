
using MetroFramework;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Config.Helper;
using TabloidWizard.Properties;

namespace TabloidWizard.Classes
{
    public class ConfigFilesCollection
    {
        public XmlFile[] ConfigFiles;
        public ConfigFilesCollection()
        {
            ConfigFiles = new XmlFile[Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)).Length];
        }
        /// <summary>
        /// Return site path
        /// </summary>
        public string ProjectFolderPath
        {
            get
            {
                return ConfigFiles[0].ConfigFilePath.Substring(0, ConfigFiles[0].ConfigFilePath.Length - 27);
            }
        }
        /// <summary>
        /// Return site config path
        /// </summary>
        public string ConfigFolderPath
        {
            get
            {
                return ConfigFiles[0].ConfigFilePath.Substring(0, ConfigFiles[0].ConfigFilePath.Length - 19);
            }
        }

        /// <summary>
        /// Change path in configFile object
        /// </summary>
        /// <param name="newPath"></param>
        public void ChangeConfigFilesPath(string newPath)
        {
            foreach (var ft in Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)))
            {
                ConfigFiles[(int)ft].ConfigFilePath = newPath + "\\configs\\" + ft + ".config";
            }
        }
        /// <summary>
        /// Write xml config files
        /// </summary>
        /// <param name="promptOnExist"></param>
        public void SaveConfigFiles(bool promptOnExist, IWin32Window own)
        {
            if (ConfigFiles == null) return;

            Directory.CreateDirectory(ConfigFolderPath); //create if not exist

            if (Directory.GetFiles(ConfigFolderPath, "*.config").Length > 0)//prompt if a file exist
                if (promptOnExist)
                    if (
                        MetroMessageBox.Show(own,Properties.Resources.ReplaceConfigFile,
                        Properties.Resources.Information,
                            MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

            //Save file
            foreach (var ft in Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)))
            {
                var configFile = ConfigFiles[(int)ft];

                var fi = new FileInfo(configFile.ConfigFilePath);
                if (fi.Exists)
                    fi.CopyTo(Path.GetDirectoryName(configFile.ConfigFilePath) + "\\" + Path.GetFileNameWithoutExtension(configFile.ConfigFilePath) + ".bak", true);

                configFile.Save();
            }

            Program.CurrentProjectFolder = ProjectFolderPath;
        }

        /// <summary>
        /// Generate xmlfile object from tabloidconfig
        /// </summary>
        public void updateXML()
        {
            // set config file
            var cf = ConfigFiles[(int)XmlFile.ConfigFilesTypes.tabloid];
            var n = cf.Xml.SelectSingleNode("/Tabloid");

            //remove automatic created view
            foreach (TabloidConfigView v in TabloidConfig.Config.Views)
                if (v.AutomaticCreation) TabloidConfig.Config.Views.Remove(v);


            //Add current config to file
            var tabloid = TabloidConfig.Config.Serialize();

            //restaure automatic created view
            AutomaticViewBuilder.SetTable(Program.AppSet.Schema);

            if (n != null) n.InnerXml = tabloid == "" ? "" : tabloid.Substring(9, tabloid.Length - 19);

            // set config menu file
            ConfigFiles[(int)XmlFile.ConfigFilesTypes.tabloidMenu].Xml.InnerXml = TabloidConfigMenu.ConfigMenu.Serialize();
            // set appSettings menu file
            var nt = ConfigFiles[(int)XmlFile.ConfigFilesTypes.appSettings].Xml.SelectSingleNode("/appSettings");
            if (nt != null) nt.InnerXml = "\n" + AppSetting.GetAppSettingNodes(Program.AppSet, true);
            // set connectionStrings menu file
            nt = ConfigFiles[(int)XmlFile.ConfigFilesTypes.connections].Xml.SelectSingleNode("/connectionStrings");
            if (nt != null) nt.InnerXml = "\n" + AppSetting.GetConnectionStringsNodes(Program.AppSet, true) + "\n";
        }

        public void ReadConfig(string folderName,AppSetting appSet, BackgroundWorker worker, IWin32Window own)
        {
            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.LodingConfigFiles));
            foreach (XmlFile.ConfigFilesTypes ct in Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)))
            {
                var fi = new FileInfo(folderName + "\\configs\\" + ct + ".config");


                if (fi.Exists)
                {
                    ConfigFiles[(int)ct] = new XmlFile(fi.FullName, ct);
                }
                else
                {
                    MetroMessageBox.Show(own, Resources.MainForm_ReadWebConfig_Ce_dossier_ne_contient_pas_de_fichier_config_web,
                        Resources.Erreur, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            DeserializeMainTabloidConfig(own);

            //read appsetting properties
            appSet.ReadAppSetting(ConfigFiles[(int)XmlFile.ConfigFilesTypes.appSettings], true);
            appSet.ReadConnectionSetting(ConfigFiles[(int)XmlFile.ConfigFilesTypes.connections], true, own);

            ////read tabloid config menu
            var tabloidmn = ConfigFiles[(int)XmlFile.ConfigFilesTypes.tabloidMenu].Xml.SelectSingleNode("/TabloidMenu");
            if (tabloidmn != null)
            {
                TabloidConfigMenu.Deserialize("<TabloidMenu>" + tabloidmn.InnerXml + "</TabloidMenu>");

                tabloidmn.InnerXml = ""; //remove tabloid content when readed
            }

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.LodingGeoStyle));
            //read olstyle file
            OlStyleCollection.Load(folderName);

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.AutomaticViewBuilding));
            AutomaticViewBuilder.SetTable(appSet.Schema);//automatic view is added on load and remove on save

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.Validation));
            WizardEvents.onConfigLoaded(appSet.Schema, own);
        }

        /// <summary>
        /// Deserialize main tabloid config file
        /// </summary>
        public void DeserializeMainTabloidConfig( IWin32Window own)
        {
            var tabloid = ConfigFiles[(int)XmlFile.ConfigFilesTypes.tabloid].Xml.SelectSingleNode("/Tabloid");
            if (tabloid != null)
            {
                try
                {
                    TabloidConfig.Deserialize("<Tabloid>" + tabloid.InnerXml + "</Tabloid>");

                    tabloid.InnerXml = ""; //remove tabloid content when readed

                    WizardEvents.OnDeserialize();
                }
                catch (Exception e)
                {
                    MetroMessageBox.Show(own, "Erreur au chargement de la configuration :" + e.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

    }
}
