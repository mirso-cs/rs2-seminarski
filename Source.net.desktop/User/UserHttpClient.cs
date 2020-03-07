using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Source.net.desktop.Shared;
using Source.net.infrastructure.Enums;

namespace Source.net.desktop.User
{
    public class UserHttpClient: HttpClient
    {
        public UserHttpClient(string Path): base(Path)
        {

        }

        public async Task Activate(int userId)
        {
            await getPath().AppendPathSegment($"/{userId}/restore").PutJsonAsync(new { });
        }

        public async Task Deactivate(int userId)
        {
            await getPath().AppendPathSegment($"/{userId}").DeleteAsync();
        }

        public async Task UpdateRole(int userId, Role role)
        {
            await getPath().AppendPathSegment($"/{userId}/role").PutJsonAsync(new { role });
        }
    }
}
