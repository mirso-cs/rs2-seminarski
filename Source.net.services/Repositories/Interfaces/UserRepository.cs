using Infrastructure.Entities;

namespace Source.net.services.Repositories.Interfaces
{
    public interface UserRepository: Repository<User>
    {
        User GetUserByUsername(string username);
        User GetByEmail(string email);
        User SetToken(string username, string token);
        User ActivateUser(int id);
    }
}
