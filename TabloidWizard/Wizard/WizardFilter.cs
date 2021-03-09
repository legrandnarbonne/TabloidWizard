using Gui.Wizard;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using TabloidWizard.Classes;

namespace TabloidWizard
{

    /// <summary>
    /// Filter wizard not use 
    /// </summary>
    public partial class WizardFilter : MetroForm
    {
        ConfigFilesCollection _configFiles;

        public WizardFilter(ConfigFilesCollection configFiles)
        {
            InitializeComponent();
            _configFiles = configFiles;
        }
        
        void Button_end(object sender, PageEventArgs e)
        {
     
        }


        void txtTable_TextChanged(object sender, EventArgs e)
        {

        }

        private void header4_Load(object sender, EventArgs e)
        {

        }

        private void WizardTable_Load(object sender, EventArgs e)
        {

        }
    }
}