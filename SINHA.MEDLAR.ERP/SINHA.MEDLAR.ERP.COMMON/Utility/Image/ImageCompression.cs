using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.COMMON.Utility.Image;
using System.Drawing.Imaging;

namespace SINHA.MEDLAR.ERP.COMMON.Utility.Image
{
   public class ImageCompression
    {
        public static Byte[] Resize(System.Drawing.Image image, int maxWidth, int maxHeight, float dpix, float dpiy)
        {

            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            var newImage = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var graphic = Graphics.FromImage(newImage))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            newImage.SetResolution(dpix, dpiy);

            return ImageConversion.ImageToByteArray(newImage);
        }

        public static Byte[] Resize(byte[] byteArray, int maxWidth, int maxHeight, float dpix, float dpiy)
        {
           System.Drawing.Image image = ImageConversion.ByteArrayToImage(byteArray);

            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            var newImage = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var graphic = Graphics.FromImage(newImage))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            newImage.SetResolution(dpix, dpiy);

            return ImageConversion.ImageToByteArray(newImage);
        }

        public static Byte[] GetThumbnail(System.Drawing.Image image, int width = 40, int height = 40)
        {
            System.Drawing.Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
            image.Dispose();
            return ImageConversion.ImageToByteArray(thumb);
        }

        private ImageCodecInfo GetEncoderInfo(System.Drawing.Imaging.ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

    }
}
