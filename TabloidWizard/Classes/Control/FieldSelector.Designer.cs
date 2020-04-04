namespace TabloidWizard.Classes.Control
{
    partial class FieldSelector
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lstChamp = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSchema = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(109, 30);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(121, 21);
            this.cmbTable.TabIndex = 40;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "de la table :";
            // 
            // lstChamp
            // 
            this.lstChamp.FormattingEnabled = true;
            this.lstChamp.Location = new System.Drawing.Point(109, 57);
            this.lstChamp.Name = "lstChamp";
            this.lstChamp.Size = new System.Drawing.Size(121, 21);
            this.lstChamp.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Champ à afficher :";
            // 
            // cmdSchema
            // 
            this.cmdSchema.FormattingEnabled = true;
            this.cmdSchema.Location = new System.Drawing.Point(109, 3);
            this.cmdSchema.Name = "cmdSchema";
            this.cmdSchema.Size = new System.Drawing.Size(121, 21);
            this.cmdSchema.TabIndex = 42;
            this.cmdSchema.SelectedIndexChanged += new System.EventHandler(this.cmdSchema_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Utiliser le schéma :";
            // 
            // FieldSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSchema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstChamp);
            this.Controls.Add(this.label7);
            this.Name = "FieldSelector";
            this.Size = new System.Drawing.Size(240, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox lstChamp;
        public System.Windows.Forms.ComboBox cmbTable;
        public System.Windows.Forms.ComboBox cmdSchema;
    }
}
