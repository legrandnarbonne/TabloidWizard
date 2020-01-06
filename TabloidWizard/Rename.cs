using System.Windows.Forms;

namespace TabloidWizard
{
    public partial class Rename : Form
    {
        public Rename(string currentName)
        {
            InitializeComponent();
            lblCurrent.Text = Properties.Resources.RenameOldName+currentName;
            txtNewName.Text = currentName;
        }
    }
}
