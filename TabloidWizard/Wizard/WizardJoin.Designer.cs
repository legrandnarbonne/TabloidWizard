namespace TabloidWizard
{
    partial class WizardJoin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardJoin));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Fin = new Gui.Wizard.WizardPage();
            this.header4 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.wjOrder = new Gui.Wizard.WizardPage();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.header2 = new Gui.Wizard.Header();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.wjVisibilite = new Gui.Wizard.WizardPage();
            this.header1 = new Gui.Wizard.Header();
            this.lstVisibilites = new System.Windows.Forms.CheckedListBox();
            this.wjStart = new Gui.Wizard.WizardPage();
            this.lstAutoJoin = new System.Windows.Forms.ListBox();
            this.radManu = new System.Windows.Forms.RadioButton();
            this.radAuto = new System.Windows.Forms.RadioButton();
            this.header6 = new Gui.Wizard.Header();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTypeJointure = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.wjRef = new Gui.Wizard.WizardPage();
            this.chkCmbChRefHT = new System.Windows.Forms.CheckBox();
            this.cmbChampRef = new System.Windows.Forms.ComboBox();
            this.lblChampRef = new System.Windows.Forms.Label();
            this.header7 = new Gui.Wizard.Header();
            this.wjRef2 = new Gui.Wizard.WizardPage();
            this.cmbChampRef2 = new System.Windows.Forms.ComboBox();
            this.lblChampRef2 = new System.Windows.Forms.Label();
            this.header3 = new Gui.Wizard.Header();
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Fin.SuspendLayout();
            this.wjOrder.SuspendLayout();
            this.wjVisibilite.SuspendLayout();
            this.wjStart.SuspendLayout();
            this.wjRef.SuspendLayout();
            this.wjRef2.SuspendLayout();
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
            this.Fin.Size = new System.Drawing.Size(324, 298);
            this.Fin.TabIndex = 5;
            this.Fin.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Button_end);
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
            this.header4.Size = new System.Drawing.Size(324, 57);
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
            // wjOrder
            // 
            this.wjOrder.Controls.Add(this.cmbOrderType);
            this.wjOrder.Controls.Add(this.label1);
            this.wjOrder.Controls.Add(this.header2);
            this.wjOrder.Controls.Add(this.cmbOrder);
            this.wjOrder.Controls.Add(this.label7);
            this.wjOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wjOrder.IsFinishPage = false;
            this.wjOrder.Location = new System.Drawing.Point(0, 0);
            this.wjOrder.Name = "wjOrder";
            this.wjOrder.Size = new System.Drawing.Size(324, 298);
            this.wjOrder.TabIndex = 4;
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Location = new System.Drawing.Point(127, 131);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(121, 21);
            this.cmbOrderType.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Par ordre :";
            // 
            // header2
            // 
            this.header2.BackColor = System.Drawing.SystemColors.Control;
            this.header2.CausesValidation = false;
            this.header2.Description = "";
            this.header2.Dock = System.Windows.Forms.DockStyle.Top;
            this.header2.Image = ((System.Drawing.Image)(resources.GetObject("header2.Image")));
            this.header2.Location = new System.Drawing.Point(0, 0);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(324, 57);
            this.header2.TabIndex = 29;
            this.header2.Title = "Assistant ajout de jointure";
            // 
            // cmbOrder
            // 
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Location = new System.Drawing.Point(127, 86);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(121, 21);
            this.cmbOrder.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ordonner par :";
            // 
            // wjVisibilite
            // 
            this.wjVisibilite.Controls.Add(this.header1);
            this.wjVisibilite.Controls.Add(this.lstVisibilites);
            this.wjVisibilite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wjVisibilite.IsFinishPage = false;
            this.wjVisibilite.Location = new System.Drawing.Point(0, 0);
            this.wjVisibilite.Name = "wjVisibilite";
            this.wjVisibilite.Size = new System.Drawing.Size(324, 298);
            this.wjVisibilite.TabIndex = 2;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Description = "Sélectionez la visibilité souhaitée";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(324, 57);
            this.header1.TabIndex = 29;
            this.header1.Tag = "";
            this.header1.Title = "Assistant ajout de jointure";
            // 
            // lstVisibilites
            // 
            this.lstVisibilites.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstVisibilites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstVisibilites.CheckOnClick = true;
            this.lstVisibilites.FormattingEnabled = true;
            this.lstVisibilites.Location = new System.Drawing.Point(67, 70);
            this.lstVisibilites.Name = "lstVisibilites";
            this.lstVisibilites.Size = new System.Drawing.Size(120, 144);
            this.lstVisibilites.TabIndex = 6;
            // 
            // wjStart
            // 
            this.wjStart.Controls.Add(this.lstAutoJoin);
            this.wjStart.Controls.Add(this.radManu);
            this.wjStart.Controls.Add(this.radAuto);
            this.wjStart.Controls.Add(this.header6);
            this.wjStart.Controls.Add(this.cmbTable);
            this.wjStart.Controls.Add(this.label10);
            this.wjStart.Controls.Add(this.cmbTypeJointure);
            this.wjStart.Controls.Add(this.label9);
            this.wjStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wjStart.IsFinishPage = false;
            this.wjStart.Location = new System.Drawing.Point(0, 0);
            this.wjStart.Name = "wjStart";
            this.wjStart.Size = new System.Drawing.Size(324, 298);
            this.wjStart.TabIndex = 6;
            // 
            // lstAutoJoin
            // 
            this.lstAutoJoin.FormattingEnabled = true;
            this.lstAutoJoin.Location = new System.Drawing.Point(77, 95);
            this.lstAutoJoin.MultiColumn = true;
            this.lstAutoJoin.Name = "lstAutoJoin";
            this.lstAutoJoin.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAutoJoin.Size = new System.Drawing.Size(190, 69);
            this.lstAutoJoin.TabIndex = 30;
            // 
            // radManu
            // 
            this.radManu.AutoSize = true;
            this.radManu.Location = new System.Drawing.Point(12, 192);
            this.radManu.Name = "radManu";
            this.radManu.Size = new System.Drawing.Size(119, 17);
            this.radManu.TabIndex = 29;
            this.radManu.TabStop = true;
            this.radManu.Text = "créer manuellement";
            this.radManu.UseVisualStyleBackColor = true;
            this.radManu.CheckedChanged += new System.EventHandler(this.radManu_CheckedChanged);
            // 
            // radAuto
            // 
            this.radAuto.AutoSize = true;
            this.radAuto.Checked = true;
            this.radAuto.Location = new System.Drawing.Point(12, 72);
            this.radAuto.Name = "radAuto";
            this.radAuto.Size = new System.Drawing.Size(151, 17);
            this.radAuto.TabIndex = 28;
            this.radAuto.TabStop = true;
            this.radAuto.Text = "Générer automatiquement";
            this.radAuto.UseVisualStyleBackColor = true;
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
            this.header6.Size = new System.Drawing.Size(324, 57);
            this.header6.TabIndex = 27;
            this.header6.Title = "Assistant ajout de jointure";
            // 
            // cmbTable
            // 
            this.cmbTable.Enabled = false;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(146, 218);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(121, 21);
            this.cmbTable.TabIndex = 26;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Table à joindre :";
            // 
            // cmbTypeJointure
            // 
            this.cmbTypeJointure.Enabled = false;
            this.cmbTypeJointure.FormattingEnabled = true;
            this.cmbTypeJointure.Items.AddRange(new object[] {
            "N:1",
            "1:N",
            "1:1"});
            this.cmbTypeJointure.Location = new System.Drawing.Point(146, 256);
            this.cmbTypeJointure.Name = "cmbTypeJointure";
            this.cmbTypeJointure.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeJointure.TabIndex = 24;
            this.cmbTypeJointure.SelectedIndexChanged += new System.EventHandler(this.cmbTypeJointure_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Type de jointure :";
            // 
            // wjRef
            // 
            this.wjRef.Controls.Add(this.chkCmbChRefHT);
            this.wjRef.Controls.Add(this.cmbChampRef);
            this.wjRef.Controls.Add(this.lblChampRef);
            this.wjRef.Controls.Add(this.header7);
            this.wjRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wjRef.IsFinishPage = false;
            this.wjRef.Location = new System.Drawing.Point(0, 0);
            this.wjRef.Name = "wjRef";
            this.wjRef.Size = new System.Drawing.Size(324, 298);
            this.wjRef.TabIndex = 1;
            // 
            // chkCmbChRefHT
            // 
            this.chkCmbChRefHT.AutoSize = true;
            this.chkCmbChRefHT.Checked = true;
            this.chkCmbChRefHT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCmbChRefHT.Location = new System.Drawing.Point(131, 161);
            this.chkCmbChRefHT.Name = "chkCmbChRefHT";
            this.chkCmbChRefHT.Size = new System.Drawing.Size(143, 17);
            this.chkCmbChRefHT.TabIndex = 31;
            this.chkCmbChRefHT.Text = "Afficher la liste simplifiée";
            this.chkCmbChRefHT.UseVisualStyleBackColor = true;
            this.chkCmbChRefHT.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmbChampRef
            // 
            this.cmbChampRef.FormattingEnabled = true;
            this.cmbChampRef.Items.AddRange(new object[] {
            "N:1",
            "1:N",
            "1:1"});
            this.cmbChampRef.Location = new System.Drawing.Point(82, 125);
            this.cmbChampRef.Name = "cmbChampRef";
            this.cmbChampRef.Size = new System.Drawing.Size(170, 21);
            this.cmbChampRef.TabIndex = 30;
            // 
            // lblChampRef
            // 
            this.lblChampRef.AutoSize = true;
            this.lblChampRef.Location = new System.Drawing.Point(12, 98);
            this.lblChampRef.Name = "lblChampRef";
            this.lblChampRef.Size = new System.Drawing.Size(184, 13);
            this.lblChampRef.TabIndex = 29;
            this.lblChampRef.Text = "Champ de référence de la table {0} :";
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
            this.header7.Size = new System.Drawing.Size(324, 57);
            this.header7.TabIndex = 28;
            this.header7.Title = "Assistant ajout de jointure";
            // 
            // wjRef2
            // 
            this.wjRef2.Controls.Add(this.cmbChampRef2);
            this.wjRef2.Controls.Add(this.lblChampRef2);
            this.wjRef2.Controls.Add(this.header3);
            this.wjRef2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wjRef2.IsFinishPage = false;
            this.wjRef2.Location = new System.Drawing.Point(0, 0);
            this.wjRef2.Name = "wjRef2";
            this.wjRef2.Size = new System.Drawing.Size(324, 298);
            this.wjRef2.TabIndex = 3;
            // 
            // cmbChampRef2
            // 
            this.cmbChampRef2.FormattingEnabled = true;
            this.cmbChampRef2.Items.AddRange(new object[] {
            "N:1",
            "1:N",
            "1:1"});
            this.cmbChampRef2.Location = new System.Drawing.Point(138, 123);
            this.cmbChampRef2.Name = "cmbChampRef2";
            this.cmbChampRef2.Size = new System.Drawing.Size(121, 21);
            this.cmbChampRef2.TabIndex = 34;
            // 
            // lblChampRef2
            // 
            this.lblChampRef2.AutoSize = true;
            this.lblChampRef2.Location = new System.Drawing.Point(19, 96);
            this.lblChampRef2.Name = "lblChampRef2";
            this.lblChampRef2.Size = new System.Drawing.Size(184, 13);
            this.lblChampRef2.TabIndex = 33;
            this.lblChampRef2.Text = "Champ de référence de la table {0} :";
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
            this.header3.Size = new System.Drawing.Size(324, 57);
            this.header3.TabIndex = 29;
            this.header3.Title = "Assistant ajout de jointure";
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Controls.Add(this.wjOrder);
            this.wizard1.Controls.Add(this.wjVisibilite);
            this.wizard1.Controls.Add(this.wjRef2);
            this.wizard1.Controls.Add(this.wjRef);
            this.wizard1.Controls.Add(this.wjStart);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wjStart,
            this.wjRef,
            this.wjRef2,
            this.wjVisibilite,
            this.wjOrder,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(324, 346);
            this.wizard1.TabIndex = 0;
            // 
            // WizardJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 426);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardJoin";
            this.Text = "Jointure";
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.wjOrder.ResumeLayout(false);
            this.wjOrder.PerformLayout();
            this.wjVisibilite.ResumeLayout(false);
            this.wjStart.ResumeLayout(false);
            this.wjStart.PerformLayout();
            this.wjRef.ResumeLayout(false);
            this.wjRef.PerformLayout();
            this.wjRef2.ResumeLayout(false);
            this.wjRef2.PerformLayout();
            this.wizard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.Label label8;
        private Gui.Wizard.WizardPage wjOrder;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Label label1;
        private Gui.Wizard.Header header2;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.Label label7;
        private Gui.Wizard.WizardPage wjVisibilite;
        private Gui.Wizard.Header header1;
        private System.Windows.Forms.CheckedListBox lstVisibilites;
        private Gui.Wizard.WizardPage wjStart;
        private Gui.Wizard.Header header6;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTypeJointure;
        private System.Windows.Forms.Label label9;
        private Gui.Wizard.WizardPage wjRef;
        private System.Windows.Forms.ComboBox cmbChampRef;
        private System.Windows.Forms.Label lblChampRef;
        private Gui.Wizard.Header header7;
        private Gui.Wizard.WizardPage wjRef2;
        private System.Windows.Forms.ComboBox cmbChampRef2;
        private System.Windows.Forms.Label lblChampRef2;
        private Gui.Wizard.Header header3;
        private Gui.Wizard.Wizard wizard1;
        private System.Windows.Forms.RadioButton radManu;
        private System.Windows.Forms.RadioButton radAuto;
        private System.Windows.Forms.ListBox lstAutoJoin;
        private System.Windows.Forms.CheckBox chkCmbChRefHT;
    }
}