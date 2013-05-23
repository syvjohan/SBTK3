using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    public partial class SBTK3 : Form
    {
        List<PictureBox> clips;
        bool isCreatingRect = false;
        Rectangle currentClipRect;
        Point beginRectPt;
        Point endRectPt;

        public SBTK3()
        {
            InitializeComponent();

            currentClipRect = Rectangle.Empty;
            clips = new List<PictureBox>();

            // Allowed file formats.
            loadImgDialog.Filter = "*.png, *.jpg, *.bmp|*.png;*.jpg;*.bmp";

            SetupEventHandlers();
        }

        void SetupEventHandlers()
        {
            // Eventhandler to begin/end creating a rectangle for clips.
            previewPicBox.Click += delegate(object sender, EventArgs e)
            {
                isCreatingRect = !isCreatingRect;
                if (isCreatingRect)
                {
                    beginRectPt = previewPicBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));
                }                
            };

            // Eventhandler to resize rectangle.
            previewPicBox.MouseMove += delegate(object sender, MouseEventArgs ma)
            {
                if (isCreatingRect)
                {
                    endRectPt = new Point(ma.X, ma.Y);
                    previewPicBox.Invalidate(Rectangle.Empty, false);
                }
            };

            previewPicBox.Paint += delegate(object sender, PaintEventArgs pea)
            {
                currentClipRect = RectFromMinMax(beginRectPt, endRectPt);
                if (currentClipRect != Rectangle.Empty && previewPicBox.Image != null)
                {
                    Graphics g = pea.Graphics;
                    g.DrawRectangle(Pens.White, currentClipRect);
                }
            };

            composePnl.Click += delegate(object sender, EventArgs ea)
            {
                if (currentClipRect != Rectangle.Empty)
                {
                    PictureBox pb = GetPreviewImageSnapshot();

                    bool isSelected = false; // Variable to check which pictureBox is selected by the user.
                    bool isDragging = false; // Variable to controlling the dragging.
                    Point offset = Point.Empty;

                    // Lets us start dragging the control around, and sends all others to the back.
                    pb.MouseDown += delegate(object s, MouseEventArgs ma)
                    {
                        isDragging = true;
                        offset = ma.Location;

                        pb.BringToFront();
                        // Gives the controll Focus, which makes it possible for pb.GotFocus and LostFocus to execute.
                        pb.Focus(); 
                    };

                    pb.GotFocus += delegate(object s, EventArgs e)
                    {
                        isSelected = true;
                        pb.Invalidate();
                    };
                    pb.LostFocus += delegate(object s, EventArgs e) {
                        isSelected = false;
                        pb.Invalidate();
                    };

                    pb.Paint += delegate(object s, PaintEventArgs e)
                    {
                        if (isSelected)
                        {
                            // Draw a rectangle around the selected pictureBox in the composePnl.
                            e.Graphics.DrawRectangle(
                                Pens.Gold,
                                new Rectangle(
                                    pb.ClientRectangle.X,
                                    pb.ClientRectangle.Y,
                                    pb.ClientRectangle.Width - 1,
                                    pb.ClientRectangle.Height - 1
                                )
                            );
                        }
                    };

                    // Stop dragging.
                    pb.MouseUp += delegate(object s, MouseEventArgs ma)
                    {
                        isDragging = false;
                        pb.Invalidate();
                    };

                    // Lets the user move the picturebox into its current location.
                    pb.MouseMove += delegate(object s, MouseEventArgs ma)
                    {
                        if (isDragging)
                        {
                            Point pos = composePnl.PointToClient(pb.PointToScreen(ma.Location));

                            pb.Location = new Point(pos.X - offset.X, pos.Y - offset.Y);
                        }
                    };

                    pb.PreviewKeyDown += delegate(object s, PreviewKeyDownEventArgs ke)
                    {
                        // Lets the user delete a picturebox in the List by pressing "Delete".
                        if (ke.KeyCode == Keys.Delete)
                        {
                            clips.Remove(pb);
                            composePnl.Controls.Remove(pb);
                        }
                    };

                    // Add clips to our clip list and the controls of the composePnl.
                    clips.Add(pb);
                    composePnl.Controls.Add(pb);
                    currentClipRect = Rectangle.Empty;
                    beginRectPt = endRectPt = Point.Empty;
                }

            };
        }

        /// <summary>
        /// Draw an image with the same size as the currentCliptRec.
        /// </summary>
        /// <returns></returns>
        PictureBox GetPreviewImageSnapshot()
        {
            Size imageSize = new Size(currentClipRect.Width, currentClipRect.Height);

            Image img = new Bitmap(imageSize.Width, imageSize.Height);

            Graphics g = Graphics.FromImage(img);

            g.DrawImage(
                previewPicBox.Image,
                new Rectangle(0, 0, imageSize.Width, imageSize.Height),
                currentClipRect,
                GraphicsUnit.Pixel
            );

            PictureBox pb = new PictureBox();
            pb.Image = img;
            pb.MaximumSize = pb.MinimumSize = imageSize;

            return pb;
        }

        /// <summary>
        /// Draw a negative and positive rectangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        Rectangle RectFromMinMax(Point a, Point b)
        {
            Rectangle rect = Rectangle.Empty;

            // Configure X and width.
            if (a.X > b.X)
            {
                rect.X = b.X;
                rect.Width = a.X - b.X;
            }
            else
            {
                rect.X = a.X;
                rect.Width = b.X - a.X;
            }

            // Configure Y and height.
            if (a.Y > b.Y)
            {
                rect.Y = b.Y;
                rect.Height = a.Y - b.Y;
            }
            else
            {
                rect.Y = a.Y;
                rect.Height = b.Y - a.Y;
            }


            return rect;
        }

        /// <summary>
        /// Exports an image from the clips.
        /// </summary>
        /// <param name="filename"></param>
        void ExportImage(string filename)
        {
            // Hold image size.
            Size sz = Size.Empty;

            foreach (PictureBox pb in clips)
            {
                int offsetX = pb.Location.X + pb.Width;
                int offsetY = pb.Location.Y + pb.Height;

                sz.Width = (offsetX > sz.Width) ? offsetX : sz.Width;
                sz.Height = (offsetY > sz.Height) ? offsetY : sz.Height;
            }
            

            Image bmp = new Bitmap(sz.Width, sz.Height);

            Graphics g = Graphics.FromImage(bmp);

            g.FillRectangle(Brushes.Transparent, new Rectangle(0, 0, bmp.Width, bmp.Height));

            foreach (PictureBox pb in clips)
            {
                g.DrawImage(pb.Image, pb.Location);
            }

            // Saving the file as an png format
            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                bmp.Save(stream, ImageFormat.Png);
            };
        }

        #region EVENTHANDLERS

        /// <summary>
        /// Makes the loaded files to be added in the imagePnl and set there size to 32*32.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = loadImgDialog.ShowDialog();

            if (dr != DialogResult.OK)
                return;

            Image img = Image.FromFile(loadImgDialog.FileName);

            PictureBox box = new PictureBox();
            box.Image = img;
            // sets the size of the pictureBox
            box.MaximumSize = new Size(32, 32);
            box.SizeMode = PictureBoxSizeMode.StretchImage;

            box.Click += delegate (object s, EventArgs ea)
            {
                previewPicBox.Image = box.Image;
            };

            imagePnl.Controls.Add(box);
        }

        /// <summary>
        /// Makes all exported files saves as png files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "*.png|*.png";            

            DialogResult dr = sfd.ShowDialog();

            if (dr != DialogResult.OK)
            {
                return;
            }

            // Set the exported file name to end with png.
            ExportImage(sfd.FileName.EndsWith(".png") ? sfd.FileName : sfd.FileName + ".png");
        }

        /// <summary>
        /// StripMenu to Clear the right Panel (composePnl).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clips.Clear();
            composePnl.Controls.Clear();
        }

        #endregion

       /// <summary>
        /// StripMenu to view object deleting help.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To delete one of the object in the right panel, press the key \"Del\"");
        }

    }

    
}
