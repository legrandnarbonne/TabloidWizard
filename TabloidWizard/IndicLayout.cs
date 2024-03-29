﻿using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tabloid.Classes.Config;
using Tabloid.Classes.Optimisation.Cache;
using TabloidWizard.Classes.WizardTools;
using static Tabloid.Classes.Config.TabloidConfigIndicateur;

namespace TabloidWizard
{
    public partial class IndicLayout : MetroForm
    {
        TableLayoutPanel currentTable;
        PictureBox currentImage;
        TabloidConfigSynthese currentSynthese;
        //Dictionary<string, TabloidConfigIndicateur> indicDic;

        Image plus;
        Image unknow;
        Image unknow_s;
        Image classic;
        Image topList;
        Image graphic;

        bool _layoutSelectionChange;

        public IndicLayout(TabloidConfigSynthese s)
        {
            currentSynthese = s;

            InitializeComponent();

            setImage();

            cmbIndic.DataSource = IndicCache.GetIndicList().Values.ToArray();

            if (currentSynthese != null)
                renderSynthese();

            setActive(panel);

            if (panel.Controls.Count > 1)
            {
                var ctrl = panel.Controls[1];
                if (ctrl.Controls.Count > 1)
                    setActiveImg((PictureBox)ctrl.Controls[1]);
            }
        }

        //private void setIndicDictionary()
        //{
        //    indicDic = new Dictionary<string, TabloidConfigIndicateur>();
        //    foreach (TabloidConfigIndicateur i in currentSynthese.Indicateurs)
        //        indicDic[i.Nom] = i;

        //    foreach (TabloidConfigView v in TabloidConfig.Config.Views)
        //        foreach (TabloidConfigIndicateur i in v.Indicateurs)
        //            indicDic[i.Nom] = i;
        //}

        private void renderSynthese()
        {
            foreach (TabloidConfigRow r in currentSynthese.Affichage)
                renderLine(r);

            calcSize(panel);
        }

        void renderLine(TabloidConfigRow r)
        {
            var row = addRow(panel, r);
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
            var old = currentImage;
            currentImage = sender;

            if (old != null) old.Refresh();

            currentImage.Refresh();

            var indic = getIndicFromTag(currentImage.Tag);

            _layoutSelectionChange = true;
            cmbIndic.SelectedItem = indic;

        }

        private void setBorder(object sender, PaintEventArgs e)
        {
            var pb = ((PictureBox)sender);

            if (pb == currentImage)
                ControlPaint.DrawBorder(e.Graphics, pb.ClientRectangle,
                    Color.Blue, 3, ButtonBorderStyle.Solid,
                    Color.Blue, 3, ButtonBorderStyle.Solid,
                    Color.Blue, 3, ButtonBorderStyle.Solid,
                    Color.Blue, 3, ButtonBorderStyle.Solid);
        }

        private TabloidConfigIndicateur getIndicFromTag(object tag)
        {
            var c = (TabloidConfigCell)tag;

            if (c == null || string.IsNullOrEmpty(c.Indicateur)) return null;

            return IndicCache.GetIndicCache(c.Indicateur);//indicDic[c.Indicateur];
        }

        /// <summary>
        /// Add row to tableLayoutPanel
        /// </summary>
        /// <param name="parent">TableLayoutPanel parent</param>
        /// <returns>newly created TableLayoutPanel representing new row</returns>
        private TableLayoutPanel addRow(TableLayoutPanel parent, TabloidConfigRow tcr)
        {
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

            var imgCtrl = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackgroundImage = plus,
                BackgroundImageLayout = ImageLayout.Center
            };


            imgCtrl.MouseDown += picAddColumn_Click;
            tab.Controls.Add(imgCtrl, 0, 0);

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

        /// <summary>
        /// Add a column to a display row
        /// </summary>
        /// <param name="parent">display row</param>
        /// <param name="c"></param>
        private void addColumn(TableLayoutPanel parent, TabloidConfigCell c)
        {
            parent.SuspendLayout();

            //add column
            parent.ColumnCount++;
            var pos = parent.ColumnCount - 1;
            parent.ColumnStyles.Insert(pos, new ColumnStyle(SizeType.Percent, 100f));

            var pb = getIndicImageCtrl(c);

            parent.Controls.Add(pb, pos, 0);

            if (c == null) pb.Tag = new TabloidConfigCell();

            parent.ResumeLayout();
        }

