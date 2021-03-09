namespace TabloidWizard
{
    partial class WizardCalendrier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardCalendrier));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.fieldDef = new Gui.Wizard.WizardPage();
            this.Calendar = new Gui.Wizard.WizardPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUtilFin = new System.Windows.Forms.RadioButton();
            this.txtFin = new System.Windows.Forms.TextBox();
            this.chkCreaFin = new System.Windows.Forms.RadioButton();
            this.cmbFin = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDebut = new System.Windows.Forms.TextBox();
            this.chkCreaDeb = new System.Windows.Forms.RadioButton();
            this.cmbDeb = new System.Windows.Forms.ComboBox();
            this.chkUtilDeb = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTitre = new System.Windows.Forms.ComboBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.chkCreaTitre = new System.Windows.Forms.RadioButton();
            this.chkExistTitre = new System.Windows.Forms.RadioButton();
            this.radMnParam = new System.Windows.Forms.RadioButton();
            this.radMnPrincipal = new System.Windows.Forms.RadioButton();
            this.chkAddToMenu = new System.Windows.Forms.CheckBox();
            this.Fin = new Gui.Wizard.WizardPage();
            this.header5 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.fieldDef.SuspendLayout();
            this.Calendar.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Fin.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Controls.Add(this.fieldDef);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.fieldDef,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(297, 420);
            this.wizard1.TabIndex = 0;
            // 
            // fieldDef
            // 
            this.fieldDef.Controls.Add(this.Calendar);
            this.fieldDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldDef.IsFinishPage = false;
            this.fieldDef.Location = new System.Drawing.Point(0, 0);
            this.fieldDef.Name = "fieldDef";
            this.fieldDef.Size = new System.Drawing.Size(297, 372);
            this.fieldDef.TabIndex = 6;
            // 
            // Calendar
            // 
            this.Calendar.Controls.Add(this.groupBox3);
            this.Calendar.Controls.Add(this.groupBox2);
            this.Calendar.Controls.Add(this.groupBox1);
            this.Calendar.Controls.Add(this.radMnParam);
            this.Calendar.Controls.Add(this.radMnPrincipal);
            this.Calendar.Controls.Add(this.chkAddToMenu);
            this.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Calendar.IsFinishPage = false;
            this.Calendar.Location = new System.Drawing.Point(0, 0);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(297, 372);
            this.Calendar.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUtilFin);
            this.groupBox3.Controls.Add(this.txtFin);
            this.groupBox3.Controls.Add(this.chkCreaFin);
            this.groupBox3.Controls.Add(this.cmbFin);
            this.groupBox3.Location = new System.Drawing.Point(12, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 87);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nom du champ fin";
            // 
            // chkUtilFin
            // 
            this.chkUtilFin.AutoSize = true;
            this.chkUtilFin.Location = new System.Drawing.Point(70, 52);
            this.chkUtilFin.Name = "chkUtilFin";
            this.chkUtilFin.Size = new System.Drawing.Size(60, 17);
            this.chkUtilFin.TabIndex = 46;
            this.chkUtilFin.Text = "Utiliser ";
            this.chkUtilFin.UseVisualStyleBackColor = true;
            // 
            // txtFin
            // 
            this.txtFin.Location = new System.Drawing.Point(131, 24);
            this.txtFin.Name = "txtFin";
            this.txtFin.Size = new System.Drawing.Size(121, 21);
            this.txtFin.TabIndex = 32;
            // 
            // chkCreaFin
            // 
            this.chkCreaFin.AutoSize = true;
            this.chkCreaFin.Checked = true;
            this.chkCreaFin.Location = new System.Drawing.Point(70, 26);
            this.chkCreaFin.Name = "chkCreaFin";
            this.chkCreaFin.Size = new System.Drawing.Size(55, 17);
            this.chkCreaFin.TabIndex = 38;
            this.chkCreaFin.TabStop = true;
            this.chkCreaFin.Text = "Créer ";
            this.chkCreaFin.UseVisualStyleBackColor = true;
            this.chkCreaFin.CheckedChanged += new System.EventHandler(this.chkCreaFin_CheckedChanged);
            // 
            // cmbFin
            // 
            this.cmbFin.Enabled = false;
            this.cmbFin.FormattingEnabled = true;
            this.cmbFin.Location = new System.Drawing.Point(131, 51);
            this.cmbFin.Name = "cmbFin";
            this.cmbFin.Size = new System.Drawing.Size(150, 21);
            this.cmbFin.TabIndex = 43;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDebut);
            this.groupBox2.Controls.Add(this.chkCreaDeb);
            this.groupBox2.Controls.Add(this.cmbDeb);
            this.groupBox2.Controls.Add(this.chkUtilDeb);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 92);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nom du champ début";
            // 
            // txtDebut
            // 
            this.txtDebut.Location = new System.Drawing.Point(131, 26);
            this.txtDebut.Name = "txtDebut";
            this.txtDebut.Size = new System.Drawing.Size(121, 21);
            this.txtDebut.TabIndex = 33;
            // 
            // chkCreaDeb
            // 
            this.chkCreaDeb.AutoSize = true;
            this.chkCreaDeb.Checked = true;
            this.chkCreaDeb.Location = new System.Drawing.Point(70, 28);
            this.chkCreaDeb.Name = "chkCreaDeb";
            this.chkCreaDeb.Size = new System.Drawing.Size(55, 17);
            this.chkCreaDeb.TabIndex = 37;
            this.chkCreaDeb.TabStop = true;
            this.chkCreaDeb.Text = "Créer ";
            this.chkCreaDeb.UseVisualStyleBackColor = true;
            this.chkCreaDeb.CheckedChanged += new System.EventHandler(this.chkCreaDeb_CheckedChanged);
            // 
            // cmbDeb
            // 
            this.cmbDeb.Enabled = false;
            this.cmbDeb.FormattingEnabled = true;
            this.cmbDeb.Location = new System.Drawing.Point(131, 53);
            this.cmbDeb.Name = "cmbDeb";
            this.cmbDeb.Size = new System.Drawing.Size(150, 21);
            this.cmbDeb.TabIndex = 42;
            // 
            // chkUtilDeb
            // 
            this.chkUtilDeb.AutoSize = true;
            this.chkUtilDeb.Location = new System.Drawing.Point(70, 57);
            this.chkUtilDeb.Name = "chkUtilDeb";
            this.chkUtilDeb.Size = new System.Drawing.Size(60, 17);
            this.chkUtilDeb.TabIndex = 45;
            this.chkUtilDeb.Text = "Utiliser ";
            this.chkUtilDeb.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTitre);
            this.groupBox1.Controls.Add(this.txtTitre);
            this.groupBox1.Controls.Add(this.chkCreaTitre);
            this.groupBox1.Controls.Add(this.chkExistTitre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 83);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nom du champ titre";
            // 
            // cmbTitre
            // 
            this.cmbTitre.DisplayMember = "column_name";
            this.cmbTitre.Enabled = false;
            this.cmbTitre.FormattingEnabled = true;
            this.cmbTitre.Location = new System.Drawing.Point(131, 51);
            this.cmbTitre.Name = "cmbTitre";
            this.cmbTitre.Size = new System.Drawing.Size(150, 21);
            this.cmbTitre.TabIndex = 41;
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(131, 24);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(121, 21);
            this.txtTitre.TabIndex = 35;
            // 
            // chkCreaTitre
            // 
            this.chkCreaTitre.AutoSize = true;
            this.chkCreaTitre.Checked = true;
            this.chkCreaTitre.Location = new System.Drawing.Point(70, 27);
            this.chkCreaTitre.Name = "chkCreaTitre";
            this.chkCreaTitre.Size = new System.Drawing.Size(55, 17);
            this.chkCreaTitre.TabIndex = 36;
            this.chkCreaTitre.TabStop = true;
            this.chkCreaTitre.Text = "Créer ";
            this.chkCreaTitre.UseVisualStyleBackColor = true;
            this.chkCreaTitre.CheckedChanged += new System.EventHandler(this.Titre_CheckedChanged);
            // 
            // chkExistTitre
            // 
            this.chkExistTitre.AutoSize = true;
            this.chkExistTitre.Location = new System.Drawing.Point(70, 52);
            this.chkExistTitre.Name = "chkExistTitre";
            this.chkExistTitre.Size = new System.Drawing.Size(60, 17);
            this.chkExistTitre.TabIndex = 44;
            this.chkExistTitre.Text = "Utiliser ";
            this.chkExistTitre.UseVisualStyleBackColor = true;
            // 
            // radMnParam
            // 
            this.radMnParam.AutoSize = true;
            this.radMnParam.Location = new System.Drawing.Point(117, 340);
            this.radMnParam.Name = "radMnParam";
            this.radMnParam.Size = new System.Drawing.Size(75, 17);
            this.radMnParam.TabIndex = 49;
            this.radMnParam.Text = "Paramètre";
            this.radMnParam.UseVisualStyleBackColor = true;
            // 
            // radMnPrincipal
            // 
            this.radMnPrincipal.AutoSize = true;
            this.radMnPrincipal.Checked = true;
            this.radMnPrincipal.Location = new System.Drawing.Point(117, 317);
            this.radMnPrincipal.Name = "radMnPrincipal";
            this.radMnPrincipal.Size = new System.Drawing.Size(64, 17);
            this.radMnPrincipal.TabIndex = 48;
            this.radMnPrincipal.TabStop = true;
            this.radMnPrincipal.Text = "Principal";
            this.radMnPrincipal.UseVisualStyleBackColor = true;
            // 
            // chkAddToMenu
            // 
            this.chkAddToMenu.AutoSize = true;
            this.chkAddToMenu.Checked = true;
            this.chkAddToMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddToMenu.Location = new System.Drawing.Point(42, 294);
            this.chkAddToMenu.Name = "chkAddToMenu";
            this.chkAddToMenu.Size = new System.Drawing.Size(106, 17);
            this.chkAddToMenu.TabIndex = 47;
            this.chkAddToMenu.Text = "Ajouter au menu";
            this.chkAddToMenu.UseVisualStyleBackColor = true;
            this.chkAddToMenu.CheckedChanged += new System.EventHandler(this.chkAddToMenu_CheckedChanged);
            // 
            // Fin
            // 
            this.Fin.Controls.Add(this.header5);
            this.Fin.Controls.Add(this.label8);
            this.Fin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fin.IsFinishPage = true;
            this.Fin.Location = new System.Drawing.Point(0, 0);
            this.Fin.Name = "Fin";
            this.Fin.Size = new System.Drawing.Size(297, 372);
            this.Fin.TabIndex = 5;
            this.Fin.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Button_end);
            // 
            // header5
            // 
            this.header5.BackColor = System.Drawing.SystemColors.Control;
            this.header5.CausesValidation = false;
            this.header5.Description = "";
            this.header5.Dock = System.Windows.Forms.DockStyle.Top;
            this.header5.Image = ((System.Drawing.Image)(resources.GetObject("header5.Image")));
            this.header5.Location = new System.Drawing.Point(0, 0);
            this.header5.Name = "header5";
            this.header5.Size = new System.Drawing.Size(297, 57);
            this.header5.TabIndex = 12;
            this.header5.Title = "Assistant d\'ajout";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cliquez sur \"Finish\" pour réaliser l\'opération.";
            // 
            // WizardCalendrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 500);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 500);
            this.Name = "WizardCalendrier";
            this.Text = "Calendrier";
            this.wizard1.ResumeLayout(false);
            this.fieldDef.ResumeLayout(false);
            this.Calendar.ResumeLayout(false);
            this.Calendar.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private Gui.Wizard.WizardPage fieldDef;
        private Gui.Wizard.WizardPage Calendar;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtDebut;
        private System.Windows.Forms.TextBox txtFin;
        private System.Windows.Forms.RadioButton chkUtilFin;
        private System.Windows.Forms.RadioButton chkUtilDeb;
        private System.Windows.Forms.RadioButton chkExistTitre;
        private System.Windows.Forms.ComboBox cmbFin;
        private System.Windows.Forms.ComboBox cmbDeb;
        private System.Windows.Forms.ComboBox cmbTitre;
        private System.Windows.Forms.RadioButton chkCreaFin;
        private System.Windows.Forms.RadioButton chkCreaDeb;
        private System.Windows.Forms.RadioButton chkCreaTitre;
        private System.Windows.Forms.RadioButton radMnParam;
        private System.Windows.Forms.RadioButton radMnPrincipal;
        private System.Windows.Forms.CheckBox chkAddToMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}