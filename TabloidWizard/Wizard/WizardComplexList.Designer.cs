namespace TabloidWizard
{
    partial class WizardComplexList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardComplexList));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.cmbJoin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbChamp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioCrea = new System.Windows.Forms.RadioButton();
            this.radioExist = new System.Windows.Forms.RadioButton();
            this.chkDistinct = new System.Windows.Forms.CheckBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.Fin = new Gui.Wizard.WizardPage();
            this.header5 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.Fin.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Controls.Add(this.Fin);
            resources.ApplyResources(this.wizard1, "wizard1");
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info,
            this.Fin});
            // 
            // Info
            // 
            this.Info.Controls.Add(this.cmbJoin);
            this.Info.Controls.Add(this.label3);
            this.Info.Controls.Add(this.cmbTable);
            this.Info.Controls.Add(this.label11);
            this.Info.Controls.Add(this.cmbChamp);
            this.Info.Controls.Add(this.label2);
            this.Info.Controls.Add(this.radioCrea);
            this.Info.Controls.Add(this.radioExist);
            this.Info.Controls.Add(this.chkDistinct);
            this.Info.Controls.Add(this.chkName);
            this.Info.Controls.Add(this.txtViewName);
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.txtTable);
            this.Info.Controls.Add(this.label7);
            this.Info.Controls.Add(this.header4);
            resources.ApplyResources(this.Info, "Info");
            this.Info.IsFinishPage = false;
            this.Info.Name = "Info";
            this.Info.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Info_CloseFromNext);
            // 
            // cmbJoin
            // 
            resources.ApplyResources(this.cmbJoin, "cmbJoin");
            this.cmbJoin.FormattingEnabled = true;
            this.cmbJoin.Name = "cmbJoin";
            this.cmbJoin.SelectedIndexChanged += new System.EventHandler(this.cmbJoin_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmbTable
            // 
            resources.ApplyResources(this.cmbTable, "cmbTable");
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // cmbChamp
            // 
            resources.ApplyResources(this.cmbChamp, "cmbChamp");
            this.cmbChamp.FormattingEnabled = true;
            this.cmbChamp.Name = "cmbChamp";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // radioCrea
            // 
            resources.ApplyResources(this.radioCrea, "radioCrea");
            this.radioCrea.Checked = true;
            this.radioCrea.Name = "radioCrea";
            this.radioCrea.TabStop = true;
            this.radioCrea.UseVisualStyleBackColor = true;
            this.radioCrea.CheckedChanged += new System.EventHandler(this.radioCrea_CheckedChanged);
            // 
            // radioExist
            // 
            resources.ApplyResources(this.radioExist, "radioExist");
            this.radioExist.Name = "radioExist";
            this.radioExist.UseVisualStyleBackColor = true;
            // 
            // chkDistinct
            // 
            resources.ApplyResources(this.chkDistinct, "chkDistinct");
            this.chkDistinct.Checked = true;
            this.chkDistinct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDistinct.Name = "chkDistinct";
            this.chkDistinct.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            resources.ApplyResources(this.chkName, "chkName");
            this.chkName.Checked = true;
            this.chkName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkName.Name = "chkName";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // txtViewName
            // 
            resources.ApplyResources(this.txtViewName, "txtViewName");
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.TextChanged += new System.EventHandler(this.txtViewName_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtTable
            // 
            resources.ApplyResources(this.txtTable, "txtTable");
            this.txtTable.Name = "txtTable";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Ajout d\'une liste sous-forme d\'un tableau";
            resources.ApplyResources(this.header4, "header4");
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Name = "header4";
            this.header4.Title = "Assistant d\'ajout";
            // 
            // Fin
            // 
            this.Fin.Controls.Add(this.header5);
            this.Fin.Controls.Add(this.label8);
            resources.ApplyResources(this.Fin, "Fin");
            this.Fin.IsFinishPage = true;
            this.Fin.Name = "Fin";
            this.Fin.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Button_end);
            // 
            // header5
            // 
            this.header5.BackColor = System.Drawing.SystemColors.Control;
            this.header5.CausesValidation = false;
            this.header5.Description = "";
            resources.ApplyResources(this.header5, "header5");
            this.header5.Image = ((System.Drawing.Image)(resources.GetObject("header5.Image")));
            this.header5.Name = "header5";
            this.header5.Title = "Assistant d\'ajout";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // WizardComplexList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wizard1);
            this.Name = "WizardComplexList";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.CheckBox chkDistinct;
        private System.Windows.Forms.RadioButton radioExist;
        private System.Windows.Forms.RadioButton radioCrea;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbChamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJoin;
        private System.Windows.Forms.Label label3;
    }
}