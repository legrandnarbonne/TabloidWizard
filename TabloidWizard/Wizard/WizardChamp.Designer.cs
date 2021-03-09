namespace TabloidWizard
{
    partial class WizardField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardField));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.Graphique = new Gui.Wizard.WizardPage();
            this.cmbGraph = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.visibilite = new Gui.Wizard.WizardPage();
            this.lstVisibilites = new System.Windows.Forms.CheckedListBox();
            this.header1 = new Gui.Wizard.Header();
            this.header2 = new Gui.Wizard.Header();
            this.Button = new Gui.Wizard.WizardPage();
            this.txtToolTipBtn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIcoBtn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrlBtn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.header3 = new Gui.Wizard.Header();
            this.Fin = new Gui.Wizard.WizardPage();
            this.header5 = new Gui.Wizard.Header();
            this.label8 = new System.Windows.Forms.Label();
            this.Champ = new Gui.Wizard.WizardPage();
            this.fs = new TabloidWizard.Classes.Control.FieldSelector();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lstTypeCrea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomCrea = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.radioCrea = new System.Windows.Forms.RadioButton();
            this.radioExist = new System.Windows.Forms.RadioButton();
            this.header6 = new Gui.Wizard.Header();
            this.Editeur = new Gui.Wizard.WizardPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.wzCmbEditeur = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.WzTxtTitre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.header4 = new Gui.Wizard.Header();
            this.type = new Gui.Wizard.WizardPage();
            this.hdrChooseRoute = new Gui.Wizard.Header();
            this.radField = new System.Windows.Forms.RadioButton();
            this.radbutton = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wizard1.SuspendLayout();
            this.Graphique.SuspendLayout();
            this.visibilite.SuspendLayout();
            this.header1.SuspendLayout();
            this.Button.SuspendLayout();
            this.Fin.SuspendLayout();
            this.Champ.SuspendLayout();
            this.Editeur.SuspendLayout();
            this.type.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.Button);
            this.wizard1.Controls.Add(this.visibilite);
            this.wizard1.Controls.Add(this.Graphique);
            this.wizard1.Controls.Add(this.Champ);
            this.wizard1.Controls.Add(this.Editeur);
            this.wizard1.Controls.Add(this.type);
            this.wizard1.Controls.Add(this.Fin);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(20, 60);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.type,
            this.Editeur,
            this.Champ,
            this.Graphique,
            this.visibilite,
            this.Button,
            this.Fin});
            this.wizard1.Size = new System.Drawing.Size(343, 395);
            this.wizard1.TabIndex = 0;
            // 
            // Graphique
            // 
            this.Graphique.Controls.Add(this.cmbGraph);
            this.Graphique.Controls.Add(this.label7);
            this.Graphique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graphique.IsFinishPage = false;
            this.Graphique.Location = new System.Drawing.Point(0, 0);
            this.Graphique.Name = "Graphique";
            this.Graphique.Size = new System.Drawing.Size(343, 347);
            this.Graphique.TabIndex = 7;
            // 
            // cmbGraph
            // 
            this.cmbGraph.FormattingEnabled = true;
            this.cmbGraph.Location = new System.Drawing.Point(68, 126);
            this.cmbGraph.Name = "cmbGraph";
            this.cmbGraph.Size = new System.Drawing.Size(241, 21);
            this.cmbGraph.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Nom du graphique :";
            // 
            // visibilite
            // 
            this.visibilite.Controls.Add(this.lstVisibilites);
            this.visibilite.Controls.Add(this.header1);
            this.visibilite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visibilite.IsFinishPage = false;
            this.visibilite.Location = new System.Drawing.Point(0, 0);
            this.visibilite.Name = "visibilite";
            this.visibilite.Size = new System.Drawing.Size(343, 347);
            this.visibilite.TabIndex = 2;
            // 
            // lstVisibilites
            // 
            this.lstVisibilites.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstVisibilites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstVisibilites.CheckOnClick = true;
            this.lstVisibilites.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVisibilites.FormattingEnabled = true;
            this.lstVisibilites.Items.AddRange(new object[] {
            "Liste",
            "Détail",
            "Export",
            "Publipostage",
            "Calendrier"});
            this.lstVisibilites.Location = new System.Drawing.Point(109, 126);
            this.lstVisibilites.Name = "lstVisibilites";
            this.lstVisibilites.Size = new System.Drawing.Size(124, 95);
            this.lstVisibilites.TabIndex = 7;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Controls.Add(this.header2);
            this.header1.Description = "Selectionnez la ou les vues dans lesquelles afficher cet objet";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(343, 57);
            this.header1.TabIndex = 5;
            this.header1.Title = "Assistant d\'ajout";
            // 
            // header2
            // 
            this.header2.BackColor = System.Drawing.SystemColors.Control;
            this.header2.CausesValidation = false;
            this.header2.Description = "Selectionnez la ou les vues dans lesquelles afficher cet objet";
            this.header2.Dock = System.Windows.Forms.DockStyle.Top;
            this.header2.Image = ((System.Drawing.Image)(resources.GetObject("header2.Image")));
            this.header2.Location = new System.Drawing.Point(0, 0);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(343, 57);
            this.header2.TabIndex = 9;
            this.header2.Title = "Assistant d\'ajout";
            // 
            // Button
            // 
            this.Button.Controls.Add(this.txtToolTipBtn);
            this.Button.Controls.Add(this.label4);
            this.Button.Controls.Add(this.txtIcoBtn);
            this.Button.Controls.Add(this.label3);
            this.Button.Controls.Add(this.txtUrlBtn);
            this.Button.Controls.Add(this.label2);
            this.Button.Controls.Add(this.header3);
            this.Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button.IsFinishPage = false;
            this.Button.Location = new System.Drawing.Point(0, 0);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(343, 347);
            this.Button.TabIndex = 3;
            // 
            // txtToolTipBtn
            // 
            this.txtToolTipBtn.Location = new System.Drawing.Point(37, 138);
            this.txtToolTipBtn.Name = "txtToolTipBtn";
            this.txtToolTipBtn.Size = new System.Drawing.Size(272, 21);
            this.txtToolTipBtn.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Info bulle :";
            // 
            // txtIcoBtn
            // 
            this.txtIcoBtn.Location = new System.Drawing.Point(155, 90);
            this.txtIcoBtn.Name = "txtIcoBtn";
            this.txtIcoBtn.Size = new System.Drawing.Size(121, 21);
            this.txtIcoBtn.TabIndex = 16;
            this.txtIcoBtn.Text = "/images/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "U.R.L. de l\'icone :";
            // 
            // txtUrlBtn
            // 
            this.txtUrlBtn.Location = new System.Drawing.Point(155, 63);
            this.txtUrlBtn.Name = "txtUrlBtn";
            this.txtUrlBtn.Size = new System.Drawing.Size(121, 21);
            this.txtUrlBtn.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtUrlBtn, "Url du type maPage.aspx?val={0}&retour={2}");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "U.R.L. à appeler :";
            // 
            // header3
            // 
            this.header3.BackColor = System.Drawing.SystemColors.Control;
            this.header3.CausesValidation = false;
            this.header3.Description = "Saisissez les propriétés du bouton";
            this.header3.Dock = System.Windows.Forms.DockStyle.Top;
            this.header3.Image = ((System.Drawing.Image)(resources.GetObject("header3.Image")));
            this.header3.Location = new System.Drawing.Point(0, 0);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(343, 57);
            this.header3.TabIndex = 10;
            this.header3.Title = "Assistant d\'ajout";
            // 
            // Fin
            // 
            this.Fin.Controls.Add(this.header5);
            this.Fin.Controls.Add(this.label8);
            this.Fin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fin.IsFinishPage = true;
            this.Fin.Location = new System.Drawing.Point(0, 0);
            this.Fin.Name = "Fin";
            this.Fin.Size = new System.Drawing.Size(343, 347);
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
            this.header5.Size = new System.Drawing.Size(343, 57);
            this.header5.TabIndex = 12;
            this.header5.Title = "Assistant d\'ajout";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(66, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Utilisez le boutton Finish pour créer l\'objet";
            // 
            // Champ
            // 
            this.Champ.Controls.Add(this.fs);
            this.Champ.Controls.Add(this.txtDec);
            this.Champ.Controls.Add(this.label10);
            this.Champ.Controls.Add(this.txtLong);
            this.Champ.Controls.Add(this.label9);
            this.Champ.Controls.Add(this.lstTypeCrea);
            this.Champ.Controls.Add(this.label1);
            this.Champ.Controls.Add(this.txtNomCrea);
            this.Champ.Controls.Add(this.lbl);
            this.Champ.Controls.Add(this.radioCrea);
            this.Champ.Controls.Add(this.radioExist);
            this.Champ.Controls.Add(this.header6);
            this.Champ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Champ.IsFinishPage = false;
            this.Champ.Location = new System.Drawing.Point(0, 0);
            this.Champ.Name = "Champ";
            this.Champ.Size = new System.Drawing.Size(343, 347);
            this.Champ.TabIndex = 6;
            // 
            // fs
            // 
            this.fs.ConnectionString = null;
            this.fs.Location = new System.Drawing.Point(49, 221);
            this.fs.Name = "fs";
            this.fs.Size = new System.Drawing.Size(240, 88);
            this.fs.TabIndex = 35;
            // 
            // txtDec
            // 
            this.txtDec.Location = new System.Drawing.Point(211, 148);
            this.txtDec.Name = "txtDec";
            this.txtDec.Size = new System.Drawing.Size(62, 21);
            this.txtDec.TabIndex = 34;
            this.toolTip1.SetToolTip(this.txtDec, "Url du type maPage.aspx?val={0}&retour={2}");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(150, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "décimale :";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(78, 148);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(62, 21);
            this.txtLong.TabIndex = 32;
            this.toolTip1.SetToolTip(this.txtLong, "Url du type maPage.aspx?val={0}&retour={2}");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Longueur  :";
            // 
            // lstTypeCrea
            // 
            this.lstTypeCrea.FormattingEnabled = true;
            this.lstTypeCrea.Location = new System.Drawing.Point(137, 111);
            this.lstTypeCrea.Name = "lstTypeCrea";
            this.lstTypeCrea.Size = new System.Drawing.Size(121, 21);
            this.lstTypeCrea.TabIndex = 30;
            this.lstTypeCrea.SelectedIndexChanged += new System.EventHandler(this.validateFieldCreation);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Type du champ :";
            // 
            // txtNomCrea
            // 
            this.txtNomCrea.Location = new System.Drawing.Point(137, 84);
            this.txtNomCrea.Name = "txtNomCrea";
            this.txtNomCrea.Size = new System.Drawing.Size(121, 21);
            this.txtNomCrea.TabIndex = 28;
            this.toolTip1.SetToolTip(this.txtNomCrea, "Url du type maPage.aspx?val={0}&retour={2}");
            this.txtNomCrea.TextChanged += new System.EventHandler(this.validateFieldCreation);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(46, 87);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(83, 13);
            this.lbl.TabIndex = 27;
            this.lbl.Text = "nom du champ :";
            // 
            // radioCrea
            // 
            this.radioCrea.AutoSize = true;
            this.radioCrea.Checked = true;
            this.radioCrea.Location = new System.Drawing.Point(13, 65);
            this.radioCrea.Name = "radioCrea";
            this.radioCrea.Size = new System.Drawing.Size(146, 17);
            this.radioCrea.TabIndex = 26;
            this.radioCrea.TabStop = true;
            this.radioCrea.Text = "Créer un nouveau champ";
            this.radioCrea.UseVisualStyleBackColor = true;
            this.radioCrea.CheckedChanged += new System.EventHandler(this.radioExist_CheckedChanged);
            // 
            // radioExist
            // 
            this.radioExist.AutoSize = true;
            this.radioExist.Location = new System.Drawing.Point(13, 198);
            this.radioExist.Name = "radioExist";
            this.radioExist.Size = new System.Drawing.Size(211, 17);
            this.radioExist.TabIndex = 25;
            this.radioExist.Text = "Utiliser un champ existant dans la base";
            this.radioExist.UseVisualStyleBackColor = true;
            this.radioExist.CheckedChanged += new System.EventHandler(this.radioExist_CheckedChanged);
            // 
            // header6
            // 
            this.header6.BackColor = System.Drawing.SystemColors.Control;
            this.header6.CausesValidation = false;
            this.header6.Description = "Selectionner le champ de la table à utiliser";
            this.header6.Dock = System.Windows.Forms.DockStyle.Top;
            this.header6.Image = ((System.Drawing.Image)(resources.GetObject("header6.Image")));
            this.header6.Location = new System.Drawing.Point(0, 0);
            this.header6.Name = "header6";
            this.header6.Size = new System.Drawing.Size(343, 50);
            this.header6.TabIndex = 5;
            this.header6.Title = "Assistant d\'ajout";
            // 
            // Editeur
            // 
            this.Editeur.Controls.Add(this.txtDescription);
            this.Editeur.Controls.Add(this.wzCmbEditeur);
            this.Editeur.Controls.Add(this.label6);
            this.Editeur.Controls.Add(this.WzTxtTitre);
            this.Editeur.Controls.Add(this.label5);
            this.Editeur.Controls.Add(this.header4);
            this.Editeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editeur.IsFinishPage = false;
            this.Editeur.Location = new System.Drawing.Point(0, 0);
            this.Editeur.Name = "Editeur";
            this.Editeur.Size = new System.Drawing.Size(343, 347);
            this.Editeur.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(12, 140);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(312, 190);
            this.txtDescription.TabIndex = 27;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wzCmbEditeur
            // 
            this.wzCmbEditeur.FormattingEnabled = true;
            this.wzCmbEditeur.Location = new System.Drawing.Point(100, 104);
            this.wzCmbEditeur.Name = "wzCmbEditeur";
            this.wzCmbEditeur.Size = new System.Drawing.Size(121, 21);
            this.wzCmbEditeur.TabIndex = 26;
            this.wzCmbEditeur.SelectedIndexChanged += new System.EventHandler(this.wzCmbEditeur_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Editeur :";
            // 
            // WzTxtTitre
            // 
            this.WzTxtTitre.Location = new System.Drawing.Point(100, 77);
            this.WzTxtTitre.Name = "WzTxtTitre";
            this.WzTxtTitre.Size = new System.Drawing.Size(121, 21);
            this.WzTxtTitre.TabIndex = 24;
            this.WzTxtTitre.TextChanged += new System.EventHandler(this.WzTxtTitre_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Titre :";
            // 
            // header4
            // 
            this.header4.BackColor = System.Drawing.SystemColors.Control;
            this.header4.CausesValidation = false;
            this.header4.Description = "Saisissez les propriétés du champ";
            this.header4.Dock = System.Windows.Forms.DockStyle.Top;
            this.header4.Image = ((System.Drawing.Image)(resources.GetObject("header4.Image")));
            this.header4.Location = new System.Drawing.Point(0, 0);
            this.header4.Name = "header4";
            this.header4.Size = new System.Drawing.Size(343, 57);
            this.header4.TabIndex = 11;
            this.header4.Title = "Assistant d\'ajout";
            // 
            // type
            // 
            this.type.Controls.Add(this.hdrChooseRoute);
            this.type.Controls.Add(this.radField);
            this.type.Controls.Add(this.radbutton);
            this.type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type.IsFinishPage = false;
            this.type.Location = new System.Drawing.Point(0, 0);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(343, 347);
            this.type.TabIndex = 1;
            // 
            // hdrChooseRoute
            // 
            this.hdrChooseRoute.BackColor = System.Drawing.SystemColors.Control;
            this.hdrChooseRoute.CausesValidation = false;
            this.hdrChooseRoute.Description = "Selectionner le type d\'élément à ajouter";
            this.hdrChooseRoute.Dock = System.Windows.Forms.DockStyle.Top;
            this.hdrChooseRoute.Image = ((System.Drawing.Image)(resources.GetObject("hdrChooseRoute.Image")));
            this.hdrChooseRoute.Location = new System.Drawing.Point(0, 0);
            this.hdrChooseRoute.Name = "hdrChooseRoute";
            this.hdrChooseRoute.Size = new System.Drawing.Size(343, 50);
            this.hdrChooseRoute.TabIndex = 4;
            this.hdrChooseRoute.Title = "Assistant d\'ajout";
            // 
            // radField
            // 
            this.radField.Checked = true;
            this.radField.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radField.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radField.Location = new System.Drawing.Point(66, 119);
            this.radField.Name = "radField";
            this.radField.Size = new System.Drawing.Size(131, 24);
            this.radField.TabIndex = 3;
            this.radField.TabStop = true;
            this.radField.Text = "Ajouter un champ";
            // 
            // radbutton
            // 
            this.radbutton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radbutton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbutton.Location = new System.Drawing.Point(66, 89);
            this.radbutton.Name = "radbutton";
            this.radbutton.Size = new System.Drawing.Size(131, 24);
            this.radbutton.TabIndex = 2;
            this.radbutton.Text = "Ajouter un bouton";
            // 
            // WizardField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 475);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WizardField";
            this.Text = "Ajout de champ";
            this.Load += new System.EventHandler(this.Wizard_Load);
            this.wizard1.ResumeLayout(false);
            this.Graphique.ResumeLayout(false);
            this.Graphique.PerformLayout();
            this.visibilite.ResumeLayout(false);
            this.header1.ResumeLayout(false);
            this.Button.ResumeLayout(false);
            this.Button.PerformLayout();
            this.Fin.ResumeLayout(false);
            this.Fin.PerformLayout();
            this.Champ.ResumeLayout(false);
            this.Champ.PerformLayout();
            this.Editeur.ResumeLayout(false);
            this.Editeur.PerformLayout();
            this.type.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage type;
        private System.Windows.Forms.RadioButton radField;
        private System.Windows.Forms.RadioButton radbutton;
        private Gui.Wizard.WizardPage visibilite;
        private Gui.Wizard.WizardPage Button;
        private Gui.Wizard.WizardPage Editeur;
        private Gui.Wizard.Header hdrChooseRoute;
        private Gui.Wizard.Header header1;
        private Gui.Wizard.Header header3;
        private Gui.Wizard.Header header2;
        private System.Windows.Forms.TextBox txtToolTipBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIcoBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrlBtn;
        private System.Windows.Forms.Label label2;
        private Gui.Wizard.Header header4;
        private Gui.Wizard.WizardPage Fin;
        private Gui.Wizard.Header header5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox wzCmbEditeur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WzTxtTitre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private Gui.Wizard.WizardPage Champ;
        private System.Windows.Forms.ComboBox lstTypeCrea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomCrea;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.RadioButton radioCrea;
        private System.Windows.Forms.RadioButton radioExist;
        private Gui.Wizard.Header header6;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescription;
        private Classes.Control.FieldSelector fs;
        private System.Windows.Forms.CheckedListBox lstVisibilites;
        private Gui.Wizard.WizardPage Graphique;
        private System.Windows.Forms.ComboBox cmbGraph;
        private System.Windows.Forms.Label label7;
    }
}