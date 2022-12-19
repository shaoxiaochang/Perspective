using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace Perspective
{
    public partial class Form1 : Form
    {
        double[,] A = new double[8, 8];
        double[] b = new double[8];
        Bitmap image1;

        public Form1()
        {
            InitializeComponent();

            image1 = new Bitmap(pictureBox1.Image);

            // points
            int x1 = 0, x2 = 360, x3 = 0, x4 = 360;
            int y1 = 0, y2 = 0, y3 = 450, y4 = 450;

            int xx1 = 689, xx2 = 2407, xx3 = 187, xx4 = 2945;
            int yy1 = 532, yy2 = 477, yy3 = 2703, yy4 = 2661;

            Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] {
                { x1, y1, x1*y1, 1, 0, 0, 0, 0},
                { x2, y2, x2*y2, 1, 0, 0, 0, 0},
                { x3, y3, x3*y3, 1, 0, 0, 0, 0},
                { x4, y4, x4*y4, 1, 0, 0, 0, 0},
                { 0, 0, 0, 0, x1, y1, x1*y1, 1},
                { 0, 0, 0, 0, x2, y2, x2*y2, 1},
                { 0, 0, 0, 0, x3, y3, x3*y3, 1},
                { 0, 0, 0, 0, x4, y4, x4*y4, 1}
            });
            Vector<double> b = Vector<double>.Build.Dense(new double[] { xx1, xx2, xx3, xx4, yy1, yy2, yy3, yy4 });
            // calculate matrix parameters
            var result = A.Solve(b);

            // interpolation
            Bitmap bmp = new Bitmap(360, 450);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    var double_x = (result[0] * i) + (result[1] * j) + (result[2] * i * j) + result[3];
                    var double_y = (result[4] * i) + (result[5] * j) + (result[6] * i * j) + result[7];
                    int y = (int)(double_y);
                    int x = (int)(double_x);
                    var v = (double_y - y);
                    var u = (double_x - x);

                    var R = (1 - u) * (1 - v) * image1.GetPixel(x, y).R
                        + u * (1 - v) * image1.GetPixel(x, y + 1).R
                        + v * (1 - u) * image1.GetPixel(x + 1, y).R
                        + u * v * image1.GetPixel(x + 1, y + 1).R;
                    var G = (1 - u) * (1 - v) * image1.GetPixel(x, y).G
                        + u * (1 - v) * image1.GetPixel(x, y + 1).G
                        + v * (1 - u) * image1.GetPixel(x + 1, y).G
                        + u * v * image1.GetPixel(x + 1, y + 1).G;
                    var B = (1 - u) * (1 - v) * image1.GetPixel(x, y).B
                        + u * (1 - v) * image1.GetPixel(x, y + 1).B
                        + v * (1 - u) * image1.GetPixel(x + 1, y).B
                        + u * v * image1.GetPixel(x + 1, y + 1).B;

                    bmp.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));
                }
            }

            pictureBox2.Image = bmp;
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private void ShowCoords(Int32 mouseX, Int32 mouseY)
        {
            Int32 realW = pictureBox1.Image.Width;
            Int32 realH = pictureBox1.Image.Height;
            Int32 currentW = pictureBox1.ClientRectangle.Width;
            Int32 currentH = pictureBox1.ClientRectangle.Height;
            Double zoomW = (currentW / (Double)realW);
            Double zoomH = (currentH / (Double)realH);
            Double zoomActual = Math.Min(zoomW, zoomH);
            Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
            Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;

            Int32 realX = (Int32)((mouseX - padX) / zoomActual);
            Int32 realY = (Int32)((mouseY - padY) / zoomActual);
            lblPosXval.Text = realX < 0 || realX > realW ? "-" : realX.ToString();
            lblPosYVal.Text = realY < 0 || realY > realH ? "-" : realY.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Default check: left mouse button only
            if (e.Button == MouseButtons.Left)
                ShowCoords(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Allows dragging to also update the coords. Checking the button
            // on a MouseMove is an easy way to detect click dragging.
            if (e.Button == MouseButtons.Left)
                ShowCoords(e.X, e.Y);
        }
    }
}