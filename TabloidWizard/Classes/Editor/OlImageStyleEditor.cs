using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Tabloid.Classes.Objects;
using Tabloid.Classes.Objects.OlObjects;

namespace TabloidWizard.Classes.Editor
{
    public class OlImageStyleEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var frm = new OlImageStyleFormEditor((OlStyle.OlImage)value);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                value = frm.CurrentOlImage;

            return base.EditValue(context, provider, value);
    }
}
}
