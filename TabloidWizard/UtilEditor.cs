using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using Tabloid.Classes.Tools;

namespace TabloidWizard
{
    public partial class UtilEditor : MetroForm
    {
        public UtilEditor()
        {
            InitializeComponent();

            cmbAuth.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text))// login is required
                MetroMessageBox.Show(this,Properties.Resources.LoginCouldnotbeempty, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (cmbAuth.SelectedIndex == 0 && !SecurityHelper.CheckPasswordCompliance(txtMdp1.Text))//form authentication
                    MetroMessageBox.Show(this,Properties.Resources.PasswordRegExpMess, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (cmbAuth.SelectedIndex == 0 && txtMdp1.Text!=txtMdp2.Text)//form authentication
                        MetroMessageBox.Show(this,Properties.Resources.ConfirmPasswordError, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void cmbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblAuth.Text = cmbAuth.SelectedIndex == 0 ? "Login :" : "Identifiant Windows :";
            txtMdp1.Enabled = txtMdp2.Enabled = cmbAuth.SelectedIndex == 0;
        }
    }
}
