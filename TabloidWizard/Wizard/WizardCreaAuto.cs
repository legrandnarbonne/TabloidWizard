using Gui.Wizard;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using System.Linq;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using MetroFramework.Forms;

namespace TabloidWizard
{
    public partial class WizardCreaAuto : MetroForm
    {
        TabloidConfigView _view;
        const string triggerName = "autocreateafterinsert";

        public WizardCreaAuto(TabloidConfigView v)
        {
            InitializeComponent();
            _view = v;

            lbListe.Text = $"à la création d'un enregistrement de '{_view.Nom}' compléter la liste :";

            cmbListe.DataSource = v.Jointures.Where(j => j.Relation == "1:N" && j.Jointures.asN1()).ToList();

        }

        //créer dans la liste {0} les élément à partir de {1}
        //à la création d'un enregistrement de {0} compléter la liste {1} :
        private void Info_CloseFromNext(object sender, PageEventArgs e)
        {
            // add insertselect function
            e.Cancel = !WizardSQLHelper.ExecuteFromFile("functions\\insertselect.sql", new string[] { _view.Schema }, Program.AppSet.ConnectionString,this);

            var where = string.IsNullOrEmpty(txtWhere.Text) ? "'1=1'" : txtWhere.Text;

            var dest = ((TabloidConfigJointure)cmbListe.SelectedItem);

            var src = ((TabloidConfigJointure)cmbSrc.SelectedItem);

            var srcFields = $"concat('{src.DbKey},',New.{_view.DbKey})";
            var destFields = $"'{src.ChampDeRef},{dest.ChampDeRef2}'";

            var function = $"PERFORM {_view.Schema}.insertselect('{_view.Schema}.{src.NomTable}',{where},{srcFields},'{_view.Schema}.{dest.NomTable}',{destFields});";

            if (!string.IsNullOrEmpty(txtIf.Text))
                function = $"if {txtIf.Text} Then " + function + "end if;";
            

            var param = new string[] {
                _view.Schema,
                triggerName+_view.NomTable,
                _view.NomTable,
                "AFTER INSERT",
                _view.Schema+"."+ triggerName+_view.NomTable,
               function
            };

            e.Cancel = !WizardSQLHelper.ExecuteFromFile("trigger.sql", param, Program.AppSet.ConnectionString,this);

        }

        private void cmbListe_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbListe.SelectedItem == null)
            {
                cmbSrc.Visible = lbSrc.Visible = false;
                return;
            }

            var join = ((TabloidConfigJointure)cmbListe.SelectedItem);

            lbSrc.Text = $"créer dans la liste {join} les élément à partir de :";

            cmbSrc.DataSource = join.Jointures.Where(j => j.Relation == "N:1" || string.IsNullOrEmpty(j.Relation)).ToList();

        }


    }
}