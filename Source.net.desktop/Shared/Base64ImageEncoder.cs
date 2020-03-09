using System;
using System.Drawing;
using System.IO;

namespace Source.net.desktop.Shared
{
    public class Base64ImageEncoder : ImageEncoder
    {
        public Image Decode(string base64)
        {
            var pic = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(pic))
            {
                return Image.FromStream(ms);
            }
        }

        public string Encode(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}
