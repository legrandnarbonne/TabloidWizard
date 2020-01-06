using System.IO;
using System.Windows.Forms;

namespace TabloidWizard
{
    public partial class maj : Form
    {
        public maj(string destinationPath)
        {
            InitializeComponent();
            
            chkWebConfig.Checked=chkWebConfig.Enabled = new FileInfo(destinationPath + "\\web.config").Exists;

            chkUpload.Checked=chkUpload.Enabled = new DirectoryInfo(destinationPath + "\\uploads").Exists;

            chkOpenJs.Checked=chkOpenJs.Enabled=new DirectoryInfo(destinationPath + "\\scripts").Exists;

            chkImg.Checked = chkImg.Enabled = new DirectoryInfo(destinationPath + "\\images").Exists;
        }

    }
}
