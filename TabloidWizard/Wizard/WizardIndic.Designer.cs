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
            this.wiStart = new Gui.Wizard.WizardPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.header6 = new Gui.Wizard.Header();
            this.wiNewIndic = new Gui.Wizard.WizardPage();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.header7 = new Gui.Wizard.Header();
            this.wiUseExisting = new Gui.Wizard.WizardPage();
            this.header3 = new Gui.Wizard.Header();
            this.wizard1 = new Gui.Wizard.Wizard();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.Fin.SuspendLayout();
            this.wiStart.SuspendLayout();
            this.wiNewIndic.SuspendLayout();
            this.wiUseExisting.SuspendLayout();
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
            this.Fin.Size = new System.Drawing.Size(298, 300);
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
            this.header4.Size = new System.Drawing.Size(298, 57);
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
            // wiStart
            // 
            this.wiStart.Controls.Add(this.radioButton2);
            this.wiStart.Controls.Add(this.radioButton1);
            this.wiStart.Controls.Add(this.header6);
            this.wiStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wiStart.IsFinishPage = false;
            this.wiStart.Location = new System.Drawing.Point(0, 0);
            this.wiStart.Name = "wiStart";
            this.wiStart.Size = new System.Drawing.Size(298, 300);
            this.wiStart.TabIndex = 6;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(62, 143);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(164, 17);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "Utiliser un indicateur existant";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(62, 107);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(152, 17);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Créer un nouvel indicateur";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // header6
            // 
            this.header6.BackColor = System.Drawing.SystemColors.Control;
            this.header6.CausesValidation = false;
            this.header6.Description = "";
            this.header6.Dock = System.Windows.Forms.DockStyle.Top;
            this.header6.Image = ((System.Drawing.Image)(resources.GetObject("header6.Image")));
            this.header6.Location = new System.Drawing.Point(0, 0);
            this.header6.Name = "header6";
            this.header6.Size = new System.Drawing.Size(298, 57);
            this.header6.TabIndex = 27;
            this.header6.Title = "Assistant ajout d\'indicateur";
            // 
            // wiNewIndic
            // 
            this.wiNewIndic.Controls.Add(this.cmbType);
            this.wiNewIndic.Controls.Add(this.label10);
            this.wiNewIndic.Controls.Add(this.header7);
            this.wiNewIndic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wiNewIndic.IsFinishPage = false;
            this.wiNewIndic.Location = new System.Drawing.Point(0, 0);
            this.wiNewIndic.Name = "wiNewIndic";
            this.wiNewIndic.Size = new System.Drawing.Size(298, 300);
            this.wiNewIndic.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(132, 140);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(137, 21);
            this.cmbType.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 143);
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
            this.header7.Size = new System.Drawing.Size(298, 57);
            this.header7.TabIndex = 28;
            this.header7.Title = "Assistant ajout d\'indicateur";
            // 
            // wiUseExisting
            // 
            this.wiUseExisting.Controls.Add(this.label1);
            this.wiUseExisting.Controls.Add(this.comboBox3);
            this.wiUseExisting.Controls.Add(this.label3);
            this.wiUseExisting.Controls.Add(this.comboBox1);
            this.wiUseExisting.Controls.Add(this.header3);
            this.wiUseExisting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wiUseExisting.IsFinishPage = false;
            this.wiUseExisting.Location = new System.Drawing.Point(0, 0);
            this.wiUseExisting.Name = "wiUseExisting";
            this.wiUseExisting.Size = new System.Drawing.Size(298, 300);
            this.wiUseExisting.TabIndex = 3;
            // 
            // header3
            // 
            this.header3.BackColor = System.Drawing.SystemColors.Control;
            this.header3.CausesValidation = false;
            this.header3.Description = "";
            this.header3.Dock = System.Windows.Forms.DockStyle.Top;
            this.header3.Image = ((System.Drawing.Image)(resources.GetObject("header3.Image")));
            this.header3.Location = new System.Drawing.Point(0, 0);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(298, 57);
            this.header3.TabIndex = 29;
            this.header3.Title = "Assistant ajout d\'indicateur";
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.wiStart);
            this.wizard1.Controls.Add(this.wiNewIndic);
            this.wizard1.Controls.Add(this.wiUseExisting);
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wiStart,
            this.wiNewIndic,
            this.wiUseExisting,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(298, 348);
            this.wizard1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Utiliser un indicateur rattaché à :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Indicateur disponible :";
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(149, 168);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(91, 21);
            this.comboBox3.TabIndex = 36;
            // 
            // WizardIndic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 348);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardIndic";
            this.Text = "Wizard";
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.wiStart.ResumeLayout(false);
            this.wiStart.PerformLayout();
            this.wiNewIndic.ResumeLayout(false);
            this.wiNewIndic.PerformLayout();
            this.wiUseExisting.ResumeLayout(false);
            this.wiUseExisting.PerformLayout();
            this.wizard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.Label label8;
        private Gui.Wizard.WizardPage wiStart;
        private Gui.Wizard.Header header6;
        private Gui.Wizard.WizardPage wiNewIndic;
        private Gui.Wizard.Header header7;
        private Gui.Wizard.WizardPage wiUseExisting;
        private Gui.Wizard.Header header3;
        private Gui.Wizard.Wizard wizard1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}