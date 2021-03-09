
using System;
using System.Collections.Generic;
using Tabloid.Classes.Config;
using System.Linq;
using static TabloidWizard.AnalyseStr;
using TabloidWizard.Classes.Tools;
using System.Windows.Forms;

namespace TabloidWizard.Classes.Analyse
{
    class JoinWithNoConstraint : AnalyseResult, IAnalyseResult
    {
        IWin32Window _own;

        public override int Level
        {
            get
            {
                return 2;
            }
        }
        public override string Title
        {
            get
            {
                return string.Format(Properties.Resources.JoinWithNoConstraintTitle, Join.Nom, View.Titre);
            }
        }
        public override string Description
        {
            get
            {
                return string.Format(Properties.Resources.JoinWithNoConstraint_Description, Join.Nom, View.NomTable, Join.NomTable);
            }
        }

        public override AnalyseAction[] AnalyseActions
        {
            get
            {
                return new AnalyseAction[]{
                    new AnalyseAction(Properties.Resources.JoinWithNoConstraintBuildConstraint,buildConstraint),
                    new AnalyseAction(Properties.Resources.JoinWithNoConstraintBuildAllConstraint,buildAllConstraint)};
            }
        }

        private void buildConstraint(object sender, EventArgs e)
        {
            BuildConstraint();
        }

        private void buildAllConstraint(object sender, EventArgs e)
        {
            var results = ((AnalyseAction)sender).Results;

            foreach (TableAnalysisResult tar in results)
            {
                var childs = tar.GetListOf<JoinWithNoConstraint>();

                foreach (JoinWithNoConstraint j in childs)
                    j.BuildConstraint();
            }
        }

        public IEnumerable<T> GetListOf<T>(List<AnalyseResult> results)
        {
            return results.OfType<T>();
        }

        public void BuildConstraint()
        {
            var key = WizardSQLHelper.GetPrimaryKeyName(Join.NomTable);
            //var param = new string[] { View.Schema, Join.NomTable, View.NomTable, Join.ChampDeRef, View.Schema, key };
            //WizardHelper.ExecuteFromFile("addConstraint.sql", param, Program.AppSet.ConnectionString);
            WizardSQLHelper.addConstraint(View.Schema, Join.NomTable, View.NomTable, Join.ChampDeRef, View.Schema, key,_own);
           
        }

        public TabloidConfigJointure Join { get; set; }

        public TabloidConfigView View { get; set; }

        public JoinWithNoConstraint(TabloidConfigJointure join, TabloidConfigView view,IWin32Window own)
        {
            _own = own;
            Join = join;
            View = view;
        }
    }
}
