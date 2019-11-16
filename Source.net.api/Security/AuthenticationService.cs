using Source.net.api.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.net.api.Security
{
    public interface AuthenticationService
    {
        bool IsAuthenticated(LoginRequest request, out string token);

    }
}
