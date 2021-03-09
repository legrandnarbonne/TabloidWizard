using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Controls;
using Tabloid.Classes.Data;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardAlias : MetroForm
    {

        public TabloidConfigJointure NewJoin { get; set; }

        public WizardAlias(TabloidConfigJointure j)
        {

            NewJoin = j ?? new TabloidConfigJointure();

            InitializeComponent();
 
        }


        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            NewJoin.AliasDbKey = txtNewDbKey.Text;
            NewJoin.AliasTable = txtNewName.Text;

            NewJoin.Select = $"{txtNewName.Text}.{NewJoin.DbKey} as {txtNewDbKey.Text}";
        }
    }
}