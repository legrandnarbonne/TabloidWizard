
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tabloid.Classes.Objects;

namespace TabloidWizard.Classes.Editor
{
    public partial class ColorFormEditor : MetroForm
    {
        public ColorFormEditor(EditableColor color)
        {
            InitializeComponent();

            if (color != null) colorEditorManager1.Color = Color.FromArgb(color.A, color.R, color.G, color.B);

            else colorEditorManager1.Color = Color.Cyan;
        }

        private void colorEditorManager1_ColorChanged(object sender, EventArgs e)
        {
            previewPanel.BackColor = colorEditorManager1.Color;
        }
    }
}
