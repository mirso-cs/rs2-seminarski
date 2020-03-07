using Source.net.desktop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.net.desktop.Post
{
    public class PostHttpClient: HttpClient
    {
        public PostHttpClient(string path): base(path)
        {

        }
    }
}
