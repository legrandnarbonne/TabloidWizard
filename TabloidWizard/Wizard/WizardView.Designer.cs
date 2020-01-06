namespace TabloidWizard
{
    partial class WizardTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardTable));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.txtNomVue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.radUseExistingTable = new System.Windows.Forms.RadioButton();
            this.radAddTable = new System.Windows.Forms.RadioButton();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.TxtRef = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.Fin = new Gui.Wizard.WizardPage();
            this.header5 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.wizardPage1 = new Gui.Wizard.WizardPage();
            this.chkDefaultView = new System.Windows.Forms.CheckBox();
            this.chkAjMenu = new System.Windows.Forms.CheckBox();
            this.radMnParam = new System.Windows.Forms.RadioButton();
            this.radMnMain = new System.Windows.Forms.RadioButton();
            this.Calendar = new Gui.Wizard.WizardPage();
            this.chkDetail = new System.Windows.Forms.CheckBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtInititView = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.Fin.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.Calendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Controls.Add(this.wizardPage1);
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Controls.Add(this.Calendar);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info,
            this.wizardPage1,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(335, 383);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.txtInititView);
            this.Info.Controls.Add(this.label3);
            this.Info.Controls.Add(this.txtNomVue);
            this.Info.Controls.Add(this.label6);
            this.Info.Controls.Add(this.cmbTable);
            this.Info.Controls.Add(this.radUseExistingTable);
            this.Info.Controls.Add(this.radAddTable);
            this.Info.Controls.Add(this.txtSchema);
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.txtTable);
            this.Info.Controls.Add(this.TxtRef);
            this.Info.Controls.Add(this.label5);
            this.Info.Controls.Add(this.label7);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = false;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(335, 335);
            this.Info.TabIndex = 4;
            // 
            // txtNomVue
            // 
            this.txtNomVue.Location = new System.Drawing.Point(167, 100);
            this.txtNomVue.Name = "txtNomVue";
            this.txtNomVue.Size = new System.Drawing.Size(121, 21);
            this.txtNomVue.TabIndex = 34;
            this.txtNomVue.TextChanged += new System.EventHandler(this.txtNomVue_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Nom de la nouvelle vue";
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(140, 165);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(175, 21);
            this.cmbTable.TabIndex = 32;
            // 
            // radUseExistingTable
            // 
            this.radUseExistingTable.AutoSize = true;
            this.radUseExistingTable.Location = new System.Drawing.Point(55, 142);
            this.radUseExistingTable.Name = "radUseExistingTable";
            this.radUseExistingTable.Size = new System.Drawing.Size(208, 17);
            this.radUseExistingTable.TabIndex = 31;
            this.radUseExistingTable.Text = "Ajouter une vue à une table existante";
            this.radUseExistingTable.UseVisualStyleBackColor = true;
            this.radUseExistingTable.CheckedChanged += new System.EventHandler(this.radUseExistingTable_CheckedChanged);
            // 
            // radAddTable
            // 
            this.radAddTable.AutoSize = true;
            this.radAddTable.Checked = true;
            this.radAddTable.Location = new System.Drawing.Point(55, 198);
            this.radAddTable.Name = "radAddTable";
            this.radAddTable.Size = new System.Drawing.Size(184, 17);
            this.radAddTable.TabIndex = 30;
            this.radAddTable.TabStop = true;
            this.radAddTable.Text = "Creer une nouvelle table en base";
            this.radAddTable.UseVisualStyleBackColor = true;
            this.radAddTable.CheckedChanged += new System.EventHandler(this.radUseExistingTable_CheckedChanged);
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(194, 226);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(121, 21);
            this.txtSchema.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Schéma";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(194, 263);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(121, 21);
            this.txtTable.TabIndex = 27;
            this.txtTable.TextChanged += new System.EventHandler(this.txtTable_TextChanged);
            // 
            // TxtRef
            // 
            this.TxtRef.Location = new System.Drawing.Point(194, 297);
            this.TxtRef.Name = "TxtRef";
            this.TxtRef.Size = new System.Drawing.Size(121, 21);
            this.TxtRef.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Clef de la nouvelle table :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Nom de la nouvelle table :";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Ajout de table/vue";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(335, 57);
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
            this.Fin.Size = new System.Drawing.Size(284, 294);
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
            this.header5.Size = new System.Drawing.Size(284, 57);
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
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.chkDefaultView);
            this.wizardPage1.Controls.Add(this.chkAjMenu);
            this.wizardPage1.Controls.Add(this.radMnParam);
            this.wizardPage1.Controls.Add(this.radMnMain);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.IsFinishPage = false;
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(335, 335);
            this.wizardPage1.TabIndex = 8;
            // 
            // chkDefaultView
            // 
            this.chkDefaultView.AutoSize = true;
            this.chkDefaultView.Location = new System.Drawing.Point(51, 222);
            this.chkDefaultView.Name = "chkDefaultView";
            this.chkDefaultView.Size = new System.Drawing.Size(168, 17);
            this.chkDefaultView.TabIndex = 38;
            this.chkDefaultView.Text = "Définir comme vue par défaut";
            this.chkDefaultView.UseVisualStyleBackColor = true;
            // 
            // chkAjMenu
            // 
            this.chkAjMenu.AutoSize = true;
            this.chkAjMenu.Checked = true;
            this.chkAjMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAjMenu.Location = new System.Drawing.Point(51, 97);
            this.chkAjMenu.Name = "chkAjMenu";
            this.chkAjMenu.Size = new System.Drawing.Size(147, 17);
            this.chkAjMenu.TabIndex = 37;
            this.chkAjMenu.Text = "Ajouter la vue à un menu";
            this.chkAjMenu.UseVisualStyleBackColor = true;
            this.chkAjMenu.CheckedChanged += new System.EventHandler(this.chkAjMenu_CheckedChanged);
            // 
            // radMnParam
            // 
            this.radMnParam.AutoSize = true;
            this.radMnParam.Checked = true;
            this.radMnParam.Location = new System.Drawing.Point(123, 162);
            this.radMnParam.Name = "radMnParam";
            this.radMnParam.Size = new System.Drawing.Size(157, 17);
            this.radMnParam.TabIndex = 1;
            this.radMnParam.TabStop = true;
            this.radMnParam.Text = "ajouter au menu paramètre";
            this.radMnParam.UseVisualStyleBackColor = true;
            // 
            // radMnMain
            // 
            this.radMnMain.AutoSize = true;
            this.radMnMain.Location = new System.Drawing.Point(123, 128);
            this.radMnMain.Name = "radMnMain";
            this.radMnMain.Size = new System.Drawing.Size(146, 17);
            this.radMnMain.TabIndex = 0;
            this.radMnMain.Text = "ajouter au menu principal";
            this.radMnMain.UseVisualStyleBackColor = true;
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
            this.Calendar.Size = new System.Drawing.Size(335, 383);
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
            // txtInititView
            // 
            this.txtInititView.Location = new System.Drawing.Point(167, 63);
            this.txtInititView.Name = "txtInititView";
            this.txtInititView.Size = new System.Drawing.Size(121, 21);
            this.txtInititView.TabIndex = 38;
            this.txtInititView.TextChanged += new System.EventHandler(this.txtInititView_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Titre de la nouvelle vue";
            // 
            // WizardTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 383);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardTable";
            this.Text = "Wizard";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.Calendar.ResumeLayout(false);
            this.Calendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Info;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.Label label7;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtRef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.RadioButton radUseExistingTable;
        private System.Windows.Forms.RadioButton radAddTable;
        private System.Windows.Forms.Label label6;
        private Gui.Wizard.WizardPage Calendar;
        private System.Windows.Forms.CheckBox chkDetail;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Label label2;
        private Gui.Wizard.WizardPage wizardPage1;
        private System.Windows.Forms.CheckBox chkAjMenu;
        private System.Windows.Forms.RadioButton radMnParam;
        private System.Windows.Forms.RadioButton radMnMain;
        private System.Windows.Forms.CheckBox chkDefaultView;
        private System.Windows.Forms.TextBox txtNomVue;
        private System.Windows.Forms.TextBox txtInititView;
        private System.Windows.Forms.Label label3;
    }
}