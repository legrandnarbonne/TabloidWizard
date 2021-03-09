namespace TabloidWizard
{
    partial class WizardAlias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardAlias));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewDbKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.Calendar = new Gui.Wizard.WizardPage();
            this.chkDetail = new System.Windows.Forms.CheckBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.Calendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Controls.Add(this.Calendar);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info});
            this.wizard1.Size = new System.Drawing.Size(365, 398);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.txtNewName);
            this.Info.Controls.Add(this.label3);
            this.Info.Controls.Add(this.txtNewDbKey);
            this.Info.Controls.Add(this.label6);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = false;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(365, 350);
            this.Info.TabIndex = 4;
            this.Info.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Info_CloseFromNext);
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(167, 63);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(121, 21);
            this.txtNewName.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nouveau nom de jointure";
            // 
            // txtNewDbKey
            // 
            this.txtNewDbKey.Location = new System.Drawing.Point(167, 100);
            this.txtNewDbKey.Name = "txtNewDbKey";
            this.txtNewDbKey.Size = new System.Drawing.Size(121, 21);
            this.txtNewDbKey.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Nouveau nom de clef";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(365, 57);
            this.header4.TabIndex = 11;
            this.header4.Title = "Transformation en alias";
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
            this.Calendar.Size = new System.Drawing.Size(365, 398);
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
            // WizardAlias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 478);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardAlias";
            this.Text = "Alias";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.Calendar.ResumeLayout(false);
            this.Calendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Info;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private Gui.Wizard.WizardPage Calendar;
        private System.Windows.Forms.CheckBox chkDetail;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewDbKey;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Label label3;
    }
}