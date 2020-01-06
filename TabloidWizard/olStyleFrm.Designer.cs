namespace TabloidWizard
{
    partial class olStyleFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(olStyleFrm));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstStyle = new System.Windows.Forms.ListBox();
            this.toolStripField = new System.Windows.Forms.ToolStrip();
            this.btnAjoutStyle = new System.Windows.Forms.ToolStripButton();
            this.btnSuppStyle = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripField.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(453, 337);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstStyle);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripField);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(685, 337);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 1;
            // 
            // lstStyle
            // 
            this.lstStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStyle.FormattingEnabled = true;
            this.lstStyle.Location = new System.Drawing.Point(0, 0);
            this.lstStyle.Name = "lstStyle";
            this.lstStyle.Size = new System.Drawing.Size(228, 312);
            this.lstStyle.TabIndex = 0;
            this.lstStyle.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // toolStripField
            // 
            this.toolStripField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAjoutStyle,
            this.btnSuppStyle});
            this.toolStripField.Location = new System.Drawing.Point(0, 312);
            this.toolStripField.Name = "toolStripField";
            this.toolStripField.Size = new System.Drawing.Size(228, 25);
            this.toolStripField.TabIndex = 5;
            this.toolStripField.Text = "toolStrip1";
            // 
            // btnAjoutStyle
            // 
            this.btnAjoutStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAjoutStyle.Image = ((System.Drawing.Image)(resources.GetObject("btnAjoutStyle.Image")));
            this.btnAjoutStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjoutStyle.Name = "btnAjoutStyle";
            this.btnAjoutStyle.Size = new System.Drawing.Size(23, 22);
            this.btnAjoutStyle.Text = "toolStripButton1";
            this.btnAjoutStyle.Click += new System.EventHandler(this.btnAjoutStyle_Click);
            // 
            // btnSuppStyle
            // 
            this.btnSuppStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSuppStyle.Image = ((System.Drawing.Image)(resources.GetObject("btnSuppStyle.Image")));
            this.btnSuppStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuppStyle.Name = "btnSuppStyle";
            this.btnSuppStyle.Size = new System.Drawing.Size(23, 22);
            this.btnSuppStyle.Text = "toolStripButton2";
            this.btnSuppStyle.Click += new System.EventHandler(this.btnSuppStyle_Click);
            // 
            // olStyleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 337);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "olStyleFrm";
            this.Text = "Style cartographie";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripField.ResumeLayout(false);
            this.toolStripField.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstStyle;
        private System.Windows.Forms.ToolStrip toolStripField;
        private System.Windows.Forms.ToolStripButton btnAjoutStyle;
        private System.Windows.Forms.ToolStripButton btnSuppStyle;
    }
}