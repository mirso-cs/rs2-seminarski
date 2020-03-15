using Source.net.infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Source.net.infrastructure.Views;
using Source.net.infrastructure.Dtos;

namespace Source.net.mobile.Services
{
    public class PaymentHttpClient
    {
#if DEBUG
        protected readonly string baseUrl = "http://localhost:51185/api";
#endif

#if RELEASE
        protected readonly string baseUrl = "https://api.site.com";
#endif
        public async Task<UserView> Pay(PaymentDto request)
        {
            return await $"{baseUrl}/user/package"
                 .WithOAuthBearerToken(HttpClient.Token)
                 .PostJsonAsync(request)
                 .ReceiveJson<UserView>();
        }
    }
}
