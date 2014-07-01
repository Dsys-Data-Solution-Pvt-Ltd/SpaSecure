using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.Drawing.Text;
using GenCode128;

namespace SMS
{
    public class Barcode
    {
        public static string GenerateSpecialBarcode(string barcodetext, int weight, System.Web.HttpContext context, bool addQuietzone)
        {
            string savedImgFilePath = string.Empty;
            Image myimg = new Bitmap(200, 50);
            myimg = Code128Rendering.MakeBarcodeImage(barcodetext, weight, addQuietzone);
            myimg = Barcode.resizeImage(myimg, new Size(myimg.Width, myimg.Height + 15));

            savedImgFilePath = ConfigurationManager.AppSettings["barcodeImageFolder"].ToString() + "Img_" + System.Guid.NewGuid().ToString() + ".bmp";

            Graphics Gfx = Graphics.FromImage(myimg);

            SolidBrush Bru = new SolidBrush(Color.FromName("Black"));
            Font f = new Font(new FontFamily("Verdana"), 8, FontStyle.Bold);
            Gfx.DrawString(barcodetext, f, new SolidBrush(Color.FromName("Black")), 7, myimg.Height - 15);

            myimg.Save(context.Server.MapPath(savedImgFilePath), System.Drawing.Imaging.ImageFormat.Bmp);
            return savedImgFilePath;
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = size.Width;
            int sourceHeight = size.Height;

            int destWidth = sourceWidth;
            int destHeight = sourceHeight;

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.Clear(Color.White);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, imgToResize.Width, imgToResize.Height);
            g.Dispose();

            return (Image)b;
        }
    }
}
