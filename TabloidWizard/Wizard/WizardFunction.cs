using Gui.Wizard;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Data;
using TabloidWizard.Classes.Tools;

namespace TabloidWizard
{
    public partial class WizardFunction : MetroForm
    {
        public TabloidConfigFunction function;
        /// <summary>
        /// Function creation wizard
        /// </summary>
        /// <param name="schema">Name of postgres schema or database name for mysql</param>
        public WizardFunction(string schema)
        {
            InitializeComponent();

            string lastError;

            var dt = DataTools.Data(WizardSQLHelper.BuildSQLFromFile("functionList.sql", new String[] { schema }), Program.AppSet.ConnectionString, out lastError);
            cmbFunction.DataSource = dt;
            cmbFunction.DisplayMember = dt.Columns[1].ColumnName;

        }

        private void Button_end(object sender, PageEventArgs e)
        {
            function = new TabloidConfigFunction
            {
                Titre = txtFunction.Text,
                Nom = cmbFunction.Text
            };


        }



        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            //TxtRef.Text = "id_" + txtTable.Text;
            //txtInititView.Text = txtTable.Text;
        }

    }
}