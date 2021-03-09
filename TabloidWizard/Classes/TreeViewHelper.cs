using MetroFramework;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace TabloidWizard.Classes
{
    static class TreeViewHelper
    {
        public static void TreeSelectOnMouseUp(object sender, MouseEventArgs e)
        {
            // Point where the mouse is clicked.
            var p = new Point(e.X, e.Y);

            var tree = (TreeView)sender;

            // Get the node that the user has clicked.
            var node = tree.GetNodeAt(p);
            //if (node != null)
            //{
                // Select the node the user has clicked.
                // The node appears selected until the menu is displayed on the screen.
                tree.SelectedNode = node;
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="col"></param>
        /// <param name="key"></param>
        /// <param name="title"></param>
        /// <param name="subCollection">Name of property containing sub collection must be null for 1 level collection</param>
        public static void LoadTreeFromCollection(TreeView tv, ConfigurationElementCollection col, string key, string title, string subCollection, IWin32Window own)
        {
            try
            {
                tv.Nodes.Clear();
                AddNodes(tv, col, key, title, subCollection);

                tv.ExpandAll();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(own,ex.Message);
            }
        }
        /// <summary>
        /// Add tree node to treeview
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="col"></param>
        /// <param name="key"></param>
        /// <param name="title"></param>
        /// <param name="subCollection">Name of property containing sub collection must be null for 1 level collection</param>
        /// <param name="parent"></param>
        private static void AddNodes(TreeView tv, ConfigurationElementCollection col, string key, string title, string subCollection, TreeNode parent = null)
        {
            foreach (ConfigurationElement item in col)
            {
                TreeNode n;
                if (parent == null)
                    n = tv.Nodes.Add((string)GetPropValue(item, key), (string)GetPropValue(item, title));
                else
                    n = parent.Nodes.Add((string)GetPropValue(item, key), (string)GetPropValue(item, title));

                n.Tag = item;

                if (subCollection != null)
                {
                    ConfigurationElementCollection sub = (ConfigurationElementCollection)GetPropValue(item, subCollection);

                    if (sub.Count > 0)
                    {
                        AddNodes(tv, sub, key, title, subCollection, n);
                    }
                }
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            if (string.IsNullOrEmpty(propName)) return src.ToString();
            if (src.GetType().GetProperty(propName) == null) return null;
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
