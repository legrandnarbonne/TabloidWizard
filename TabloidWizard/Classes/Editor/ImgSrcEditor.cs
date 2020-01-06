using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using static Tabloid.Classes.Objects.OlObjects.OlStyle;

namespace TabloidWizard.Classes.Editor
{
    public class ImgSrcEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var frm = new ImgSrcFormEditor();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                value = (ImageSource)frm._currentfilePath;

            return base.EditValue(context, provider, value);
    }
}
}
