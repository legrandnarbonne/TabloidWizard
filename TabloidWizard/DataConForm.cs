using MetroFramework.Forms;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace TabloidWizard
{
    public partial class DataConForm : MetroForm
    {
        public DataConForm()
        {
            InitializeComponent();
        }

        private void DataConForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=DbProviderFactories.GetFactoryClasses();
            dataGridView1.AutoResizeColumns();
            dataGridView1.ReadOnly = true;
        }
    }
}
