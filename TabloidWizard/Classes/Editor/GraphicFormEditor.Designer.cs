namespace TabloidWizard.Classes.Editor
{
    partial class GraphicFormEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicFormEditor));
            this.topSplit = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lstGraphic = new System.Windows.Forms.ListBox();
            this.btnVisu = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSupp = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitDisplay = new System.Windows.Forms.SplitContainer();
            this.imgGraphic = new System.Windows.Forms.PictureBox();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.topSplit)).BeginInit();
            this.topSplit.Panel1.SuspendLayout();
            this.topSplit.Panel2.SuspendLayout();
            this.topSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDisplay)).BeginInit();
            this.splitDisplay.Panel1.SuspendLayout();
            this.splitDisplay.Panel2.SuspendLayout();
            this.splitDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // topSplit
            // 
            this.topSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSplit.Location = new System.Drawing.Point(0, 0);
            this.topSplit.Name = "topSplit";
            // 
            // topSplit.Panel1
            // 
            this.topSplit.Panel1.Controls.Add(this.splitContainer2);
            // 
            // topSplit.Panel2
            // 
            this.topSplit.Panel2.Controls.Add(this.splitDisplay);
            this.topSplit.Size = new System.Drawing.Size(741, 462);
            this.topSplit.SplitterDistance = 246;
            this.topSplit.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Size = new System.Drawing.Size(246, 462);
            this.splitContainer2.SplitterDistance = 197;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lstGraphic);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnVisu);
            this.splitContainer3.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer3.Panel2.Controls.Add(this.btnSupp);
            this.splitContainer3.Size = new System.Drawing.Size(246, 197);
            this.splitContainer3.SplitterDistance = 167;
            this.splitContainer3.TabIndex = 1;
            // 
            // lstGraphic
            // 
            this.lstGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGraphic.FormattingEnabled = true;
            this.lstGraphic.Location = new System.Drawing.Point(0, 0);
            this.lstGraphic.Name = "lstGraphic";
            this.lstGraphic.Size = new System.Drawing.Size(246, 167);
            this.lstGraphic.TabIndex = 0;
            this.lstGraphic.SelectedIndexChanged += new System.EventHandler(this.lstGraphic_SelectedIndexChanged);
            // 
            // btnVisu
            // 
            this.btnVisu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVisu.Location = new System.Drawing.Point(66, 0);
            this.btnVisu.Name = "btnVisu";
            this.btnVisu.Size = new System.Drawing.Size(59, 26);
            this.btnVisu.TabIndex = 2;
            this.btnVisu.Text = "Visualiser";
            this.btnVisu.UseVisualStyleBackColor = true;
            this.btnVisu.Click += new System.EventHandler(this.btnVisu_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(125, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSupp
            // 
            this.btnSupp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSupp.Location = new System.Drawing.Point(177, 0);
            this.btnSupp.Name = "btnSupp";
            this.btnSupp.Size = new System.Drawing.Size(69, 26);
            this.btnSupp.TabIndex = 0;
            this.btnSupp.Text = "Supprimer";
            this.btnSupp.UseVisualStyleBackColor = true;
            this.btnSupp.Click += new System.EventHandler(this.btnSupp_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(246, 261);
            this.propertyGrid1.TabIndex = 2;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // splitDisplay
            // 
            this.splitDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDisplay.Location = new System.Drawing.Point(0, 0);
            this.splitDisplay.Name = "splitDisplay";
            this.splitDisplay.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDisplay.Panel1
            // 
            this.splitDisplay.Panel1.Controls.Add(this.imgGraphic);
            // 
            // splitDisplay.Panel2
            // 
            this.splitDisplay.Panel2.Controls.Add(this.chkPreview);
            this.splitDisplay.Size = new System.Drawing.Size(491, 462);
            this.splitDisplay.SplitterDistance = 428;
            this.splitDisplay.TabIndex = 1;
            // 
            // imgGraphic
            // 
            this.imgGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgGraphic.Location = new System.Drawing.Point(0, 0);
            this.imgGraphic.Name = "imgGraphic";
            this.imgGraphic.Size = new System.Drawing.Size(491, 428);
            this.imgGraphic.TabIndex = 0;
            this.imgGraphic.TabStop = false;
            // 
            // chkPreview
            // 
            this.chkPreview.AutoSize = true;
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point(399, 10);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(85, 17);
            this.chkPreview.TabIndex = 0;
            this.chkPreview.Text = "Prévisualiser";
            this.chkPreview.UseVisualStyleBackColor = true;
            this.chkPreview.CheckedChanged += new System.EventHandler(this.chkPreview_CheckedChanged);
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.topSplit);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.btnCancel);
            this.MainSplit.Panel2.Controls.Add(this.btnOk);
            this.MainSplit.Size = new System.Drawing.Size(741, 497);
            this.MainSplit.SplitterDistance = 462;
            this.MainSplit.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(591, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(666, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // GraphicFormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 497);
            this.Controls.Add(this.MainSplit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GraphicFormEditor";
            this.Text = "Editeur de graphique";
            this.Load += new System.EventHandler(this.GraphicFormEditor_Load);
            this.topSplit.Panel1.ResumeLayout(false);
            this.topSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topSplit)).EndInit();
            this.topSplit.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitDisplay.Panel1.ResumeLayout(false);
            this.splitDisplay.Panel2.ResumeLayout(false);
            this.splitDisplay.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDisplay)).EndInit();
            this.splitDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgGraphic)).EndInit();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer topSplit;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstGraphic;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSupp;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnVisu;
        private System.Windows.Forms.PictureBox imgGraphic;
        private System.Windows.Forms.SplitContainer splitDisplay;
        private System.Windows.Forms.CheckBox chkPreview;
    }
}