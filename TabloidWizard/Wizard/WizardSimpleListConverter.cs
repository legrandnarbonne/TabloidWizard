using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardSimpleListConverter : MetroForm
    {
        TabloidConfigColonne _field;
        TabloidConfigView _view;

        public WizardSimpleListConverter(TabloidConfigView view, TabloidConfigColonne field)
        {
            InitializeComponent();
            _field = field;
            _view = view;
        }

        void Button_end(object sender, PageEventArgs e)
        {

            if (Tools.isTableExist(txtTable.Text))
            {
                MetroMessageBox.Show(this,"Ce nom de table existe déja !","Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            e.Cancel = !WizardSQLHelper.ConvertSimpleList(_view,_field,txtTable.Text,this);

        }
    }
}