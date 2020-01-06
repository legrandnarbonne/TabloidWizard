using Gui.Wizard;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class WizardIndic : Form
    {
        TabloidConfigView _view;


        public WizardIndic(TabloidConfigView view)
        {
            _view = view;

            InitializeComponent();

            cmbType.DataSource= Enum.GetValues(typeof(TabloidConfigIndicateur.WidgetType));
        }
        
    }
}