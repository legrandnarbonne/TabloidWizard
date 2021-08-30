/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 26/02/2013
 * Time: 18:22
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using Tabloid.Classes.Objects;
using TabloidWizard.Classes.Tools;
using static TabloidWizard.Classes.Tools.AuthenticationHandler;

namespace TabloidWizard.Classes
{
    public enum Provider
    {
        MySql,
        Postgres
    }

    public enum TabloidTypes
    {
        Default,
        Questionnaire
    }
    [Serializable]
    /// <summary>
    ///     Description of appSetting.
    /// </summary>
    public class AppSetting
    {
        [Category("Serveur"), Description("URL du site")]
        public string URL { get; set; }

        [Category("Thème"), Description("")]
        public Tabloid.Classes.Optimisation.BundleConfig.Themes theme { get; set; }

        [Category("Mail"), Description("Serveur SMTP")]
        public string SMTPServer { get; set; }

        [Category("Mail"), Description("Mail administrateur")]
        public string MailAdmin { get; set; }

        [Category("Mail"), Description("Mail pour envoi des messages")]
        public string SMTPFrom { get; set; }

        [Category("S.M.S."), Description("Utilisateur SMSBox")]
        public string smsBoxUser { get; set; }

        [Category("S.M.S."), Description("Mot de passe SMSBox")]
        public string smsBoxPassword { get; set; }

        [Category("S.M.S."), Description("Clef de cryptage")]
        public string EncryptionKey { get; set; }

        [Category("Auto enrollement"), Description("domaine netbios")]
        public string AutoenrollmentDomain { get; set; }

        [Category("Auto enrollement"), Description("login du compte à utiliser pour requêter le LDAP")]
        public string AutoenrollmentUtil { get; set; }

        [Category("Auto enrollement"), Description("mot de passe du profil de requête")]
        public string AutoenrollmentMdp { get; set; }

        [Category("Auto enrollement"), Description("id du rôle à affecter aux nouveaux profils")]
        public string AutoenrollmentRole { get; set; }

        [Category("Database"), Description("Chaine de connection")]
        public string ConnectionString { get; set; }

        string _schema;
        [Category("Database"), Description("Schema postgres par defaut")]
        public string Schema
        {
            get
            {
                return _schema;
            }
            set
            {
                _schema = value;
            }
        }

        [Category("Database"), Description("Type de base")]
        public Provider ProviderType { get; set; }

        [Category("Database"), Description("Identifiant de paramètre (@ pour postgrés ? pour MySql")]
        public string identParam { get; set; }

        [Category("Suivi"), Description("Liste des adresses mails pour l'envoi des alertes de suppression. Le  séparateur est la virgule.")]
        public string mailSuiviSupp { get; set; }

        [Category("Suivi"), Description("Liste des adresses mails pour l'envoi des alertes de création. Le  séparateur est la virgule.")]
        public string mailSuiviCrea { get; set; }

        [Category("Suivi"), Description("Liste des adresses mails pour l'envoi des alertes de modification. Le  séparateur est la virgule.")]
        public string mailSuiviModif { get; set; }

        [Category("Suivi"), Description("Liste des adresses mails pour l'envoi des alertes d'ouverture de session. Le  séparateur est la virgule.")]
        public string mailSuiviSessionStart { get; set; }

        [Category("Suivi"), Description("Liste des adresses mails pour l'envoi des alertes de fin de session. Le  séparateur est la virgule.")]
        public string mailSuiviSessionEnd { get; set; }

        [Category("Géographie"),
         Description(
             "URL de MapServer. Par exemple map/cgi-bin/mapserv.exe?map=F:/Data/MapFiles/Mon_projet/map/mapfile/map.map."
             )]
        public string Map { get; set; }

        [Category("Géographie"), Description("URL du proxy. N'est plus utilisé")]
        public string Proxy { get; set; }

        [Category("Géographie"), Description("Etendue de la carte. Utiliser la vergule comme séparateur")]
        public string Bounds { get; set; }

        [Category("Géographie"), Description("Définition des niveaux de zooms.")]
        public string Zooms { get; set; }

        [Category("Géographie"),
         Description(
             "URL du raster. Par exemple dans le cas d'un serveur TileCache dans un rertoire map : map/tilecache/tilecache.cgi?"
             )]
        public string RasterUrl { get; set; }

        [Category("Géographie"), Description("Nom de la couche raster dans le mapfile.")]
        public string RasterLayerName { get; set; }

        [Category("Géographie"), Description("Niveau de zoom suite à une recherche GPS."), DefaultValue(12)]
        public string GPSLocationZoomLevel { get; set; }

        [Category("Géographie"), Description("Clef de l'API Google.")]
        public string GoogleAPIKey { get; set; }

        [Category("Géographie"), Description("Clef de l'API IGN.")]
        public string IGNAPIKey { get; set; }

