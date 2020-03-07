using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using System.Collections.Generic;

namespace Source.net.services.Repositories.Interfaces
{
    public interface UserRepository: Repository<User, UserFilters>
    {
        User GetUserByUsername(string username);
        User GetByEmail(string email);
        User SetToken(string username, string token);
        User ActivateUser(int id);
    }
}
