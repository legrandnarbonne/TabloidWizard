using System.Drawing;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace TabloidWizard
{
    public partial class LogViewer : MetroForm
    {
        string _message;
        string _log;
        Color _messageColor;

        public string Message
        {
            get { return _message; }
            set {
                _message = value;
                setMessage();
            }
        }

        public string Log
        {
            get { return _log; }
            set
            {
                _log = value;
                setMessage();
            }
        }

        public Color MessageColor {
            get { return _messageColor; }
            set
            {
                _messageColor = value;
                setMessage();
            }
        }

        public LogViewer()
        {
            InitializeComponent();
        }

        void setMessage()
        {
            lblMessage.Text = Message;
            lblMessage.ForeColor = MessageColor;
            txtLog.Text = _log;
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void metroButton2_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(_log);
        }
    }
}
