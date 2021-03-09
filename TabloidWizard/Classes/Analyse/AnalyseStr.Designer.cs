namespace TabloidWizard
{
    partial class AnalyseStr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyseStr));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.chkFullDisplay = new MetroFramework.Controls.MetroToggle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTable = new System.Windows.Forms.Label();
            this.lbView = new System.Windows.Forms.Label();
            this.grpAnalyse = new System.Windows.Forms.GroupBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpAnalyse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(19, 79);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(472, 390);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btn.png");
            this.imageList1.Images.SetKeyName(1, "analyse1.png");
            this.imageList1.Images.SetKeyName(2, "analyse2.png");
            this.imageList1.Images.SetKeyName(3, "analyse3.png");
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(645, 474);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chkFullDisplay
            // 
            this.chkFullDisplay.AutoSize = true;
            this.chkFullDisplay.Location = new System.Drawing.Point(640, 56);
            this.chkFullDisplay.Name = "chkFullDisplay";
            this.chkFullDisplay.Size = new System.Drawing.Size(80, 17);
            this.chkFullDisplay.TabIndex = 2;
            this.chkFullDisplay.Text = "Off";
            this.chkFullDisplay.UseSelectable = true;
            this.chkFullDisplay.CheckedChanged += new System.EventHandler(this.chkFullDisplay_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTable);
            this.groupBox1.Controls.Add(this.lbView);
            this.groupBox1.Location = new System.Drawing.Point(509, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Context";
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Location = new System.Drawing.Point(29, 51);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(40, 13);
            this.lbTable.TabIndex = 1;
            this.lbTable.Text = "Table :";
            // 
            // lbView
            // 
            this.lbView.AutoSize = true;
            this.lbView.Location = new System.Drawing.Point(29, 25);
            this.lbView.Name = "lbView";
            this.lbView.Size = new System.Drawing.Size(32, 13);
            this.lbView.TabIndex = 0;
            this.lbView.Text = "Vue :";
            // 
            // grpAnalyse
            // 
            this.grpAnalyse.Controls.Add(this.txtdesc);
            this.grpAnalyse.Controls.Add(this.pnlBtn);
            this.grpAnalyse.Controls.Add(this.txtRes);
            this.grpAnalyse.Location = new System.Drawing.Point(509, 170);
            this.grpAnalyse.Name = "grpAnalyse";
            this.grpAnalyse.Size = new System.Drawing.Size(211, 298);
            this.grpAnalyse.TabIndex = 4;
            this.grpAnalyse.TabStop = false;
            this.grpAnalyse.Text = "Analyse";
            // 
            // txtdesc
            // 
            this.txtdesc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtdesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdesc.Enabled = false;
            this.txtdesc.Location = new System.Drawing.Point(6, 82);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(199, 98);
            this.txtdesc.TabIndex = 2;
            // 
            // pnlBtn
            // 
            this.pnlBtn.AutoSize = true;
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.Location = new System.Drawing.Point(3, 295);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(205, 0);
            this.pnlBtn.TabIndex = 1;
            // 
            // txtRes
            // 
            this.txtRes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRes.Enabled = false;
            this.txtRes.Location = new System.Drawing.Point(6, 19);
            this.txtRes.Multiline = true;
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(199, 57);
            this.txtRes.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(270, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(327, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(393, 31);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(415, 32);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(13, 13);
            this.lbl3.TabIndex = 8;
            this.lbl3.Text = "0";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(349, 32);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 13);
            this.lbl2.TabIndex = 9;
            this.lbl2.Text = "0";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(292, 32);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 13);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tout afficher :";
            // 
            // AnalyseStr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 503);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpAnalyse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkFullDisplay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(741, 503);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(741, 503);
            this.Name = "AnalyseStr";
            this.Text = "Analyse de la structure";
            this.Load += new System.EventHandler(this.AnalyseStr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAnalyse.ResumeLayout(false);
            this.grpAnalyse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.Label lbView;
        private System.Windows.Forms.GroupBox grpAnalyse;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.Panel pnlBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtdesc;
        private MetroFramework.Controls.MetroToggle chkFullDisplay;
        private System.Windows.Forms.Label label1;
    }
}