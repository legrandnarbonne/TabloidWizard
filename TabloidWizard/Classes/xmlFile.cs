/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 23/02/2013
 * Time: 16:24
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace TabloidWizard.Classes
{
    /// <summary>
    ///     Description of projectFile.
    /// </summary>
    public class XmlFile
    {
        public string ConfigFilePath;
        public ConfigFilesTypes ConfigType;
        public XmlDocument Xml;
        public enum ConfigFilesTypes { appSettings, connections, tabloid, tabloidMenu };

        public XmlFile(string folderName, ConfigFilesTypes t)
        {
            ConfigType = t;
            ConfigFilePath = folderName;
            Read();
        }

        public void RemoveNode(string path)
        {
            var n = Xml.SelectSingleNode(path);
            RemoveNode(n);
        }

        private static void RemoveNode(XmlNode n)
        {
            if (n == null) return;
            if (n.ParentNode == null) return;
            n.ParentNode.RemoveChild(n);
        }

        /// <summary>
        /// serialize xml
        /// </summary>
        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ConfigFilePath));//create path if not exist
            using (TextWriter sw = new StreamWriter(ConfigFilePath, false, Encoding.UTF8)) //Set encoding
            {
                Xml.Save(sw);
            }
        }
        /// <summary>
        /// Read xml file
        /// </summary>
        private void Read()
        {
            Xml = new XmlDocument();
            Xml.Load(ConfigFilePath);
        }

        #region project properties


        private XmlNode GetNodeFromCollection(string collectionPath, string name, string key)
        {
            var xnList = Xml.SelectNodes(collectionPath);
            return xnList == null ?
                null :
                xnList.Cast<XmlNode>().FirstOrDefault(n => n.Attributes != null && n.Attributes[key].Value == name);
        }

        public string GetAttributeFromCollection(string collectionPath, string name, string attribute)
        {
            var n = GetNodeFromCollection(collectionPath, name, "name");
            return n.Attributes == null ? null : n.Attributes[attribute].Value;
        }

        public string GetValueFromKey(string collectionPath, string key, bool remove)
        {
            var n = GetNodeFromCollection(collectionPath, key, "key");
            if (n == null) return null;
            if (remove) RemoveNode(n);
            return n.Attributes == null ? null : n.Attributes["value"].Value;
        }

        #endregion project properties
    }
}