using System.Threading.Tasks;
using Flurl.Http;
using Source.net.infrastructure.Enums;

namespace Source.net.desktop.Shared
{
    public abstract class HttpClient
    {
        public string Path { get; }
        public static string Token { get; set; }
        public static Role RoleId { get; set; }
        public ObjectUrlEncoder ObjectEncoder { get; }

        public HttpClient(string path)
        {
            Path = path;
            ObjectEncoder = new ObjectUrlEncoder();
        }

        public async Task<T> Get<T>(object filters = null)
        {
            IFlurlRequest request = getPath(filters);

            return await request.GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(int id)
        {
            IFlurlRequest request = getPath();

            return await request.AppendPathSegment($"/{id}").GetJsonAsync<T>();
        }

        protected IFlurlRequest getPath(object filters = null)
        {
            string baseString = $"{Properties.Settings.Default.baseUrl}/{Path}";

            if (filters != null)
            {
                baseString += $"?{ObjectEncoder.AsUrl(filters)}";
            }

            return baseString.WithOAuthBearerToken(Token);
        }
    }
}
