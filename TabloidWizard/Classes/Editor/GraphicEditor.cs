using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Tabloid.Classes.Config;

namespace TabloidWizard.Classes.Editor
{
    public class GraphicEditor: UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            
            var modifiedCollection = ((TabloidConfigGraphCollection)value).Clone();
            var frm = new GraphicFormEditor(CurrentContext.CurrentView,(TabloidConfigGraphCollection)modifiedCollection);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                value = modifiedCollection;

            return base.EditValue(context, provider, value);
        }
    }
}
