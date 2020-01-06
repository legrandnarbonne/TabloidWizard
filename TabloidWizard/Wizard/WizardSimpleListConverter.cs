using Gui.Wizard;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardSimpleListConverter : Form
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
                MessageBox.Show("Ce nom de table existe déja !","Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            e.Cancel = !WizardSQLHelper.ConvertSimpleList(_view,_field,txtTable.Text);

        }
    }
}