        [Category("SSL-Netasq"), Description("Adresse IP du Netasq.")]
        public string SSOIP { get; set; }

        [Category("SSL-Netasq"), Description("Nom du paramètre dans la requête contenant le nom de l'utilisateur.")]
        public string SSOUtilVar { get; set; }

        [Category("Divers"), Description("Chemin disque absolu pour le stockage des logs.")]
        public string TabloidLogsPath { get; set; }

        [Category("Divers"), Description("Chemin disque absolu pour le stockage des graphiques de statistique.")]
        public string ChartImageHandler { get; set; }

        [Category("Divers"), Description("Titre de l'application")]
        public string Titre { get; set; }

        [Category("Divers"), Description("Icone (Font-awesome)")]
        public string Icone { get; set; }

        [Category("Ouverture de session"), Description("URL de la page d'accueil")]
        public string pageDefaut { get; set; }

        [Category("Ouverture de session"), Description("Nom du champ de la table role contenant l'URL de la page d'accueil pour une gestion de la page d'accueil en fonction du profil")]
        public string champPageDefaut { get; set; }

        [Category("Ouverture de session"), Description("Autoriser un profil 'Anonymous'")]
        public bool AllowAnonymous { get; set; }

        [Category("Ouverture de session"), Description("Type d'authentification désirée")]
        public AuthenticationType ModeAuthentification { get; set; }

        [Category("Ouverture de session"), Description("Utiliser les groupe de sécurité d'un LDAP"),DefaultValue(false)]
        public bool UseLDAPSecurityGroup { get; set; }

        [Category("Divers"), Description("Active le mode débug SQL si égal à oui"), DefaultValue("oui")]
        public string sqlDebug { get; set; }

        [Category("Divers"),
         Description("Active la création automatique de valideur (contraintes lièes aux types) sur tout les champs")]
        public string valideurAuto { get; set; }

        [Category("Divers"),
        Description("Chaine de caractères quelconque permettant l'encryption de donnée par le moteur. Attention la modification de cette chaine impactera les mots de passes de utilisateurs si vous utilisez une authentification par formulaire!")]
        public string grainDeSable { get; set; }

        [Category("Divers"),
         Description(
             "Limite le nombre de destinataire des mails. Les envois sont tronçonnés pour ne contenir au maximum le nombre de destinataires correspondant à cette propriété."
             )]
        public string splitMail { get; set; }

        [Category("Datagouv"), Description("Clef de l'API data.gouv.fr.")]
        public string DataGouvAPIKey { get; set; }

        [Category("Datagouv"), Description("URL de l'API data.gouv.fr.")]
        public string DataGouvUri { get; set; }

        [Category("Etiquette"), Description("Entier représentant la largeur des etiquettes en mm.")]
        public String labelWidth { get; set; }

        [Category("Etiquette"), Description("Entier représentant la hauteur des etiquettes en mm.")]
        public String labelHeight { get; set; }

        [Category("Divers"),Description("Permet un mode de fonctionnement spécifique de type questionnaire par exemple.")]
        public TabloidTypes TabloidType { get; set; }
        
        [Category("Démarches simplifiées"), Description("Clef API demarches simplifiées.")]
        public String DSKey { get; set; }

        [Category("Démarches simplifiées"), Description("URL de l'API demarches simplifiées.")]
        public String DSURL { get; set; }


        /// <summary>
        ///     Set properties from app.config
        /// </summary>
        /// <param name="src">xmlFile witch contain web.config</param>
        /// <param name="remove">remove node when readed</param>
        public void ReadAppSetting(XmlFile src, bool remove)
        {
            foreach (var pi in GetType().GetProperties())
            {
                switch (pi.Name)
                {
                    default:
                        object val = src.GetValueFromKey("/appSettings/add", pi.Name, remove);

                        if (pi.PropertyType.Name == "Boolean") val = Convert.ToBoolean(val);
                        if (pi.PropertyType.BaseType.Name == "Enum" && val != null) val = Enum.Parse(pi.PropertyType, val.ToString()) as Enum;

                        pi.SetValue(this, val, null);

                        break;
                }
            }



            if (remove) src.RemoveNode("/configuration/connectionStrings/add[@name='TabloidConnection']");
        }
        public void ReadConnectionSetting(XmlFile src, bool remove, IWin32Window own)
        {
            foreach (var pi in GetType().GetProperties())
            {
                switch (pi.Name)
                {
                    case "ConnectionString":
                        ConnectionString = src.GetAttributeFromCollection("/connectionStrings/add",
                            "TabloidConnection", "connectionString");
                        break;

                    case ("ProviderType"):

                        DataTools.DefaultProviderName = src.GetAttributeFromCollection("/connectionStrings/add",
                                "TabloidConnection", "providerName");

                        ProviderType = GetProviderType(DataTools.DefaultProviderName);
                        WizardTools.Tools.SetDefaultProviderFromAppSet();
                        SqlCommands.Provider = ProviderType;
                        break;
                }
            }

            if (string.IsNullOrEmpty(Schema))//set schéma for old version
                if (MetroMessageBox.Show(own,Properties.Resources.AddSchema, Properties.Resources.Confirmation, MessageBoxButtons.OKCancel)
                    == DialogResult.OK)
                {
                    setSchemaFromConnectionString(ProviderType);
                    WizardSQLHelper.SetAllViewSchema(Schema);
                }

            if (remove) src.RemoveNode("/connectionStrings/add[@name='TabloidConnection']");
        }




