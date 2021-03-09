using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    /// <summary>
    ///     Description of settingForm.
    /// </summary>
    public partial class SettingForm : MetroForm
    {
        bool _authenticationChange;
        bool _setAuthenticationModeOnClose;//if set to true modify web.config when closing

        /// <summary>
        /// Display project properties
        /// </summary>
        /// <param name="setAuthenticationOnClose">set to true or null to set web.config authentication option on closing</param>
        public SettingForm(bool setAuthenticationOnClose=true)
        {
            _setAuthenticationModeOnClose = setAuthenticationOnClose;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_setAuthenticationModeOnClose) AuthenticationHandler.Set(Program.AppSet.ModeAuthentification);
            DialogResult = DialogResult.OK;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var obj = (AppSetting)propertyGrid1.SelectedObject;

            _authenticationChange = e.ChangedItem.Label == "ModeAuthentification";

            if (obj.ModeAuthentification != AuthenticationHandler.AuthenticationType.Windows &&
                !string.IsNullOrEmpty(obj.AutoenrollmentDomain))
                MetroMessageBox.Show(this,Properties.Resources.AuthenticationAndAutoEnrollementError, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}