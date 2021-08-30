using Gui.Wizard;
using MetroFramework.Forms;
using System;
using Tabloid.Classes.Config;
using Tabloid.Classes.Optimisation.Cache;
using TabloidWizard.Classes.WizardTools;

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
            Fin.CloseFromNext+=Fin_CloseFromNext;
        }

        private void Fin_CloseFromNext(object sender, PageEventArgs e)
        {
            Result = new TabloidConfigIndicateur();

            Result.Type = (TabloidConfigIndicateur.WidgetType)cmbType.SelectedValue;
            Result.Texte = txtIndic.Text;

            var parentCollection = _view != null ? _view.Indicateurs : TabloidConfig.Config.Synthese.Indicateurs;

            var i=Tools.AddWithUniqueName(parentCollection, Result, "I");

            IndicCache.setIndicCache();
        }

        private void wiStart_CloseFromNext(object sender, PageEventArgs e)
        {

        }

        private void chkExistant_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}