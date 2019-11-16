using Infrastructure.Entities;
using System.Collections.Generic;

namespace Source.net.api.Repositories.Interfaces
{
    public interface UserRepository
    {
        IEnumerable<User> GetAll();
        User GetUser(int id);
        User GetUserByUsername(string username);
        User SetToken(string username, string token);
    }
}
