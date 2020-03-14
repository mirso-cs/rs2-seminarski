using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Source.net.mobile.Services
{
    public class Authenticator
    {
#if DEBUG
        private readonly string baseUrl = "http://localhost:51185/api";
#endif

#if RELEASE
        private readonly string baseUrl = "https://api.site.com";
#endif


        public Authenticator() { }

        public async Task<AuthUser> Login(string username, string password)
        {
            string request = $"{getPath()}/login";

            AuthUser response = await request
                .PostJsonAsync(new LoginDto() { Password = password, Username = username })
                .ReceiveJson<AuthUser>();

            return response;
        }

        public async Task Register(RegisterDto request)
        {
            string path = $"{getPath()}/register";
            await path.PostJsonAsync(request);
        }

        private string getPath()
        {
            return $"{baseUrl}/user";
        }
    }
}
