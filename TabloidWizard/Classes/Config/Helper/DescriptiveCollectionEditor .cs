using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Tabloid.Classes.Config
{
    /// <summary>
    /// enable descriptive panel when editing collections 
    /// </summary>
    public class DescriptiveCollectionEditor : CollectionEditor
    {
        public DescriptiveCollectionEditor(Type type) : base(type) { }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm form = base.CreateCollectionForm();
            form.Shown += delegate
            {
                ShowDescription(form);
            };
            return form;
        }
        static void ShowDescription(Control control)
        {
            var grid = control as PropertyGrid;
            if (grid != null) grid.HelpVisible = true;
            foreach (Control child in control.Controls)
            {
                ShowDescription(child);
            }
        }
    }
}