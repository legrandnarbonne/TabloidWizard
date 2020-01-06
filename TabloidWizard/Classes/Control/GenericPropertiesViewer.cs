using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tabloid.Classes.Config;

namespace TabloidWizard.Classes.Control
{
    public partial class GenericPropertiesViewer<CollectionType, ObjectType> : UserControl, IGenericPropertiesViewer
        where CollectionType : BaseConfigurationElementCollection<ObjectType>
        where ObjectType : BrowsableConfigurationElement, IConfigurationElementCollectionElement, new()
    {
        #region properties

        string _typesName;
        string _typeName;
        ImageList _imgList;
        EventHandler _onEditElement;
        DragDropPos _dragdroppos;
        Color _titleColor;
        Color _helpColor;

        /// <summary>
        /// if set to true use currentview as default parent else use currentfunction
        /// </summary>
        public bool UseCurrentViewAsDefault { get; set; }

        public string TypesName
        {
            get
            {
                return _typesName;
            }
            set
            {
                lblList.Text = string.Format("- Liste des {0} -", value);
                _typesName = value;
            }
        }

        public string TypeName
        {
            get
            {
                return _typeName;
            }
            set
            {
                btnAdd.Text = string.Format("Ajouter {0}", value);

                _typeName = value;
            }
        }

        /// <summary>
        /// Displayed collection keep null to use Context.CurrentView as reférence collection
        /// </summary>
        public CollectionType CurrentCollection { get; set; }

        public Color TitleColor
        {
            get { return _titleColor; }
            set
            {
                lblProperties.BackColor = lblList.BackColor = _titleColor = value;
            }
        }

        public Color HelpColor
        {
            get { return _helpColor; }
            set
            {
                properties.BackColor = properties.HelpBackColor = properties.CommandsBackColor =
                properties.LineColor = _helpColor = value;
            }
        }
        /// <summary>
        /// Name of property containing child for multilevel object
        /// </summary>
        public string ChildPropertyName { get; set; }

        /// <summary>
        /// Name of view property to display
        /// </summary>
        public string DisplayPropertyName { get; set; }

        public bool EnableMove { get; set; }

        public bool EnableDelete { get; set; }

        public ImageList imgList
        {
            get
            {
                return _imgList;
            }
            set
            {
                list.ImageList = value;
                _imgList = value;
            }
        }

        public ObjectType SelectedObject { get; internal set; }

        public bool IsClipBoardEmpty { get; set; }

        public object ClipBoard { get; set; }

        public EventHandler OnCopy { get; set; }

        public EventHandler OnPaste { get; set; }

        public TreeViewEventHandler AfterSelectedItemChange { get; set; }

        /// <summary>
        /// Call after object move or property change 
        /// </summary>
        public EventHandler<PropertyValueChangedEventArgs> OnPropertyValueChanged { get; set; }
        public EventHandler<AddEventArgs> OnAddElement { get; set; }


        public EventHandler<System.ComponentModel.CancelEventArgs> OnContextOpening { get; set; }

        public EventHandler OnEditElement
        {
            get
            {
                return _onEditElement;
            }
            set
            {

                _onEditElement = value;
                cmEdit.Visible = value != null;//ContextMenu.Items[2]
            }
        }

        public EventHandler OnDeleteElement { get; set; }

        public EventHandler AfterObjectCollectionSet { get; set; }

        public EventHandler OnCollectionModified { get; set; }
        #endregion

        #region Methods
        public GenericPropertiesViewer()
        {
            UseCurrentViewAsDefault = true;

            InitializeComponent();

            btnToTop.ShortcutKeys = Keys.Control | Keys.PageUp;

            searchBox1.OnTextChange = onSearchTextChange;
        }


        /// <summary>
        /// return configuration element for given view or currentcollection if set
        /// </summary>
        public CollectionType ConfigurationElementCollection(IViewFct view)
        {
            return CurrentCollection ?? (CollectionType)TreeViewHelper.GetPropValue(view, DisplayPropertyName);
        }

        /// <summary>
        /// return configuration element for given view or currentcollection if set
        /// </summary>
        public CollectionType ConfigurationElementCollection(TabloidConfigFunction function)
        {
            return CurrentCollection ?? (CollectionType)TreeViewHelper.GetPropValue(function, DisplayPropertyName);
        }

        /// <summary>
        /// Display collection from view. DisplayPropertyName hold the name of property containing collection to display
        /// </summary>
        /// <param name="obj">view object</param>
        public void SetObjectCollection(IViewFct obj = null, bool modified = false)
        {
            if (obj == null)
                obj = UseCurrentViewAsDefault ? (IViewFct)CurrentContext.CurrentView : CurrentContext.CurrentFunction;

            if (obj != null && ConfigurationElementCollection(obj) != null)
            {
                list.BeginUpdate();

                WizardTools.Tools.setTreeViewFromCollection(list, ConfigurationElementCollection(obj), ChildPropertyName);

                AfterObjectCollectionSet?.Invoke(this, null);

                if (modified) OnCollectionModified?.Invoke(this, null);

                list.EndUpdate();
            }
            else
                list.Nodes.Clear();

            updateDisplay();
        }


        public void SetObjectCollection(CollectionType collection, bool modified = false)
        {
            if (collection != null)
            {
                CurrentCollection = collection;

                list.BeginUpdate();

                WizardTools.Tools.setTreeViewFromCollection(list, collection, ChildPropertyName);

                AfterObjectCollectionSet?.Invoke(this, null);

                if (modified) OnCollectionModified?.Invoke(this, null);

                list.EndUpdate();
            }
            else
                list.Nodes.Clear();

            updateDisplay();
        }

        public void RefreshGrid()
        {
            properties.SelectedObject = properties.SelectedObject;
        }

        public void ClearObjectCollection()
        {
            list.Nodes.Clear();
            updateDisplay();
        }

        void updateDisplay()
        {
            SelectedObject = null;

            if (list.SelectedNode != null)
            {
                SelectedObject = (ObjectType)list.SelectedNode.Tag;

                lblProperties.Text = "Propriétes de " + SelectedObject;
                btnDelete.Text = string.Format("Effacer {0}.", SelectedObject);

            }
            else
            {
                lblProperties.Text = "- Sélectionnez une entrée dans la liste de gauche -";
            }

            properties.SelectedObject = SelectedObject;

            btnDelete.Visible = cmDelete.Visible = OnDeleteElement != null | EnableDelete;

            //if one level hide add child
            ContextMenu.Items["cmAddChild"].Visible = ChildPropertyName != null;//OnChildAdd != null;

            //if no clipboard event hide copy and paste
            ContextMenu.Items["cmCopy"].Visible = OnCopy != null;
            ContextMenu.Items["cmPaste"].Visible = OnCopy != null;
            ContextMenu.Items["cmSepCopy"].Visible = OnCopy != null;

            //disable move
            moveSep.Visible = btnToBotom.Visible = btnToTop.Visible = btnMoveDown.Visible = btnMoveUp.Visible = EnableMove;

            //disable entry where selection is needed
            btnDelete.Enabled =
            ContextMenu.Items["cmAddChild"].Enabled = ContextMenu.Items["cmDelete"].Enabled = ContextMenu.Items["cmEdit"].Enabled = ContextMenu.Items["cmCopy"].Enabled = SelectedObject != null;
        }
        #endregion

        #region Events

        void onSearchTextChange(object sender, EventArgs e)
        {
            //blocks repainting tree till all objects loaded
            list.BeginUpdate();

            searchInNodeCollection(list.Nodes);

            //enables redrawing tree after all objects have been added
            list.EndUpdate();
        }
        /// <summary>
        /// Search string in treenode Text property
        /// </summary>
        /// <param name="collection"></param>
        void searchInNodeCollection(TreeNodeCollection collection)
        {
            foreach (TreeNode n in collection)
            {
                n.BackColor = n.Text.IndexOf(searchBox1.Text, StringComparison.CurrentCultureIgnoreCase) != -1 ?
                    Color.Yellow : Color.White;

                if (n.Nodes.Count > 0)
                    searchInNodeCollection(n.Nodes);
            }
        }

        void lstBox_SelectedIndexChanged(object sender, TreeViewEventArgs e)
        {
            updateDisplay();
            AfterSelectedItemChange?.Invoke(this, e);
        }

        private void btnToTop_Click(object sender, EventArgs e)
        {
            moveObject(1, true, false);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            moveObject(-1, false, false);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            moveObject(1, false, false);
        }

        private void btnToBotom_Click(object sender, EventArgs e)
        {
            moveObject(-1, false, true);
        }

        void listkeyEvent(object sender, KeyEventArgs e)
        {
            if (!EnableMove) return;

            int move = 0;
            bool top = false;
            bool bottom = false;

            switch (e.KeyValue)
            {
                case 107://+
                    move = 1;
                    bottom = e.Control;
                    break;
                case 109://-
                    move = -1;
                    top = e.Control;
                    break;
            }

            moveObject(move, top, bottom);
        }
        /// <summary>
        /// Move element
        /// </summary>
        /// <param name="move">define movement +1 move down -1 move up </param>
        /// <param name="top">if set to true element is moved to the top of collection</param>
        /// <param name="bottom">if set to true element is moved to the botom of collection</param>
        void moveObject(int move, bool top, bool bottom)
        {
            CollectionType parentCollection = getParentCollection(SelectedObject);

            if (parentCollection != null && parentCollection.MoveItemInCollection(SelectedObject, move, top, bottom))
            {
                SetObjectCollection(CurrentContext.CurrentView, true);
                OnPropertyValueChanged?.Invoke(this, null);
            }
        }

        CollectionType getParentCollection(ObjectType obj)
        {
            if (obj == null) return null;

            CollectionType parentCollection = CurrentCollection ?? ConfigurationElementCollection(CurrentContext.CurrentView);

            if (!string.IsNullOrEmpty(ChildPropertyName))//this is a multilevel object
            {
                var parent = TreeViewHelper.GetPropValue(obj, "Parent");

                if (parent != null) parentCollection = (CollectionType)TreeViewHelper.GetPropValue(parent, ChildPropertyName);
            }

            return parentCollection;
        }
        /// <summary>
        /// Return child object collection
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        CollectionType getChild(ObjectType obj)
        {
            if (string.IsNullOrEmpty(ChildPropertyName)) return null;

            return (CollectionType)TreeViewHelper.GetPropValue(obj, ChildPropertyName);
        }

        /// <summary>
        /// Context menu opening event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmPaste.Enabled = ClipBoard != null;
            OnContextOpening?.Invoke(this, e);
        }

