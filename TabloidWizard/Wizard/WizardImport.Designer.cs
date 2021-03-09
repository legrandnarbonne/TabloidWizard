namespace TabloidWizard
{
    partial class WizardImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardImport));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.txtTitreImport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnglet = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRef = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.header4 = new Gui.Wizard.Header();
            this.Calendar = new Gui.Wizard.WizardPage();
            this.chkDetail = new System.Windows.Forms.CheckBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAjoutExcelCol = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.wizard1.Size = new System.Drawing.Size(523, 546);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.button2);
            this.Info.Controls.Add(this.btnAjoutExcelCol);
            this.Info.Controls.Add(this.txtTitreImport);
            this.Info.Controls.Add(this.label3);
            this.Info.Controls.Add(this.lblOnglet);
            this.Info.Controls.Add(this.label4);
            this.Info.Controls.Add(this.textBox1);
            this.Info.Controls.Add(this.button1);
            this.Info.Controls.Add(this.txtRef);
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.dgv);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = false;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(523, 498);
            this.Info.TabIndex = 4;
            this.Info.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Info_CloseFromNext);
            // 
            // txtTitreImport
            // 
            this.txtTitreImport.Location = new System.Drawing.Point(158, 57);
            this.txtTitreImport.Name = "txtTitreImport";
            this.txtTitreImport.Size = new System.Drawing.Size(165, 21);
            this.txtTitreImport.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Nom du nouvel import :";
            // 
            // lblOnglet
            // 
            this.lblOnglet.AutoSize = true;
            this.lblOnglet.Location = new System.Drawing.Point(171, 187);
            this.lblOnglet.Name = "lblOnglet";
            this.lblOnglet.Size = new System.Drawing.Size(163, 13);
            this.lblOnglet.TabIndex = 59;
            this.lblOnglet.Text = ".......................................";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Onglet :";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(92, 96);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(348, 50);
            this.textBox1.TabIndex = 57;
            this.textBox1.Text = "Utilisez le bouton ci-dessous pour charger un fichier type permettant d\'analyser " +
    "la structure des fichiers que vous importerez.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 18);
            this.button1.TabIndex = 42;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRef
            // 
            this.txtRef.AutoSize = true;
            this.txtRef.Location = new System.Drawing.Point(171, 167);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(163, 13);
            this.txtRef.TabIndex = 41;
            this.txtRef.Text = ".......................................";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Fichier import type :";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 211);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(499, 218);
            this.dgv.TabIndex = 39;
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
            this.header4.Size = new System.Drawing.Size(523, 57);
            this.header4.TabIndex = 11;
            this.header4.Title = "Création d\'un import";
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
            this.Calendar.Size = new System.Drawing.Size(523, 546);
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
            // btnAjoutExcelCol
            // 
            this.btnAjoutExcelCol.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAjoutExcelCol.Location = new System.Drawing.Point(366, 435);
            this.btnAjoutExcelCol.Name = "btnAjoutExcelCol";
            this.btnAjoutExcelCol.Size = new System.Drawing.Size(145, 37);
            this.btnAjoutExcelCol.TabIndex = 62;
            this.btnAjoutExcelCol.Text = "Ajouter l\'ensemble des colonnes du fichier source";
            this.btnAjoutExcelCol.UseVisualStyleBackColor = false;
            this.btnAjoutExcelCol.Click += new System.EventHandler(this.btnAjoutExcelCol_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PowderBlue;
            this.button2.Location = new System.Drawing.Point(215, 435);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 37);
            this.button2.TabIndex = 63;
            this.button2.Text = "Ajouter l\'ensemble des champs de la vue";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WizardImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 626);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardImport";
            this.Text = "Ajout d\'import";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.Calendar.ResumeLayout(false);
            this.Calendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Info;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.ToolTip toolTip1;
        private Gui.Wizard.WizardPage Calendar;
        private System.Windows.Forms.CheckBox chkDetail;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtRef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOnglet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtTitreImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAjoutExcelCol;
    }
}