namespace TabloidWizard
{
    partial class WizardIndic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardIndic));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Fin = new Gui.Wizard.WizardPage();
            this.header4 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.wiNewIndic = new Gui.Wizard.WizardPage();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.header7 = new Gui.Wizard.Header();
            this.wizard1 = new Gui.Wizard.Wizard();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIndic = new System.Windows.Forms.TextBox();
            this.Fin.SuspendLayout();
            this.wiNewIndic.SuspendLayout();
            this.wizard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fin
            // 
            this.Fin.Controls.Add(this.header4);
            this.Fin.Controls.Add(this.label8);
            this.Fin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fin.IsFinishPage = true;
            this.Fin.Location = new System.Drawing.Point(0, 0);
            this.Fin.Name = "Fin";
            this.Fin.Size = new System.Drawing.Size(325, 276);
            this.Fin.TabIndex = 5;
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
            this.header4.Size = new System.Drawing.Size(325, 57);
            this.header4.TabIndex = 29;
            this.header4.Title = "Assistant ajout de jointure";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Utilisez le bouton Finish pour créer l\'objet";
            // 
            // wiNewIndic
            // 
            this.wiNewIndic.Controls.Add(this.txtIndic);
            this.wiNewIndic.Controls.Add(this.label1);
            this.wiNewIndic.Controls.Add(this.cmbType);
            this.wiNewIndic.Controls.Add(this.label10);
            this.wiNewIndic.Controls.Add(this.header7);
            this.wiNewIndic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wiNewIndic.IsFinishPage = false;
            this.wiNewIndic.Location = new System.Drawing.Point(0, 0);
            this.wiNewIndic.Name = "wiNewIndic";
            this.wiNewIndic.Size = new System.Drawing.Size(325, 276);
            this.wiNewIndic.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(126, 114);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(137, 21);
            this.cmbType.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Type d\'indicateur :";
            // 
            // header7
            // 
            this.header7.BackColor = System.Drawing.SystemColors.Control;
            this.header7.CausesValidation = false;
            this.header7.Description = "";
            this.header7.Dock = System.Windows.Forms.DockStyle.Top;
            this.header7.Image = ((System.Drawing.Image)(resources.GetObject("header7.Image")));
            this.header7.Location = new System.Drawing.Point(0, 0);
            this.header7.Name = "header7";
            this.header7.Size = new System.Drawing.Size(325, 57);
            this.header7.TabIndex = 28;
            this.header7.Title = "Assistant ajout d\'indicateur";
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.wiNewIndic);
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wiNewIndic,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(325, 324);
            this.wizard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Titre :";
            // 
            // txtIndic
            // 
            this.txtIndic.Location = new System.Drawing.Point(126, 71);
            this.txtIndic.Name = "txtIndic";
            this.txtIndic.Size = new System.Drawing.Size(137, 21);
            this.txtIndic.TabIndex = 32;
            // 
            // WizardIndic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 404);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardIndic";
            this.Text = "Indicateur";
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.wiNewIndic.ResumeLayout(false);
            this.wiNewIndic.PerformLayout();
            this.wizard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.Label label8;
        private Gui.Wizard.WizardPage wiNewIndic;
        private Gui.Wizard.Header header7;
        private Gui.Wizard.Wizard wizard1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIndic;
        private System.Windows.Forms.Label label1;
    }
}