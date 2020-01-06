using System;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes;
using TabloidWizard.Classes.Control;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;

namespace TabloidWizard
{
    public partial class MenuEditor2 : Form
    {
        GenericPropertiesViewer<TabloidMenu, TabloidConfigMenuItem> _viewer;
        TabloidMenu _menu;

        public MenuEditor2(TabloidMenu mn)
        {
            InitializeComponent();

            _menu = mn;

            _viewer = new GenericPropertiesViewer<TabloidMenu, TabloidConfigMenuItem>()
            {
                Dock = DockStyle.Fill,
                HelpColor = System.Drawing.Color.FromArgb(255, 56, 214, 8),
                TitleColor = System.Drawing.Color.FromArgb(255, 39, 153, 4),

                TypesName = "Menu",
                TypeName = "Menu",

                EnableMove = true,
                EnableDelete = true,

                OnAddElement = addMenu,

                ChildPropertyName = "SousMenu",
                DisplayPropertyName = "Titre",
            };

            Controls.Add(_viewer);

            _viewer.SetObjectCollection(mn);
        }

        private void addMenu(object sender, GenericPropertiesViewer<TabloidMenu, TabloidConfigMenuItem>.AddEventArgs e)
        {
            var item = _viewer.SelectedObject;

            var newChild = new TabloidConfigMenuItem
            {
                Titre = "Nouveau",
                Parent = item
            };

            Tools.AddWithUniqueName(_menu, newChild, "M",item==null?null: item.SousMenu);

            _viewer.SetObjectCollection(_menu);
        }
    }
}
