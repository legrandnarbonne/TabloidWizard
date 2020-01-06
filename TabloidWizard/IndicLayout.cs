using System;
using System.Drawing;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using TabloidWizard.Classes.Tools;
using TabloidWizard.Classes.WizardTools;
using static Tabloid.Classes.Config.TabloidConfigIndicateur;

namespace TabloidWizard
{
    public partial class IndicLayout : Form
    {
        TableLayoutPanel currentTable;
        PictureBox currentImage;
        TabloidConfigSynthese currentSynthese;

        Image plus;
        Image unknow;
        Image unknow_s;
        Image classic;
        Image topList;
        Image graphic;

        public IndicLayout(TabloidConfigSynthese s)
        {
            currentSynthese = s;

            InitializeComponent();

            setImage();

            if (currentSynthese != null)
                renderSynthese();

            setActive(panel);
        }

        private void renderSynthese()
        {

            foreach (TabloidConfigRow r in currentSynthese.Affichage)
                renderLine(r);

            calcSize(panel);
        }

        void renderLine(TabloidConfigRow r)
        {
            var row = addRow(panel,r);
            foreach (TabloidConfigCell c in r.Cellules)
                addColumn(row, c);

        }

        private void setImage()
        {
            plus = Image.FromFile("Images/add.png");
            unknow = Image.FromFile("Images/unknow.png");
            unknow_s = Image.FromFile("Images/unknow_s.png");
            classic = Image.FromFile("Images/classic.png");
            graphic = Image.FromFile("Images/graph.png");
            topList = Image.FromFile("Images/topList.png");
        }



        private void ImgCtrl_Click(object sender, EventArgs e)
        {
            setActiveImg(((PictureBox)sender));
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            setActive((TableLayoutPanel)sender);
        }

        private void setActive(TableLayoutPanel tableLayout)
        {
            if (currentTable != null) currentTable.BackColor = Color.White;
            currentTable = tableLayout;
            currentTable.BackColor = Color.Aqua;
        }

