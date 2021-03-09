using Gui.Wizard;
using MetroFramework.Forms;
using System;
using Tabloid.Classes.Config;

namespace TabloidWizard
{
    public partial class WizardIndic : MetroForm
    {
        TabloidConfigView _view;
        public TabloidConfigIndicateur Result;

        public WizardIndic(TabloidConfigView view = null)
        {
            _view = view;

            InitializeComponent();

            cmbType.DataSource = Enum.GetValues(typeof(TabloidConfigIndicateur.WidgetType));
            Fin.CloseFromBack+=Fin_CloseFromBack;
        }

        private void Fin_CloseFromBack(object sender, PageEventArgs e)
        {

        }

        private void wiStart_CloseFromNext(object sender, PageEventArgs e)
        {
            Result = null;


        }

        private void chkExistant_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}