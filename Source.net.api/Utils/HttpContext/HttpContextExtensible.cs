using Source.net.infrastructure.Views;
using System.Collections.Generic;
using System.Security.Claims;

namespace Source.net.api.Utils.HttpContext
{
    public interface HttpContextExtensible
    {
        UserView getUserFromClaims(IEnumerable<Claim> Claims);
    }
}
