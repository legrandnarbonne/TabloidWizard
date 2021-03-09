using MetroFramework.Forms;
using System.Windows.Forms;

namespace TabloidWizard
{
    public partial class Rename : MetroForm
    {
        public Rename(string currentName)
        {
            InitializeComponent();
            lblCurrent.Text = Properties.Resources.RenameOldName+currentName;
            txtNewName.Text = currentName;
        }
    }
}
