using System;
using System.Windows.Forms;

namespace TabloidWizard.Classes.Analyse
{
    class AnalyseResult :IAnalyseResult
    {
        public virtual string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual int Level
        {
            get
            {
                return 1;
            }
        }

        public virtual string Title
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual AnalyseAction[] AnalyseActions
        {
            get
            {
                return new AnalyseAction[] {};
            }
        }

        // User-defined conversion from TableAnalysisResult to TreeNode
        public static implicit operator TreeNode(AnalyseResult d)
        {
            var node = new TreeNode
            {
                Tag = d,
                Text = d.Title,
                ImageIndex = d.Level,
                SelectedImageIndex = d.Level
            };


            return node;
        }
    }
}
