/*
 * Created by SharpDevelop.
 * User: DAPOJERO
 * Date: 23/02/2013
 * Time: 16:09
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes;
using TabloidWizard.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;
using Tabloid.Classes;
using TabloidWizard.Classes.Control;
using TabloidWizard.Classes.WizardTools;
using Tabloid.Classes.Objects.OlObjects;
using Tabloid.Classes.Config.Helper;
using Microsoft.Win32;
using ExtensionMethods;
using TabloidWizard.Classes.Tools;
using Tabloid.Classes.Data;
using MetroFramework.Forms;
using MetroFramework;
using TabloidWizard.Classes.Editor;
using static TabloidWizard.Classes.AppSetting;

namespace TabloidWizard
{

    /// <summary>
    ///     Description of MainForm.
    /// </summary>
    public partial class MainForm : MetroForm, IMRUClient
    {
        const string _registryPath = "Software\\TabloidWizard";

        GenericPropertiesViewer<TabloidConfigColonneCollection, TabloidConfigColonne> _fieldViewer;
        GenericPropertiesViewer<TabloidConfigEditionsCollection, TabloidConfigEdition> _editionViewer;
        GenericPropertiesViewer<TabloidConfigGraphCollection, TabloidConfigGraph> _graphiqViewer;
        GenericPropertiesViewer<TabloidConfigRechercheCollection, TabloidConfigRecherche> _filterViewer;
        GenericPropertiesViewer<TabloidConfigPredefExportCollection, TabloidConfigPredefExport> _exportViewer;
        GenericPropertiesViewer<TabloidConfigJointureCollection, TabloidConfigJointure> _joinViewer;
        GenericPropertiesViewer<TabloidConfigIndicateurCollection, TabloidConfigIndicateur> _indicViewer;
        GenericPropertiesViewer<TabloidConfigTriggerCollection, TabloidConfigTrigger> _triggerViewer;
        GenericPropertiesViewer<TabloidConfigImportCollection, TabloidConfigImport> _importViewer;

        TabPage _triggerTabPage;

        /// <summary>
        /// Current web.config path
        /// </summary>
        //public string _currentPath;
        BackgroundWorker _gbw;
        WaitingForm _waitingForm;
        Object _clipboard;
        bool _projectModified;//set to true if project have been modified and not saved
        bool _upDateFromPropertyGrid;//set to true if object modified in property grid
        Dictionary<Tabloid.Classes.Controls.TemplateType, int> fieldIconDictionary =
            new Dictionary<Tabloid.Classes.Controls.TemplateType, int>{
                { Tabloid.Classes.Controls.TemplateType.Btn, 0 }
            };

        bool _displayView = true;//goes false if display function

        public MainForm()
        {
            InitializeComponent();

            Program.CurrentXLSStructure = new XLSStructure();

            this.StyleManager = metroStyleManager1;

            createdViewWarningState = new List<TabloidConfigView>();

            SetViewersTabs();

            tabviewfct.SelectedIndex = 0;
            SetProjectReady(false);

            SetCollectionEditor();
            SetDefaultEditor();

            lstViews.ImageList = imgView;
            lstViews.ImageIndex = lstFct.ImageIndex = 0;
            lstViews.ImagePadding = lstFct.ImagePadding = 10;
            lstViews.Font = lstFct.Font = new Font("Arial", 14);

            //load display level from registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(_registryPath);
            if (key != null)
            {
                var v = key.GetValue("DisplayLevel");
                if (v != null)
                {
                    cmbDisplayLevel.SelectedIndex = (int)key.GetValue("DisplayLevel");
                }
                key.Close();
            }
            else
                cmbDisplayLevel.SelectedIndex = 0;
        }
        void SetViewersTabs()
        {
            _fieldViewer = (GenericPropertiesViewer<TabloidConfigColonneCollection, TabloidConfigColonne>)addTab(
                new GenericPropertiesViewer<TabloidConfigColonneCollection, TabloidConfigColonne>
                {
                    TypesName = "Champs",
                    TypeName = "Champ",

                    Padding = new Padding(0, 10, 0, 0),

                    ChildPropertyName = "Colonnes",
                    DisplayPropertyName = "Colonnes",

                    imgList = imgField,
                    EnableMove = true,

                    OnAddElement = addField,
                    OnDeleteElement = deleteField,
                    AllowCopy = true,
                    OnPaste = collerToolStripMenuItem_Click,

                    SearchInProperty = "Champ",

                    OnPropertyValueChanged = onFieldModified,
                    AfterSelectedItemChange = setCurrentContext,
                    AfterObjectCollectionSet = addFieldIcon,
                    OnCollectionModified = collectionModified,
                    OnContextOpening = fieldContextOpening,

                });

            _fieldViewer.list.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _fieldViewer.list.DrawNode += new DrawTreeNodeEventHandler(FieldView_DrawNode);

            _joinViewer = (GenericPropertiesViewer<TabloidConfigJointureCollection, TabloidConfigJointure>)addTab(
                new GenericPropertiesViewer<TabloidConfigJointureCollection, TabloidConfigJointure>
                {
                    Name = "lstJointuress",
                    TypesName = "Jointures",
                    TypeName = "Jointure",

                    Padding = new Padding(0, 10, 0, 0),

                    ChildPropertyName = "Jointures",
                    DisplayPropertyName = "Jointures",

                    EnableDelete = true,

                    SearchInProperty = "ChampDeRef;ChampDeRef2",

                    OnAddElement = addJoin,
                    OnContextOpening = joinContextOpening,
                    AllowCopy = true,
                    OnPaste = joinPaste_Click,

                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified
                });
            _filterViewer = (GenericPropertiesViewer<TabloidConfigRechercheCollection, TabloidConfigRecherche>)addTab(
                new GenericPropertiesViewer<TabloidConfigRechercheCollection, TabloidConfigRecherche>
                {
                    TypesName = "Filtres",
                    TypeName = "Filtre",
                    Name = "lstFiltres",

                    Padding = new Padding(0, 10, 0, 0),

                    DisplayPropertyName = "Recherche",
                    EnableMove = true,
                    EnableDelete = true,

                    OnAddElement = addFilter,
                    AllowCopy = true,
                    OnPaste = filterPaste_Click,

                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified
                });
            _editionViewer = (GenericPropertiesViewer<TabloidConfigEditionsCollection, TabloidConfigEdition>)addTab(
                new GenericPropertiesViewer<TabloidConfigEditionsCollection, TabloidConfigEdition>
                {
                    TypesName = "Editions",
                    TypeName = "Edition",
                    Name = "lstEditions",

                    Padding = new Padding(0, 10, 0, 0),

                    DisplayPropertyName = "Editions",

                    EnableDelete = true,

                    OnAddElement = addEdition,
                    AllowCopy = true,
                    OnPaste = editionPaste_Click,

                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified
                });

            _graphiqViewer = (GenericPropertiesViewer<TabloidConfigGraphCollection, TabloidConfigGraph>)addTab(
                new GenericPropertiesViewer<TabloidConfigGraphCollection, TabloidConfigGraph>
                {
                    TypesName = "Graphiques",
                    TypeName = "Graphique",
                    Name = "lstGraphs",

                    Padding = new Padding(0, 10, 0, 0),

                    ChildPropertyName = "Graphiques",
                    DisplayPropertyName = "Graphiques",

                    EnableDelete = true,
                    EnableMove = true,

                    AllowCopy = true,
                    OnPaste = graphPaste_Click,

                    OnAddElement = addGraph,
                    OnEditElement = editGraph,
                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified
                });
            _exportViewer = (GenericPropertiesViewer<TabloidConfigPredefExportCollection, TabloidConfigPredefExport>)addTab(
                new GenericPropertiesViewer<TabloidConfigPredefExportCollection, TabloidConfigPredefExport>
                {
                    TypesName = "Exports",
                    TypeName = "Export",
                    Name = "lstExports",

                    Padding = new Padding(0, 10, 0, 0),

                    DisplayPropertyName = "Exports",

                    EnableDelete = true,

                    AllowCopy = true,
                    OnPaste = exportPaste_Click,

                    OnAddElement = addExport,

                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified
                });
            _indicViewer = (GenericPropertiesViewer<TabloidConfigIndicateurCollection, TabloidConfigIndicateur>)addTab(
                new GenericPropertiesViewer<TabloidConfigIndicateurCollection, TabloidConfigIndicateur>
                {
                    TypesName = "Indicateurs",
                    TypeName = "Indicateur",
                    Name = "lstIndics",

                    Padding = new Padding(0, 10, 0, 0),

                    DisplayPropertyName = "Indicateurs",

                    EnableDelete = true,

                    OnAddElement = addIndic,
                    AllowCopy = true,
                    OnPaste = indicPaste_Click,

                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified
                });
            _importViewer = (GenericPropertiesViewer<TabloidConfigImportCollection, TabloidConfigImport>)addTab(
                new GenericPropertiesViewer<TabloidConfigImportCollection, TabloidConfigImport>
                {
                    TypesName = "Imports",
                    TypeName = "Import",
                    Name = "lstImports",

                    Padding = new Padding(0, 10, 0, 0),

                    DisplayPropertyName = "Imports",

                    EnableDelete = true,

                    OnAddElement = addImportTable_Click,
                    AllowCopy = true,
                    OnPaste = importPaste_Click,

                    OnPropertyValueChanged = TablePropertyValueChanged,
                    AfterSelectedItemChange = setCurrentContext,
                    OnCollectionModified = collectionModified,
                    OnContextOpening = importContextOpening,
                });
            _triggerViewer = (GenericPropertiesViewer<TabloidConfigTriggerCollection, TabloidConfigTrigger>)addTab(
                new GenericPropertiesViewer<TabloidConfigTriggerCollection, TabloidConfigTrigger>
                {
                    TypesName = "Triggers",
                    TypeName = "Trigger",
                    Name = "lstTriggers",

                    Padding = new Padding(0, 10, 0, 0),

                    DisplayPropertyName = "Triggers",

                    EnableDelete = true,

                    OnAddElement = addTrigger,

                    AllowCopy = true,
                    OnPaste = triggerPaste_Click
                });

            _triggerTabPage = tabFieldDetail.TabPages[tabFieldDetail.TabPages.Count - 1];
        }

        private void triggerPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentTrigger = _triggerViewer.SelectedObject;

            var copied = (TabloidConfigTrigger)_triggerViewer.ClipBoard;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Triggers, copied, "I");
            _triggerViewer.ClipBoard = null;
            _triggerViewer.SetObjectCollection();
            setProjectModified();
        }

        private void importPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentImport = _importViewer.SelectedObject;

            var copied = (TabloidConfigImport)_importViewer.ClipBoard;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Imports, copied, "IM");
            _importViewer.ClipBoard = null;
            _importViewer.SetObjectCollection();
            setProjectModified();
        }

        private void indicPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentIndic = _indicViewer.SelectedObject;

            var copied = (TabloidConfigIndicateur)_indicViewer.ClipBoard;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Indicateurs, copied, "I");
            _indicViewer.ClipBoard = null;
            _indicViewer.SetObjectCollection();
            setProjectModified();
        }

        private void exportPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentExport = _exportViewer.SelectedObject;

            var copied = (TabloidConfigEdition)_exportViewer.ClipBoard;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Exports, copied, "E");
            _exportViewer.ClipBoard = null;
            _exportViewer.SetObjectCollection();
            setProjectModified();
        }

        private void graphPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentGraph = _graphiqViewer.SelectedObject;

            var copied = (TabloidConfigGraph)_joinViewer.ClipBoard;
            copied.Parent = CurrentContext.CurrentGraph;

            var dest = CurrentContext.CurrentGraph == null ?
                null : CurrentContext.CurrentGraph.Graphiques;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Graphiques, copied, "G", dest);
            _graphiqViewer.ClipBoard = null;
            _graphiqViewer.SetObjectCollection();
            setProjectModified();
        }

        private void editionPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentEdition = _editionViewer.SelectedObject;

            var copied = (TabloidConfigEdition)_editionViewer.ClipBoard;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Editions, copied, "E");
            _editionViewer.ClipBoard = null;
            _editionViewer.SetObjectCollection();
            setProjectModified();
        }

        private void filterPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentFilter = _filterViewer.SelectedObject;

            var copied = (TabloidConfigRecherche)_filterViewer.ClipBoard;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Recherche, copied, "R");
            _filterViewer.ClipBoard = null;
            _filterViewer.SetObjectCollection();
            setProjectModified();
        }

        private void joinPaste_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentJoin = _joinViewer.SelectedObject;

            var copied = (TabloidConfigJointure)_joinViewer.ClipBoard;
            copied.Parent = CurrentContext.CurrentJoin;

            var dest = CurrentContext.CurrentJoin == null ?
                null : CurrentContext.CurrentJoin.Jointures;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Jointures, copied, "J", dest);
            _joinViewer.ClipBoard = null;
            _joinViewer.SetObjectCollection();
            setProjectModified();
        }



        private void onFieldModified(object sender, PropertyValueChangedEventArgs e)
        {
            WizardEvents.afterFieldPropertyChange(sender, e, this);
            setProjectModified();
        }



        private void collectionModified(object sender, EventArgs e)
        {
            setProjectModified();
        }

        private void addFieldIcon(object sender, EventArgs e)
        {
            foreach (TreeNode n in _fieldViewer.list.Nodes)
            {
                if (TabloidControl.TabloidControlList.ContainsKey(((TabloidConfigColonne)n.Tag).Editeur))
                    n.ImageIndex = n.SelectedImageIndex = TabloidControl.TabloidControlList[((TabloidConfigColonne)n.Tag).Editeur].IconType;

            }
        }

        private void FieldView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            DrawNode(_fieldViewer.list, e);
        }

        private void DrawNode(TreeView tree, DrawTreeNodeEventArgs e)
        {
            bool selected = (e.State & TreeNodeStates.Selected) != 0;

            var width = tree.Width - SystemInformation.VerticalScrollBarWidth - 2;
            e.DrawDefault = true;

            // Retrieve the node font. If the node font has not been set,
            // use the TreeView font.
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)tree).Font;

            if (!selected && e.Node.BackColor != Color.Empty)
            {
                var rec = new Rectangle(e.Node.Bounds.Left, e.Node.Bounds.Top,
                    width, e.Node.Bounds.Height);
                e.Graphics.FillRectangle(new SolidBrush(e.Node.BackColor), rec);
                e.DrawDefault = false;


                // Draw the node text.
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, rec);
            }
            //add tab information
            if (e.Node.Tag != null)
            {
                var cc = (TabloidConfigColonne)e.Node.Tag;

                if (!String.IsNullOrEmpty(cc.Tab) || !String.IsNullOrEmpty(cc.Groupe) && !cc.Groupe.StartsWith("!"))
                {
                    var tab = !String.IsNullOrEmpty(cc.Tab);
                    var title = tab ? cc.Tab : cc.Groupe;

                    Pen customPen = new Pen(Color.LightGray, 1);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    var m = (int)e.Graphics.MeasureString(title, nodeFont).Width;

                    var fullWithBounds = new Rectangle(e.Node.Bounds.Left, e.Node.Bounds.Top, width - e.Node.Bounds.Left - 5, e.Node.Bounds.Height);

                    if (tab)
                        e.Graphics.FillRectangle(Brushes.LightGray,
                            new Rectangle(e.Node.Bounds.Left + width - e.Node.Bounds.Left - 5 - m, e.Node.Bounds.Top, m, e.Node.Bounds.Height - 1));
                    else
                        e.Graphics.DrawRectangle(customPen,
                            new Rectangle(e.Node.Bounds.Left + width - e.Node.Bounds.Left - 5 - m, e.Node.Bounds.Top, m, e.Node.Bounds.Height - 1));

                    e.Graphics.DrawLine(customPen, new Point(0, e.Bounds.Top),
                                new Point(tree.Width - 4, e.Bounds.Top));
                    // Draw the tab title.

                    e.Graphics.DrawString(title, nodeFont, tab ? Brushes.White : Brushes.LightGray,
                        fullWithBounds, stringFormat);

                    customPen.Dispose();
                }
            }
        }

        private static void SetDefaultEditor()
        {
            TypeDescriptor.AddAttributes(
                typeof(TabloidConfigGraphCollection),
                new EditorAttribute(typeof(Classes.Editor.GraphicEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(
                typeof(String),
                new EditorAttribute(typeof(Classes.Editor.GenericPropertySelector), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(
                typeof(Tabloid.Classes.Objects.EditableColor),
                new EditorAttribute(typeof(Classes.Editor.ColorEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(
                  typeof(OlStyle.ImageSource),
                  new EditorAttribute(
                  typeof(Classes.Editor.ImgSrcEditor),
                  typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(
                  typeof(OlStyle.OlImage),
                  new EditorAttribute(
                  typeof(Classes.Editor.OlImageStyleEditor),
                  typeof(UITypeEditor)));
        }

        private static void SetCollectionEditor()
        {
            TypeDescriptor.AddAttributes(typeof(TabloidConfigColonneCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigDataSourceCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigDependanceCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigEditionsCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigFillerCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigFilterCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigFunctionCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigGraphCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigJointureCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigLayersCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigMenu), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigRechercheCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigViewCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigTriggerCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));
            TypeDescriptor.AddAttributes(typeof(TabloidConfigValideurCollection), new EditorAttribute(typeof(DescriptiveCollectionEditor), typeof(UITypeEditor)));

        }

        /// <summary>
        ///     Open from already used WebConfig
        /// </summary>
        /// <param name="fileName">already used WebConfig path</param>
        public void OpenMRUFile(string fileName)
        {
            Program.AppSet = new AppSetting();

            ReadConfig(fileName, Program.AppSet);

            //Tools.setDefaultProvider();

        }

        /// <summary>
        ///     Load config files and set appSetting and TabloidConfig
        /// </summary>
        /// <param name="folderName">Web.config path</param>
        /// <param name="appSet">appSet to define</param>
        private void ReadConfig(string folderName, AppSetting appSet)
        {
            _waitingForm = new WaitingForm(ReadConfig)
            {
                Text = "Chargement",
                progressBar = { Style = ProgressBarStyle.Marquee }
            };

            _waitingForm.Wr.RunWorkerAsync(new object[] { folderName, appSet });

            _waitingForm.ShowDialog();

            SetFunctionListFromConfig();
            SetViewListFromConfig();

            Program.CurrentProjectFolder = _configFiles.ProjectFolderPath;


            //ModuleTable
            mnPhotoModule.Checked = TabloidModule.IsModuleActivated(TabloidModule.ModuleTableType.Phototheque);

            updateStatusBar();

            SetProjectReady(true);
        }
        private void ReadConfig(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;
            var worker = (BackgroundWorker)sender;

            var folderName = (string)args[0];
            var appSet = (AppSetting)args[1];

            _configFiles = new ConfigFilesCollection();//new XmlFile[Enum.GetNames(typeof(XmlFile.ConfigFilesTypes)).Length];

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.LodingConfigFiles));

            foreach (XmlFile.ConfigFilesTypes ct in Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)))
            {
                var fi = new FileInfo(folderName + "\\configs\\" + ct + ".config");


                if (fi.Exists)
                {
                    _configFiles._configFiles[(int)ct] = new XmlFile(fi.FullName, ct);


                }
                else
                {
                    MetroMessageBox.Show(this, Resources.MainForm_ReadWebConfig_Ce_dossier_ne_contient_pas_de_fichier_config_web,
                        Resources.Erreur, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            _mruManager.Add(folderName);
            //_currentPath = folderName;

            DeserializeMainTabloidConfig();

            //read appsetting properties
            appSet.ReadAppSetting(_configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.appSettings], true);
            appSet.ReadConnectionSetting(_configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.connections], true, this);

            ////read tabloid config menu
            var tabloidmn = _configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.tabloidMenu].Xml.SelectSingleNode("/TabloidMenu");
            if (tabloidmn != null)
            {
                TabloidConfigMenu.Deserialize("<TabloidMenu>" + tabloidmn.InnerXml + "</TabloidMenu>");

                tabloidmn.InnerXml = ""; //remove tabloid content when readed
            }

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.LodingGeoStyle));
            //read olstyle file
            OlStyleCollection.Load(folderName);

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.AutomaticViewBuilding));
            AutomaticViewBuilder.SetTable(appSet.Schema);//automatic view is added on load and remove on save

            worker.ReportProgress(0, new WaitingFormProperties(Resources.Chargement, Resources.Validation));
            WizardEvents.onConfigLoaded(appSet.Schema, this);
        }

        private void updateStatusBar()
        {
            var vProject = getVersion(Program.CurrentProjectFolder);
            var vWizard = getVersion(Program.CurrentWizardFolder + "\\Sources\\Tabloid\\Tabloid");

            txtStatut.Text = String.Format(Resources.StatusMatrix,
                Program.AppSet.Titre,
                Program.CurrentProjectFolder,
                vProject,
                vWizard);

            btnStatusUpdateEngine.Visible = vProject != vWizard;

            if (vProject == vWizard)
                txtStatut.Text += Resources.NoUpdate;


        }

        private string getVersion(string folderName)
        {
            var d = new FileInfo(folderName + "\\bin\\tabloid.dll");

            if (!d.Exists) return Resources.NotDefine;

            return FileVersionInfo.GetVersionInfo(folderName + "\\bin\\tabloid.dll").FileVersion;
        }

        /// <summary>
        /// Deserialize main tabloid config file
        /// </summary>
        void DeserializeMainTabloidConfig()
        {
            var tabloid = _configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.tabloid].Xml.SelectSingleNode("/Tabloid");
            if (tabloid != null)
            {
                try
                {
                    TabloidConfig.Deserialize("<Tabloid>" + tabloid.InnerXml + "</Tabloid>");

                    tabloid.InnerXml = ""; //remove tabloid content when readed

                    WizardEvents.OnDeserialize();
                }
                catch(Exception e)
                {
                    MetroMessageBox.Show(this, "Erreur au chargement de la configuration :"+e.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        /// <summary>
        ///     Set if project is ready
        /// </summary>
        /// <param name="v"></param>
        void SetProjectReady(bool v)
        {
            toolStripMenuItem8.Enabled = toolStripMenuItem14.Enabled = btnProprietes.Enabled = v;
            analyserLaStructureDeVotreProjetToolStripMenuItem.Enabled = pageDeSynthèseToolStripMenuItem.Enabled = v;
            modulesMenuItem.Enabled = MnMaj.Enabled = sauvegarderToolStripMenuItem.Enabled = MnPublier.Enabled = v;
            propTable.Enabled = v;
            _fieldViewer.Enabled = _filterViewer.Enabled = _joinViewer.Enabled = _editionViewer.Enabled = _indicViewer.Enabled = _importViewer.Enabled = _triggerViewer.Enabled = _exportViewer.Enabled = _graphiqViewer.Enabled = v;
            codeXMLToolStripMenuItem.Enabled = MnSave.Enabled = v;
            genQlikViewToolStripMenuItem.Enabled = MnSaveAs.Enabled = btnEnregistrer.Enabled = générateurDeQuestionnaireToolStripMenuItem.Enabled = v;
            btnExecute.Enabled = btnLog.Enabled = styleCartographieToolStripMenuItem.Enabled = v;
            contextMenuView.Enabled = v;

            txtStartMsg.Visible = !v;
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            _mruManager = new MRUManager(this);
            _mruManager.Initialize(
                this, // owner form
                toolStripMenuItem12, // Recent Files menu item
                _registryPath); // Registry path to keep MRU list
        }
        /// <summary>
        /// update configfile object and save to specified folder
        /// </summary>
        /// <param name="As"></param>
        void Save(bool As)
        {
            _configFiles.updateXML();

            var isFirstSave = _configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.tabloid].ConfigFilePath.StartsWith("source", StringComparison.InvariantCulture);

            As |= isFirstSave;
            //change file path



            if (_configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.tabloid].ConfigFilePath == null || As)//new folder
            {
                var fbd = new FolderBrowserDialog();
                var result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var dirInfo = new DirectoryInfo(fbd.SelectedPath);
                    if (!dirInfo.Exists)
                    {
                        MetroMessageBox.Show(this, Resources.DirectoryNotExist, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _configFiles.ChangeConfigFilesPath(fbd.SelectedPath);
                    Tools.publication(_configFiles, this, true);
                }
                else return;
            }
            _configFiles.SaveConfigFiles(As && !isFirstSave, this);

            _projectModified = false;
        }

        #region Global

        MRUManager _mruManager;

        ConfigFilesCollection _configFiles;
        private List<TabloidConfigView> createdViewWarningState;

        #endregion Global

        #region Menu events

        /// <summary>
        ///     New project from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewFromDatabase(object sender, EventArgs e)
        {
            var fbf = new NewFromBaseForm();

            fbf.ShowDialog();

            if (fbf.DialogResult == DialogResult.OK)
            {
                SetViewListFromConfig();
                SetProjectReady(true);
                _configFiles = new ConfigFilesCollection();
                Tools.EditSetting(_configFiles);
            }
        }



        /// <summary>
        ///     New project from site
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFromSite(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog { Description = Resources.folder_site_selection };
            var result = fbd.ShowDialog();
            if (result != DialogResult.OK) return;
            var folderName = fbd.SelectedPath;

            Program.AppSet = new AppSetting();
            ReadConfig(folderName, Program.AppSet);

            //Tools.setDefaultProvider();
        }

        /// <summary>
        ///     Display properties form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertiesMenu(object sender, EventArgs e)
        {
            EditProperties();
        }

        /// <summary>
        /// Edit current project properties
        /// </summary>
        private void EditProperties()
        {
            var sf = new SettingForm();

            var temp = Program.AppSet.CloneJson<AppSetting>();

            sf.propertyGrid1.SelectedObject = temp;

            sf.ShowDialog();

            if (sf.DialogResult == DialogResult.OK)
            {
                if (Program.AppSet.Schema != temp.Schema)
                {
                    var dlg = MetroMessageBox.Show(this, Resources.ChangeProjectSchema, Resources.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlg == DialogResult.Yes)
                    {
                        WizardSQLHelper.SetAllViewSchema(temp.Schema);
                    }
                }

                Program.AppSet = temp;
            }

            setProjectModified();
        }

        /// <summary>
        ///     To Web.config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsMenu(object sender, EventArgs e)
        {
            Save(true);
        }

        private void SaveMenu(object sender, EventArgs e)
        {
            Save(false);
        }

        #endregion Menu events

        #region Display

        #region Objects Lists display

        /// <summary>
        ///     Set View List from TabloidConfig.Config.Views
        /// </summary>
        void SetViewListFromConfig(bool projectModified = false)
        {
            if (MnDisplayDefaultView.Checked)
                Tools.setGListBoxFromCollection(lstViews, TabloidConfig.Config.Views);
            else
                Tools.setGListBoxFromCollection(lstViews, TabloidConfig.Config.Views, "AutomaticCreation");

            lstViews.Sorted = true;

            for (int i = 0; i < lstViews.Items.Count; i++)
            {
                var v = (GListBoxItem)lstViews.Items[i];

                //if (!MnDisplayDefaultView.Checked&&
                //    ((TabloidConfigView)v.Tag).AutomaticCreation) v.

                if (isDefaultTable((TabloidConfigView)v.Tag))
                    v.Images.Add(4);
                if (((TabloidConfigView)v.Tag).GeoLoc.Type != TabloidConfigGeoLoc.GeoLocType.None)
                    v.Images.Add(3);
                if (!string.IsNullOrEmpty(((TabloidConfigView)v.Tag).Calendrier.Debut))
                    v.Images.Add(1);
                if (((TabloidConfigView)v.Tag).Fichiers)
                    v.Images.Add(2);
            }

            lstViews.Refresh();

            if (projectModified) setProjectModified();
        }

        void SetFunctionListFromConfig(bool projectModified = false)
        {
            Tools.setGListBoxFromCollection(lstFct, TabloidConfig.Config.Functions);

            lstFct.Sorted = true;

            lstFct.Refresh();

            if (projectModified) setProjectModified();

            SetFunctionProperties();
        }

        private bool isDefaultTable(TabloidConfigView tag)
        {
            if (Program.AppSet.pageDefaut == null) return false;
            return Program.AppSet.pageDefaut.IndexOf("table=" + tag.Nom, StringComparison.OrdinalIgnoreCase) > -1;
        }



        void setProjectModified()
        {
            _projectModified = true;
            if (chkSavAuto.Checked) Save(false);
        }

        #endregion List

        #region Properties
        void SetViewProperties()
        {
            CurrentContext.CurrentView = null;

            if (lstViews.SelectedIndex != -1)
            {
                CurrentContext.CurrentView = (TabloidConfigView)((GListBoxItem)lstViews.SelectedItem).Tag;
                lblTable.Text = Resources.MainForm_SetTableProperties_Propriétés_de_ + CurrentContext.CurrentView.Titre;
            }
            else
                lblTable.Text = "";

            propTable.SelectedObject = CurrentContext.CurrentView;
        }
        /// <summary>
        /// Update properties display for selected funtion
        /// </summary>
        void SetFunctionProperties()
        {
            CurrentContext.CurrentFunction = null;

            if (lstFct.SelectedIndex != -1)
            {
                CurrentContext.CurrentFunction = (TabloidConfigFunction)((GListBoxItem)lstFct.SelectedItem).Tag;
                lblTable.Text = Resources.MainForm_SetTableProperties_Propriétés_de_ + CurrentContext.CurrentFunction.Titre;
            }
            else
                lblTable.Text = "";

            propTable.SelectedObject = CurrentContext.CurrentFunction;
        }

        #endregion Properties

        #region List events
        /// <summary>
        /// Call after selected view change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_upDateFromPropertyGrid)
                if (_displayView) SetViewProperties();
                else SetFunctionProperties();

            _upDateFromPropertyGrid = false;

            if (_displayView)
            {
                if (CurrentContext.CurrentView != null)
                    if (CurrentContext.CurrentView.AutomaticCreation && !createdViewWarningState.Contains(CurrentContext.CurrentView))
                    {
                        var dr = MetroMessageBox.Show(this, Resources.Automatic_generated_view, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Cancel) return;
                        createdViewWarningState.Add(CurrentContext.CurrentView);
                    }
            }


            updateViewers();
        }

        void updateViewers()
        {
            _fieldViewer.SetObjectCollection();
            _joinViewer.SetObjectCollection();
            _filterViewer.SetObjectCollection();
            _editionViewer.SetObjectCollection();
            _exportViewer.SetObjectCollection();
            _graphiqViewer.SetObjectCollection();
            _indicViewer.SetObjectCollection();
            _triggerViewer.SetObjectCollection();
            _importViewer.SetObjectCollection();
        }
        #endregion List events
        #endregion Affichage

        private void codeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _configFiles.updateXML();
            var editor = new XMLEditor(_configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.tabloid].Xml.OuterXml);
            editor.ShowDialog();
        }



        #region top menu

        private void NewProject_Click(object sender, EventArgs e)
        {
            _configFiles = new ConfigFilesCollection();//new XmlFile[Enum.GetValues(typeof(XmlFile.ConfigFilesTypes)).Length];

            var fi = new FileInfo("sources\\tabloid.config");
            _configFiles._configFiles[(int)XmlFile.ConfigFilesTypes.tabloid] = new XmlFile(fi.FullName, XmlFile.ConfigFilesTypes.tabloid);
            DeserializeMainTabloidConfig();

            fi = new FileInfo("defaultProperties.xml");

            if (fi.Exists)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
                StreamReader reader = new StreamReader("defaultProperties.xml");
                Program.AppSet = (AppSetting)serializer.Deserialize(reader);
                reader.Close();
            }

            var w = new WizardSchema(_configFiles);

            // set new olstyle project collection
            OlStyleCollection.olStyles = new List<OlStyle>();

            if (w.ShowDialog() != DialogResult.OK) return;

            SetViewListFromConfig();
            SetProjectReady(true);
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Program.AppSet.URL)) return;
            if (!Program.AppSet.URL.StartsWith("http://", StringComparison.InvariantCulture) &&
                !Program.AppSet.URL.StartsWith("https://", StringComparison.InvariantCulture))
                Program.AppSet.URL = "http://" + Program.AppSet.URL;

            var p = new Process();
            p.StartInfo.FileName = Program.AppSet.URL;
            p.Start();

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Program.AppSet.TabloidLogsPath)) return;

            var fi = new FileInfo(Program.AppSet.TabloidLogsPath);
            if (!fi.Exists)
            {
                MetroMessageBox.Show(this, Resources.Log_file_exist, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var p = new Process();
            p.StartInfo.FileName = Program.AppSet.TabloidLogsPath;
            p.Start();
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.makeZipSite(Program.CurrentProjectFolder, this);
        }

        private void publierUnSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.publication(_configFiles, this);
        }

        private void MnEditeurMenu_Click(object sender, EventArgs e)
        {
            var mne = new MenuEditor2(TabloidConfigMenu.ConfigMenu.TopMenu);
            mne.ShowDialog();

            setProjectModified();
        }

        #endregion

        #region tools menu
        private void convertisseur1x2xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();

            if (fd.ShowDialog() != DialogResult.OK) return;

            var webConfigSrc = fd.FileName;

            if (webConfigSrc == null) return;

            var sr = new StreamReader(webConfigSrc);
            var content = sr.ReadToEnd();
            sr.Close();

            content =
                VersionConverter.Renamed.Aggregate(content, (current, o) => current.Replace(o.OldName, o.NewName));

            //rename old File
            var newFileName = Path.GetDirectoryName(webConfigSrc) + "\\" + Path.GetFileNameWithoutExtension(webConfigSrc) + "_avant_conversion.bak";
            var fi = new FileInfo(newFileName);
            if (fi.Exists)
            {
                var result = MetroMessageBox.Show(this, Resources.MainForm_convertisseur1x2xToolStripMenuItem_Click_Un_fichier_portant_le_nom_web_bak_existe_déja__Souhaitez_vous_l_écraser_,
    Resources.Information, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.No) return;
                fi.Delete();
            }
            File.Move(webConfigSrc, newFileName);

            //write converted file
            var sw = new StreamWriter(webConfigSrc);
            sw.Write(content);
            sw.Close();

            MetroMessageBox.Show(this, Resources.MainForm_convertisseur1x2xToolStripMenuItem_Click_Converssion_réussie_,
                Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Qlikview script générator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void génererUnScriptQlikViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "QlikView Script|*.qvs| |*.*",
                Title = Resources.Save_as
            };

            sfd.ShowDialog();

            if (sfd.FileName == "") return;

            var sr = new StreamReader("sources\\QlikView\\startBlock.qvs");
            var script = sr.ReadToEnd();
            sr.Close();

            var result = new StringBuilder(script);

            var globalFieldList = new List<string>();

            foreach (TabloidConfigView v in TabloidConfig.Config.Views)
            {
                var arr = new ArrayVerify();
                if (TabloidTables.IsTabloidTable(v.Nom, ref arr) != -1) continue;

                // create tab
                result.AppendFormat("\r\n///$tab {0}\r\n", v.Titre);
                // Add start comment
                result.AppendFormat("// Start of {0}\r\n", v.Titre);
                //add alias table name
                result.AppendFormat("[{0}]:\r\n", v.Titre);
                // Load statement
                result.Append("Load\r\n");

                var fields = new List<string>();
                var scrSelect = new List<string>();

                fields.Add($"{v.DbKey} as [{v.Nom + "Key"}]");
                scrSelect.Add(v.DbKey);

                foreach (TabloidConfigColonne tc in v.Colonnes)
                {
                    if (//tc.Editeur == Tabloid.Classes.Controls.TemplateType.View ||
                        tc.Editeur == Tabloid.Classes.Controls.TemplateType.Graphique) continue;

                    if (string.IsNullOrEmpty(tc.Jointure) && !tc.ChampGenere)
                    {
                        var name = tc.Titre;

                        if (globalFieldList.Contains(name)) name = name + " " + v.Titre;
                        if (name == "") name = tc.Champ;

                        fields.Add($"{tc.Champ.ToLower()} as [{name}]");
                        globalFieldList.Add(name);

                        scrSelect.Add(tc.Champ.ToLower());
                    }
                    else
                    {
                        var j = v.Jointures[tc.Jointure];
                        if (j == null) continue;
                        if (j.Relation != "N:1" && !string.IsNullOrEmpty(j.Relation)) continue;
                        fields.Add($"{ChampTools.RemoveTableName(j.ChampDeRef.ToLower())} as [{j.NomTable + "Key"}]");
                        scrSelect.Add(j.ChampDeRef.ToLower());
                    }
                }

                result.Append(joinNotNull(",\r\n", fields.ToArray()));
                result.Append(";\r\n");
                // Select statement

                result.Append("SQL Select\r\n");

                result.Append(joinNotNull(",\r\n", scrSelect.ToArray()));
                result.Append("\r\n");
                // Form statement
                result.AppendFormat("From {1}{0}\r\n", v.NomTable, Program.AppSet.ProviderType != Provider.MySql ? v.Schema + "." : "");

                // Where statement
                result.AppendFormat("Where deleted_{0}=0;\r\n", v.NomTable);

                // Add end comment
                result.AppendFormat("// End of {0}\r\n", v.Titre);
            }

            var sw = new StreamWriter(sfd.FileName);
            sw.Write(result);
            sw.Close();
        }

        #endregion

        #region field method


        private void collerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentContext.CurrentField = _fieldViewer.SelectedObject;

            var copiedColumn = (TabloidConfigColonne)_fieldViewer.ClipBoard;
            copiedColumn.Parent = CurrentContext.CurrentField;

            var dest = CurrentContext.CurrentField == null ?
                null : CurrentContext.CurrentField.Colonnes;

            Tools.AddWithUniqueName(CurrentContext.CurrentView.Colonnes, copiedColumn, "C", dest);
            _fieldViewer.ClipBoard = null;
            _fieldViewer.SetObjectCollection();
            setProjectModified();
        }

        private void simpleListConverter_Click(object sender, EventArgs e)
        {
            var w = new WizardSimpleListConverter(CurrentContext.CurrentView, _fieldViewer.SelectedObject);

            if (w.ShowDialog() == DialogResult.OK)
            {
                _fieldViewer.SetObjectCollection(CurrentContext.CurrentView, true);
                SetViewListFromConfig(true);
            }

        }
        /// <summary>
        /// Convert text field to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextFielConverter_Click(object sender, EventArgs e)
        {
            var w = new WizardFieldToListConverter(CurrentContext.CurrentView, _fieldViewer.SelectedObject);

            if (w.ShowDialog() == DialogResult.OK)
            {
                _fieldViewer.SetObjectCollection(CurrentContext.CurrentView, true);
                SetViewListFromConfig(true);
            }
        }

        private void addAutomaticFilter(object sender, EventArgs e)
        {
            var f = new TabloidConfigRecherche
            {
                ChampTabloid = _fieldViewer.SelectedObject,// CurrentContext.CurrentField.Nom,
                VisibleListe = true
            };

            var name = Tools.AddWithUniqueName(CurrentContext.CurrentView.Recherche, f, "R");

            _filterViewer.SetObjectCollection();
            setProjectModified();

            MetroMessageBox.Show(this, Resources.Search_filter + name + Resources.Have_been_added);
        }

        /// <summary>
        /// Add field 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addField(object sender, GenericPropertiesViewer<TabloidConfigColonneCollection, TabloidConfigColonne>.AddEventArgs e)
        {
            AddFieldFromWizard(_displayView ? (IViewFct)CurrentContext.CurrentView : CurrentContext.CurrentFunction, e.Parent);
        }

        /// <summary>
        /// Display Wizard to add field
        /// </summary>
        /// <param name="view"></param>
        /// <param name="parentField"></param>
        /// <returns></returns>
        void AddFieldFromWizard(IViewFct view, TabloidConfigColonne parentField = null)
        {
            var w = new WizardField(view, parentField, Program.AppSet.ConnectionString, Program.AppSet.ProviderType);

            if (w.ShowDialog() == DialogResult.OK)
            {
                _fieldViewer.SetObjectCollection();
                if (w.JoinListUpdated) _joinViewer.SetObjectCollection();
                WizardEvents.afterFieldAdded(CurrentContext.CurrentView);
                CurrentContext.CurrentView.AutomaticCreation = false;
                setProjectModified();
            }
        }

        private void deleteField(object sender, EventArgs e)
        {
            CurrentContext.CurrentField = _fieldViewer.SelectedObject;

            var ch = CurrentContext.CurrentField;
            var currentViewTable = CurrentContext.CurrentView.NomTable;

            if (Program.AppSet.ProviderType == Provider.Postgres)
                currentViewTable = CurrentContext.CurrentView.Schema + "." + currentViewTable;

            if (MetroMessageBox.Show(this,
                    string.Format(Resources.Confirm_supp, ch.Nom, ch.Champ, currentViewTable),
                Resources.Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            var tc = CurrentContext.CurrentView.Colonnes;

            if (ch.Parent != null) tc = ch.Parent.Colonnes;

            tc.Remove(ch);

            if (ch.Editeur != Tabloid.Classes.Controls.TemplateType.Constant)
            {
                if (string.IsNullOrEmpty(ch.Jointure))
                {//field is in current table we can remove in table
                    if (MetroMessageBox.Show(this, Resources.Remove_from_database, Resources.Confirmation, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        SqlCommands.DropColumn(CurrentContext.CurrentView.NomTable, ch.Champ, CurrentContext.CurrentView.Schema, this);

                }
                else
                {//field from joined table
                    if (CurrentContext.CurrentView.Jointures.Contains(ch.Jointure))
                    {
                        var j = CurrentContext.CurrentView.Colonnes.GetColonnes().Where(
                            c => string.Equals(c.Jointure, ch.Jointure, StringComparison.OrdinalIgnoreCase)).ToList();

                        if (j.Count == 0)//join use else where
                            if (MetroMessageBox.Show(this, Resources.Field_in_join_remove_join, Resources.Confirmation, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var joinToRemove = CurrentContext.CurrentView.Jointures.GetJointure(ch.Jointure);
                                if (joinToRemove == null) return;
                                var parent = CurrentContext.CurrentView.Jointures;
                                if (joinToRemove.Parent != null) parent = joinToRemove.Parent.Jointures;

                                parent.Remove(joinToRemove);
                                _joinViewer.SetObjectCollection();

                                if ((joinToRemove.Relation == "N:1" || joinToRemove.Relation == null) &&
                                    MetroMessageBox.Show(this, Resources.Remove_from_database, Resources.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    SqlCommands.DropColumn(currentViewTable, joinToRemove.ChampDeRef, CurrentContext.CurrentView.Schema, this);
                                    //var param = new[] { currentViewTable, joinToRemove.ChampDeRef };
                                    //var result = !WizardHelper.ExecuteFromFile("supField.sql", param, Program.AppSet.ConnectionString);
                                }
                            }
                    }
                }
            }
            _fieldViewer.SetObjectCollection();
            setProjectModified();
        }

        #endregion

        #region filter method
        private void addFilter(object sender, EventArgs e)
        {
            var newFilter = new TabloidConfigRecherche();
            Tools.AddWithUniqueName(CurrentContext.CurrentView.Recherche, newFilter, "R");
            _filterViewer.SetObjectCollection();
            setProjectModified();
        }
        #endregion

        #region join methods


        private void addJoin(object sender, GenericPropertiesViewer<TabloidConfigJointureCollection, TabloidConfigJointure>.AddEventArgs e)
        {
            var w = new WizardJoin(
                CurrentContext.CurrentView,
                e.Parent,
                Program.AppSet.ConnectionString);

            if (w.ShowDialog() == DialogResult.OK)
            {
                _joinViewer.SetObjectCollection();
                setProjectModified();
            }
        }

        #endregion

        #region view/table methods
        private void générerLesJointuresAutomatiquementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lastError = "";

            WizardSQLHelper.SetJoinFromConstraint(CurrentContext.CurrentView, Program.AppSet.ConnectionString, ref lastError);

            _joinViewer.SetObjectCollection();

            setProjectModified();
        }
        private void contextMenuTable_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DialogResult dr = DialogResult.Cancel;
            bool fieldAddAction = true;

            switch (e.ClickedItem.Name)
            {
                case "ajouterUnChampListeSimple":
                    dr = new WizardList(CurrentContext.CurrentView).ShowDialog();
                    break;
                case "ajouterUnChampListeComplexe":
                    dr = new WizardComplexList(CurrentContext.CurrentView).ShowDialog();
                    break;
                case "ajouterTable":
                    var wiz = new WizardTable(Program.AppSet.ConnectionString, Program.AppSet.ProviderType);
                    dr = wiz.ShowDialog();
                    if (dr == DialogResult.OK) CurrentContext.CurrentView = wiz.CreatedView;
                    fieldAddAction = false;
                    break;
                case "ajouterUneTableCalendrierToolStripMenuItem":
                    var w3 = new WizardCalendrier(CurrentContext.CurrentView, Program.AppSet.ConnectionString, Program.AppSet.ProviderType);
                    dr = w3.ShowDialog();
                    break;
            }

            _joinViewer.SetObjectCollection();//join could be added and cancel pressed

            if (dr == DialogResult.OK)
            {
                if (fieldAddAction) WizardEvents.afterFieldAdded(CurrentContext.CurrentView);
                CurrentContext.CurrentView.AutomaticCreation = false;
                SetViewListFromConfig(true);
            }

            setProjectModified();
        }

        void ajouterUneTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var w3 = new WizardTable(Program.AppSet.ConnectionString, Program.AppSet.ProviderType);
            if (w3.ShowDialog() == DialogResult.OK) SetViewListFromConfig(true);
            lstViews.SelectedIndex = lstViews.Items.Count - 1;
        }

        //private void ajouterUneTableCalendrierToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var w3 = new WizardCalendrier(CurrentContext.CurrentView, Program.AppSet.ConnectionString, Program.AppSet.ProviderType);
        //    if (w3.ShowDialog() == DialogResult.OK)
        //    {
        //        CurrentContext.CurrentView.AutomaticCreation = false;
        //        SetViewListFromConfig(true);
        //    }
        //    lstViews.SelectedIndex = lstViews.Items.Count - 1;
        //}
        private void ajouterUnChampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFieldFromWizard(CurrentContext.CurrentView, null);
        }

        private void ajouterAuMenuParamètreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WizardSQLHelper.AddToParamMenu(CurrentContext.CurrentView, this);
            setProjectModified();
        }

        private void ajouterCommeMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WizardSQLHelper.AddToMenu(this, CurrentContext.CurrentView);
            setProjectModified();
        }

        private void supprimerLaTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentTable = CurrentContext.CurrentView.NomTable;

            if (Program.AppSet.ProviderType == Provider.Postgres)
                currentTable = CurrentContext.CurrentView.Schema + "." + currentTable;

            if (MetroMessageBox.Show(this,
                    string.Format(Resources.Confirm_supp_view, CurrentContext.CurrentView.Nom, currentTable),
                Resources.Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            if (MetroMessageBox.Show(this, Resources.Remove_view_database, Resources.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var param = new[] { currentTable };
                var result = !WizardSQLHelper.ExecuteFromFile("supTable.sql", param, Program.AppSet.ConnectionString, this);
            }

            TabloidConfig.Config.Views.Remove(CurrentContext.CurrentView);

            //TabloidConfig.Config.Views.RemoveAt(lstViews.SelectedIndex);

            SetViewListFromConfig(true);
        }

        private void créerUneNouvelleVuePourCetteTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newView = new TabloidConfigView
            {
                Titre = CurrentContext.CurrentView.Titre + "- Nouvelle vue",
                Nom = CurrentContext.CurrentView.NomTable + "2",
                NomTable = CurrentContext.CurrentView.NomTable,
                Schema = CurrentContext.CurrentView.Schema,
                DbKey = CurrentContext.CurrentView.DbKey
            };

            TabloidConfig.Config.Views.Add(newView);
            SetViewListFromConfig(true);
        }

        private void afficherLeContenuDuSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frmGrid = new GridViewForm2(CurrentContext.CurrentView, Program.AppSet.ConnectionString);

            frmGrid.ShowDialog();
        }
        #endregion


        #region helper
        private string joinNotNull(string sep, string[] array)
        {
            return String.Join(sep, array.Where(s => !String.IsNullOrEmpty(s)));
        }
        #endregion

        #region listbox helper
        private void lstViews_MouseDown(object sender, MouseEventArgs e)
        {
            var lst = (ListBox)sender;
            if (e.Button == MouseButtons.Right)
                lst.SelectedIndex = lst.IndexFromPoint(e.X, e.Y);
        }
        #endregion




        private void générateurDeQuestionnaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new QGen();
            frm.ShowDialog();

            SetViewListFromConfig();

            setProjectModified();
        }

        private void TablePropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _upDateFromPropertyGrid = true;
            CurrentContext.CurrentView.AutomaticCreation = false;

            if (((Control)s).Name == "propTable")
            {

                if (e.ChangedItem.PropertyDescriptor.Name == "Phototheque" && (bool)e.ChangedItem.Value)//verify if module is enabled
                    if (!TabloidModule.IsModuleActivated(TabloidModule.ModuleTableType.Phototheque))
                        mnPhotoModule.Checked = TabloidModule.Activate(TabloidModule.ModuleTableType.Phototheque, this);

                WizardEvents.afterViewPropertyChange(s, e, this);

                SetViewListFromConfig(true);
            }

            setProjectModified();

        }

        /// <summary>
        /// Add Graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addGraph(object sender, GenericPropertiesViewer<TabloidConfigGraphCollection, TabloidConfigGraph>.AddEventArgs e)
        {
            var frmG = new GraphForm(CurrentContext.CurrentView, null, e.Parent);

            if (frmG.ShowDialog() == DialogResult.OK)
                _graphiqViewer.SetObjectCollection(CurrentContext.CurrentView, true);
        }
        private void addIndic(object sender, GenericPropertiesViewer<TabloidConfigIndicateurCollection, TabloidConfigIndicateur>.AddEventArgs e)
        {
            var newIndic = new TabloidConfigIndicateur();
            Tools.AddWithUniqueName(CurrentContext.CurrentView.Indicateurs, newIndic, "I");
            _indicViewer.SetObjectCollection();
            setProjectModified();
        }
        //private void addImport(object sender, GenericPropertiesViewer<TabloidConfigImportCollection, TabloidConfigImport>.AddEventArgs e)
        //{
        //    var newImport = new TabloidConfigImport();
        //    Tools.AddWithUniqueName(CurrentContext.CurrentView.Imports, newImport, "IM");
        //    _importViewer.SetObjectCollection();
        //    setProjectModified();
        //}
        private void addTrigger(object sender, GenericPropertiesViewer<TabloidConfigTriggerCollection, TabloidConfigTrigger>.AddEventArgs e)
        {
            var newTrigger = new TabloidConfigTrigger();
            Tools.AddWithUniqueName(CurrentContext.CurrentView.Triggers, newTrigger, "T");
            _triggerViewer.SetObjectCollection();
            setProjectModified();
        }

        private void editGraph(object sender, EventArgs e)
        {
            var g = CurrentContext.CurrentGraph;

            while (g.Parent != null)
            { g = g.Parent; }

            var frmG = new GraphForm(CurrentContext.CurrentView, g);

            if (frmG.ShowDialog() == DialogResult.OK)
                _graphiqViewer.SetObjectCollection(CurrentContext.CurrentView, true);
        }

        private void fieldContextOpening(object sender, CancelEventArgs e)
        {
            var mn = ((GenericPropertiesViewer<TabloidConfigColonneCollection, TabloidConfigColonne>)sender).ContextMenu;
            var isSelection = _fieldViewer.SelectedObject != null;


            if (!mn.Items.ContainsKey("mnFieldFilter"))
            {
                if (mn.Items[mn.Items.Count - 1].GetType() == typeof(ToolStripMenuItem))
                    mn.Items.Add(new ToolStripSeparator { Name = "mnFieldSep" });

                var autoFilter = new ToolStripMenuItem { Text = Resources.AddAutomaticFilter, Name = "mnFieldFilter" };
                mn.Items.Add(autoFilter);

                autoFilter.Click += addAutomaticFilter;
            }

            if (!mn.Items.ContainsKey("mnFieldlistConv"))
            {
                var listConv = new ToolStripMenuItem { Text = Resources.ConvertToComplexList, Name = "mnFieldlistConv" };
                mn.Items.Add(listConv);

                listConv.Click += simpleListConverter_Click;
            }

            if (!mn.Items.ContainsKey("mnFieldConvToList"))
            {
                var listConv = new ToolStripMenuItem { Text = Resources.ConvertToList, Name = "mnFieldConvToList" };
                mn.Items.Add(listConv);

                listConv.Click += TextFielConverter_Click;
            }

            if (!mn.Items.ContainsKey("mnFieldOpenJoin"))
            {
                if (mn.Items[mn.Items.Count - 1].GetType() == typeof(ToolStripMenuItem))
                    mn.Items.Add(new ToolStripSeparator { Name = "mnFieldSep" });

                var openJoin = new ToolStripMenuItem { Text = Resources.DisplayCorrespondingJoin, Name = "mnFieldOpenJoin" };
                mn.Items.Add(openJoin);

                openJoin.Click += openJoin_Click;
            }

            if (!mn.Items.ContainsKey("mnFieldOpenView"))
            {
                var openView = new ToolStripMenuItem { Text = Resources.DisplayCorrespondigView, Name = "mnFieldOpenView" };
                mn.Items.Add(openView);

                openView.Click += openView_Click;
            }


            //display only if selection is not empty
            mn.Items["mnFieldOpenView"].Enabled = mn.Items["mnFieldOpenJoin"].Enabled = mn.Items["mnFieldFilter"].Enabled =
            mn.Items["mnFieldlistConv"].Enabled = mn.Items["mnFieldlistConv"].Enabled = isSelection;

            if (!isSelection) return;

            var ctrl = TabloidControl.TabloidControlList[_fieldViewer.SelectedObject.Editeur];

            //for textbox field display convert menu
            mn.Items["mnFieldConvToList"].Visible = !ctrl.isSingleObjectSelector &&
                                                    !ctrl.isArrayObjectSelector &&
                                                    !ctrl.isButton;// editor == Tabloid.Classes.Controls.TemplateType.ComboBox ||


            //for combox or comboboxplus field display convert menu
            //var editor = _fieldViewer.SelectedObject.Editeur;
            mn.Items["mnFieldlistConv"].Visible = ctrl.isSingleObjectSelector;// editor == Tabloid.Classes.Controls.TemplateType.ComboBox ||
                                                                              //   editor == Tabloid.Classes.Controls.TemplateType.ComboBoxPlus;

            //for field with join display open join
            mn.Items["mnFieldOpenJoin"].Visible = !string.IsNullOrEmpty(_fieldViewer.SelectedObject.Jointure);

            //for view or gridview editor display ope view
            mn.Items["mnFieldOpenView"].Visible = ctrl.isArrayObjectSelector;//editor == Tabloid.Classes.Controls.TemplateType.View ||
                                                                             //editor == Tabloid.Classes.Controls.TemplateType.GridView;
        }
        private void importContextOpening(object sender, CancelEventArgs e)
        {
            //var mn = ((GenericPropertiesViewer<TabloidConfigImportCollection, TabloidConfigImport>)sender).ContextMenu;
            //var isSelection = _importViewer.SelectedObject != null;




            //if (!mn.Items.ContainsKey("mnAddImport"))
            //{
            //    var importTable = new ToolStripMenuItem { Text = Resources.AddImport, Name = "mnAddImport" };
            //    mn.Items.Add(importTable);

            //    importTable.Click += addImportTable_Click;
            //}


            ////display only if selection is not empty
            //mn.Items["mnAddImport"].Enabled = true; //!isSelection;

            ////if (!isSelection) return;

        }

        private void addImportTable_Click(object sender, EventArgs e)
        {
            var wz = new WizardImport(_importViewer.SelectedObject, CurrentContext.CurrentView);

            if (wz.ShowDialog() == DialogResult.OK)
            {
                Tools.AddWithUniqueName(CurrentContext.CurrentView.Imports, wz.ImportResult, "IM");
                _importViewer.SetObjectCollection();
                setProjectModified();
            }
        }

        private void openView_Click(object sender, EventArgs e)
        {
            var joinNode = findJoin(_fieldViewer.SelectedObject.Jointure);
            if (joinNode != null)
            {
                var sjoin = (TabloidConfigJointure)joinNode.Tag;
                selectViewTableName(sjoin.NomTable);
            }
        }

        void selectViewTableName(string tableName)
        {
            foreach (GListBoxItem item in lstViews.Items)
            {
                if (((TabloidConfigView)item.Tag).NomTable == tableName)
                {
                    lstViews.SelectedItem = item;
                    break;
                }
            }
        }

        private void openJoin_Click(object sender, EventArgs e)
        {
            tabFieldDetail.SelectedTab = tabFieldDetail.TabPages[1];
            _joinViewer.list.SelectedNode = findJoin(_fieldViewer.SelectedObject.Jointure);
        }

        /// <summary>
        /// Return treenode representing join for a given name
        /// </summary>
        /// <param name="joinName"></param>
        /// <returns></returns>
        TreeNode findJoin(string joinName)
        {
            var search = _joinViewer.list.Nodes.Find(joinName, true);

            if (search.Length == 0) return null;
            return _joinViewer.list.Nodes.Find(_fieldViewer.SelectedObject.Jointure, true)[0];
        }

        private void joinContextOpening(object sender, CancelEventArgs e)
        {
            var mn = ((GenericPropertiesViewer<TabloidConfigJointureCollection, TabloidConfigJointure>)sender).ContextMenu;
            var isSelection = _joinViewer.SelectedObject != null;

            mn.Items.Remove(mn.Items["mnJoin1"]);
            mn.Items.Remove(mn.Items["mnJoin2"]);
            mn.Items.Remove(mn.Items["mnJoinSep"]);

            if (!isSelection) return;

            var selectJoin = (TabloidConfigJointure)_joinViewer.SelectedObject;

            var destView = TabloidConfig.Config.Views[selectJoin.NomTable];//todo search with nomtable property

            if (!mn.Items.ContainsKey("mnAlias"))
            {
                if (mn.Items[mn.Items.Count - 1].GetType() == typeof(ToolStripMenuItem))
                    mn.Items.Add(new ToolStripSeparator { Name = "mnAliasSep" });

                var mnAlias = new ToolStripMenuItem { Text = Resources.AliasTransform, Name = "mnAlias" };
                mn.Items.Add(mnAlias);

                mnAlias.Click += steAlias;
            }

            if (destView != null)
            {
                // open view menu
                if (!mn.Items.ContainsKey("mnJoinOpenView"))
                {
                    if (mn.Items[mn.Items.Count - 1].GetType() == typeof(ToolStripMenuItem))
                        mn.Items.Add(new ToolStripSeparator { Name = "mnFieldSep" });

                    var openView = new ToolStripMenuItem { Text = "Afficher la vue correspondante", Name = "mnJoinOpenView" };
                    mn.Items.Add(openView);

                    openView.Click += joinOpenView_Click;
                }
                ////////////////////////////////////
                if (mn.Items[mn.Items.Count - 1].GetType() == typeof(ToolStripMenuItem))
                    mn.Items.Add(new ToolStripSeparator { Name = "mnJoinSep" });

                var parentView = CurrentContext.CurrentView;
                if (selectJoin.Parent != null)
                    parentView = TabloidConfig.Config.Views[selectJoin.Parent.NomTable];//todo search with nomtable property

                var mn1 = mn.Items.Add(
                   Text = string.Format(Resources.BuildSameJoin, destView.Nom, parentView),
                   null,
                   joinConvert
                );

                mn1.Name = "mnJoin1";

                // add symetric recursive join generation item in contextmenu
                if (selectJoin.Parent == null) return;
                var root = TabloidConfigJointure.GetRoot(selectJoin.Parent);
                if (selectJoin.Parent.Parent != null)//multi level join
                {
                    var mn2 = mn.Items.Add(
                    Text = string.Format(Resources.BuildSameJoinRecursively, destView.Nom, root.NomTable),
                    null,
                    RecursiveJoinConvert);

                    mn2.Name = "mnJoin2";
                }
            }
        }

        private void steAlias(object sender, EventArgs e)
        {
            var wiz = new WizardAlias(_joinViewer.SelectedObject);
            wiz.ShowDialog();

            _joinViewer.RefreshGrid();

            setProjectModified();
        }

        private void joinOpenView_Click(object sender, EventArgs e)
        {
            selectViewTableName(_joinViewer.SelectedObject.NomTable);
        }

        protected void joinConvert(object sender, EventArgs e)
        {
            WizardJoin.joinConverter(_joinViewer.SelectedObject, false);
        }

        protected void RecursiveJoinConvert(object sender, EventArgs e)
        {
            WizardJoin.joinConverter(_joinViewer.SelectedObject, true);
        }

        private void addEdition(object sender, EventArgs e)
        {
            Tools.AddWithUniqueName(CurrentContext.CurrentView.Editions, new TabloidConfigEdition(), "E");

            var paramMenu = WizardSQLHelper.getParamMenu();
            if (paramMenu != null)
                if (paramMenu.SousMenu.findFirstFromType(TabloidConfigMenuItem.MenuType.Publipostage) == null)
                    WizardSQLHelper.AddToParamMenu(this, new TabloidConfigMenuItem { Type = TabloidConfigMenuItem.MenuType.Publipostage, Titre = "Publipostage" });

            _editionViewer.SetObjectCollection();

            setProjectModified();
        }


        private void définirLesPropriètésParDéfautsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sf = new SettingForm();

            var defaultProperties = new AppSetting();

            var fi = new FileInfo("defaultProperties.xml");
            if (fi.Exists)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
                StreamReader reader = new StreamReader("defaultProperties.xml");
                defaultProperties = (AppSetting)serializer.Deserialize(reader);
                reader.Close();
            }

            sf.propertyGrid1.SelectedObject = defaultProperties;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
                StreamWriter writer = new StreamWriter("defaultProperties.xml", false);
                serializer.Serialize(writer, defaultProperties);
                writer.Close();
            }
        }

        private void attacherUneCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wiz = new WizardLoc(CurrentContext.CurrentView);

            wiz.ShowDialog();

            SetViewListFromConfig(true);
            //SetFieldListFromConfig(true);

        }

        private void créezDesÉlémentsAutomatiquementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wiz = new WizardCreaAuto(CurrentContext.CurrentView);
            wiz.ShowDialog();
        }

        private void contextMenuTable_Opening(object sender, CancelEventArgs e)
        {
            var display = lstViews.SelectedItem != null;

            foreach (int i in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })
                contextMenuView.Items[i].Visible = display;

            if (display)
            {
                var v = (TabloidConfigView)((GListBoxItem)lstViews.SelectedItem).Tag;

                créezDesÉlémentsAutomatiquementToolStripMenuItem.Visible = v.Jointures.Where(j => j.Relation == "1:N" && j.Jointures.asN1()).ToList().Count > 0;
            }
        }


        private void mettreÀJourLeMoteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.publication(_configFiles, this, true);

            updateStatusBar();
        }

        private void connecteurInstallésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dcf = new DataConForm();
            dcf.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void styleCartographieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new olStyleFrm();

            frm.ShowDialog();

            OlStyleCollection.Save(_configFiles.ProjectFolderPath);
        }

        private void addExport(object sender, EventArgs e)
        {
            Tools.AddWithUniqueName(CurrentContext.CurrentView.Exports, new TabloidConfigPredefExport(), "E");

            _exportViewer.SetObjectCollection();
            setProjectModified();
        }

        private void setCurrentContext(object sender, EventArgs e)
        {
            if (!_upDateFromPropertyGrid)
                switch (((Control)sender).Name)
                {
                    case "lstChamps":
                        CurrentContext.CurrentField = _fieldViewer.SelectedObject;
                        break;
                    case "lstJointures":
                        CurrentContext.CurrentJoin = _joinViewer.SelectedObject;
                        break;
                    case "lstFiltres":
                        CurrentContext.CurrentFilter = _filterViewer.SelectedObject;
                        break;
                    case "lstEditions":
                        CurrentContext.CurrentEdition = _editionViewer.SelectedObject;
                        break;
                    case "lstGraphs":
                        CurrentContext.CurrentGraph = _graphiqViewer.SelectedObject;
                        break;
                    case "lstImports":
                        CurrentContext.CurrentImport = _importViewer.SelectedObject;
                        break;
                    case "lstExports":
                        CurrentContext.CurrentExport = _exportViewer.SelectedObject;
                        break;
                    case "lstTriggers":
                        CurrentContext.CurrentTrigger = _triggerViewer.SelectedObject;
                        break;
                    case "lstIndics":
                        CurrentContext.CurrentIndic = _indicViewer.SelectedObject;
                        break;
                }

            _upDateFromPropertyGrid = false;
        }

        private void activerLeModulePhotothèqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
                if (MetroMessageBox.Show(this, Resources.DisableModule, Resources.Information, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;


            // set phototheque module state
            if (TabloidModule.SetModuleState(!((ToolStripMenuItem)sender).Checked, TabloidModule.ModuleTableType.Phototheque, this))
                ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void SetAsStartViewMenuItem_Click(object sender, EventArgs e)
        {
            AppSetting.setDefaultPage(CurrentContext.CurrentView.Nom);
            SetViewListFromConfig(true);
        }

        private void MnDisplayDefaultView_Click(object sender, EventArgs e)
        {
            MnDisplayDefaultView.Checked = !MnDisplayDefaultView.Checked;
            SetViewListFromConfig(false);
        }

        private void analyserLaStructureDeVotreProjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var analyseForm = new AnalyseStr();
            analyseForm.ShowDialog();
            //update bisplay
            SetViewListFromConfig();
        }

        private Control addTab(Control ctrl)
        {
            ctrl.Dock = DockStyle.Fill;
            var name = ((IGenericPropertiesViewer)ctrl).TypesName;

            var tabPage = new TabPage(name) { Name = "Tab_" + name };
            tabPage.Controls.Add(ctrl);

            tabFieldDetail.TabPages.Add(tabPage);

            return ctrl;
        }

        private void cmbDisplayLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayConfigSetting.CurrentDisplayLevel = (DisplayConfigSetting.displayLevelTypes)cmbDisplayLevel.SelectedIndex;

            //save to registry
            RegistryKey key = Registry.CurrentUser.CreateSubKey(_registryPath);

            key.SetValue("DisplayLevel", cmbDisplayLevel.SelectedIndex);
            key.Close();

            propTable.SelectedObject = propTable.SelectedObject;

            if (cmbDisplayLevel.SelectedIndex < 2)
                tabFieldDetail.TabPages[7].HidePage();
            else
                if (!_triggerTabPage.IsVisible()) tabFieldDetail.TabPages.Add(_triggerTabPage);

            _fieldViewer.RefreshGrid();
            _joinViewer.RefreshGrid();
            _filterViewer.RefreshGrid();
            _editionViewer.RefreshGrid();
            _exportViewer.RefreshGrid();
            _graphiqViewer.RefreshGrid();
            _indicViewer.RefreshGrid();
            _triggerViewer.RefreshGrid();
        }

        private void btnStatusUpdateEngine_Click(object sender, EventArgs e)
        {
            Tools.publication(_configFiles, this, true);

            updateStatusBar();
        }

        private void pageDeSynthèseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TabloidConfig.Config.Synthese.Affichage.Count == 0)
            {
                if (MetroMessageBox.Show(this, Resources.AddNewSynthese, Resources.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    var row = new TabloidConfigRow();

                    Tools.AddWithUniqueName(
                        TabloidConfig.Config.Synthese.Affichage, row, "SR");

                    var cell = new TabloidConfigCell();

                    Tools.AddWithUniqueName(
                        row.Cellules, cell, "SC");
                }
                else return;
            }


            var frm = new IndicLayout(TabloidConfig.Config.Synthese);

            frm.ShowDialog();
        }
        /// <summary>
        /// Change from tab view to tab function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabviewfct_SelectedIndexChanged(object sender, EventArgs e)
        {
            _displayView = _joinViewer.Enabled = _filterViewer.Enabled = _graphiqViewer.Enabled =
                _editionViewer.Enabled = _indicViewer.Enabled = _exportViewer.Enabled = _triggerViewer.Enabled =

                _fieldViewer.UseCurrentViewAsDefault = _joinViewer.UseCurrentViewAsDefault = _filterViewer.UseCurrentViewAsDefault = _graphiqViewer.UseCurrentViewAsDefault =
                _editionViewer.UseCurrentViewAsDefault = _indicViewer.UseCurrentViewAsDefault = _exportViewer.UseCurrentViewAsDefault = _triggerViewer.UseCurrentViewAsDefault =
                tabviewfct.SelectedIndex == 0;


            switch (tabviewfct.SelectedIndex)
            {
                case 0://view tab
                    lblTable.BackColor =
                        Color.FromArgb(219, 175, 0);
                    propTable.CommandsBackColor = propTable.BackColor = propTable.HelpBackColor = propTable.LineColor =
                    propTable.SelectedItemWithFocusBackColor =
                        Color.FromArgb(242, 218, 121);

                    SetViewProperties();
                    break;
                case 1://function tab
                    lblTable.BackColor =
                        Color.FromArgb(0, 192, 0);
                    propTable.CommandsBackColor = propTable.BackColor = propTable.HelpBackColor = propTable.LineColor =
                    propTable.SelectedItemWithFocusBackColor =
                        Color.FromArgb(128, 255, 128);

                    SetFunctionProperties();
                    break;
            }

            updateViewers();
        }

        private void ajouterUneFonctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wf = new WizardFunction(Program.AppSet.Schema);
            if (wf.ShowDialog() == DialogResult.OK)
            {
                TabloidConfig.Config.Functions.Add(wf.function);//add function

                if (wf.chkAddMenu.Checked)//add menu
                    WizardSQLHelper.AddToMenu(this, wf.function);

                SetFunctionListFromConfig(true);
            }
        }

        private void supprimerUneFonctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this,
                string.Format(Resources.DeleteFunctionConfirm, CurrentContext.CurrentFunction.Nom),
                 Resources.Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            TabloidConfig.Config.Functions.Remove(CurrentContext.CurrentFunction);

            SetFunctionListFromConfig(true);
        }

        // This class defines the gradient colors for 
        // the MenuStrip and the ToolStrip.
        class CustomProfessionalColors : ProfessionalColorTable
        {
            public override Color ToolStripGradientBegin
            { get { return Color.BlueViolet; } }

            public override Color ToolStripGradientMiddle
            { get { return Color.CadetBlue; } }

            public override Color ToolStripGradientEnd
            { get { return Color.CornflowerBlue; } }

            public override Color MenuStripGradientBegin
            { get { return Color.Salmon; } }

            public override Color MenuStripGradientEnd
            { get { return Color.OrangeRed; } }
        }

        private void toolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.Black;
        }

        private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }

        private void activerPostgisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string err;

            var sql = "Create extension postgis;";

            DataTools.Command(sql, null, Program.AppSet.ConnectionString, out err);

            if (!string.IsNullOrEmpty(err))
                MetroMessageBox.Show(this, string.Format(Resources.ErrorMessage, err), Resources.Erreur, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(PgAdmin.IsPgAdminInstalled().ToString());
            var c = new Connexion(Program.AppSet.ConnectionString);

            PgAdmin.BackupDatabase(c.Host,c.UserID,c.Password, c.Database, @"c:\\", "test.sql",c.Port);
        }
    }



    static class CurrentContext
    {
        private static TabloidConfigView _currentView;

        public static TabloidConfigView CurrentView { get; set; }

        public static TabloidConfigFunction CurrentFunction { get; set; }

        public static TabloidConfigColonne CurrentField { get; set; }
        public static TabloidConfigGraph CurrentGraph { get; set; }
        public static TabloidConfigIndicateur CurrentIndic { get; internal set; }
        public static TabloidConfigImport CurrentImport { get; internal set; }

        public static TabloidConfigTrigger CurrentTrigger { get; internal set; }
        public static TabloidConfigJointure CurrentJoin { get; set; }
        public static TabloidConfigRecherche CurrentFilter { get; internal set; }
        public static List<ToolStripItem> ConvertContextJoinMenuItems { get; internal set; }
        public static TabloidConfigEdition CurrentEdition { get; internal set; }
        public static TabloidConfigPredefExport CurrentExport { get; internal set; }
    }
}