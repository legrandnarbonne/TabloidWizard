using System.Windows.Forms;

namespace ExtensionMethods
{
    /// <summary>
    /// Add show/hide method to Tabpage
    /// Thanks to https://stackoverflow.com/questions/552579/how-to-hide-tabpage-from-tabcontrol
    /// </summary>
    public static class TabControlExtension
    {

        public static bool IsVisible(this TabPage tabPage)
        {
            if (tabPage.Parent == null)
                return false;
            else if (tabPage.Parent.Contains(tabPage))
                return true;
            else
                return false;
        }

        public static void HidePage(this TabPage tabPage)
        {
            TabControl parent = (TabControl)tabPage.Parent;
            parent.TabPages.Remove(tabPage);
        }

        public static void ShowPageInTabControl(this TabPage tabPage, TabControl parent)
        {
            parent.TabPages.Add(tabPage);
        }
    }
}