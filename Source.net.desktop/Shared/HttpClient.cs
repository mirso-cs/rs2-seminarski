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
            IFlurlRequest request = getPath();

            if (filters != null)
            {
                request.SetQueryParams(filters);
            }

            return await request.GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(int id)
        {
            IFlurlRequest request = getPath();

            return await request.AppendPathSegment($"/{id}").GetJsonAsync<T>();
        }

        public async Task Insert<T>(T request)
        {
            await getPath().PostJsonAsync(request);
        }

        public async Task Update<T>(T request)
        {
            await getPath().PatchJsonAsync(request);
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
