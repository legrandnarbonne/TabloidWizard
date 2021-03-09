using Gui.Wizard;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardLoc : MetroForm
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
                MetroMessageBox.Show(this,Properties.Resources.FieldNameNeeded, Properties.Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);

            var param = new string[] { _view.Nom, txtGeomFiled.Text, $"geometry({cmbType.SelectedItem},{txtSrid.Text})", _view.Schema };

            WizardSQLHelper.ExecuteFromFile("addField.sql", param, Program.AppSet.ConnectionString,this);

            TabloidConfigGeoLoc.GeoLocType geoLocType;
            Enum.TryParse(cmbType.SelectedItem.ToString(), out geoLocType);

            _view.GeoLoc.Type = geoLocType;
            _view.GeoLoc.TitreCouche =_view.Titre;
            _view.GeoLoc.Geom = txtGeomFiled.Text;
            _view.GeoLoc.Srid = txtSrid.Text;
            _view.GeoLoc.ForcerSRID = true;

            if (chkAddMenu.Checked)
            {
                WizardSQLHelper.AddToMenu(this,_view, "Carte " + _view.Titre, TabloidConfigMenuItem.MenuType.Carte, null);
            }

        }
    }
}