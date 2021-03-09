using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TabloidWizard.Classes.Control
{
    /// <summary>
    /// Thanks to https://www.codeproject.com/Articles/2091/ListBox-with-Icons
    /// </summary>
    public class GListBoxItem
    {
        private object _myObject;
        private int _myImageIndex;
        public List<int> Images { get; set; }

        // properties 
        public object Tag
        {
            get { return _myObject; }
            set { _myObject = value; }
        }
        public int ImageIndex
        {
            get { return _myImageIndex; }
            set { _myImageIndex = value; }
        }
        //constructor
        public GListBoxItem(object o, int index)
        {
            _myObject = o;
            _myImageIndex = index;
            Images = new List<int>();
        }
        public GListBoxItem(object o) : this(o, -1) { }
        public GListBoxItem() : this("") { }


        public override string ToString()
        {
            return _myObject.ToString();
        }
    }//End of GListBoxItem class

    // GListBox class 
    public class GListBox : ListBox
    {
        private ImageList _myImageList;
        public ImageList ImageList
        {
            get { return _myImageList; }
            set { _myImageList = value; }
        }

        public int? ImageIndex { get; set; }
        public int ImagePadding { get; set; }

        [Category("Appearance")]
        [Description("Background of selected object.")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedBackgroundColor { get; set; }//Color.FromArgb(255,219,175,0)

        public GListBox()
        {
            // Set owner draw mode
            this.DrawMode = DrawMode.OwnerDrawFixed;

            SelectedBackgroundColor = Color.FromArgb(255, 219, 175, 0);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //e.DrawBackground();
            //draw Background
            int itemIndex = e.Index;
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            if (itemIndex >= 0 && itemIndex < Items.Count)
            {
                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? SelectedBackgroundColor : Color.White);
                e.Graphics.FillRectangle(backgroundColorBrush, e.Bounds);
            }

            e.DrawFocusRectangle();

            //draw item
            if (Items == null || Items.Count == 0) return;

            GListBoxItem item;
            Rectangle bounds = e.Bounds;

            var xOffset = bounds.Left;

            if (ImageList != null)
            {
                ItemHeight = ImageList.ImageSize.Height;

                if (e.Index != -1)
                {
                    if (ImageIndex != null) item = Convert(Items[e.Index], ImageIndex);
                    else item = (GListBoxItem)Items[e.Index];

                    var textSize = e.Graphics.MeasureString(item.ToString(), e.Font);
                    var textTop = bounds.Top + ((ItemHeight / 2) - (textSize.Height / 2));

                    if (item.ImageIndex != -1)
                    {
                        ImageList.Draw(e.Graphics, xOffset, bounds.Top, item.ImageIndex);
                        xOffset += ImagePadding + _myImageList.ImageSize.Width;
                        e.Graphics.DrawString(item.ToString(), e.Font, new SolidBrush(e.ForeColor),
                            xOffset, textTop);
                        xOffset += (int)textSize.Width;
                    }
                    else
                    {
                        e.Graphics.DrawString(item.ToString(), e.Font, new SolidBrush(e.ForeColor),
                            bounds.Left, bounds.Top);
                    }

                    //add icon
                    foreach (int img in item.Images)
                    {
                        xOffset += ImagePadding;
                        ImageList.Draw(e.Graphics, xOffset, bounds.Top, img);
                        xOffset += _myImageList.ImageSize.Width;
                    }
                }
            }
            else
            {
                if (e.Index != -1)
                {
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font,
                        new SolidBrush(e.ForeColor), bounds.Left, bounds.Top);
                }
                else
                {
                    e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor),
                        bounds.Left, bounds.Top);
                }
            }
            base.OnDrawItem(e);
        }

        private GListBoxItem Convert(object i, int? imageIndex)
        {
            if (i is GListBoxItem)
            {
                var gi = (GListBoxItem)i;

                gi.ImageIndex = (int)ImageIndex;

                return gi;
            }

            return new GListBoxItem(i, (int)imageIndex);

        }
    }
}
