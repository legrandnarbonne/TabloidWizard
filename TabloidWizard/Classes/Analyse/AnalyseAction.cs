
using System;
using System.Collections.Generic;
using static TabloidWizard.AnalyseStr;

namespace TabloidWizard.Classes.Analyse
{
    class AnalyseAction
    {
        public AnalyseAction(string caption,EventHandler handler)
        {
            Caption = caption;
            Handler = handler;
        }

        public string Caption { get; set; }

        public List<TableAnalysisResult> Results;

        public event EventHandler Handler;

        public virtual void OnClick(object sender, EventArgs e)
        {
            Handler?.Invoke(this, e);
        }
    }
}
