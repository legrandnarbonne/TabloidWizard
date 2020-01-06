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
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(21, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 77);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Le dossier n\'est pas vide. Les données qu\'il contient seront supprimées au cours " +
    "de la publication. Si vous souhaitez créer une sauvegarde cochez la case sauvega" +
    "rde complète.";
            // 
            // chkUpload
            // 
            this.chkUpload.AutoSize = true;
            this.chkUpload.Checked = true;
            this.chkUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpload.Location = new System.Drawing.Point(32, 132);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(107, 17);
            this.chkUpload.TabIndex = 1;
            this.chkUpload.Text = "le dossier Upload";
            this.chkUpload.UseVisualStyleBackColor = true;
            // 
            // chkOpenJs
            // 
            this.chkOpenJs.AutoSize = true;
            this.chkOpenJs.Checked = true;
            this.chkOpenJs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenJs.Location = new System.Drawing.Point(32, 152);
            this.chkOpenJs.Name = "chkOpenJs";
            this.chkOpenJs.Size = new System.Drawing.Size(183, 17);
            this.chkOpenJs.TabIndex = 2;
            this.chkOpenJs.Text = "les style perso. de la cartographie";
            this.chkOpenJs.UseVisualStyleBackColor = true;
            // 
            // chkWebConfig
            // 
            this.chkWebConfig.AutoSize = true;
            this.chkWebConfig.Checked = true;
            this.chkWebConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWebConfig.Location = new System.Drawing.Point(32, 190);
            this.chkWebConfig.Name = "chkWebConfig";
            this.chkWebConfig.Size = new System.Drawing.Size(235, 17);
            this.chkWebConfig.TabIndex = 3;
            this.chkWebConfig.Text = "la configuration du serveur web (web.config)";
            this.chkWebConfig.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Conserver :";
            // 
            // chkSAV
            // 
            this.chkSAV.AutoSize = true;
            this.chkSAV.Location = new System.Drawing.Point(32, 232);
            this.chkSAV.Name = "chkSAV";
            this.chkSAV.Size = new System.Drawing.Size(191, 17);
            this.chkSAV.TabIndex = 5;
            this.chkSAV.Text = "sauvegardé l\'ensemble du contenu";
            this.chkSAV.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(120, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Lancer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(201, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chkImg
            // 
            this.chkImg.AutoSize = true;
            this.chkImg.Checked = true;
            this.chkImg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImg.Location = new System.Drawing.Point(32, 171);
            this.chkImg.Name = "chkImg";
            this.chkImg.Size = new System.Drawing.Size(117, 17);
            this.chkImg.TabIndex = 8;
            this.chkImg.Text = "le dossier \"Images\"";
            this.chkImg.UseVisualStyleBackColor = true;
            // 
            // maj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.chkImg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkSAV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkWebConfig);
            this.Controls.Add(this.chkOpenJs);
            this.Controls.Add(this.chkUpload);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "maj";
            this.Text = "Mise à jour";
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