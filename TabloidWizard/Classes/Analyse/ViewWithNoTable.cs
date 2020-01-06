

using System;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using static TabloidWizard.AnalyseStr;

namespace TabloidWizard.Classes.Analyse
{
    class ViewWithNoTable : AnalyseResult, IAnalyseResult
    {

        public override string Title
        {
            get
            {
                return Properties.Resources.ViewWithNoTableTitle;
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

        public ViewWithNoTable(TableAnalysisResult tr)
        {
            ParentTableResult = tr;
        }

        public override AnalyseAction[] AnalyseActions
        {
            get
            {
                return new AnalyseAction[]{
                    new AnalyseAction("Supprimer la vue",DeleteView),
                    new AnalyseAction("Créer une nouvelle vue",buildView)};
            }
        }


        private void DeleteView(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.ConfirmDeleteView, Properties.Resources.Question, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                TabloidConfig.Config.Views.Remove(ParentTableResult.Views[0]);
            }
        }

        private void buildView(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
