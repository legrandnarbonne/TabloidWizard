using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabloidWizard.Classes
{
    public class XLSStructure
    {
        public int IgnoreLine { get; set; }

        public int CurrentWorkBookNum { get; internal set; }
        public string FileName { get; internal set; }
        internal List<WorkBook> WorkBooks { get; set; }

        public WorkBook CurrentWorkBook
        {
            get
            {
                return WorkBooks[CurrentWorkBookNum];
            }
        }

        public class WorkBook
        {
            public List<string> Columns { get; internal set; }
            public string Name { get; internal set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
