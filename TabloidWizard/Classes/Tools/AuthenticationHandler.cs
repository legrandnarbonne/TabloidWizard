
using System.Windows.Forms;
using System.Xml.Linq;

namespace TabloidWizard.Classes.Tools
{
    public static class AuthenticationHandler
    {
        public enum AuthenticationType { Anonyme, Formulaire, Windows }

        /// <summary>
        /// Set web.config file to use selected authentication
        /// </summary>
        /// <param name="type"></param>
        public static void Set(AuthenticationType type)
        {
            var config = XDocument.Load($"{Program.CurrentProjectFolder}/Web.config");

            switch (type)
            {
                case AuthenticationType.Anonyme:
                    setIISAuthenticationType(config, false);
                    setFormAuthentication(config, true);
                    break;
                case AuthenticationType.Formulaire:
                    setIISAuthenticationType(config, false);
                    setFormAuthentication(config, true);
                    break;
                case AuthenticationType.Windows:
                    setIISAuthenticationType(config, true);
                    setFormAuthentication(config, false);
                    break;
            }

            config.Save($"{Program.CurrentProjectFolder}/Web.config");
        }

        /// <summary>
        /// Manage form declaration
        /// </summary>
        /// <param name="config">config to modify</param>
        /// <param name="addFormDeclaration">if true add form declaration. if false form declaration node is removed</param>
        private static void setFormAuthentication(XDocument config, bool addFormDeclaration)
        {
            //<!--<authentication mode="Forms">
            //  <forms name=".ASPXFORMSAUTH" defaultUrl="~/tabloid/BSabout.aspx" loginUrl="~/tabloid/login/BSLogin.aspx" protection="None" timeout="30" />
            //</authentication>!-->
            //redirect authentication to form
            var targetNode = config.Root.Element("system.web");
            var authentication = targetNode.Element("authentication");

            if (authentication == null)
            {
                if (!addFormDeclaration) return;

                authentication = new XElement("authentication",new XAttribute("mode", "Forms"));
                targetNode.Add(authentication);
            }
            

            if (!addFormDeclaration)
            {
                authentication.Remove();
                return;
            }

            var forms = new XElement("forms",
                new XAttribute("name", ".ASPXFORMSAUTH"),
                new XAttribute("defaultUrl", "~/tabloid/BSabout.aspx"),
                new XAttribute("loginUrl", "~/tabloid/login/BSLogin.aspx"),
                new XAttribute("protection", "None"),
                new XAttribute("timeout", "30"));

            authentication.RemoveNodes();
            authentication.Add(forms);
        }

        /// <summary>
        /// Set IIS authentication type 
        /// </summary>
        /// <param name="windows">if true windows authentication is set. if false anonymous authentication will be used</param>
        static void setIISAuthenticationType(XDocument config,bool windows)
        {
            var parentNode = config.Root.Element("system.webServer")
                                        .Element("security")
                                        .Element("authentication");
            //set anonymous authentication
            var targetNode = config.Root.Element("system.webServer")
                                        .Element("security")
                                        .Element("authentication")
                                        .Element("anonymousAuthentication");
            if (targetNode == null)
            {
                targetNode = new XElement("anonymousAuthentication", new XAttribute("enabled", "True"));
                parentNode.Add(targetNode);
            }


            targetNode.Attribute("enabled").Value = (!windows).ToString();

            //set windows authentication
            targetNode = config.Root.Element("system.webServer")
                                        .Element("security")
                                        .Element("authentication")
                                        .Element("windowsAuthentication");

            if (targetNode == null)
            {                
                targetNode = new XElement("windowsAuthentication", new XAttribute("enabled", "True"));
                parentNode.Add(targetNode);
            }

            targetNode.Attribute("enabled").Value = windows.ToString();
        }
        
    }
}
