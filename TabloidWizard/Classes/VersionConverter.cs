namespace TabloidWizard.Classes
{
    internal static class VersionConverter
    {
        public static readonly RenamedObject[] Renamed =
        {
            new RenamedObject("Tabloid.Classes.Tools.tabloidConfig", "Tabloid.Classes.Config.TabloidConfig"),
            new RenamedObject("Tabloid.Classes.Tools.tabloidConfigMenu", "Tabloid.Classes.Config.TabloidConfigMenu"),
            new RenamedObject("editeur=\"btn", "editeur=\"Btn"),
            new RenamedObject("defaut","Defaut"),
            new RenamedObject("textBox","TextBox"),
            new RenamedObject("mail","Mail"),
            new RenamedObject("mobile","Mobile"),
            new RenamedObject("QRReader","QrReader"),
            new RenamedObject("label","Label"),
            new RenamedObject("autoCompleteTextBox","AutoCompleteTextBox"),
            new RenamedObject("memo","Memo"),
            new RenamedObject("comboBox","ComboBox"),
            new RenamedObject("dropDownCheckList","DropDownCheckList"),
            new RenamedObject("comboBoxPlus","ComboBoxPlus"),
            new RenamedObject("cascadingComboBox","CascadingComboBox"),
            new RenamedObject("checkBox","CheckBox"),
            new RenamedObject("fileUpload","FileUpload"),
            new RenamedObject("cmdSup","CmdSup"),
            new RenamedObject("listBox","ListBox"),
            new RenamedObject("masque","Masque"),
            new RenamedObject("picture","Picture"),
            new RenamedObject("collapsibleList","CollapsibleList"),
            new RenamedObject("concat","Concat"),
            //tabloid config menu types
            new RenamedObject("type=\"liste","type=\"Liste"),
            new RenamedObject("type=\"detail","type=\"Detail"),
            new RenamedObject("type=\"carte","type=\"Carte"),
            new RenamedObject("type=\"url","type=\"Url"),
            new RenamedObject("type=\"simple","type=\"Simple"),
            new RenamedObject("type=\"sms","type=\"Sms"),
            new RenamedObject("type=\"statSMS","type=\"StatSms"),
            new RenamedObject("type=\"txtSMS","type=\"TxtSms"),
            new RenamedObject("type=\"filtre","type=\"Filtre"),
            new RenamedObject("type=\"publipostage","type=\"Publipostage"),
            new RenamedObject("type=\"utilisateur","type=\"Utilisateur"),
            new RenamedObject("type=\"etiquette","type=\"Etiquette"),
            new RenamedObject("type=\"calendrier","type=\"Calendrier"),
            //tabloid graph operator types
            new RenamedObject("operateur=\"compte","operateur=\"Compte"),
            new RenamedObject("operateur=\"somme","operateur=\"Somme"),
            new RenamedObject("operateur=\"moyenne","operateur=\"Moyenne"),
            new RenamedObject("operateur=\"max","operateur=\"Max"),
            new RenamedObject("operateur=\"max","operateur=\"Max"),
            //tabloid map types
            new RenamedObject("type=\"poly","type=\"Poly"),
            new RenamedObject("type=\"point","type=\"Point"),
            new RenamedObject("type=\"none","type=\"None"),
            //tabloid research types
            new RenamedObject("typeSelection=\"listeACoche","typeSelection=\"ListeACoche"),
            new RenamedObject("typeSelection=\"caseACocher","typeSelection=\"CaseACocher"),
            new RenamedObject("typeSelection=\"comparateur","typeSelection=\"Comparateur"),
            //tabloid populate types
            new RenamedObject("peupler=\"aucun","peupler=\"Aucun"),
            new RenamedObject("peupler=\"sql","peupler=\"Sql"),
            new RenamedObject("peupler=\"donnees","peupler=\"Donnees"),
            //tabloid barcode types
            new RenamedObject("barCodeType=\"aucun","barCodeType=\"Aucun"),
            new RenamedObject("barCodeType=\"QRCode","barCodeType=\"QrCode")
            //tabloid edition types
            //new RenamedObject("type=\"eMail","barCodeType=\"Email"),
            //new RenamedObject("type=\"upload","barCodeType=\"Upload")
        };

        public class RenamedObject
        {
            public RenamedObject(string oldName, string newName)
            {
                NewName = newName;
                OldName = oldName;
            }

            public string OldName { get; private set; }
            public string NewName { get; private set; }
        }
    }
}