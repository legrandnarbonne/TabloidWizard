namespace TabloidWizard
{
    partial class WizardLoc
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardLoc));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.txtSrid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAddMenu = new System.Windows.Forms.CheckBox();
            this.txtGeomFiled = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info});
            this.wizard1.Size = new System.Drawing.Size(364, 341);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.txtSrid);
            this.Info.Controls.Add(this.label2);
            this.Info.Controls.Add(this.cmbType);
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.chkAddMenu);
            this.Info.Controls.Add(this.txtGeomFiled);
            this.Info.Controls.Add(this.label7);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = true;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(364, 293);
            this.Info.TabIndex = 4;
            this.Info.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Info_CloseFromNext);
            // 
            // txtSrid
            // 
            this.txtSrid.Location = new System.Drawing.Point(151, 202);
            this.txtSrid.Name = "txtSrid";
            this.txtSrid.Size = new System.Drawing.Size(121, 21);
            this.txtSrid.TabIndex = 32;
            this.txtSrid.Text = "3943";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Projection :";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Point",
            "Polygon",
            "Line"});
            this.cmbType.Location = new System.Drawing.Point(151, 154);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Type de géométrie :";
            // 
            // chkAddMenu
            // 
            this.chkAddMenu.AutoSize = true;
            this.chkAddMenu.Checked = true;
            this.chkAddMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddMenu.Location = new System.Drawing.Point(113, 245);
            this.chkAddMenu.Name = "chkAddMenu";
            this.chkAddMenu.Size = new System.Drawing.Size(187, 17);
            this.chkAddMenu.TabIndex = 28;
            this.chkAddMenu.Text = "Ajouter la carte au menu principal";
            this.chkAddMenu.UseVisualStyleBackColor = true;
            // 
            // txtGeomFiled
            // 
            this.txtGeomFiled.Location = new System.Drawing.Point(151, 108);
            this.txtGeomFiled.Name = "txtGeomFiled";
            this.txtGeomFiled.Size = new System.Drawing.Size(121, 21);
            this.txtGeomFiled.TabIndex = 27;
            this.txtGeomFiled.Text = "the_geom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Nom du champ géométrie :";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Ajout d\'une carte";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(364, 57);
            this.header4.TabIndex = 11;
            this.header4.Title = "Cartographie";
            // 
            // WizardLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 421);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardLoc";
            this.Text = "Géolocalisation";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Info;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtGeomFiled;
        private System.Windows.Forms.CheckBox chkAddMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtSrid;
        private System.Windows.Forms.Label label2;
    }
}