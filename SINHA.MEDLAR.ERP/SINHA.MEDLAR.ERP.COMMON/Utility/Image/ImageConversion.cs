using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.COMMON.Utility.Image
{
    public class ImageConversion
    {

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

            //Bitmap bitmap = new Bitmap(100, 100);
            //bitmap.SetResolution(96.0F, 96.0F);

            return returnImage;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static byte[] AsJpeg(byte[] data)
        {
            using (var inStream = new MemoryStream(data))
            using (var outStream = new MemoryStream())
            {
                var imageStream = System.Drawing.Image.FromStream(inStream);
                imageStream.Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return outStream.ToArray();
            }
        }
        
    }
}