        /// <summary>
        /// Add element to root
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddElement?.Invoke(this, new AddEventArgs { Parent = null });
        }

        /// <summary>
        /// Delete node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode == null) return;

            deleteSelectedObject();
        }

        void deleteSelectedObject()
        {

            if (OnDeleteElement != null)
            {
                OnDeleteElement?.Invoke(this, null);
                updateDisplay();
                return;
            }

            var result = MessageBox.Show(
                string.Format("Confirmez vous la suppression de : {0}?", SelectedObject),
                "Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (result != DialogResult.OK) return;

            if (EnableDelete)
            {
                getParentCollection(SelectedObject).Remove(SelectedObject);

                SetObjectCollection();

                OnCollectionModified?.Invoke(this, null);
            }

            updateDisplay();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnEditElement?.Invoke(this, e);
        }

        private void properties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            OnPropertyValueChanged?.Invoke(this, e);
            SetObjectCollection();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            OnPaste?.Invoke(this, e);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            OnCopy?.Invoke(this, e);
        }

        private void btnAddChild_Click_1(object sender, EventArgs e)
        {
            OnAddElement?.Invoke(this, new AddEventArgs { Parent = SelectedObject });
        }
        #endregion

        /// <summary>
        /// Event Arg holding move information
        /// </summary>
        public class AddEventArgs : EventArgs
        {
            public ObjectType Parent { get; set; }
        }

        private void setParent(ObjectType obj, ObjectType parent)
        {
            obj.GetType().GetProperty("Parent").SetValue(obj, parent, null);
        }

        private void list_DragDrop(object sender, DragEventArgs e)
        {
            if (!EnableMove) return;

            // Retrieve the client coordinates of the drop location.
            var targetPoint = list.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            var targetNode = list.GetNodeAt(targetPoint);
            if (string.IsNullOrEmpty(ChildPropertyName))//not multi level
                targetNode = null;

            // Retrieve the node that was dragged.
            var draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (draggedNode.Equals(targetNode)) return;//|| targetNode == null
                                                       // Remove the node from its current 
                                                       // location and add it to the node at the drop location.

            var item = (ObjectType)draggedNode.Tag;

            // remove item from original collection
            var parentCollection = getParentCollection(item);
            parentCollection.Remove(item);

            //remove node from previous location
            draggedNode.Remove();

            //future Parent
            ObjectType targetObject;
            CollectionType targetObjectCollection;
            var insertPos = -1;

            if (_dragdroppos.SelectedNode != null)
            {//drop before or after
                var node = _dragdroppos.SelectedNode;
                var parent = node.Parent;
                var addToRoot = parent == null || string.IsNullOrEmpty(ChildPropertyName);

                var parentCollectionNode = addToRoot ? list.Nodes : parent.Nodes;

                targetObject = addToRoot ? null : (ObjectType)parent.Tag;
                targetObjectCollection = addToRoot ?
                    ConfigurationElementCollection(CurrentContext.CurrentView) : getChild((ObjectType)parent.Tag);

                insertPos = _dragdroppos.Up ? node.Index : node.Index + 1;
                parentCollectionNode.Insert(node.Index, draggedNode);
            }
            else
            {//drop on node
                if (targetNode == null)
                {//add to root
                    list.Nodes.Add(draggedNode);
                    targetObject = null;
                    targetObjectCollection = ConfigurationElementCollection(CurrentContext.CurrentView);
                }
                else
                {//add to a child
                    targetNode.Nodes.Add(draggedNode);

                    targetObject = (ObjectType)targetNode.Tag;
                    targetObjectCollection = getChild(targetObject);

                    targetNode.Expand();
                }
            }

            setParent(item, targetObject);
            if (insertPos == -1)
                //targetObjectCollection.Add(item);
                targetObjectCollection.Insert(targetObjectCollection.Count, item);
            else
                targetObjectCollection.Insert(insertPos, item);


            OnPropertyValueChanged?.Invoke(this, null);
        }

        private void list_DragEnter(object sender, DragEventArgs e)
        {
            if (EnableMove) e.Effect = DragDropEffects.Move;
            _dragdroppos = new DragDropPos();
        }

        private void list_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (EnableMove)
                list.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void list_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            var targetPoint = list.PointToClient(new Point(e.X, e.Y));
            var nodeMoving = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            // Select the node at the mouse position.
            var nodeOver = list.GetNodeAt(targetPoint);//list.SelectedNode =

            list.Scroll();

            if (nodeOver != null && (nodeOver != nodeMoving || (nodeOver.Parent != null && nodeOver.Index == (nodeOver.Parent.Nodes.Count - 1))))
            {
                int offsetY = list.PointToClient(Cursor.Position).Y - nodeOver.Bounds.Top;
                var top = offsetY < (nodeOver.Bounds.Height / 2);
                var bottom = offsetY < (nodeOver.Bounds.Height / 3);

                if (top)
                {
                    if (!_dragdroppos.Up || _dragdroppos.SelectedNode != nodeOver)
                        setDragLine(true, nodeOver);
                }
                else if (bottom)
                {
                    if (_dragdroppos.Up || _dragdroppos.SelectedNode != nodeOver)
                        setDragLine(false, nodeOver);
                }
                else
                {
                    if (_dragdroppos.SelectedNode != null)
                        setDragLine(true, null);
                }
            }
        }

        private void setDragLine(bool top, TreeNode nodeOver)
        {
            list.Refresh();
            _dragdroppos.Up = top;
            _dragdroppos.SelectedNode = nodeOver;
            if (nodeOver != null) DrawLine(nodeOver, top);
        }

        private void DrawLine(TreeNode NodeOver, bool top)
        {
            Graphics g = list.CreateGraphics();

            var LeftPos = NodeOver.Bounds.Left;
            if (NodeOver.ImageIndex > -1) LeftPos -= list.ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;

            var RightPos = list.Width - 4;

            var bound = top ? NodeOver.Bounds.Top : NodeOver.Bounds.Bottom;

            g.DrawLine(new Pen(Color.Black, 2), new Point(LeftPos, bound), new Point(RightPos, bound));
        }

        private void list_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHelper.TreeSelectOnMouseUp(sender, e);
        }

        class DragDropPos
        {
            public bool Up { get; set; }
            public TreeNode SelectedNode { get; set; }
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            OnEditElement?.Invoke(this, e);
        }
    }
    /// <summary>
    /// thanks to https://stackoverflow.com/questions/6034942/treeview-autoscroll-while-dragging
    /// </summary>
    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public static void Scroll(this System.Windows.Forms.Control control)
        {
            var pt = control.PointToClient(Cursor.Position);

            if ((pt.Y + 20) > control.Height)
            {
                // scroll down
                SendMessage(control.Handle, 277, (IntPtr)1, (IntPtr)0);
            }
            else if (pt.Y < 20)
            {
                // scroll up
                SendMessage(control.Handle, 277, (IntPtr)0, (IntPtr)0);
            }
        }
    }
}
