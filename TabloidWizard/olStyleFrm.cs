
using MetroFramework.Forms;
using System.Windows.Forms;
using Tabloid.Classes.Objects.OlObjects;
using TabloidWizard.Classes;

namespace TabloidWizard
{
    public partial class olStyleFrm : MetroForm
    {

        public olStyleFrm()
        {
            InitializeComponent();
            refreshListBox();
        }


        private void refreshListBox()
        {
            lstStyle.DataSource = null;
            if (OlStyleCollection.olStyles.Count == 0) return;
                      
            lstStyle.DataSource = OlStyleCollection.olStyles;
            lstStyle.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            propertyGrid1.SelectedObject = lstStyle.SelectedValue;
        }

        private void btnAjoutStyle_Click(object sender, System.EventArgs e)
        {
            var currentName = "Style";
            var prefixe = currentName;
            var c = -1;

            while (OlStyleCollection.olStyles.Find(i => i.Name == currentName) != null)
            {
                c++;
                currentName = $"{prefixe}({c})";
            }

            OlStyleCollection.olStyles.Add(new OlStyle(currentName));

            refreshListBox();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Name == "Name") refreshListBox();
        }

        private void btnSuppStyle_Click(object sender, System.EventArgs e)
        {
            if (lstStyle.SelectedItem!=null)
            {
                OlStyleCollection.olStyles.Remove((OlStyle)lstStyle.SelectedItem);
                refreshListBox();
            }
        }
    }
}
