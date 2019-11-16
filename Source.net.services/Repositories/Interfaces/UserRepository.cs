using Infrastructure.Entities;
using System.Collections.Generic;

namespace Source.net.services.Repositories.Interfaces
{
    public interface UserRepository
    {
        IEnumerable<User> GetAll();
        User GetUser(int id);
        User GetUserByUsername(string username);
        User GetByEmail(string email);
        User SetToken(string username, string token);
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
        User ActivateUser(int id);

    }
}
