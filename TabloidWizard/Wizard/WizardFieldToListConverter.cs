using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardFieldToListConverter : MetroForm
    {
        TabloidConfigColonne _field;
        TabloidConfigView _view;

        public WizardFieldToListConverter(TabloidConfigView view, TabloidConfigColonne field)
        {
            InitializeComponent();
            _field = field;
            _view = view;
        }

        void Button_end(object sender, PageEventArgs e)
        {

            if (Tools.isTableExist(txtTable.Text))
            {
                MetroMessageBox.Show(this,Properties.Resources.TableAlreadyExist,Properties.Resources.Error,MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            e.Cancel = !WizardSQLHelper.ConvertFieldToList(_view,_field,txtTable.Text,this);

        }
    }
}