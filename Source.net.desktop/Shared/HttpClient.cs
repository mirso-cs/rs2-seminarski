using System.Threading.Tasks;
using Flurl.Http;

namespace Source.net.desktop.Shared
{
    public class HttpClient
    {
        public string Path { get; }
        public ClassUrlEncoder Encoder { get; }

        public HttpClient(string path)
        {
            Path = path;
            Encoder = new ClassUrlEncoder();
        }

        public async Task<T> Get<T>(object filters = null)
        {
            string request = $"{Properties.Settings.Default.baseUrl}/{Path}";

            if(filters != null)
            {
                request += $"?{Encoder.EncodeAsUrl(filters)}";
            }


           return await request.GetJsonAsync<T>();
        }
    }
}
