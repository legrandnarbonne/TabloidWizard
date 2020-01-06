namespace TabloidWizard
{
    partial class MenuEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuEditor));
            this.MnTree = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouter = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnMenuPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.monterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.décendreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnTree
            // 
            this.MnTree.AllowDrop = true;
            this.MnTree.ContextMenuStrip = this.contextMenu;
            this.MnTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MnTree.Location = new System.Drawing.Point(0, 0);
            this.MnTree.Name = "MnTree";
            this.MnTree.Size = new System.Drawing.Size(502, 349);
            this.MnTree.TabIndex = 0;
            this.MnTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.MnTree_ItemDrag);
            this.MnTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.MnTree_DragDrop);
            this.MnTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.MnTree_DragEnter);
            this.MnTree.DoubleClick += new System.EventHandler(this.MnTree_DoubleClick);
            this.MnTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MnTree_MouseUp);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editerToolStripMenuItem,
            this.ajouter,
            this.ajouterUnMenuPrincipalToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.toolStripSeparator1,
            this.monterToolStripMenuItem,
            this.décendreToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(214, 142);
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.editerToolStripMenuItem.Text = "Editer";
            this.editerToolStripMenuItem.Click += new System.EventHandler(this.editerToolStripMenuItem_Click);
            // 
            // ajouter
            // 
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(213, 22);
            this.ajouter.Text = "Ajouter un sous menu";
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // ajouterUnMenuPrincipalToolStripMenuItem
            // 
            this.ajouterUnMenuPrincipalToolStripMenuItem.Name = "ajouterUnMenuPrincipalToolStripMenuItem";
            this.ajouterUnMenuPrincipalToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.ajouterUnMenuPrincipalToolStripMenuItem.Text = "Ajouter un menu principal";
            this.ajouterUnMenuPrincipalToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnMenuPrincipalToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // monterToolStripMenuItem
            // 
            this.monterToolStripMenuItem.Name = "monterToolStripMenuItem";
            this.monterToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.monterToolStripMenuItem.Text = "Monter";
            this.monterToolStripMenuItem.Click += new System.EventHandler(this.moveMenu);
            // 
            // décendreToolStripMenuItem
            // 
            this.décendreToolStripMenuItem.Name = "décendreToolStripMenuItem";
            this.décendreToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.décendreToolStripMenuItem.Text = "Décendre";
            this.décendreToolStripMenuItem.Click += new System.EventHandler(this.moveMenu);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(427, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(352, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MnTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(502, 381);
            this.splitContainer1.SplitterDistance = 349;
            this.splitContainer1.TabIndex = 3;
            // 
            // MenuEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 381);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuEditor";
            this.Text = "Editeur de menu";
            this.contextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView MnTree;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ajouter;
        private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnMenuPrincipalToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem monterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem décendreToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}