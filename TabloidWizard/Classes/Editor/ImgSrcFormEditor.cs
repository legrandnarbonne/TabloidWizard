using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TabloidWizard.Classes.Editor
{
    public partial class ImgSrcFormEditor : Form
    {
        public string _currentDir;
        private BorderedPictureBox _currentSelectedBox;
        public string _currentfilePath;

        // PictureBoxes we use to display thumbnails.
        private List<BorderedPictureBox> PictureBoxes = new List<BorderedPictureBox>();

        // Thumbnail sizes.
        private const int ThumbWidth = 100;
        private const int ThumbHeight = 100;

        public ImgSrcFormEditor()
        {
            _currentDir = Program.CurrentProjectFolder + "\\images";

            Directory.CreateDirectory(_currentDir);

            InitializeComponent();

            updateThunbmnails();
        }



        // Display thumbnails for the selected directory.
        private void updateThunbmnails(string selectPath=null)
        {
            // Delete the old PictureBoxes.
            foreach (BorderedPictureBox pic in PictureBoxes)
            {
                //pic.Click -= PictureBox_Click;
                pic.DoubleClick -= PictureBox_DoubleClick;
                pic.Dispose();
            }
            flpThumbnails.Controls.Clear();
            PictureBoxes = new List<BorderedPictureBox>();

            // If the directory doesn't exist, do nothing else.
            if (!Directory.Exists(_currentDir)) return;

            // Get the names of the files in the directory.
            List<string> filenames = new List<string>();
            string[] patterns =
                { "*.png", "*.gif", "*.jpg", "*.bmp", "*.tif" };
            foreach (string pattern in patterns)
            {
                filenames.AddRange(Directory.GetFiles(_currentDir,
                    pattern, SearchOption.TopDirectoryOnly));
            }
            filenames.Sort();

            // Load the files.
            foreach (string filename in filenames)
            {
                // Load the picture into a PictureBox.
                BorderedPictureBox pic = new BorderedPictureBox();

                pic.ClientSize = new Size(ThumbWidth, ThumbHeight);
                pic.Image = new Bitmap(filename);

                // If the image is too big, zoom.
                if ((pic.Image.Width > ThumbWidth) ||
                    (pic.Image.Height > ThumbHeight))
                {
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pic.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                // Add the DoubleClick event handler.
                pic.Click += PictureBox_Click;
                pic.DoubleClick += PictureBox_DoubleClick;

                // Add a tooltip.
                FileInfo file_info = new FileInfo(filename);

                pic.Tag = file_info;

                if (pic.Tag.ToString() == selectPath) selectPictureBox(pic);

                // Add the PictureBox to the FlowLayoutPanel.
                pic.Parent = flpThumbnails;
            }

        }
        // Open the file.
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            // Get the file's information.
            BorderedPictureBox pic = sender as BorderedPictureBox;
            selectPictureBox(pic);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            var pictureBox = (BorderedPictureBox)sender;

            selectPictureBox(pictureBox);
        }

        private void selectPictureBox(BorderedPictureBox pictureBox)
        { 
            if (_currentSelectedBox != null)
            {
                _currentSelectedBox.BorderColor = null;
                _currentSelectedBox.Refresh();
            }

            _currentSelectedBox = pictureBox;

            _currentfilePath = $"/images{pictureBox.Tag.ToString().Substring(_currentDir.Length).Replace("\\","/")}";

            pictureBox.BorderColor = Color.Black;

            pictureBox.Refresh();
        }

        public class BorderedPictureBox : PictureBox
        {
            public Color? BorderColor { get; set; }
            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
                if (BorderColor != null) ControlPaint.DrawBorder(pe.Graphics, pe.ClipRectangle, (Color)BorderColor, ButtonBorderStyle.Solid);
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Ajouter un fichier",

                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Fichiers images (*.png,*.gif,*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.gif;*.png;*.jpg; *.jpeg; *.jpe; *.jfif; *.png|Tout les fichiers (*.*) | *.*;",
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fi = new FileInfo(openFileDialog1.FileName);
                fi.CopyTo(_currentDir + "\\" + Path.GetFileName(openFileDialog1.FileName),true);

                updateThunbmnails(_currentDir + "\\" + Path.GetFileName(openFileDialog1.FileName));

            }
        }
    }
}
