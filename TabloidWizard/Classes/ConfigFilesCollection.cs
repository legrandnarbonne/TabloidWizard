
using MetroFramework;
using System;
using System.IO;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Config.Helper;

namespace TabloidWizard.Classes
{
    public class ConfigFilesCollection
    {
        public XmlFile[] _configFiles;
        public ConfigFilesCollection()
        {
            _configFiles = new XmlFile[Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)).Length];
        }
        /// <summary>
        /// Return site path
        /// </summary>
        public string ProjectFolderPath
        {
            get
            {
                return _configFiles[0].ConfigFilePath.Substring(0, _configFiles[0].ConfigFilePath.Length - 27);
            }
        }
        /// <summary>
        /// Return site config path
        /// </summary>
        public string ConfigFolderPath
        {
            get
            {
                return _configFiles[0].ConfigFilePath.Substring(0, _configFiles[0].ConfigFilePath.Length - 19);
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
                _configFiles[(int)ft].ConfigFilePath = newPath + "\\configs\\" + ft + ".config";
            }
        }
        /// <summary>
        /// Write xml config files
        /// </summary>
        /// <param name="promptOnExist"></param>
        public void SaveConfigFiles(bool promptOnExist, IWin32Window own)
        {
            if (_configFiles == null) return;

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
                var configFile = _configFiles[(int)ft];

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
            var cf = _configFiles[(int)XmlFile.ConfigFilesTypes.tabloid];
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
            _configFiles[(int)XmlFile.ConfigFilesTypes.tabloidMenu].Xml.InnerXml = TabloidConfigMenu.ConfigMenu.Serialize();
            // set appSettings menu file
            var nt = _configFiles[(int)XmlFile.ConfigFilesTypes.appSettings].Xml.SelectSingleNode("/appSettings");
            if (nt != null) nt.InnerXml = "\n" + AppSetting.GetAppSettingNodes(Program.AppSet, true);
            // set connectionStrings menu file
            nt = _configFiles[(int)XmlFile.ConfigFilesTypes.connections].Xml.SelectSingleNode("/connectionStrings");
            if (nt != null) nt.InnerXml = "\n" + AppSetting.GetConnectionStringsNodes(Program.AppSet, true) + "\n";
        }

    }
}
