namespace TabloidWizard
{
    partial class WizardList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardList));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtRef = new System.Windows.Forms.TextBox();
            this.cmbExistingField = new System.Windows.Forms.ComboBox();
            this.radNewField = new System.Windows.Forms.RadioButton();
            this.radExistingField = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radUseTable = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.radNewTable = new System.Windows.Forms.RadioButton();
            this.chkAddToparamMenu = new System.Windows.Forms.CheckBox();
            this.cmbView = new System.Windows.Forms.ComboBox();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.Fin = new Gui.Wizard.WizardPage();
            this.header5 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.Alias = new Gui.Wizard.WizardPage();
            this.radUseExistingJoin = new System.Windows.Forms.RadioButton();
            this.radUseAlias = new System.Windows.Forms.RadioButton();
            this.txtalias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Fin.SuspendLayout();
            this.Alias.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Controls.Add(this.Alias);
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info,
            this.Alias,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(352, 513);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.groupBox2);
            this.Info.Controls.Add(this.groupBox1);
            this.Info.Controls.Add(this.txtViewName);
            this.Info.Controls.Add(this.label2);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = false;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(352, 465);
            this.Info.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtRef);
            this.groupBox2.Controls.Add(this.cmbExistingField);
            this.groupBox2.Controls.Add(this.radNewField);
            this.groupBox2.Controls.Add(this.radExistingField);
            this.groupBox2.Location = new System.Drawing.Point(3, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 134);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Référence dans la table actuelle";
            // 
            // TxtRef
            // 
            this.TxtRef.Location = new System.Drawing.Point(171, 32);
            this.TxtRef.Name = "TxtRef";
            this.TxtRef.Size = new System.Drawing.Size(121, 21);
            this.TxtRef.TabIndex = 24;
            // 
            // cmbExistingField
            // 
            this.cmbExistingField.Enabled = false;
            this.cmbExistingField.FormattingEnabled = true;
            this.cmbExistingField.Location = new System.Drawing.Point(143, 74);
            this.cmbExistingField.Name = "cmbExistingField";
            this.cmbExistingField.Size = new System.Drawing.Size(151, 21);
            this.cmbExistingField.TabIndex = 36;
            // 
            // radNewField
            // 
            this.radNewField.AutoSize = true;
            this.radNewField.Checked = true;
            this.radNewField.Location = new System.Drawing.Point(12, 32);
            this.radNewField.Name = "radNewField";
            this.radNewField.Size = new System.Drawing.Size(153, 17);
            this.radNewField.TabIndex = 34;
            this.radNewField.TabStop = true;
            this.radNewField.Text = "Créer un nouveau champ :";
            this.radNewField.UseVisualStyleBackColor = true;
            // 
            // radExistingField
            // 
            this.radExistingField.AutoSize = true;
            this.radExistingField.Location = new System.Drawing.Point(14, 74);
            this.radExistingField.Name = "radExistingField";
            this.radExistingField.Size = new System.Drawing.Size(109, 17);
            this.radExistingField.TabIndex = 35;
            this.radExistingField.Text = "Utiliser le champ :";
            this.radExistingField.UseVisualStyleBackColor = true;
            this.radExistingField.CheckedChanged += new System.EventHandler(this.radExistingField_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.radUseTable);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTable);
            this.groupBox1.Controls.Add(this.radNewTable);
            this.groupBox1.Controls.Add(this.chkAddToparamMenu);
            this.groupBox1.Controls.Add(this.cmbView);
            this.groupBox1.Location = new System.Drawing.Point(3, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 197);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puiser dans la table";
            // 
            // radUseTable
            // 
            this.radUseTable.AutoSize = true;
            this.radUseTable.Location = new System.Drawing.Point(9, 136);
            this.radUseTable.Name = "radUseTable";
            this.radUseTable.Size = new System.Drawing.Size(153, 17);
            this.radUseTable.TabIndex = 29;
            this.radUseTable.Text = "Utiliser une table existante";
            this.radUseTable.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Nom de la nouvelle table :";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(143, 75);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(151, 21);
            this.txtTable.TabIndex = 27;
            this.txtTable.TextChanged += new System.EventHandler(this.txtTable_TextChanged);
            // 
            // radNewTable
            // 
            this.radNewTable.AutoSize = true;
            this.radNewTable.Checked = true;
            this.radNewTable.Location = new System.Drawing.Point(9, 29);
            this.radNewTable.Name = "radNewTable";
            this.radNewTable.Size = new System.Drawing.Size(143, 17);
            this.radNewTable.TabIndex = 28;
            this.radNewTable.TabStop = true;
            this.radNewTable.Text = "Créer une nouvelle table";
            this.radNewTable.UseVisualStyleBackColor = true;
            this.radNewTable.CheckedChanged += new System.EventHandler(this.radNewTable_CheckedChanged);
            // 
            // chkAddToparamMenu
            // 
            this.chkAddToparamMenu.AutoSize = true;
            this.chkAddToparamMenu.Checked = true;
            this.chkAddToparamMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddToparamMenu.Location = new System.Drawing.Point(39, 102);
            this.chkAddToparamMenu.Name = "chkAddToparamMenu";
            this.chkAddToparamMenu.Size = new System.Drawing.Size(164, 17);
            this.chkAddToparamMenu.TabIndex = 33;
            this.chkAddToparamMenu.Text = "Ajouter au menu paramètres";
            this.chkAddToparamMenu.UseVisualStyleBackColor = true;
            // 
            // cmbView
            // 
            this.cmbView.Enabled = false;
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(143, 159);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(151, 21);
            this.cmbView.TabIndex = 30;
            this.cmbView.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // txtViewName
            // 
            this.txtViewName.Location = new System.Drawing.Point(146, 82);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(151, 21);
            this.txtViewName.TabIndex = 32;
            this.txtViewName.TextChanged += new System.EventHandler(this.txtViewName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Titre de l\'éditeur :";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Ajout de liste simple";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(352, 57);
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
            this.Fin.Size = new System.Drawing.Size(352, 465);
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
            this.header5.Size = new System.Drawing.Size(352, 57);
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
            // Alias
            // 
            this.Alias.Controls.Add(this.radUseExistingJoin);
            this.Alias.Controls.Add(this.radUseAlias);
            this.Alias.Controls.Add(this.txtalias);
            this.Alias.Controls.Add(this.label1);
            this.Alias.Controls.Add(this.textBox1);
            this.Alias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alias.IsFinishPage = false;
            this.Alias.Location = new System.Drawing.Point(0, 0);
            this.Alias.Name = "Alias";
            this.Alias.Size = new System.Drawing.Size(352, 465);
            this.Alias.TabIndex = 6;
            // 
            // radUseExistingJoin
            // 
            this.radUseExistingJoin.AutoSize = true;
            this.radUseExistingJoin.Location = new System.Drawing.Point(12, 148);
            this.radUseExistingJoin.Name = "radUseExistingJoin";
            this.radUseExistingJoin.Size = new System.Drawing.Size(156, 17);
            this.radUseExistingJoin.TabIndex = 31;
            this.radUseExistingJoin.Text = "Utiliser la jointure existante";
            this.radUseExistingJoin.UseVisualStyleBackColor = true;
            // 
            // radUseAlias
            // 
            this.radUseAlias.AutoSize = true;
            this.radUseAlias.Checked = true;
            this.radUseAlias.Location = new System.Drawing.Point(12, 78);
            this.radUseAlias.Name = "radUseAlias";
            this.radUseAlias.Size = new System.Drawing.Size(91, 17);
            this.radUseAlias.TabIndex = 30;
            this.radUseAlias.TabStop = true;
            this.radUseAlias.Text = "Créer un alias";
            this.radUseAlias.UseVisualStyleBackColor = true;
            this.radUseAlias.CheckedChanged += new System.EventHandler(this.radUseAlias_CheckedChanged);
            // 
            // txtalias
            // 
            this.txtalias.Location = new System.Drawing.Point(119, 112);
            this.txtalias.Name = "txtalias";
            this.txtalias.Size = new System.Drawing.Size(100, 21);
            this.txtalias.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom de l\'alias :";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(3, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(318, 28);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Cette table est déja jointe. Souhaitez vous créer un alias ?";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WizardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 593);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardList";
            this.Text = "Liste de choix";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.Alias.ResumeLayout(false);
            this.Alias.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.ComboBox cmbView;
        private System.Windows.Forms.RadioButton radUseTable;
        private System.Windows.Forms.RadioButton radNewTable;
        private Gui.Wizard.WizardPage Alias;
        private System.Windows.Forms.TextBox txtalias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkAddToparamMenu;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExistingField;
        private System.Windows.Forms.RadioButton radExistingField;
        private System.Windows.Forms.RadioButton radNewField;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radUseExistingJoin;
        private System.Windows.Forms.RadioButton radUseAlias;
    }
}