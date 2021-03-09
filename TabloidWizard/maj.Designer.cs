namespace TabloidWizard
{
    partial class maj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maj));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.chkOpenJs = new System.Windows.Forms.CheckBox();
            this.chkWebConfig = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSAV = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkImg = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // chkUpload
            // 
            resources.ApplyResources(this.chkUpload, "chkUpload");
            this.chkUpload.Checked = true;
            this.chkUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.UseVisualStyleBackColor = true;
            // 
            // chkOpenJs
            // 
            resources.ApplyResources(this.chkOpenJs, "chkOpenJs");
            this.chkOpenJs.Checked = true;
            this.chkOpenJs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenJs.Name = "chkOpenJs";
            this.chkOpenJs.UseVisualStyleBackColor = true;
            // 
            // chkWebConfig
            // 
            resources.ApplyResources(this.chkWebConfig, "chkWebConfig");
            this.chkWebConfig.Checked = true;
            this.chkWebConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWebConfig.Name = "chkWebConfig";
            this.chkWebConfig.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkSAV
            // 
            resources.ApplyResources(this.chkSAV, "chkSAV");
            this.chkSAV.Name = "chkSAV";
            this.chkSAV.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chkImg
            // 
            resources.ApplyResources(this.chkImg, "chkImg");
            this.chkImg.Checked = true;
            this.chkImg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImg.Name = "chkImg";
            this.chkImg.UseVisualStyleBackColor = true;
            // 
            // maj
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkImg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkSAV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkWebConfig);
            this.Controls.Add(this.chkOpenJs);
            this.Controls.Add(this.chkUpload);
            this.Controls.Add(this.textBox1);
            this.Name = "maj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.CheckBox chkUpload;
        public System.Windows.Forms.CheckBox chkOpenJs;
        public System.Windows.Forms.CheckBox chkWebConfig;
        public System.Windows.Forms.CheckBox chkSAV;
        public System.Windows.Forms.CheckBox chkImg;
    }
}