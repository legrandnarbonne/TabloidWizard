namespace TabloidWizard
{
    partial class UtilEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMdp1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMdp2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAuth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.No;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // txtNom
            // 
            resources.ApplyResources(this.txtNom, "txtNom");
            this.txtNom.Name = "txtNom";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtPrenom
            // 
            resources.ApplyResources(this.txtPrenom, "txtPrenom");
            this.txtPrenom.Name = "txtPrenom";
            // 
            // lblAuth
            // 
            resources.ApplyResources(this.lblAuth, "lblAuth");
            this.lblAuth.Name = "lblAuth";
            // 
            // txtLogin
            // 
            resources.ApplyResources(this.txtLogin, "txtLogin");
            this.txtLogin.Name = "txtLogin";
            // 
            // txtMail
            // 
            resources.ApplyResources(this.txtMail, "txtMail");
            this.txtMail.Name = "txtMail";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnOk
            // 
            this.btnOk.CausesValidation = false;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtMdp1
            // 
            resources.ApplyResources(this.txtMdp1, "txtMdp1");
            this.txtMdp1.Name = "txtMdp1";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtMdp2
            // 
            resources.ApplyResources(this.txtMdp2, "txtMdp2");
            this.txtMdp2.Name = "txtMdp2";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cmbAuth
            // 
            this.cmbAuth.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAuth, "cmbAuth");
            this.cmbAuth.Items.AddRange(new object[] {
            resources.GetString("cmbAuth.Items"),
            resources.GetString("cmbAuth.Items1")});
            this.cmbAuth.Name = "cmbAuth";
            this.cmbAuth.SelectedIndexChanged += new System.EventHandler(this.cmbAuth_SelectedIndexChanged);
            // 
            // UtilEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbAuth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMdp2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMdp1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblAuth);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCancel);
            this.Name = "UtilEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtLogin;
        public System.Windows.Forms.TextBox txtMail;
        public System.Windows.Forms.TextBox txtNom;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtMdp1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMdp2;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cmbAuth;
    }
}