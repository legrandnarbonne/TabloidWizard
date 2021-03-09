namespace TabloidWizard.Classes.Editor
{
    partial class SqlEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlEditor));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            this.txtSql = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.fs = new TabloidWizard.Classes.Control.FieldSelector();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(528, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(622, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtSql
            // 
            // 
            // 
            // 
            this.txtSql.CustomButton.Image = null;
            this.txtSql.CustomButton.Location = new System.Drawing.Point(268, 2);
            this.txtSql.CustomButton.Name = "";
            this.txtSql.CustomButton.Size = new System.Drawing.Size(171, 171);
            this.txtSql.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSql.CustomButton.TabIndex = 1;
            this.txtSql.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSql.CustomButton.UseSelectable = true;
            this.txtSql.CustomButton.Visible = false;
            this.txtSql.Lines = new string[0];
            this.txtSql.Location = new System.Drawing.Point(23, 63);
            this.txtSql.MaxLength = 32767;
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.PasswordChar = '\0';
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSql.SelectedText = "";
            this.txtSql.SelectionLength = 0;
            this.txtSql.SelectionStart = 0;
            this.txtSql.ShortcutsEnabled = true;
            this.txtSql.Size = new System.Drawing.Size(442, 176);
            this.txtSql.TabIndex = 16;
            this.txtSql.UseSelectable = true;
            this.txtSql.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSql.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(622, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Inserer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // fs
            // 
            this.fs.ConnectionString = null;
            this.fs.Location = new System.Drawing.Point(471, 63);
            this.fs.Name = "fs";
            this.fs.Size = new System.Drawing.Size(240, 88);
            this.fs.TabIndex = 17;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(564, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Inserer le nom complet";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SqlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 280);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.fs);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(720, 280);
            this.MinimumSize = new System.Drawing.Size(720, 280);
            this.Name = "SqlEditor";
            this.Text = "Saisie SQL";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private Control.FieldSelector fs;
        private System.Windows.Forms.Button button3;
        public MetroFramework.Controls.MetroTextBox txtSql;
        private System.Windows.Forms.Button button4;
    }
}