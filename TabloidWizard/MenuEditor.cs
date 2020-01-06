using System;
using System.Drawing;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class MenuEditor : Form
    {
        TabloidMenu _menu;
        public MenuEditor(TabloidMenu menu)
        {
            InitializeComponent();
            _menu = menu;
            TreeViewHelper.LoadTreeFromCollection(MnTree,_menu,"Nom","Titre","SousMenu");
        }



        private void editerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editNode((TabloidConfigMenuItem)MnTree.SelectedNode.Tag);
        }

        private void MnTree_DoubleClick(object sender, EventArgs e)
        {
            if (MnTree.SelectedNode != null) editNode((TabloidConfigMenuItem)MnTree.SelectedNode.Tag);
        }

        private void editNode(TabloidConfigMenuItem menuItem)
        {
            var pe = new PropriesForm(menuItem);

            if (pe.ShowDialog() == DialogResult.OK)
            {
                TreeViewHelper.LoadTreeFromCollection(MnTree, _menu, "Nom", "Titre", "SousMenu");
            }
        }
        /// <summary>
        /// Add child to selected node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ajouter_Click(object sender, EventArgs e)
        {
            var item = (TabloidConfigMenuItem)MnTree.SelectedNode.Tag;

            var newChild = new TabloidConfigMenuItem
            {
                Titre = "Nouveau",
                Parent = item
            };

            var mn=Tools.AddWithUniqueName(_menu, newChild, "M", item.SousMenu);
            TreeViewHelper.LoadTreeFromCollection(MnTree, _menu, "Nom", "Titre", "SousMenu");

            editNode(item.SousMenu[mn]);

        }


        private void MnTree_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewHelper.TreeSelectOnMouseUp(sender, e);
        }

        private void ajouterUnMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = new TabloidConfigMenuItem
            {
                Titre = "Nouveau"
            };

            var mn=Tools.AddWithUniqueName(_menu, item, "M");
            TreeViewHelper.LoadTreeFromCollection(MnTree, _menu, "Nom", "Titre", "SousMenu");

            editNode(item.SousMenu[mn]);
        }
        /// <summary>
        /// delete menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item =(TabloidConfigMenuItem)MnTree.SelectedNode.Tag;
            var parentCollection = getParentCollection(item);

            parentCollection.Remove(item);

            TreeViewHelper.LoadTreeFromCollection(MnTree, _menu, "Nom", "Titre", "SousMenu");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void moveMenu(object sender, EventArgs e)
        {
            var item = (TabloidConfigMenuItem)MnTree.SelectedNode.Tag;
            var parentCollection = getParentCollection(item);

            if (parentCollection.MoveItemInCollection(item, ((ToolStripMenuItem)sender).Name=="monterToolStripMenuItem"?-1:1))
                TreeViewHelper.LoadTreeFromCollection(MnTree, _menu, "Nom", "Titre", "SousMenu");
        }        

        private TabloidMenu getParentCollection(string itemName)
        {
            var item = _menu.findFirstFromName(itemName);
            return getParentCollection(item);
        }

        private TabloidMenu getParentCollection(TabloidConfigMenuItem item)
        {
            return item.Parent == null ? _menu : item.Parent.SousMenu;
        }

        // drag method from https://stackoverflow.com/questions/20915260/c-sharp-winforms-dragdrop-within-the-same-treeviewcontrol
        private void MnTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void MnTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void MnTree_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            var targetPoint = MnTree.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            var targetNode = MnTree.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            var draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (draggedNode.Equals(targetNode) ) return;//|| targetNode == null
            // Remove the node from its current 
            // location and add it to the node at the drop location.

            var item = (TabloidConfigMenuItem)draggedNode.Tag;

            // remove item from original collection
            var parentCollection = getParentCollection(item); 
            parentCollection.Remove(item);

            //remove node from previous location
            draggedNode.Remove();

            TabloidMenu targetItemCollection;
            
            if (targetNode == null)
            {//add node to target node
                MnTree.Nodes.Add(draggedNode);
                targetItemCollection = _menu;
                item.Parent = null;
            }
            else
            {
                targetNode.Nodes.Add(draggedNode);
                targetItemCollection = ((TabloidConfigMenuItem)targetNode.Tag).SousMenu;
                item.Parent = (TabloidConfigMenuItem)targetNode.Tag;
                targetNode.Expand();
            }

            targetItemCollection.Add(item);
        }
    }
}
