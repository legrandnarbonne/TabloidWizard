namespace TabloidWizard.Classes.Editor
{
    partial class ImgSrcFormEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgSrcFormEditor));
            this.button1 = new System.Windows.Forms.Button();
            this.colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.tipPicture = new System.Windows.Forms.ToolTip(this.components);
            this.flpThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(423, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(508, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(12, 227);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(128, 23);
            this.btnAddPicture.TabIndex = 17;
            this.btnAddPicture.Text = "Ajouter une image";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // flpThumbnails
            // 
            this.flpThumbnails.AutoScroll = true;
            this.flpThumbnails.Location = new System.Drawing.Point(12, 12);
            this.flpThumbnails.Name = "flpThumbnails";
            this.flpThumbnails.Size = new System.Drawing.Size(571, 209);
            this.flpThumbnails.TabIndex = 18;
            this.flpThumbnails.DoubleClick += new System.EventHandler(this.PictureBox_DoubleClick);
            // 
            // ImgSrcFormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 262);
            this.Controls.Add(this.flpThumbnails);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(611, 300);
            this.MinimumSize = new System.Drawing.Size(611, 300);
            this.Name = "ImgSrcFormEditor";
            this.Text = "Sélectionner une image";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.ToolTip tipPicture;
        private System.Windows.Forms.FlowLayoutPanel flpThumbnails;
    }
}