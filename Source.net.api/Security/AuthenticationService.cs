using Infrastructure.Dtos;

namespace Source.net.api.Security
{
    public interface AuthenticationService
    {
        bool IsAuthenticated(LoginDto request, out string token);

    }
}
