using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageColorTrun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                //                private float[] colorArray = new float[]{
                //0.33,0.59,0.11,0,0,
                //0.33,0.59,0.11,0,0,
                //0.33,0.59,0.11,0,0,
                //0,0,0,1,0,
                //0,0,0,0,0
                //};


                Image image = new Bitmap("C:\\图标\\newbig.bmp");
                ImageAttributes imageAttributes = new ImageAttributes();
                int width = image.Width;
                int height = image.Height;

                float[][] colorMatrixElements = {
   new float[] {0.33f,  0.59f,  0.11f,  0, 0},        // 红色比例因子2
   new float[] {0.33f,  0.59f,  0.11f,  0, 0},        // 绿色比例因子1
   new float[] {0.33f,  0.59f,  0.11f,  0, 0},        // 蓝色比例因子1
   new float[] {0,  0,  0,  1, 0},        // 开端比例因子1
   new float[] {0, 0, 0, 0, 0}};    // 三个译本的0.2

                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

                imageAttributes.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap);


                //e.Graphics.DrawImage(image, 10, 10);
               
                    e.Graphics.DrawImage(
                       image,
                       new Rectangle(10, 10, width, height),  // destination rectangle 
                       0, 0,        // upper-left corner of source rectangle 
                       width,       // width of source rectangle
                       height,      // height of source rectangle
                       GraphicsUnit.Pixel,
                       imageAttributes);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
         public Image getimg()
        {
            Image image = new Bitmap("C:\\图标\\newbig.bmp");
            ImageAttributes imageAttributes = new ImageAttributes();
            int width = image.Width;
            int height = image.Height;
            Bitmap newmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(newmap);

            float[][] colorMatrixElements = {
   new float[] {0.33f,  0.59f,  0.11f,  0, 0},        // 红色比例因子2
   new float[] {0.33f,  0.59f,  0.11f,  0, 0},        // 绿色比例因子1
   new float[] {0.33f,  0.59f,  0.11f,  0, 0},        // 蓝色比例因子1
   new float[] {0,  0,  0,  1, 0},        // 开端比例因子1
   new float[] {0, 0, 0, 0, 0}};    // 三个译本的0.2

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);

            g.DrawImage(
               image,
               new Rectangle(10, 10, width, height),  // destination rectangle 
               0, 0,        // upper-left corner of source rectangle 
               width,       // width of source rectangle
               height,      // height of source rectangle
               GraphicsUnit.Pixel,
               imageAttributes);
            g.Dispose();
            return newmap;
        }
    }
}
