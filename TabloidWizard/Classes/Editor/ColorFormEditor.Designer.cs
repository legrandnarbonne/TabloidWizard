namespace TabloidWizard.Classes.Editor
{
    partial class ColorFormEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorFormEditor));
            this.colorWheel1 = new Cyotek.Windows.Forms.ColorWheel();
            this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
            this.colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            this.SuspendLayout();
            // 
            // colorWheel1
            // 
            this.colorWheel1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel1.Location = new System.Drawing.Point(50, 54);
            this.colorWheel1.Name = "colorWheel1";
            this.colorWheel1.Size = new System.Drawing.Size(191, 174);
            this.colorWheel1.TabIndex = 0;
            // 
            // colorGrid1
            // 
            this.colorGrid1.Location = new System.Drawing.Point(22, 246);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Size = new System.Drawing.Size(247, 165);
            this.colorGrid1.TabIndex = 1;
            // 
            // colorEditor1
            // 
            this.colorEditor1.Location = new System.Drawing.Point(326, 54);
            this.colorEditor1.Name = "colorEditor1";
            this.colorEditor1.Size = new System.Drawing.Size(256, 249);
            this.colorEditor1.TabIndex = 2;
            // 
            // previewPanel
            // 
            this.previewPanel.Location = new System.Drawing.Point(404, 298);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(87, 54);
            this.previewPanel.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(436, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(517, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // colorEditorManager1
            // 
            this.colorEditorManager1.ColorEditor = this.colorEditor1;
            this.colorEditorManager1.ColorGrid = this.colorGrid1;
            this.colorEditorManager1.ColorWheel = this.colorWheel1;
            this.colorEditorManager1.ColorChanged += new System.EventHandler(this.colorEditorManager1_ColorChanged);
            // 
            // ColorFormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 434);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.colorEditor1);
            this.Controls.Add(this.colorGrid1);
            this.Controls.Add(this.colorWheel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(611, 434);
            this.MinimumSize = new System.Drawing.Size(611, 434);
            this.Name = "ColorFormEditor";
            this.Text = "Sélectionner une couleur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cyotek.Windows.Forms.ColorWheel colorWheel1;
        private Cyotek.Windows.Forms.ColorGrid colorGrid1;
        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
    }
}