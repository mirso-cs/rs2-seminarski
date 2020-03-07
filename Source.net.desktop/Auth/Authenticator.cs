using Source.net.desktop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Source.net.infrastructure.Views;
using Source.net.infrastructure.Dtos;

namespace Source.net.desktop.Auth
{
    public class Authenticator
    {
        public string Path { get; }

        public Authenticator(string path)
        {
            Path = path;
        }

        public async Task<AuthUser> Login(string username, string password)
        {
            string request = $"{getPath()}/login";

            AuthUser response = await request
                .PostJsonAsync(new LoginDto() { Password = password, Username = username})
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
            return $"{Properties.Settings.Default.baseUrl}/{Path}";
        }
    }
}