        private void setActiveImg(PictureBox sender)
        {
            if (currentImage != null) currentImage.BackColor = Color.White;
            currentImage = sender;
            currentImage.BackColor = Color.Yellow;
            var indic= getIndicFromTag(currentImage.Tag);
            if (indic == null)
            {
                if (MessageBox.Show("Cette cellule ne fait pas référence à un indicateur. Souhaitez-vous en ajouter un?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                {
                    if (MessageBox.Show("Souhaitez-vous ajouter l'indicateur au niveau de la synthèse (Les indicateurs peuvent être également ajouter au niveau d'une vue)", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                    {
                        indic = new TabloidConfigIndicateur();
                        Tools.AddWithUniqueName(currentSynthese.Indicateurs, indic, "I");
                    }
                }
            }
                
            propertyGrid1.SelectedObject = indic;

        }

        private TabloidConfigIndicateur getIndicFromTag(object tag)
        {
            var c = (TabloidConfigCell)tag;
            return currentSynthese.Indicateurs[c.Indicateur];
        }

        /// <summary>
        /// Add row to tableLayoutPanel
        /// </summary>
        /// <param name="parent">TableLayoutPanel parent</param>
        /// <returns>newly created TableLayoutPanel representing new row</returns>
        private TableLayoutPanel addRow(TableLayoutPanel parent, TabloidConfigRow tcr)
        {
            //var img = unknow;

            var tab = new TableLayoutPanel
            {
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = 1,
                RowCount = 1,
                Dock = DockStyle.Fill,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            tab.Click += Tab_Click;
            tab.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));


            //add add column
            tab.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
            //PictureBox imgCtrl = picAddColumn.Clone();

            var imgCtrl = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackgroundImage = plus,
                BackgroundImageLayout = ImageLayout.Center
            };


            imgCtrl.MouseDown += picAddColumn_Click;
            tab.Controls.Add(imgCtrl, 0, 0);

            //tab.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            //tab.Controls.Add(getIndicImageCtrl(), 1, 0);


            //add line button
            //tab.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            //PictureBox imgCtrl = picAddLine.Clone();
            //imgCtrl.Name = "e";
            //imgCtrl.MouseDown += picPanelAddLine_Click;
            //tab.Controls.Add(imgCtrl,1, 0);



            //add new tab
            parent.SuspendLayout();
            parent.RowCount++;
            var pos = parent.RowCount - 1;
            parent.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            parent.Controls.Add(tab, 0, pos);

            calcSize(parent);

            setActive(tab);
            parent.ResumeLayout();

            tab.Tag = tcr;


            return tab;
        }


        private void addColumn(TableLayoutPanel parent, TabloidConfigCell c)
        {
            parent.SuspendLayout();

            //add column
            parent.ColumnCount++;
            var pos = parent.ColumnCount - 1;
            parent.ColumnStyles.Insert(pos, new ColumnStyle(SizeType.Percent, 100f));

            parent.Controls.Add(getIndicImageCtrl(c), pos, 0);

            parent.ResumeLayout();
        }

        private PictureBox getIndicImageCtrl(TabloidConfigCell c)
        {
            var i = currentSynthese.Indicateurs[c.Indicateur];
            var img = unknow;

            if (i != null)
                switch (i.Type)
                {
                    case WidgetType.TopList:
                        img = topList;
                        break;
                    case WidgetType.Classic:
                        img = classic;
                        break;
                    case WidgetType.Graphic:
                        img = graphic;
                        break;
                }

            var imgCtrl = new PictureBox { BackgroundImage = img, Dock = DockStyle.Fill, BackgroundImageLayout = ImageLayout.Center };
            imgCtrl.Tag = c;
            imgCtrl.Click += ImgCtrl_Click;

            return imgCtrl;
        }

        public void calcSize(TableLayoutPanel ctrl)
        {
            var rowHeight = (ctrl.Height - 50) / ctrl.RowStyles.Count - 1;

            ctrl.RowStyles[0].Height = 40;
            ctrl.RowStyles[0].SizeType = SizeType.Absolute;

            for (int i = 1; i <= ctrl.RowStyles.Count - 1; i++)
            {
                ctrl.RowStyles[i].Height = rowHeight;
                ctrl.RowStyles[i].SizeType = SizeType.Absolute;
            }
        }



        private void picPanelAddLine_Click(object sender, EventArgs e)
        {
            var r = new TabloidConfigRow();
            Tools.AddWithUniqueName(
                TabloidConfig.Config.Synthese.Affichage,r , "SR");
            addRow(panel,r);
        }
        private void btnAddLine_Click(object sender, EventArgs e)
        {
            var r = new TabloidConfigRow();
            Tools.AddWithUniqueName(
                 TabloidConfig.Config.Synthese.Affichage, r, "SR");
            addRow(currentTable,r);
        }

        private void picAddColumn_Click(object sender, EventArgs e)
        {
            var parent = (TableLayoutPanel)((PictureBox)sender).Parent;
            setActive(parent);


            addColumn(currentTable, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addColumn(currentTable, null);
        }

        private void Tab_Click(object sender, MouseEventArgs e)
        {

        }


        private PictureBox getPictureBox()
        {
            var targetPoint = panel.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            var targetRow = panel.GetChildAtPoint(targetPoint);

            var rowTargetPoint = targetRow.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            var ctrl = targetRow.GetChildAtPoint(rowTargetPoint);

            if (ctrl is PictureBox)
                return (PictureBox)ctrl;

            return null;
        }

        private void removeIndic_Click(object sender, EventArgs e)
        {
            var pic = getPictureBox();
            if (pic == null) return;

            var cell = (TabloidConfigCell)pic.Tag;

            cell.Indicateur = null;

            pic.BackgroundImage = unknow;
            pic.Tag = null;
        }
    }


}
