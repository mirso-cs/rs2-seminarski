using Microsoft.AspNetCore.Mvc;
using Source.net.infrastructure.Views;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Source.net.api.Utils.HttpContext
{
    public class HttpContextExtension: HttpContextExtensible
    {
        private readonly UserService _users;
        public HttpContextExtension(UserService users)
        {
            _users = users;
        }

        public UserView getUserFromClaims(IEnumerable<Claim> Claims)
        {
           string username = Claims
                .Where(c => c.Type == ClaimTypes.NameIdentifier)
                .FirstOrDefault()?.Value;
           
            return _users.GetByUsername(username);
        }
    }
}