        private PictureBox getIndicImageCtrl(TabloidConfigCell c)
        {
            var img = unknow;

            if (c != null)
            {
                var i = IndicCache.GetIndicCache(c.Indicateur);
                img = getImage(i);
            }

            var imgCtrl = new PictureBox { BackgroundImage = img, Dock = DockStyle.Fill, BackgroundImageLayout = ImageLayout.Center };
            imgCtrl.Tag = c;
            imgCtrl.Click += ImgCtrl_Click;
            imgCtrl.Paint += setBorder;

            return imgCtrl;
        }

        private Image getImage(TabloidConfigIndicateur i)
        {
            if (i != null)
                switch (i.Type)
                {
                    case WidgetType.TopList:
                        return topList;
                        break;
                    case WidgetType.Classic:
                        return classic;
                        break;
                    case WidgetType.InLine:
                        return classic;
                        break;
                    case WidgetType.Graphic:
                        return graphic;
                        break;
                }

            return unknow;
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
                TabloidConfig.Config.Synthese.Affichage, r, "SR");
            addRow(panel, r);
        }
        private void btnAddLine_Click(object sender, EventArgs e)
        {
            var r = new TabloidConfigRow();
            Tools.AddWithUniqueName(
                 TabloidConfig.Config.Synthese.Affichage, r, "SR");
            addRow(currentTable, r);
        }
        /// <summary>
        /// Create new cell layout plus click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picAddColumn_Click(object sender, EventArgs e)
        {
            createNewCell((PictureBox)sender);
        }

        /// <summary>
        /// Create new cell button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            createNewCell(currentImage);
        }

        /// <summary>
        /// Create cell
        /// </summary>
        /// <param name="pb"></param>
        private void createNewCell(PictureBox pb)
        {
            var parent = (TableLayoutPanel)(pb.Parent);

            // add cell to config
            var c = new TabloidConfigCell();
            Tools.AddWithUniqueName(
                 ((TabloidConfigRow)parent.Tag).Cellules, c, "SC");

            // add cell to layout

            setActive(parent);
            addColumn(currentTable, c);
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

        private void cmbIndic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_layoutSelectionChange && currentImage != null)
            {
                var i = ((TabloidConfigIndicateur)cmbIndic.SelectedItem);

                ((TabloidConfigCell)currentImage.Tag).Indicateur = i.Nom;
                currentImage.BackgroundImage = getImage(i);
            }

            propertyGrid1.SelectedObject = cmbIndic.SelectedItem;

            _layoutSelectionChange = false;
        }

        private void btnRemoveIndic_Click(object sender, EventArgs e)
        {
            clearCurrentImage();
        }

        /// <summary>
        /// dissociate indic from cell
        /// </summary>
        private void clearCurrentImage()
        {
            if (currentImage == null) return;
            ((TabloidConfigCell)currentImage.Tag).Indicateur = null;
            currentImage.BackgroundImage = getImage(null);
        }

        private void btnCreateIndic_Click(object sender, EventArgs e)
        {
            var wiz = new WizardIndic();
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                cmbIndic.DataSource = null;
                cmbIndic.DataSource = IndicCache.GetIndicList().Values.ToArray();

                var indic = wiz.Result;
                ((TabloidConfigCell)currentImage.Tag).Indicateur = indic.Nom;
                currentImage.BackgroundImage = getImage(indic);

                setActiveImg(currentImage);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;


            if (MetroMessageBox.Show(this, "Confirmez-vous la suppression de la cellule?", "Question", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                TableLayoutPanel parent = (TableLayoutPanel)currentImage.Parent.Parent;

                parent.SuspendLayout();

                parent.ColumnStyles.RemoveAt(parent.ColumnCount - 1);
                //parent.ColumnCount--;
                //var pos = parent.ColumnCount - 1;
                //parent.ColumnStyles.Insert(pos, new ColumnStyle(SizeType.Percent, 100f));

                //var pb = getIndicImageCtrl(c);

                //parent.Controls.Add(pb, pos, 0);

                //if (c == null) pb.Tag = new TabloidConfigCell();

                parent.ResumeLayout();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;

            var i = getIndicFromTag(currentImage.Tag);

            if (!TabloidConfig.Config.Synthese.Indicateurs.Contains(i))
            {
                MetroMessageBox.Show(this, "Cet indicateur est rattaché à une vue. Pour le supprimer rendez vous dans l'onglet Indicateur de cette dernière","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            var Confirm=MetroMessageBox.Show(this, "Cet indicateur sera supprimé définitivement", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (Confirm == DialogResult.OK)
            {
                TabloidConfig.Config.Synthese.Indicateurs.Remove(i);

                IndicCache.setIndicCache();
                clearCurrentImage();
            }
            
        }
    }


}
