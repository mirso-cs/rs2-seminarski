using System.Threading.Tasks;
using Flurl.Http;
using Source.net.infrastructure.Enums;

namespace Source.net.desktop.Shared
{
    public class HttpClient
    {
        public string Path { get; }
        public static string Token { get; set; }
        public static Role RoleId { get; set; }
        public static int UserId { get; set; }

        public HttpClient(string path)
        {
            Path = path;
        }

        public async Task<T> Get<T>(object filters = null)
        {
            IFlurlRequest request = getPath();

            if (filters != null)
            {
                request.SetQueryParams(filters);
            }

            return await request.GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            IFlurlRequest request = getPath();

            return await request.AppendPathSegment($"/{id}").GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            return await getPath().PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            return await getPath().AppendPathSegment($"/{id}").PatchJsonAsync(request).ReceiveJson<T>();
        }

        public async Task Delete(int id)
        {
            await getPath().AppendPathSegment($"/{id}").DeleteAsync();
        }

        protected IFlurlRequest getPath()
        {
            return $"{Properties.Settings.Default.baseUrl}/{Path}".WithOAuthBearerToken(Token);
        }
    }
}
