namespace TabloidWizard.Classes.Control
{
    partial class GenericPropertiesViewer<CollectionType, ObjectType>
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblList = new System.Windows.Forms.Label();
            this.splitChamps = new System.Windows.Forms.SplitContainer();
            this.list = new System.Windows.Forms.TreeView();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSepCopy = new System.Windows.Forms.ToolStripSeparator();
            this.cmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.moveSep = new System.Windows.Forms.ToolStripSeparator();
            this.btnToTop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToBotom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripField = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.properties = new System.Windows.Forms.PropertyGrid();
            this.lblProperties = new System.Windows.Forms.Label();
            this.searchBox1 = new TabloidWizard.Classes.Control.SearchBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitChamps)).BeginInit();
            this.splitChamps.Panel1.SuspendLayout();
            this.splitChamps.Panel2.SuspendLayout();
            this.splitChamps.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.toolStripField.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblList
            // 
            this.lblList.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.ForeColor = System.Drawing.Color.White;
            this.lblList.Location = new System.Drawing.Point(0, 0);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(271, 23);
            this.lblList.TabIndex = 2;
            this.lblList.Text = "- Liste des Champs -";
            this.lblList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitChamps
            // 
            this.splitChamps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChamps.Location = new System.Drawing.Point(3, 3);
            this.splitChamps.Name = "splitChamps";
            // 
            // splitChamps.Panel1
            // 
            this.splitChamps.Panel1.Controls.Add(this.list);
            this.splitChamps.Panel1.Controls.Add(this.searchBox1);
            this.splitChamps.Panel1.Controls.Add(this.toolStripField);
            this.splitChamps.Panel1.Controls.Add(this.lblList);
            // 
            // splitChamps.Panel2
            // 
            this.splitChamps.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitChamps.Panel2.Controls.Add(this.properties);
            this.splitChamps.Panel2.Controls.Add(this.lblProperties);
            this.splitChamps.Size = new System.Drawing.Size(828, 355);
            this.splitChamps.SplitterDistance = 273;
            this.splitChamps.TabIndex = 1;
            // 
            // list
            // 
            this.list.AllowDrop = true;
            this.list.ContextMenuStrip = this.ContextMenu;
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.HideSelection = false;
            this.list.Location = new System.Drawing.Point(0, 44);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(271, 284);
            this.list.TabIndex = 5;
            this.list.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.list_ItemDrag);
            this.list.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstBox_SelectedIndexChanged);
            this.list.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_DragDrop);
            this.list.DragEnter += new System.Windows.Forms.DragEventHandler(this.list_DragEnter);
            this.list.DragOver += new System.Windows.Forms.DragEventHandler(this.list_DragOver);
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listkeyEvent);
            this.list.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_MouseDown);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmAdd,
            this.cmAddChild,
            this.cmDelete,
            this.cmEdit,
            this.cmSepCopy,
            this.cmCopy,
            this.cmPaste,
            this.moveSep,
            this.btnToTop,
            this.btnMoveUp,
            this.btnMoveDown,
            this.btnToBotom});
            this.ContextMenu.Name = "contextMenuEd";
            this.ContextMenu.Size = new System.Drawing.Size(168, 236);
            this.ContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // cmAdd
            // 
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.cmAdd.Size = new System.Drawing.Size(167, 22);
            this.cmAdd.Text = "Ajouter";
            this.cmAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmAddChild
            // 
            this.cmAddChild.Name = "cmAddChild";
            this.cmAddChild.Size = new System.Drawing.Size(167, 22);
            this.cmAddChild.Text = "Ajouter un enfant";
            this.cmAddChild.Click += new System.EventHandler(this.btnAddChild_Click_1);
            // 
            // cmDelete
            // 
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.cmDelete.Size = new System.Drawing.Size(167, 22);
            this.cmDelete.Text = "Supprimer";
            this.cmDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmEdit
            // 
            this.cmEdit.Name = "cmEdit";
            this.cmEdit.Size = new System.Drawing.Size(167, 22);
            this.cmEdit.Text = "Editer";
            this.cmEdit.Visible = false;
            this.cmEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cmSepCopy
            // 
            this.cmSepCopy.Name = "cmSepCopy";
            this.cmSepCopy.Size = new System.Drawing.Size(164, 6);
            // 
            // cmCopy
            // 
            this.cmCopy.Name = "cmCopy";
            this.cmCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cmCopy.Size = new System.Drawing.Size(167, 22);
            this.cmCopy.Text = "Copier";
            this.cmCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cmPaste
            // 
            this.cmPaste.Name = "cmPaste";
            this.cmPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cmPaste.Size = new System.Drawing.Size(167, 22);
            this.cmPaste.Text = "Coller";
            this.cmPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // moveSep
            // 
            this.moveSep.Name = "moveSep";
            this.moveSep.Size = new System.Drawing.Size(164, 6);
            // 
            // btnToTop
            // 
            this.btnToTop.Name = "btnToTop";
            this.btnToTop.Size = new System.Drawing.Size(167, 22);
            this.btnToTop.Text = "Placer en haut";
            this.btnToTop.Click += new System.EventHandler(this.btnToTop_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(167, 22);
            this.btnMoveUp.Text = "Monter";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(167, 22);
            this.btnMoveDown.Text = "Descendre";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnToBotom
            // 
            this.btnToBotom.Name = "btnToBotom";
            this.btnToBotom.Size = new System.Drawing.Size(167, 22);
            this.btnToBotom.Text = "Placer en bas";
            this.btnToBotom.Click += new System.EventHandler(this.btnToBotom_Click);
            // 
            // toolStripField
            // 
            this.toolStripField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDelete});
            this.toolStripField.Location = new System.Drawing.Point(0, 328);
            this.toolStripField.Name = "toolStripField";
            this.toolStripField.Size = new System.Drawing.Size(271, 25);
            this.toolStripField.TabIndex = 4;
            this.toolStripField.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::TabloidWizard.Properties.Resources.ajout;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Ajouter un champ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::TabloidWizard.Properties.Resources.suppr2;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "toolStripButton2";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // properties
            // 
            this.properties.CategoryForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.properties.CommandsBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.properties.CommandsLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.properties.HelpBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.properties.HelpBorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.properties.LineColor = System.Drawing.SystemColors.InactiveCaption;
            this.properties.Location = new System.Drawing.Point(0, 23);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(549, 330);
            this.properties.TabIndex = 4;
            this.properties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.properties_PropertyValueChanged);
            // 
            // lblProperties
            // 
            this.lblProperties.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProperties.ForeColor = System.Drawing.Color.White;
            this.lblProperties.Location = new System.Drawing.Point(0, 0);
            this.lblProperties.Name = "lblProperties";
            this.lblProperties.Size = new System.Drawing.Size(549, 23);
            this.lblProperties.TabIndex = 3;
            this.lblProperties.Text = "- Sélectionnez une entrée dans la liste de gauche -";
            this.lblProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBox1
            // 
            this.searchBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox1.Location = new System.Drawing.Point(0, 23);
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.OnTextChange = null;
            this.searchBox1.Size = new System.Drawing.Size(271, 21);
            this.searchBox1.TabIndex = 6;
            // 
            // GenericPropertiesViewer
            // 
            this.Controls.Add(this.splitChamps);
            this.Name = "GenericPropertiesViewer";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(834, 361);
            this.splitChamps.Panel1.ResumeLayout(false);
            this.splitChamps.Panel1.PerformLayout();
            this.splitChamps.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChamps)).EndInit();
            this.splitChamps.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.toolStripField.ResumeLayout(false);
            this.toolStripField.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.SplitContainer splitChamps;
        private System.Windows.Forms.PropertyGrid properties;
        private System.Windows.Forms.Label lblProperties;
        private System.Windows.Forms.ToolStrip toolStripField;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private SearchBox searchBox1;
        public System.Windows.Forms.TreeView list;
        public System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmAdd;
        private System.Windows.Forms.ToolStripMenuItem cmAddChild;
        private System.Windows.Forms.ToolStripMenuItem cmDelete;
        private System.Windows.Forms.ToolStripMenuItem cmEdit;
        private System.Windows.Forms.ToolStripSeparator cmSepCopy;
        private System.Windows.Forms.ToolStripMenuItem cmCopy;
        private System.Windows.Forms.ToolStripMenuItem cmPaste;
        private System.Windows.Forms.ToolStripSeparator moveSep;
        private System.Windows.Forms.ToolStripMenuItem btnToTop;
        private System.Windows.Forms.ToolStripMenuItem btnMoveUp;
        private System.Windows.Forms.ToolStripMenuItem btnMoveDown;
        private System.Windows.Forms.ToolStripMenuItem btnToBotom;
    }
}
