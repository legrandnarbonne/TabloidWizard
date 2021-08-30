namespace TabloidWizard
{
    partial class IndicLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicLayout));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picAddLine = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeIndic = new System.Windows.Forms.ToolStripMenuItem();
            this.delCell = new System.Windows.Forms.ToolStripMenuItem();
            this.delRow = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCreateIndic = new System.Windows.Forms.Button();
            this.btnRemoveIndic = new System.Windows.Forms.Button();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbIndic = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAddLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // picAddLine
            // 
            resources.ApplyResources(this.picAddLine, "picAddLine");
            this.picAddLine.Name = "picAddLine";
            this.picAddLine.TabStop = false;
            this.toolTip1.SetToolTip(this.picAddLine, resources.GetString("picAddLine.ToolTip"));
            this.picAddLine.Click += new System.EventHandler(this.picPanelAddLine_Click);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.ContextMenuStrip = this.contextMenuStrip1;
            this.panel.Controls.Add(this.picAddLine, 0, 0);
            this.panel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.panel.Name = "panel";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeIndic,
            this.delCell,
            this.delRow});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // removeIndic
            // 
            this.removeIndic.Name = "removeIndic";
            resources.ApplyResources(this.removeIndic, "removeIndic");
            this.removeIndic.Click += new System.EventHandler(this.removeIndic_Click);
            // 
            // delCell
            // 
            this.delCell.Name = "delCell";
            resources.ApplyResources(this.delCell, "delCell");
            // 
            // delRow
            // 
            this.delRow.Name = "delRow";
            resources.ApplyResources(this.delRow, "delRow");
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.propertyGrid1);
            this.splitContainer4.Panel1.Controls.Add(this.cmbIndic);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.button4);
            this.splitContainer4.Panel2.Controls.Add(this.button3);
            this.splitContainer4.Panel2.Controls.Add(this.btnRemoveIndic);
            this.splitContainer4.Panel2.Controls.Add(this.btnCreateIndic);
            this.splitContainer4.Panel2.Controls.Add(this.btnAddLine);
            this.splitContainer4.Panel2.Controls.Add(this.button2);
            // 
            // propertyGrid1
            // 
            resources.ApplyResources(this.propertyGrid1, "propertyGrid1");
            this.propertyGrid1.Name = "propertyGrid1";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCreateIndic
            // 
            resources.ApplyResources(this.btnCreateIndic, "btnCreateIndic");
            this.btnCreateIndic.Name = "btnCreateIndic";
            this.btnCreateIndic.UseVisualStyleBackColor = true;
            this.btnCreateIndic.Click += new System.EventHandler(this.btnCreateIndic_Click);
            // 
            // btnRemoveIndic
            // 
            resources.ApplyResources(this.btnRemoveIndic, "btnRemoveIndic");
            this.btnRemoveIndic.Name = "btnRemoveIndic";
            this.btnRemoveIndic.UseVisualStyleBackColor = true;
            this.btnRemoveIndic.Click += new System.EventHandler(this.btnRemoveIndic_Click);
            // 
            // btnAddLine
            // 
            resources.ApplyResources(this.btnAddLine, "btnAddLine");
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbIndic
            // 
            resources.ApplyResources(this.cmbIndic, "cmbIndic");
            this.cmbIndic.FormattingEnabled = true;
            this.cmbIndic.Name = "cmbIndic";
            this.cmbIndic.SelectedIndexChanged += new System.EventHandler(this.cmbIndic_SelectedIndexChanged);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // IndicLayout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "IndicLayout";
            ((System.ComponentModel.ISupportInitialize)(this.picAddLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel panel;
        private System.Windows.Forms.PictureBox picAddLine;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeIndic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem delCell;
        private System.Windows.Forms.ToolStripMenuItem delRow;
        private System.Windows.Forms.Button btnCreateIndic;
        private System.Windows.Forms.Button btnRemoveIndic;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbIndic;
        private System.Windows.Forms.Button button4;
    }
}