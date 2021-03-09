namespace TabloidWizard
{
    partial class WizardFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardFunction));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.chkAddMenu = new System.Windows.Forms.CheckBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFunction = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.Fin = new Gui.Wizard.WizardPage();
            this.header5 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.Calendar = new Gui.Wizard.WizardPage();
            this.chkDetail = new System.Windows.Forms.CheckBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.Fin.SuspendLayout();
            this.Calendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Controls.Add(this.Calendar);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(340, 281);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.chkAddMenu);
            this.Info.Controls.Add(this.txtFunction);
            this.Info.Controls.Add(this.label3);
            this.Info.Controls.Add(this.cmbFunction);
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = false;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(340, 233);
            this.Info.TabIndex = 4;
            // 
            // chkAddMenu
            // 
            this.chkAddMenu.AutoSize = true;
            this.chkAddMenu.Checked = true;
            this.chkAddMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddMenu.Location = new System.Drawing.Point(191, 176);
            this.chkAddMenu.Name = "chkAddMenu";
            this.chkAddMenu.Size = new System.Drawing.Size(97, 17);
            this.chkAddMenu.TabIndex = 39;
            this.chkAddMenu.Text = "Créer un menu";
            this.chkAddMenu.UseVisualStyleBackColor = true;
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(167, 63);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(121, 21);
            this.txtFunction.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Titre de la nouvelle fonction";
            // 
            // cmbFunction
            // 
            this.cmbFunction.FormattingEnabled = true;
            this.cmbFunction.Location = new System.Drawing.Point(113, 121);
            this.cmbFunction.Name = "cmbFunction";
            this.cmbFunction.Size = new System.Drawing.Size(175, 21);
            this.cmbFunction.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lier la fonction :";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Ajout de fonction";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(340, 57);
            this.header4.TabIndex = 11;
            this.header4.Title = "Assistant d\'ajout";
            // 
            // Fin
            // 
            this.Fin.Controls.Add(this.header5);
            this.Fin.Controls.Add(this.label8);
            this.Fin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fin.IsFinishPage = true;
            this.Fin.Location = new System.Drawing.Point(0, 0);
            this.Fin.Name = "Fin";
            this.Fin.Size = new System.Drawing.Size(340, 233);
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
            this.header5.Size = new System.Drawing.Size(340, 57);
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
            // Calendar
            // 
            this.Calendar.Controls.Add(this.chkDetail);
            this.Calendar.Controls.Add(this.txtTitre);
            this.Calendar.Controls.Add(this.label2);
            this.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Calendar.IsFinishPage = false;
            this.Calendar.Location = new System.Drawing.Point(0, 0);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(340, 281);
            this.Calendar.TabIndex = 7;
            // 
            // chkDetail
            // 
            this.chkDetail.AutoSize = true;
            this.chkDetail.Location = new System.Drawing.Point(15, 129);
            this.chkDetail.Name = "chkDetail";
            this.chkDetail.Size = new System.Drawing.Size(141, 17);
            this.chkDetail.TabIndex = 36;
            this.chkDetail.Text = "Activer l\'affichage détail";
            this.chkDetail.UseVisualStyleBackColor = true;
            // 
            // txtTitre
            // 
            this.txtTitre.Enabled = false;
            this.txtTitre.Location = new System.Drawing.Point(142, 86);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(121, 21);
            this.txtTitre.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Titre de la vue";
            // 
            // WizardFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 361);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardFunction";
            this.Text = "Fonction";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.Calendar.ResumeLayout(false);
            this.Calendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Info;
        private Gui.Wizard.Header header4;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFunction;
        private Gui.Wizard.WizardPage Calendar;
        private System.Windows.Forms.CheckBox chkDetail;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chkAddMenu;
    }
}