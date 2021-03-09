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
            resources.ApplyResources(this.lblState, "lblState");
            this.lblState.Name = "lblState";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // txtHote
            // 
            resources.ApplyResources(this.txtHote, "txtHote");
            this.txtHote.Name = "txtHote";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            resources.GetString("cmbType.Items"),
            resources.GetString("cmbType.Items1")});
            resources.ApplyResources(this.cmbType, "cmbType");
            this.cmbType.Name = "cmbType";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbTypeSelectedIndexChanged);
            // 
            // txtUtil
            // 
            resources.ApplyResources(this.txtUtil, "txtUtil");
            this.txtUtil.Name = "txtUtil";
            // 
            // txtMdp
            // 
            resources.ApplyResources(this.txtMdp, "txtMdp");
            this.txtMdp.Name = "txtMdp";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtSchema
            // 
            resources.ApplyResources(this.txtSchema, "txtSchema");
            this.txtSchema.Name = "txtSchema";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtBase
            // 
            resources.ApplyResources(this.txtBase, "txtBase");
            this.txtBase.Name = "txtBase";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn
            // 
            resources.ApplyResources(this.btn, "btn");
            this.btn.Name = "btn";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // chkCreaAuto
            // 
            resources.ApplyResources(this.chkCreaAuto, "chkCreaAuto");
            this.chkCreaAuto.Checked = true;
            this.chkCreaAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreaAuto.Name = "chkCreaAuto";
            this.chkCreaAuto.UseVisualStyleBackColor = true;
            // 
            // chkAutoTable
            // 
            resources.ApplyResources(this.chkAutoTable, "chkAutoTable");
            this.chkAutoTable.Checked = true;
            this.chkAutoTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTable.Name = "chkAutoTable";
            this.chkAutoTable.UseVisualStyleBackColor = true;
            // 
            // chkCasse
            // 
            resources.ApplyResources(this.chkCasse, "chkCasse");
            this.chkCasse.Checked = true;
            this.chkCasse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCasse.Name = "chkCasse";
            this.chkCasse.UseVisualStyleBackColor = true;
            // 
            // chkSuppNomTable
            // 
            resources.ApplyResources(this.chkSuppNomTable, "chkSuppNomTable");
            this.chkSuppNomTable.Checked = true;
            this.chkSuppNomTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuppNomTable.Name = "chkSuppNomTable";
            this.chkSuppNomTable.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLockInDB);
            this.groupBox2.Controls.Add(this.chkAutoTable);
            this.groupBox2.Controls.Add(this.chkCreaAuto);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // chkLockInDB
            // 
            resources.ApplyResources(this.chkLockInDB, "chkLockInDB");
            this.chkLockInDB.Name = "chkLockInDB";
            this.chkLockInDB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUnderscrore);
            this.groupBox3.Controls.Add(this.chkCasse);
            this.groupBox3.Controls.Add(this.chkSuppNomTable);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkUnderscrore
            // 
            resources.ApplyResources(this.chkUnderscrore, "chkUnderscrore");
            this.chkUnderscrore.Checked = true;
            this.chkUnderscrore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnderscrore.Name = "chkUnderscrore";
            this.chkUnderscrore.UseVisualStyleBackColor = true;
            // 
            // NewFromBaseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblState);
            this.MaximizeBox = false;
            this.Name = "NewFromBaseForm";
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