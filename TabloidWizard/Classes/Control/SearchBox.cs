using System;
using System.Windows.Forms;

namespace TabloidWizard.Classes.Control
{
    public partial class SearchBox : UserControl
    {

        public EventHandler OnTextChange { get; set; }

        public string Text { get; set; }

        public SearchBox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            Text = textBox1.Text;
            OnTextChange?.Invoke(this, e);
        }
    }
}
