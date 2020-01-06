﻿using Gui.Wizard;

using System.Windows.Forms;
using Tabloid.Classes.Config;

using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardSMS : Form
    {
        TabloidConfigView _view;

        public WizardSMS(TabloidConfigView v)
        {
            InitializeComponent();
            _view = v;

            txtPass.Text = Program.AppSet.smsBoxPassword;
            txtUser.Text = Program.AppSet.smsBoxUser;
        }

        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            Program.AppSet.smsBoxPassword = txtPass.Text;
            Program.AppSet.smsBoxUser = txtUser.Text;

            Tabloid.Classes.Config.Helper.AutomaticViewBuilder.setTextes(Program.AppSet.Schema);

            if (chkAlert.Checked)
            {
                var alertMn = new TabloidConfigMenuItem {
                Titre=Properties.Resources.Alert,
                Type=TabloidConfigMenuItem.MenuType.Simple
                };

                WizardSQLHelper.AddToMenu(alertMn,null,true);

                WizardSQLHelper.AddToMenu(new TabloidConfigMenuItem
                {
                    Titre = Properties.Resources.SimpleSMS,
                    Type = TabloidConfigMenuItem.MenuType.Sms
                }, alertMn,true);

                WizardSQLHelper.AddToMenu(new TabloidConfigMenuItem
                {
                    Titre = Properties.Resources.MultiSMS,
                    Type = TabloidConfigMenuItem.MenuType.Filtre,
                    Table=_view.Nom
                }, alertMn,true);


            }
            if (chkText.Checked)
            {
                WizardSQLHelper.AddToParamMenu(new TabloidConfigMenuItem
                {
                    Titre = Properties.Resources.PreDefineText,
                    Type = TabloidConfigMenuItem.MenuType.TxtSms
                },true);
                
            }
        }
    }
}