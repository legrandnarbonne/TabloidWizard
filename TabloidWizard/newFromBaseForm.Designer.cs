namespace TabloidWizard
{
    partial class NewFromBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFromBaseForm));
            this.lblState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtHote = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtUtil = new System.Windows.Forms.TextBox();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.chkCreaAuto = new System.Windows.Forms.CheckBox();
            this.chkAutoTable = new System.Windows.Forms.CheckBox();
            this.chkCasse = new System.Windows.Forms.CheckBox();
            this.chkSuppNomTable = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLockInDB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUnderscrore = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(12, 414);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(260, 20);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "-";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 441);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 10);
            this.progressBar1.TabIndex = 1;
            // 
            // txtHote
            // 
            this.txtHote.Location = new System.Drawing.Point(128, 46);
            this.txtHote.Name = "txtHote";
            this.txtHote.Size = new System.Drawing.Size(100, 22);
            this.txtHote.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "My SQL",
            "Postgres"});
            this.cmbType.Location = new System.Drawing.Point(128, 19);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbTypeSelectedIndexChanged);
            // 
            // txtUtil
            // 
            this.txtUtil.Location = new System.Drawing.Point(128, 152);
            this.txtUtil.Name = "txtUtil";
            this.txtUtil.Size = new System.Drawing.Size(100, 22);
            this.txtUtil.TabIndex = 4;
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(128, 178);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.Size = new System.Drawing.Size(100, 22);
            this.txtMdp.TabIndex = 5;
            this.txtMdp.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSchema);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.txtMdp);
            this.groupBox1.Controls.Add(this.txtHote);
            this.groupBox1.Controls.Add(this.txtUtil);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 213);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres de connection";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Schéma  :";
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(129, 101);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(100, 22);
            this.txtSchema.TabIndex = 12;
            this.txtSchema.Text = "public";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Base :";
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(128, 74);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(100, 22);
            this.txtBase.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mot de passe :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Utilisateur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hôte :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type de base :";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(197, 457);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 7;
            this.btn.Text = "Connection";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // chkCreaAuto
            // 
            this.chkCreaAuto.AutoSize = true;
            this.chkCreaAuto.Checked = true;
            this.chkCreaAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreaAuto.Location = new System.Drawing.Point(16, 42);
            this.chkCreaAuto.Name = "chkCreaAuto";
            this.chkCreaAuto.Size = new System.Drawing.Size(189, 17);
            this.chkCreaAuto.TabIndex = 8;
            this.chkCreaAuto.Text = "Création auto des champs Tabloïd";
            this.chkCreaAuto.UseVisualStyleBackColor = true;
            // 
            // chkAutoTable
            // 
            this.chkAutoTable.AutoSize = true;
            this.chkAutoTable.Checked = true;
            this.chkAutoTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTable.Location = new System.Drawing.Point(16, 19);
            this.chkAutoTable.Name = "chkAutoTable";
            this.chkAutoTable.Size = new System.Drawing.Size(180, 17);
            this.chkAutoTable.TabIndex = 9;
            this.chkAutoTable.Text = "Création auto des tables Tabloïd";
            this.chkAutoTable.UseVisualStyleBackColor = true;
            // 
            // chkCasse
            // 
            this.chkCasse.AutoSize = true;
            this.chkCasse.Checked = true;
            this.chkCasse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCasse.Location = new System.Drawing.Point(16, 19);
            this.chkCasse.Name = "chkCasse";
            this.chkCasse.Size = new System.Drawing.Size(200, 17);
            this.chkCasse.TabIndex = 10;
            this.chkCasse.Text = "Modifier la casse de la première lettre";
            this.chkCasse.UseVisualStyleBackColor = true;
            // 
            // chkSuppNomTable
            // 
            this.chkSuppNomTable.AutoSize = true;
            this.chkSuppNomTable.Checked = true;
            this.chkSuppNomTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuppNomTable.Location = new System.Drawing.Point(16, 40);
            this.chkSuppNomTable.Name = "chkSuppNomTable";
            this.chkSuppNomTable.Size = new System.Drawing.Size(158, 17);
            this.chkSuppNomTable.TabIndex = 11;
            this.chkSuppNomTable.Text = "Supprimer le nom des tables";
            this.chkSuppNomTable.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLockInDB);
            this.groupBox2.Controls.Add(this.chkAutoTable);
            this.groupBox2.Controls.Add(this.chkCreaAuto);
            this.groupBox2.Location = new System.Drawing.Point(12, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 97);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modification de la base";
            // 
            // chkLockInDB
            // 
            this.chkLockInDB.AutoSize = true;
            this.chkLockInDB.Location = new System.Drawing.Point(16, 65);
            this.chkLockInDB.Name = "chkLockInDB";
            this.chkLockInDB.Size = new System.Drawing.Size(209, 17);
            this.chkLockInDB.TabIndex = 10;
            this.chkLockInDB.Text = "Utiliser la base pour verrouiller les enrg.";
            this.chkLockInDB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUnderscrore);
            this.groupBox3.Controls.Add(this.chkCasse);
            this.groupBox3.Controls.Add(this.chkSuppNomTable);
            this.groupBox3.Location = new System.Drawing.Point(12, 334);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 77);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Génération des titres";
            // 
            // chkUnderscrore
            // 
            this.chkUnderscrore.AutoSize = true;
            this.chkUnderscrore.Checked = true;
            this.chkUnderscrore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnderscrore.Location = new System.Drawing.Point(16, 61);
            this.chkUnderscrore.Name = "chkUnderscrore";
            this.chkUnderscrore.Size = new System.Drawing.Size(183, 17);
            this.chkUnderscrore.TabIndex = 12;
            this.chkUnderscrore.Text = "Remplacer les _ par des espaces";
            this.chkUnderscrore.UseVisualStyleBackColor = true;
            // 
            // NewFromBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 492);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblState);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 530);
            this.MinimumSize = new System.Drawing.Size(300, 530);
            this.Name = "NewFromBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Récupération de structure";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.CheckBox chkUnderscrore;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSuppNomTable;
        private System.Windows.Forms.CheckBox chkCasse;

        #endregion

        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtHote;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtUtil;
        private System.Windows.Forms.TextBox txtMdp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.CheckBox chkCreaAuto;
        private System.Windows.Forms.CheckBox chkAutoTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.CheckBox chkLockInDB;
    }
}