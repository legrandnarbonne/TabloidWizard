/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 23/02/2013
 * Time: 16:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using MetroFramework.Controls;

namespace TabloidWizard
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnStatusUpdateEngine = new System.Windows.Forms.ToolStripSplitButton();
            this.txtStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.MnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.MnPublier = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMaj = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.pageDeSynthèseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertisseur1x2xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genQlikViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.générateurDeQuestionnaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connecteurInstallésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleCartographieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyserLaStructureDeVotreProjetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activerPostgisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkSavAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.modulesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPhotoModule = new System.Windows.Forms.ToolStripMenuItem();
            this.codeXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDisplayLevel = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuView = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.ajouterTable = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerLaTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ajouterUnChampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnChampListeSimple = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnChampListeComplexe = new System.Windows.Forms.ToolStripMenuItem();
            this.attacherUneCarteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneTableCalendrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerUneNouvelleVuePourCetteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ajouterCommeMenuPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterAuMenuParamètreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.afficherLeContenuDuSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.générerLesJointuresAutomatiquementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.ajouterUnTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créezDesÉlémentsAutomatiquementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetAsStartViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.MnDisplayDefaultView = new System.Windows.Forms.ToolStripMenuItem();
            this.imgField = new System.Windows.Forms.ImageList(this.components);
            this.ajouterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnEnregistrer = new System.Windows.Forms.ToolStripButton();
            this.btnProprietes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFromSite = new System.Windows.Forms.ToolStripButton();
            this.btnFromDataBase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExecute = new System.Windows.Forms.ToolStripButton();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.ajouterUneColonneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneJointureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.imgView = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuFunction = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.ajouterUneFonctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerUneFonctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgFct = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabviewfct = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtStartMsg = new System.Windows.Forms.TextBox();
            this.lstViews = new TabloidWizard.Classes.Control.GListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstFct = new TabloidWizard.Classes.Control.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.propTable = new System.Windows.Forms.PropertyGrid();
            this.lblTable = new System.Windows.Forms.Label();
            this.tabFieldDetail = new MetroFramework.Controls.MetroTabControl();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuView.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.contextMenuFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabviewfct.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Silver;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStatusUpdateEngine,
            this.txtStatut});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(20, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1318, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnStatusUpdateEngine
            // 
            this.btnStatusUpdateEngine.BackColor = System.Drawing.Color.Silver;
            this.btnStatusUpdateEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStatusUpdateEngine.DropDownButtonWidth = 0;
            this.btnStatusUpdateEngine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusUpdateEngine.ForeColor = System.Drawing.Color.Brown;
            this.btnStatusUpdateEngine.Image = ((System.Drawing.Image)(resources.GetObject("btnStatusUpdateEngine.Image")));
            this.btnStatusUpdateEngine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStatusUpdateEngine.Name = "btnStatusUpdateEngine";
            this.btnStatusUpdateEngine.Size = new System.Drawing.Size(86, 20);
            this.btnStatusUpdateEngine.Text = "Mettre à jour";
            this.btnStatusUpdateEngine.Visible = false;
            this.btnStatusUpdateEngine.ButtonClick += new System.EventHandler(this.btnStatusUpdateEngine_Click);
            // 
            // txtStatut
            // 
            this.txtStatut.Name = "txtStatut";
            this.txtStatut.Size = new System.Drawing.Size(196, 17);
            this.txtStatut.Text = "Utilisez le menu projet pour débuter";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem14,
            this.pageDeSynthèseToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.modulesMenuItem,
            this.codeXMLToolStripMenuItem,
            this.teToolStripMenuItem,
            this.cmbDisplayLevel});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(20, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1318, 50);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator9,
            this.MnSave,
            this.MnSaveAs,
            this.toolStripSeparator10,
            this.toolStripMenuItem8,
            this.toolStripSeparator11,
            this.MnPublier,
            this.MnMaj,
            this.toolStripSeparator13,
            this.toolStripMenuItem11,
            this.toolStripSeparator14,
            this.toolStripMenuItem12});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(30, 10, 0, 0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 46);
            this.toolStripMenuItem1.Text = "Projet";
            this.toolStripMenuItem1.DropDownClosed += new System.EventHandler(this.toolStripMenuItem1_DropDownClosed);
            this.toolStripMenuItem1.DropDownOpening += new System.EventHandler(this.toolStripMenuItem1_DropDownOpening);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(537, 34);
            this.toolStripMenuItem3.Text = "Ouvrir un site existant";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.NewFromSite);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(537, 34);
            this.toolStripMenuItem4.Text = "Créer un nouveau projet";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(537, 34);
            this.toolStripMenuItem5.Text = "Nouveau projet à partir d\'une base";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.NewFromDatabase);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(534, 6);
            // 
            // MnSave
            // 
            this.MnSave.Name = "MnSave";
            this.MnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MnSave.Size = new System.Drawing.Size(537, 34);
            this.MnSave.Text = "Enregistrer les fichiers de configuration";
            this.MnSave.Click += new System.EventHandler(this.SaveMenu);
            // 
            // MnSaveAs
            // 
            this.MnSaveAs.Enabled = false;
            this.MnSaveAs.Name = "MnSaveAs";
            this.MnSaveAs.Size = new System.Drawing.Size(537, 34);
            this.MnSaveAs.Text = "Enregistrer les fichiers de configuration sous";
            this.MnSaveAs.Click += new System.EventHandler(this.SaveAsMenu);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(534, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Enabled = false;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.toolStripMenuItem8.Size = new System.Drawing.Size(537, 34);
            this.toolStripMenuItem8.Text = "Propriétés du projet";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.PropertiesMenu);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(534, 6);
            // 
            // MnPublier
            // 
            this.MnPublier.Name = "MnPublier";
            this.MnPublier.Size = new System.Drawing.Size(537, 34);
            this.MnPublier.Text = "Publier un site";
            this.MnPublier.Click += new System.EventHandler(this.publierUnSiteToolStripMenuItem_Click);
            // 
            // MnMaj
            // 
            this.MnMaj.Name = "MnMaj";
            this.MnMaj.Size = new System.Drawing.Size(537, 34);
            this.MnMaj.Text = "Mettre à jour le moteur";
            this.MnMaj.Click += new System.EventHandler(this.mettreÀJourLeMoteurToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(534, 6);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(537, 34);
            this.toolStripMenuItem11.Text = "Définir les propriètés par défauts";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.définirLesPropriètésParDéfautsToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(534, 6);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13});
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(537, 34);
            this.toolStripMenuItem12.Text = "Fichier récents";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(73, 22);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            this.toolStripMenuItem14.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripMenuItem14.Size = new System.Drawing.Size(97, 46);
            this.toolStripMenuItem14.Text = "Menu";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.MnEditeurMenu_Click);
            // 
            // pageDeSynthèseToolStripMenuItem
            // 
            this.pageDeSynthèseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pageDeSynthèseToolStripMenuItem.Image")));
            this.pageDeSynthèseToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pageDeSynthèseToolStripMenuItem.Name = "pageDeSynthèseToolStripMenuItem";
            this.pageDeSynthèseToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.pageDeSynthèseToolStripMenuItem.Size = new System.Drawing.Size(128, 46);
            this.pageDeSynthèseToolStripMenuItem.Text = "Synthèse";
            this.pageDeSynthèseToolStripMenuItem.Click += new System.EventHandler(this.pageDeSynthèseToolStripMenuItem_Click);
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertisseur1x2xToolStripMenuItem,
            this.genQlikViewToolStripMenuItem,
            this.sauvegarderToolStripMenuItem,
            this.générateurDeQuestionnaireToolStripMenuItem,
            this.connecteurInstallésToolStripMenuItem,
            this.styleCartographieToolStripMenuItem,
            this.analyserLaStructureDeVotreProjetToolStripMenuItem,
            this.activerPostgisToolStripMenuItem});
            this.outilsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("outilsToolStripMenuItem.Image")));
            this.outilsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.outilsToolStripMenuItem.Size = new System.Drawing.Size(96, 46);
            this.outilsToolStripMenuItem.Text = "Outils";
            // 
            // convertisseur1x2xToolStripMenuItem
            // 
            this.convertisseur1x2xToolStripMenuItem.Name = "convertisseur1x2xToolStripMenuItem";
            this.convertisseur1x2xToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.convertisseur1x2xToolStripMenuItem.Text = "Convertisseur 1.x > 2.x";
            this.convertisseur1x2xToolStripMenuItem.Click += new System.EventHandler(this.convertisseur1x2xToolStripMenuItem_Click);
            // 
            // genQlikViewToolStripMenuItem
            // 
            this.genQlikViewToolStripMenuItem.Enabled = false;
            this.genQlikViewToolStripMenuItem.Name = "genQlikViewToolStripMenuItem";
            this.genQlikViewToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.genQlikViewToolStripMenuItem.Text = "Génerer un script QlikView";
            this.genQlikViewToolStripMenuItem.Click += new System.EventHandler(this.génererUnScriptQlikViewToolStripMenuItem_Click);
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // générateurDeQuestionnaireToolStripMenuItem
            // 
            this.générateurDeQuestionnaireToolStripMenuItem.Name = "générateurDeQuestionnaireToolStripMenuItem";
            this.générateurDeQuestionnaireToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.générateurDeQuestionnaireToolStripMenuItem.Text = "Générateur de questionnaire";
            this.générateurDeQuestionnaireToolStripMenuItem.Click += new System.EventHandler(this.générateurDeQuestionnaireToolStripMenuItem_Click);
            // 
            // connecteurInstallésToolStripMenuItem
            // 
            this.connecteurInstallésToolStripMenuItem.Name = "connecteurInstallésToolStripMenuItem";
            this.connecteurInstallésToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.connecteurInstallésToolStripMenuItem.Text = "Connecteur installés";
            this.connecteurInstallésToolStripMenuItem.Click += new System.EventHandler(this.connecteurInstallésToolStripMenuItem_Click);
            // 
            // styleCartographieToolStripMenuItem
            // 
            this.styleCartographieToolStripMenuItem.Name = "styleCartographieToolStripMenuItem";
            this.styleCartographieToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.styleCartographieToolStripMenuItem.Text = "Style cartographie";
            this.styleCartographieToolStripMenuItem.Click += new System.EventHandler(this.styleCartographieToolStripMenuItem_Click);
            // 
            // analyserLaStructureDeVotreProjetToolStripMenuItem
            // 
            this.analyserLaStructureDeVotreProjetToolStripMenuItem.Name = "analyserLaStructureDeVotreProjetToolStripMenuItem";
            this.analyserLaStructureDeVotreProjetToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.analyserLaStructureDeVotreProjetToolStripMenuItem.Text = "Analyser la structure de votre projet";
            this.analyserLaStructureDeVotreProjetToolStripMenuItem.Click += new System.EventHandler(this.analyserLaStructureDeVotreProjetToolStripMenuItem_Click);
            // 
            // activerPostgisToolStripMenuItem
            // 
            this.activerPostgisToolStripMenuItem.Name = "activerPostgisToolStripMenuItem";
            this.activerPostgisToolStripMenuItem.Size = new System.Drawing.Size(431, 34);
            this.activerPostgisToolStripMenuItem.Text = "Activer Postgis";
            this.activerPostgisToolStripMenuItem.Click += new System.EventHandler(this.activerPostgisToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkSavAuto});
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 46);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // chkSavAuto
            // 
            this.chkSavAuto.Checked = true;
            this.chkSavAuto.CheckOnClick = true;
            this.chkSavAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSavAuto.Name = "chkSavAuto";
            this.chkSavAuto.Size = new System.Drawing.Size(246, 34);
            this.chkSavAuto.Text = "Sauvegarde auto";
            // 
            // modulesMenuItem
            // 
            this.modulesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPhotoModule});
            this.modulesMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modulesMenuItem.Image")));
            this.modulesMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.modulesMenuItem.Name = "modulesMenuItem";
            this.modulesMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.modulesMenuItem.Size = new System.Drawing.Size(124, 46);
            this.modulesMenuItem.Text = "Modules";
            // 
            // mnPhotoModule
            // 
            this.mnPhotoModule.Name = "mnPhotoModule";
            this.mnPhotoModule.Size = new System.Drawing.Size(385, 34);
            this.mnPhotoModule.Text = "Activer le module photothèque";
            this.mnPhotoModule.Click += new System.EventHandler(this.activerLeModulePhotothèqueToolStripMenuItem_Click);
            // 
            // codeXMLToolStripMenuItem
            // 
            this.codeXMLToolStripMenuItem.Name = "codeXMLToolStripMenuItem";
            this.codeXMLToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.codeXMLToolStripMenuItem.Size = new System.Drawing.Size(114, 46);
            this.codeXMLToolStripMenuItem.Text = "Code XML";
            this.codeXMLToolStripMenuItem.Visible = false;
            this.codeXMLToolStripMenuItem.Click += new System.EventHandler(this.codeXMLToolStripMenuItem_Click);
            // 
            // teToolStripMenuItem
            // 
            this.teToolStripMenuItem.Enabled = false;
            this.teToolStripMenuItem.Name = "teToolStripMenuItem";
            this.teToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.teToolStripMenuItem.Size = new System.Drawing.Size(113, 46);
            this.teToolStripMenuItem.Text = "Interface :";
            // 
            // cmbDisplayLevel
            // 
            this.cmbDisplayLevel.BackColor = System.Drawing.Color.SkyBlue;
            this.cmbDisplayLevel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbDisplayLevel.Items.AddRange(new object[] {
            "Simplifiée",
            "Avancée",
            "Expert"});
            this.cmbDisplayLevel.Name = "cmbDisplayLevel";
            this.cmbDisplayLevel.Size = new System.Drawing.Size(121, 46);
            this.cmbDisplayLevel.SelectedIndexChanged += new System.EventHandler(this.cmbDisplayLevel_SelectedIndexChanged);
            // 
            // contextMenuView
            // 
            this.contextMenuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterTable,
            this.supprimerLaTableToolStripMenuItem,
            this.toolStripSeparator5,
            this.ajouterUnChampToolStripMenuItem,
            this.ajouterUnChampListeSimple,
            this.ajouterUnChampListeComplexe,
            this.attacherUneCarteToolStripMenuItem,
            this.ajouterUneTableCalendrierToolStripMenuItem,
            this.créerUneNouvelleVuePourCetteTableToolStripMenuItem,
            this.toolStripSeparator8,
            this.ajouterCommeMenuPrincipalToolStripMenuItem,
            this.ajouterAuMenuParamètreToolStripMenuItem,
            this.toolStripSeparator12,
            this.afficherLeContenuDuSelectToolStripMenuItem,
            this.générerLesJointuresAutomatiquementToolStripMenuItem,
            this.toolStripSeparator16,
            this.ajouterUnTriggerToolStripMenuItem,
            this.SetAsStartViewMenuItem,
            this.toolStripSeparator17,
            this.MnDisplayDefaultView});
            this.contextMenuView.Name = "contextMenuTable";
            this.contextMenuView.Size = new System.Drawing.Size(356, 364);
            this.contextMenuView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuTable_Opening);
            this.contextMenuView.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuTable_ItemClicked);
            // 
            // ajouterTable
            // 
            this.ajouterTable.Name = "ajouterTable";
            this.ajouterTable.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ajouterTable.Size = new System.Drawing.Size(355, 22);
            this.ajouterTable.Text = "Ajouter une vue/table";
            // 
            // supprimerLaTableToolStripMenuItem
            // 
            this.supprimerLaTableToolStripMenuItem.Name = "supprimerLaTableToolStripMenuItem";
            this.supprimerLaTableToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.supprimerLaTableToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.supprimerLaTableToolStripMenuItem.Text = "Supprimer la vue/table";
            this.supprimerLaTableToolStripMenuItem.Click += new System.EventHandler(this.supprimerLaTableToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(352, 6);
            // 
            // ajouterUnChampToolStripMenuItem
            // 
            this.ajouterUnChampToolStripMenuItem.Name = "ajouterUnChampToolStripMenuItem";
            this.ajouterUnChampToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.ajouterUnChampToolStripMenuItem.Text = "Ajouter un champ à cette vue ";
            this.ajouterUnChampToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnChampToolStripMenuItem_Click);
            // 
            // ajouterUnChampListeSimple
            // 
            this.ajouterUnChampListeSimple.Name = "ajouterUnChampListeSimple";
            this.ajouterUnChampListeSimple.Size = new System.Drawing.Size(355, 22);
            this.ajouterUnChampListeSimple.Text = "Ajouter un champ liste déroulante simple à cette vue ";
            // 
            // ajouterUnChampListeComplexe
            // 
            this.ajouterUnChampListeComplexe.Name = "ajouterUnChampListeComplexe";
            this.ajouterUnChampListeComplexe.Size = new System.Drawing.Size(355, 22);
            this.ajouterUnChampListeComplexe.Text = "Ajouter un tableau à cette vue";
            // 
            // attacherUneCarteToolStripMenuItem
            // 
            this.attacherUneCarteToolStripMenuItem.Name = "attacherUneCarteToolStripMenuItem";
            this.attacherUneCarteToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.attacherUneCarteToolStripMenuItem.Text = "Attacher une carte";
            this.attacherUneCarteToolStripMenuItem.Click += new System.EventHandler(this.attacherUneCarteToolStripMenuItem_Click);
            // 
            // ajouterUneTableCalendrierToolStripMenuItem
            // 
            this.ajouterUneTableCalendrierToolStripMenuItem.Name = "ajouterUneTableCalendrierToolStripMenuItem";
            this.ajouterUneTableCalendrierToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.ajouterUneTableCalendrierToolStripMenuItem.Text = "Implementer un calendrier sur cette vue";
            // 
            // créerUneNouvelleVuePourCetteTableToolStripMenuItem
            // 
            this.créerUneNouvelleVuePourCetteTableToolStripMenuItem.Name = "créerUneNouvelleVuePourCetteTableToolStripMenuItem";
            this.créerUneNouvelleVuePourCetteTableToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.créerUneNouvelleVuePourCetteTableToolStripMenuItem.Text = "Créer une nouvelle vue pour cette table";
            this.créerUneNouvelleVuePourCetteTableToolStripMenuItem.Click += new System.EventHandler(this.créerUneNouvelleVuePourCetteTableToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(352, 6);
            // 
            // ajouterCommeMenuPrincipalToolStripMenuItem
            // 
            this.ajouterCommeMenuPrincipalToolStripMenuItem.Name = "ajouterCommeMenuPrincipalToolStripMenuItem";
            this.ajouterCommeMenuPrincipalToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.ajouterCommeMenuPrincipalToolStripMenuItem.Text = "Ajouter la vue au menu principal";
            this.ajouterCommeMenuPrincipalToolStripMenuItem.Click += new System.EventHandler(this.ajouterCommeMenuPrincipalToolStripMenuItem_Click);
            // 
            // ajouterAuMenuParamètreToolStripMenuItem
            // 
            this.ajouterAuMenuParamètreToolStripMenuItem.Name = "ajouterAuMenuParamètreToolStripMenuItem";
            this.ajouterAuMenuParamètreToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.ajouterAuMenuParamètreToolStripMenuItem.Text = "Ajouter la vue au menu paramètre";
            this.ajouterAuMenuParamètreToolStripMenuItem.Click += new System.EventHandler(this.ajouterAuMenuParamètreToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(352, 6);
            // 
            // afficherLeContenuDuSelectToolStripMenuItem
            // 
            this.afficherLeContenuDuSelectToolStripMenuItem.Name = "afficherLeContenuDuSelectToolStripMenuItem";
            this.afficherLeContenuDuSelectToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.afficherLeContenuDuSelectToolStripMenuItem.Text = "Afficher le contenu du \"Select\" pour cette vue";
            this.afficherLeContenuDuSelectToolStripMenuItem.Click += new System.EventHandler(this.afficherLeContenuDuSelectToolStripMenuItem_Click);
            // 
            // générerLesJointuresAutomatiquementToolStripMenuItem
            // 
            this.générerLesJointuresAutomatiquementToolStripMenuItem.Name = "générerLesJointuresAutomatiquementToolStripMenuItem";
            this.générerLesJointuresAutomatiquementToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.générerLesJointuresAutomatiquementToolStripMenuItem.Text = "Générer les jointures automatiquement";
            this.générerLesJointuresAutomatiquementToolStripMenuItem.Click += new System.EventHandler(this.générerLesJointuresAutomatiquementToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(352, 6);
            // 
            // ajouterUnTriggerToolStripMenuItem
            // 
            this.ajouterUnTriggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créezDesÉlémentsAutomatiquementToolStripMenuItem});
            this.ajouterUnTriggerToolStripMenuItem.Name = "ajouterUnTriggerToolStripMenuItem";
            this.ajouterUnTriggerToolStripMenuItem.Size = new System.Drawing.Size(355, 22);
            this.ajouterUnTriggerToolStripMenuItem.Text = "Ajouter une action automatique";
            // 
            // créezDesÉlémentsAutomatiquementToolStripMenuItem
            // 
            this.créezDesÉlémentsAutomatiquementToolStripMenuItem.Name = "créezDesÉlémentsAutomatiquementToolStripMenuItem";
            this.créezDesÉlémentsAutomatiquementToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.créezDesÉlémentsAutomatiquementToolStripMenuItem.Text = "Créez des éléments automatiquement";
            this.créezDesÉlémentsAutomatiquementToolStripMenuItem.Click += new System.EventHandler(this.créezDesÉlémentsAutomatiquementToolStripMenuItem_Click);
            // 
            // SetAsStartViewMenuItem
            // 
            this.SetAsStartViewMenuItem.Name = "SetAsStartViewMenuItem";
            this.SetAsStartViewMenuItem.Size = new System.Drawing.Size(355, 22);
            this.SetAsStartViewMenuItem.Text = "Définir comme page de démarrage";
            this.SetAsStartViewMenuItem.Click += new System.EventHandler(this.SetAsStartViewMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(352, 6);
            // 
            // MnDisplayDefaultView
            // 
            this.MnDisplayDefaultView.Name = "MnDisplayDefaultView";
            this.MnDisplayDefaultView.Size = new System.Drawing.Size(355, 22);
            this.MnDisplayDefaultView.Text = "Afficher les vues crées par défaut";
            this.MnDisplayDefaultView.Click += new System.EventHandler(this.MnDisplayDefaultView_Click);
            // 
            // imgField
            // 
            this.imgField.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgField.ImageStream")));
            this.imgField.TransparentColor = System.Drawing.Color.Transparent;
            this.imgField.Images.SetKeyName(0, "39898.png");
            this.imgField.Images.SetKeyName(1, "btn.png");
            this.imgField.Images.SetKeyName(2, "chk.png");
            this.imgField.Images.SetKeyName(3, "cmb.png");
            this.imgField.Images.SetKeyName(4, "coul.png");
            this.imgField.Images.SetKeyName(5, "lst.png");
            // 
            // ajouterToolStripMenuItem1
            // 
            this.ajouterToolStripMenuItem1.Name = "ajouterToolStripMenuItem1";
            this.ajouterToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // supprimerToolStripMenuItem4
            // 
            this.supprimerToolStripMenuItem4.Name = "supprimerToolStripMenuItem4";
            this.supprimerToolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnregistrer,
            this.btnProprietes,
            this.toolStripSeparator3,
            this.btnFromSite,
            this.btnFromDataBase,
            this.toolStripSeparator4,
            this.btnExecute,
            this.btnLog,
            this.toolStripSeparator6,
            this.toolStripSplitButton1,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(20, 80);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1318, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEnregistrer.Image = global::TabloidWizard.Properties.Resources.enrg;
            this.btnEnregistrer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(23, 22);
            this.btnEnregistrer.Click += new System.EventHandler(this.SaveMenu);
            // 
            // btnProprietes
            // 
            this.btnProprietes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProprietes.Image = ((System.Drawing.Image)(resources.GetObject("btnProprietes.Image")));
            this.btnProprietes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProprietes.Name = "btnProprietes";
            this.btnProprietes.Size = new System.Drawing.Size(23, 22);
            this.btnProprietes.ToolTipText = "Propriétés du projet";
            this.btnProprietes.Click += new System.EventHandler(this.PropertiesMenu);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFromSite
            // 
            this.btnFromSite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFromSite.Image = ((System.Drawing.Image)(resources.GetObject("btnFromSite.Image")));
            this.btnFromSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFromSite.Name = "btnFromSite";
            this.btnFromSite.Size = new System.Drawing.Size(23, 22);
            this.btnFromSite.ToolTipText = "Ouvrir un site existant";
            this.btnFromSite.Click += new System.EventHandler(this.NewFromSite);
            // 
            // btnFromDataBase
            // 
            this.btnFromDataBase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFromDataBase.Image = ((System.Drawing.Image)(resources.GetObject("btnFromDataBase.Image")));
            this.btnFromDataBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFromDataBase.Name = "btnFromDataBase";
            this.btnFromDataBase.Size = new System.Drawing.Size(23, 22);
            this.btnFromDataBase.ToolTipText = "Nouveau  projet à partir d\'une base de donnée";
            this.btnFromDataBase.Click += new System.EventHandler(this.NewFromDatabase);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExecute
            // 
            this.btnExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(23, 22);
            this.btnExecute.Text = "btnExecute";
            this.btnExecute.ToolTipText = "Executer";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnLog
            // 
            this.btnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLog.Image = ((System.Drawing.Image)(resources.GetObject("btnLog.Image")));
            this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(23, 22);
            this.btnLog.Text = "btnLog";
            this.btnLog.ToolTipText = "Afficher les logs";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUneColonneToolStripMenuItem,
            this.ajouterUneJointureToolStripMenuItem,
            this.ajouterUneTableToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::TabloidWizard.Properties.Resources.wizard;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // ajouterUneColonneToolStripMenuItem
            // 
            this.ajouterUneColonneToolStripMenuItem.Name = "ajouterUneColonneToolStripMenuItem";
            this.ajouterUneColonneToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ajouterUneColonneToolStripMenuItem.Text = "Ajouter une colonne";
            // 
            // ajouterUneJointureToolStripMenuItem
            // 
            this.ajouterUneJointureToolStripMenuItem.Name = "ajouterUneJointureToolStripMenuItem";
            this.ajouterUneJointureToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ajouterUneJointureToolStripMenuItem.Text = "Ajouter une jointure";
            // 
            // ajouterUneTableToolStripMenuItem
            // 
            this.ajouterUneTableToolStripMenuItem.Name = "ajouterUneTableToolStripMenuItem";
            this.ajouterUneTableToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ajouterUneTableToolStripMenuItem.Text = "Ajouter une table";
            this.ajouterUneTableToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneTableToolStripMenuItem_Click);
            // 
            // imgView
            // 
            this.imgView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgView.ImageStream")));
            this.imgView.TransparentColor = System.Drawing.Color.Transparent;
            this.imgView.Images.SetKeyName(0, "vue.png");
            this.imgView.Images.SetKeyName(1, "cal.png");
            this.imgView.Images.SetKeyName(2, "Ged.png");
            this.imgView.Images.SetKeyName(3, "map.png");
            this.imgView.Images.SetKeyName(4, "star.png");
            // 
            // contextMenuFunction
            // 
            this.contextMenuFunction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUneFonctionToolStripMenuItem,
            this.supprimerUneFonctionToolStripMenuItem});
            this.contextMenuFunction.Name = "contextMenuFunction";
            this.contextMenuFunction.Size = new System.Drawing.Size(239, 48);
            // 
            // ajouterUneFonctionToolStripMenuItem
            // 
            this.ajouterUneFonctionToolStripMenuItem.Name = "ajouterUneFonctionToolStripMenuItem";
            this.ajouterUneFonctionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ajouterUneFonctionToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.ajouterUneFonctionToolStripMenuItem.Text = "Ajouter une fonction";
            this.ajouterUneFonctionToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneFonctionToolStripMenuItem_Click);
            // 
            // supprimerUneFonctionToolStripMenuItem
            // 
            this.supprimerUneFonctionToolStripMenuItem.Name = "supprimerUneFonctionToolStripMenuItem";
            this.supprimerUneFonctionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.supprimerUneFonctionToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.supprimerUneFonctionToolStripMenuItem.Text = "Supprimer une fonction";
            this.supprimerUneFonctionToolStripMenuItem.Click += new System.EventHandler(this.supprimerUneFonctionToolStripMenuItem_Click);
            // 
            // imgFct
            // 
            this.imgFct.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFct.ImageStream")));
            this.imgFct.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFct.Images.SetKeyName(0, "icons8-services-30.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 105);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabviewfct);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1318, 369);
            this.splitContainer1.SplitterDistance = 435;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabviewfct
            // 
            this.tabviewfct.Controls.Add(this.tabPage1);
            this.tabviewfct.Controls.Add(this.tabPage2);
            this.tabviewfct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabviewfct.Location = new System.Drawing.Point(0, 0);
            this.tabviewfct.Name = "tabviewfct";
            this.tabviewfct.SelectedIndex = 0;
            this.tabviewfct.Size = new System.Drawing.Size(433, 367);
            this.tabviewfct.TabIndex = 4;
            this.tabviewfct.UseSelectable = true;
            this.tabviewfct.SelectedIndexChanged += new System.EventHandler(this.tabviewfct_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtStartMsg);
            this.tabPage1.Controls.Add(this.lstViews);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(425, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Liste des Vues";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtStartMsg
            // 
            this.txtStartMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStartMsg.Enabled = false;
            this.txtStartMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartMsg.ForeColor = System.Drawing.Color.Orange;
            this.txtStartMsg.Location = new System.Drawing.Point(3, 42);
            this.txtStartMsg.Multiline = true;
            this.txtStartMsg.Name = "txtStartMsg";
            this.txtStartMsg.Size = new System.Drawing.Size(419, 280);
            this.txtStartMsg.TabIndex = 3;
            this.txtStartMsg.Text = "Utilisez le menu \"Projet\" en haut à droite pour débuter un nouveau projet ou char" +
    "ger un projet existant.";
            this.txtStartMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstViews
            // 
            this.lstViews.ContextMenuStrip = this.contextMenuView;
            this.lstViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViews.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstViews.FormattingEnabled = true;
            this.lstViews.ImageIndex = 0;
            this.lstViews.ImageList = null;
            this.lstViews.ImagePadding = 0;
            this.lstViews.Location = new System.Drawing.Point(3, 42);
            this.lstViews.Name = "lstViews";
            this.lstViews.SelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(175)))), ((int)(((byte)(0)))));
            this.lstViews.Size = new System.Drawing.Size(419, 280);
            this.lstViews.TabIndex = 2;
            this.lstViews.SelectedIndexChanged += new System.EventHandler(this.lstView_SelectedIndexChanged);
            this.lstViews.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstViews_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(175)))), ((int)(((byte)(0)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "- Liste des Vues -";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstFct);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(425, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Liste des fonctions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstFct
            // 
            this.lstFct.ContextMenuStrip = this.contextMenuFunction;
            this.lstFct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFct.FormattingEnabled = true;
            this.lstFct.ImageIndex = 0;
            this.lstFct.ImageList = this.imgFct;
            this.lstFct.ImagePadding = 0;
            this.lstFct.Location = new System.Drawing.Point(3, 42);
            this.lstFct.Name = "lstFct";
            this.lstFct.SelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lstFct.Size = new System.Drawing.Size(419, 280);
            this.lstFct.TabIndex = 3;
            this.lstFct.SelectedIndexChanged += new System.EventHandler(this.lstView_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "- Liste des fonctions -";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this.propTable);
            this.splitContainer2.Panel1.Controls.Add(this.lblTable);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabFieldDetail);
            this.splitContainer2.Size = new System.Drawing.Size(879, 369);
            this.splitContainer2.SplitterDistance = 144;
            this.splitContainer2.TabIndex = 0;
            // 
            // propTable
            // 
            this.propTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(218)))), ((int)(((byte)(121)))));
            this.propTable.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(218)))), ((int)(((byte)(121)))));
            this.propTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propTable.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(218)))), ((int)(((byte)(121)))));
            this.propTable.HelpBorderColor = System.Drawing.Color.Gray;
            this.propTable.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(218)))), ((int)(((byte)(121)))));
            this.propTable.Location = new System.Drawing.Point(0, 23);
            this.propTable.Name = "propTable";
            this.propTable.SelectedItemWithFocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(218)))), ((int)(((byte)(121)))));
            this.propTable.Size = new System.Drawing.Size(877, 119);
            this.propTable.TabIndex = 4;
            this.propTable.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.TablePropertyValueChanged);
            // 
            // lblTable
            // 
            this.lblTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(175)))), ((int)(((byte)(0)))));
            this.lblTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(0, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(877, 23);
            this.lblTable.TabIndex = 3;
            this.lblTable.Text = "- Sélectionnez une vue dans la liste de gauche -";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabFieldDetail
            // 
            this.tabFieldDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFieldDetail.Location = new System.Drawing.Point(0, 0);
            this.tabFieldDetail.Name = "tabFieldDetail";
            this.tabFieldDetail.Size = new System.Drawing.Size(877, 219);
            this.tabFieldDetail.TabIndex = 0;
            this.tabFieldDetail.UseSelectable = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1358, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "TabloidWizard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuView.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.contextMenuFunction.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabviewfct.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Classes.Control.GListBox lstViews;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatut;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnEnregistrer;
        private System.Windows.Forms.ToolStripButton btnProprietes;
        private System.Windows.Forms.ToolStripButton btnFromSite;
        private System.Windows.Forms.ToolStripButton btnFromDataBase;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertisseur1x2xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genQlikViewToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propTable;
        private System.Windows.Forms.ToolStripMenuItem codeXMLToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneColonneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneJointureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnChampListeComplexe;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnChampListeSimple;
        private System.Windows.Forms.ToolStripMenuItem ajouterTable;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneTableCalendrierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnChampToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnExecute;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem ajouterAuMenuParamètreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterCommeMenuPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerLaTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem créerUneNouvelleVuePourCetteTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherLeContenuDuSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem générateurDeQuestionnaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem générerLesJointuresAutomatiquementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attacherUneCarteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chkSavAuto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnTriggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créezDesÉlémentsAutomatiquementToolStripMenuItem;
        private System.Windows.Forms.ImageList imgField;
        private System.Windows.Forms.ImageList imgView;
        private System.Windows.Forms.ToolStripMenuItem connecteurInstallésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleCartographieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem modulesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnPhotoModule;
        private System.Windows.Forms.TextBox txtStartMsg;
        private System.Windows.Forms.ToolStripMenuItem SetAsStartViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem MnDisplayDefaultView;
        private System.Windows.Forms.ToolStripMenuItem analyserLaStructureDeVotreProjetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmbDisplayLevel;
        private System.Windows.Forms.ToolStripSplitButton btnStatusUpdateEngine;
        private System.Windows.Forms.ToolStripMenuItem pageDeSynthèseToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Classes.Control.GListBox lstFct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneFonctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerUneFonctionToolStripMenuItem;
        private System.Windows.Forms.ImageList imgFct;
        private MetroFramework.Controls.MetroTabControl tabFieldDetail;
        private MetroFramework.Controls.MetroTabControl tabviewfct;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroContextMenu contextMenuView;
        private MetroContextMenu contextMenuFunction;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem MnSave;
        private System.Windows.Forms.ToolStripMenuItem MnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem MnPublier;
        private System.Windows.Forms.ToolStripMenuItem MnMaj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem activerPostgisToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
