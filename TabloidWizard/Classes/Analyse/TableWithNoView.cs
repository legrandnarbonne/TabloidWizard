

using System;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;
using static TabloidWizard.AnalyseStr;

namespace TabloidWizard.Classes.Analyse
{
    class TableWithNoView : AnalyseResult, IAnalyseResult
    {
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
                return Properties.Resources.TableWithNoViewTitle;
            }
        }
        public override string Description
        {
            get
            {
                return "";
            }
        }

        public TableAnalysisResult ParentTableResult { get; set; }

        public override AnalyseAction[] AnalyseActions
        {
            get
            {
                return new AnalyseAction[]{
                    new AnalyseAction(Properties.Resources.TableWithNoViewRenameTable,RenameTable),
                    new AnalyseAction(Properties.Resources.TableWithNoViewCreateView,buildView),
                    new AnalyseAction(Properties.Resources.JoinWithNoConstraintBuildAllConstraint,buildAllView)};
            }
        }

        public TableWithNoView(TableAnalysisResult tr)
        {
            ParentTableResult = tr;
        }

        private void RenameTable(object sender, EventArgs e)
        {
            var frmRename = new Rename(ParentTableResult.TableName);
            if (frmRename.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var param = new string[] { Program.AppSet.Schema, ParentTableResult.TableName, frmRename.txtNewName.Text };
                WizardSQLHelper.ExecuteFromFile("renameTable.sql", param, Program.AppSet.ConnectionString);
            }
        }

        private void buildAllView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void buildView(object sender, EventArgs e)
        {
            var avt = new ArrayVerify();
            var newView = new TabloidConfigView();

            BuildFromBase.GetTable(ParentTableResult.TableName, Program.AppSet.Schema, ref newView,ref avt, new BuildFromBase.BaseImporterConfig
            {
                RemoveTableName = true,
                ToUpperCase = true,
                ReplaceUnderscrore = true,
                ConnectionString = Program.AppSet.ConnectionString
            });

            TabloidConfig.Config.Views.Add(newView);

        }


    }
}
