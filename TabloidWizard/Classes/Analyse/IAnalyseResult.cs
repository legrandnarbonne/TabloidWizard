
using System.Collections.Generic;

namespace TabloidWizard.Classes.Analyse
{
    interface IAnalyseResult
    {
        string Title { get;  }
        string Description { get;  }
        int Level { get;  }
        AnalyseAction[] AnalyseActions { get; }

    }
}
