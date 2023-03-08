using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace EmuSak_Revive.GUI_WPF.Extensions
{
    public static class Imaging
    {
        public static ImageSource ConvertToImageSource(System.Drawing.Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        public static System.Drawing.Image RoundCorners(System.Drawing.Image StartImage, int CornerRadius, System.Drawing.Color BackgroundColor)
        {
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
            using (Graphics g = Graphics.FromImage(RoundedImage))
            {
                g.Clear(BackgroundColor);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                System.Drawing.Brush brush = new TextureBrush(StartImage);
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
                gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                g.FillPath(brush, gp);
                return RoundedImage;
            }
        }

        public static System.Drawing.Image ConvertButtonImageToSystemImage(System.Windows.Controls.Button btn)
        {
            // Get the image from the WPF Image control
            System.Windows.Controls.Image wpfImage = btn.Content as System.Windows.Controls.Image;

            // Convert the WPF Image to a System.Drawing.Bitmap
            Bitmap bitmap = null;
            if (wpfImage != null && wpfImage.Source != null)
            {
                BitmapSource bitmapSource = wpfImage.Source as BitmapSource;
                int width = bitmapSource.PixelWidth;
                int height = bitmapSource.PixelHeight;
                int stride = width * ((bitmapSource.Format.BitsPerPixel + 7) / 8);
                byte[] pixels = new byte[height * stride];
                bitmapSource.CopyPixels(pixels, stride, 0);

                bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                                                ImageLockMode.WriteOnly,
                                                                                bitmap.PixelFormat);
                System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bitmapData.Scan0, pixels.Length);
                bitmap.UnlockBits(bitmapData);
            }

            // Use the System.Drawing.Bitmap in your code
            if (bitmap != null)
            {
                // Do something with the bitmap

                return bitmap;
            }
            return null;
        }
    }
}