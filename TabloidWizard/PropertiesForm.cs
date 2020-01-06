using System;
using System.Windows.Forms;
using Tabloid.Classes.Config;

namespace TabloidWizard
{
    //allow menu edition
    public partial class PropriesForm : Form
    {
        public PropriesForm(TabloidConfigMenuItem i)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = i;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

    }
}
