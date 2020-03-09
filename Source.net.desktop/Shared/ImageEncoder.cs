using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.net.desktop.Shared
{
    public interface ImageEncoder
    {
        string Encode(Image image);
        Image Decode(string base64);
    }
}
