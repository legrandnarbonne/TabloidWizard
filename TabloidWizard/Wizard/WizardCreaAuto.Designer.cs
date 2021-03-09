namespace TabloidWizard
{
    partial class WizardCreaAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardCreaAuto));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Info = new Gui.Wizard.WizardPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtIf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSrc = new System.Windows.Forms.ComboBox();
            this.lbSrc = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbListe = new System.Windows.Forms.ComboBox();
            this.lbListe = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Info);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.Info});
            this.wizard1.Size = new System.Drawing.Size(372, 465);
            this.wizard1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.textBox2);
            this.Info.Controls.Add(this.textBox1);
            this.Info.Controls.Add(this.txtIf);
            this.Info.Controls.Add(this.label2);
            this.Info.Controls.Add(this.cmbSrc);
            this.Info.Controls.Add(this.lbSrc);
            this.Info.Controls.Add(this.txtWhere);
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.cmbListe);
            this.Info.Controls.Add(this.lbListe);
            this.Info.Controls.Add(this.header4);
            this.Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Info.IsFinishPage = true;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(372, 417);
            this.Info.TabIndex = 4;
            this.Info.CloseFromNext += new Gui.Wizard.PageEventHandler(this.Info_CloseFromNext);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(12, 361);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(351, 49);
            this.textBox2.TabIndex = 41;
            this.textBox2.Text = "Dans le cas d\'un filtrage par une propriété du nouvel objet, il faut eviter les v" +
    "aleurs nulle. On précisera donc dans éxécuter si New.mapropriete is not null";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 250);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 52);
            this.textBox1.TabIndex = 40;
            this.textBox1.Text = "Le filtrage des éléments à ajouter peut contenir des valeurs de l\'objet en cours " +
    "de création grâce au mot New. On utilisera par exemple : concat(\'New.mapropriete" +
    ",\'=propdusousobjet\')";
            // 
            // txtIf
            // 
            this.txtIf.Location = new System.Drawing.Point(154, 334);
            this.txtIf.Name = "txtIf";
            this.txtIf.Size = new System.Drawing.Size(183, 21);
            this.txtIf.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Exécuter si :";
            // 
            // cmbSrc
            // 
            this.cmbSrc.FormattingEnabled = true;
            this.cmbSrc.Location = new System.Drawing.Point(154, 167);
            this.cmbSrc.Name = "cmbSrc";
            this.cmbSrc.Size = new System.Drawing.Size(157, 21);
            this.cmbSrc.TabIndex = 37;
            // 
            // lbSrc
            // 
            this.lbSrc.AutoSize = true;
            this.lbSrc.Location = new System.Drawing.Point(12, 140);
            this.lbSrc.Name = "lbSrc";
            this.lbSrc.Size = new System.Drawing.Size(246, 13);
            this.lbSrc.TabIndex = 36;
            this.lbSrc.Text = "créer dans la liste {0} les élément à partir de {1} :";
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(154, 223);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(183, 21);
            this.txtWhere.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Filtrer les éléments à ajouter :";
            // 
            // cmbListe
            // 
            this.cmbListe.FormattingEnabled = true;
            this.cmbListe.Location = new System.Drawing.Point(154, 108);
            this.cmbListe.Name = "cmbListe";
            this.cmbListe.Size = new System.Drawing.Size(157, 21);
            this.cmbListe.TabIndex = 33;
            this.cmbListe.SelectedIndexChanged += new System.EventHandler(this.cmbListe_SelectedIndexChanged);
            // 
            // lbListe
            // 
            this.lbListe.AutoSize = true;
            this.lbListe.Location = new System.Drawing.Point(12, 81);
            this.lbListe.Name = "lbListe";
            this.lbListe.Size = new System.Drawing.Size(308, 13);
            this.lbListe.TabIndex = 31;
            this.lbListe.Text = "à la création d\'un enregistrement de {0} compléter la liste {1} :";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Ajouter des sous éléments à la création d\'un enregistrement";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(372, 57);
            this.header4.TabIndex = 11;
            this.header4.Title = "Assistant création automatique d\'enregistrements";
            // 
            // WizardCreaAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 545);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardCreaAuto";
            this.Text = "Wizard";
            this.wizard1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage Info;
        private Gui.Wizard.Header header4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbListe;
        private System.Windows.Forms.ComboBox cmbListe;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSrc;
        private System.Windows.Forms.Label lbSrc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtIf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}