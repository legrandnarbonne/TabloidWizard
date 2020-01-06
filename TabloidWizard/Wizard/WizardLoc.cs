using Gui.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tabloid.Classes.Config;

using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardLoc : Form
    {
        TabloidConfigView _view;
        public WizardLoc(TabloidConfigView v)
        {
            InitializeComponent();
            _view = v;

            cmbType.SelectedIndex = 0;

        }

        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            if (txtGeomFiled.Text == "")
                MessageBox.Show(Properties.Resources.FieldNameNeeded, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);

            var param = new string[] { _view.Nom, txtGeomFiled.Text, $"geometry({cmbType.SelectedItem},{txtSrid.Text})", _view.Schema };

            WizardSQLHelper.ExecuteFromFile("addField.sql", param, Program.AppSet.ConnectionString);

            TabloidConfigGeoLoc.GeoLocType geoLocType;
            Enum.TryParse(cmbType.SelectedItem.ToString(), out geoLocType);

            _view.GeoLoc.Type = geoLocType;
            _view.GeoLoc.TitreCouche =_view.Titre;
            _view.GeoLoc.Geom = txtGeomFiled.Text;
            _view.GeoLoc.Srid = txtSrid.Text;
            _view.GeoLoc.ForcerSRID = true;

            if (chkAddMenu.Checked)
            {
                WizardSQLHelper.AddToMenu(_view, "Carte " + _view.Titre, TabloidConfigMenuItem.MenuType.Carte, null);
            }

        }
    }
}