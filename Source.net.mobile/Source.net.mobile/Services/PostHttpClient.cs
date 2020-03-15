using Source.net.infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Source.net.infrastructure.Views;

namespace Source.net.mobile.Services
{
    public class PostHttpClient: HttpClient
    {
        public static int ReadPosts { get; set; } = 0;

        public PostHttpClient(string path):base(path) {}

        public async Task<IEnumerable<PostView>> GetAll(object filters = null)
        {
            IFlurlRequest request = $"{baseUrl}/{Path}/latest".WithOAuthBearerToken(Token);
            ;

            if (filters != null)
            {
                request.SetQueryParams(filters);
            }

            return await request.GetJsonAsync<IEnumerable<PostView>>();
        }

        public async Task<IEnumerable<PostView>> GetPopular()
        {
            return await $"{baseUrl}/{Path}/popular"
                .WithOAuthBearerToken(Token)
                .GetJsonAsync<IEnumerable<PostView>>();
        }

    }
}
