using Microsoft.AspNetCore.Mvc;
using Source.net.infrastructure.Views;
using Source.net.services.Services.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace Source.net.api.Utils.HttpContext
{
    public class HttpContextExtension: ControllerBase, HttpContextExtensible
    {
        private readonly UserService _users;
        public HttpContextExtension(UserService users)
        {
            _users = users;
        }

        public UserView getUser()
        {
           string username = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First()?.Value;
           return _users.GetByUsername(username);
        }
    }
}
