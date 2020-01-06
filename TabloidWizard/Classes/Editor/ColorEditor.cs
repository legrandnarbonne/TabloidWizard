using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Tabloid.Classes.Objects;

namespace TabloidWizard.Classes.Editor
{
    public class ColorEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var frm = new ColorFormEditor((EditableColor)value);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                value = new EditableColor (frm.colorEditorManager1.Color);

            return base.EditValue(context, provider, value);
    }
}
}
