using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TabloidWizard
{
    public partial class WaitingForm : Form
    {
        public BackgroundWorker Wr;
        public bool AutomaticMode = true;

        public WaitingForm(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler endWork = null)
        {
            InitWorker(doWork, endWork);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 1,1,Bounds.Width-2, Bounds.Height-2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Wr.CancelAsync();
        }
        void InitWorker(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler endWork)
        {
            if (endWork == null) endWork = genericBackgroundWorkerEnd;

            Wr = new BackgroundWorker();
            Wr.WorkerSupportsCancellation = true;
            Wr.WorkerReportsProgress = true;
            Wr.DoWork += doWork;
            Wr.ProgressChanged += bw_ProgressChanged;
            Wr.RunWorkerCompleted += endWork;
           
        }

        private void genericBackgroundWorkerEnd(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AutomaticMode) Close();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState == null) return;
            lbInfo.Text = ((WaitingFormProperties)e.UserState).Status;
            progressBar.Maximum = ((WaitingFormProperties)e.UserState).MaxProgressValue;
            progressBar.Value = e.ProgressPercentage;
            txtFile.Text = ((WaitingFormProperties)e.UserState).CurrentFile;
            progressBar.Style = ((WaitingFormProperties)e.UserState).ProgressStyle;
        }
    }

    public class WaitingFormProperties
    {
        public readonly string CurrentFile;
        public readonly int MaxProgressValue;
        public readonly ProgressBarStyle ProgressStyle;
        public readonly string Status;

        public WaitingFormProperties(string status, string currentFile = null, int maxProgressValue = 0,
            ProgressBarStyle progressStyle = ProgressBarStyle.Marquee)
        {
            Status = status;
            CurrentFile = currentFile;
            ProgressStyle = progressStyle;
            MaxProgressValue = maxProgressValue;
        }
    }
}