        /// <summary>
        /// Return schéma from connexion string
        /// </summary>
        /// <param name="providerType"></param>
        public static void setSchemaFromConnectionString(Provider providerType)
        {
            string sch = null;
            var schs = GetSchemaList(providerType);

            if (providerType == Provider.Postgres)
            {
                sch = Array.Find(schs, s => !string.Equals(s, "public", StringComparison.OrdinalIgnoreCase));
            }
            else if (providerType == Provider.MySql)
            {
                sch = schs[0];
            }

            Program.AppSet.Schema = sch;
        }

        /// <summary>
        ///     build app setting nodes from setting
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        public static string GetAppSettingNodes(AppSetting settings, bool indent)
        {
            var result = "";

            foreach (var prop in settings.GetType().GetProperties())
            {
                var val = prop.GetValue(settings, null);
                if (val != null)
                    switch (prop.Name)
                    {
                        case "ConnectionString":
                        case "ProviderType":
                            break;

                        default:
                            if (indent) result += "\t";
                            result += string.Format("<add key=\"{0}\" value=\"{1}\"/>\n", prop.Name, val);
                            break;
                    }
            }

            return result;
        }

        private static string GetProviderName(Provider p)
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

        private static Provider GetProviderType(string p)
        {
            switch (p)
            {
                case "MySql.Data.MySqlClient":
                    return Provider.MySql;

                case "Npgsql":
                    return Provider.Postgres;
            }

            return Provider.MySql;
        }
        /// <summary>
        /// Get schema list from postgres connection string or database propertie for mysql
        /// </summary>
        /// <returns></returns>
        public static string[] GetSchemaList(Provider provider)
        {
            var schemaList = new List<string>();
            var props = Program.AppSet.ConnectionString.Split(';');

            var iprops = Array.FindIndex(props, p => p.StartsWith(provider == Provider.Postgres ? "SearchPath" : "DataBase", StringComparison.OrdinalIgnoreCase));

            return props[iprops].Split('=')[1].Split(',');
        }

        public static string GetConnectionStringsNodes(AppSetting settings, bool indent)
        {
            return string.Format(
                "{2}<add name=\"TabloidConnection\" connectionString=\"{0}\" providerName=\"{1}\"/>"
                , settings.ConnectionString, GetProviderName(settings.ProviderType), indent ? "\t" : "");
        }

        /// <summary>
        /// Set default start page
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <param name="type">view display type default List</param>
        public static void setDefaultPage(string viewName, TabloidPages.Type type = TabloidPages.Type.Liste)
        {
            Program.AppSet.pageDefaut = GetDefaultPageURL(viewName,type);
        }

        /// <summary>
        /// Set default start page
        /// </summary>
        /// <param name="viewName">View name</param>
        /// <param name="type">view display type default List</param>
        public static string GetDefaultPageURL(string viewName, TabloidPages.Type type = TabloidPages.Type.Liste)
        {
            return TabloidPages.BSRelativeUrl[type] + "?table=" + viewName;
        }

        public class Connexion
        {
            public string Host { get; set; }
            public string Password { get; set; }
            public string UserID { get; set; }
            public string Database { get; set; }
            public string Port { get; set; }

            public string[] SearchPath { get; set; }
            
                
            /// <summary>
            /// Split connection string
            /// 
            /// </summary>
            public Connexion(string connStr)
            {
                Host=GetConnStringPropValue("Host", connStr)[0];
                Port=GetConnStringPropValue("Port", connStr)[0];
                UserID = GetConnStringPropValue("User ID", connStr)[0];
                Password =GetConnStringPropValue("Password", connStr)[0];
                Database = GetConnStringPropValue("Database", connStr)[0];
                SearchPath =GetConnStringPropValue("SearchPath", connStr); 
            }

            public static string[] GetConnStringPropValue(string propName, string connStr)
            {
                var schemaList = new List<string>();
                var props = connStr.Split(';');

                var iprops = Array.FindIndex(props, p => p.StartsWith(propName, StringComparison.OrdinalIgnoreCase));

                return props[iprops].Split('=')[1].Split(',');
            }
        }
    }
}