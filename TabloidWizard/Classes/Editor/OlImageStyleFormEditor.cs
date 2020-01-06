using System.Drawing;
using System.Windows.Forms;
using Tabloid.Classes.Objects.OlObjects;
using static Tabloid.Classes.Objects.OlObjects.OlStyle;

namespace TabloidWizard.Classes.Editor
{
    public partial class OlImageStyleFormEditor : Form
    {
        public OlImage CurrentOlImage;

        private OlIcon CurrentOlIcon;

        private OlPolygon CurrentOlPolygon;

        private OlCircle CurrentOlCircle;

        public OlImageStyleFormEditor(OlStyle.OlImage img)
        {            
            InitializeComponent();
            setLoadedObject(img);
        }

        private void setLoadedObject(OlStyle.OlImage img)
        {
            switch (img.GetType().Name)
            {
                case "OlIcon":
                    CurrentOlImage = CurrentOlIcon = (OlIcon)img;
                    cmbType.SelectedIndex = 0;
                    break;
                case "OlCircle":
                    CurrentOlImage = CurrentOlCircle = (OlCircle)img;
                    cmbType.SelectedIndex = 1;
                    break;
                case "OlPolygon":
                    CurrentOlImage = CurrentOlPolygon = (OlPolygon)img;
                    cmbType.SelectedIndex = 2;
                    break;


            }
        }

        private void cmbType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    if (CurrentOlIcon == null) CurrentOlIcon = new OlIcon();
                    CurrentOlImage = CurrentOlIcon;
                    break;
                case 1:
                    if (CurrentOlCircle == null) CurrentOlCircle = new OlCircle();
                    CurrentOlImage = CurrentOlCircle;
                    break;
                case 2:
                    if (CurrentOlPolygon == null) CurrentOlPolygon = new OlPolygon();
                    CurrentOlImage = CurrentOlPolygon;
                    break;
            }

            propertyGrid1.SelectedObject = CurrentOlImage;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Name == "src")//image changed set new size
            {
                Image img = System.Drawing.Image.FromFile(Program.CurrentProjectFolder+e.ChangedItem.Value);
                CurrentOlIcon.size=new Point(img.Width , img.Height);
            }
        }
    }
}
