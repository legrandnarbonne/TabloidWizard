
using System;
using System.Data;
using System.Data.Common;
using System.Xml;

namespace TabloidWizard.Classes.WizardTools
{
    public static class ConnManager
    {
        public static DataRow GetConn(Provider provider)
        {
            var factories = DbProviderFactories.GetFactoryClasses();

            var invariantName = Tools.ConvertProviderType(provider);


            foreach (DataRow row in factories.Rows)
            {
                if (string.Equals(row["InvariantName"],invariantName))
                    return row;
            }

            return null;
        }
        /// <summary>
        /// Use installed provider warning wizard must be run on serveur
        /// </summary>
        /// <param name="WebConfigPath"></param>
        /// <returns></returns>
        public static void personalizeDbProvider(string WebConfigPath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(WebConfigPath);

            XmlNode dbProviderNode = xDoc.SelectSingleNode("configuration/system.data/DbProviderFactories");

            dbProviderNode.RemoveAll();

            foreach (Provider p in Enum.GetValues(typeof(Provider)))
            {
                var factorie = GetConn(p);

                if (factorie != null)
                {
                    XmlElement remove = xDoc.CreateElement("remove");
                    remove.SetAttribute("invariant", factorie["InvariantName"].ToString());
                    dbProviderNode.AppendChild(remove);

                    XmlElement add = xDoc.CreateElement("add");
                    add.SetAttribute("name", factorie["Name"].ToString());
                    add.SetAttribute("invariant", factorie["InvariantName"].ToString());
                    add.SetAttribute("description", factorie["Description"].ToString());
                    add.SetAttribute("type", factorie["AssemblyQualifiedName"].ToString());
                    dbProviderNode.AppendChild(add);
                }
            }

            xDoc.Save(WebConfigPath);
        }

        //public static XmlNode GetConnNode(Provider provider)
        //{     <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.8.6.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />

        //    var XmlRemoveNode = new XmlElement();//<remove invariant="MySql.Data.MySqlClient" />
        //    XmlRemoveNode.SetAttribute("invariant","MySql.Data.MySqlClient");
        //    var factories = DbProviderFactories.GetFactoryClasses();
        //    return "";
        //    //foreach()
        //}
    }
}
