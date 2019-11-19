using Source.net.infrastructure.Entities;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerUserRepository : MutatorRepository<User>, UserRepository
    {

        public SqlServerUserRepository(SourceNetContext db): 
            base(db)
        {

        }

        public User GetUserByUsername(string username)
        {
            return _db.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _db.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User SetToken(string username, string token)
        {
            var user = GetUserByUsername(username);
            if (user is null)
            {
                return null;
            }
            user.Token = token;
            Update(user);
            return user;
        }
        
        public override User Delete(int id)
        {
            return ToggleStatus(id, false);
        }

        public User ActivateUser(int id)
        {
            return ToggleStatus(id, true);
        }

        private User ToggleStatus(int id, bool active)
        {
            var user = Get(id);
            user.Active = active;
            user.Token = null;
            Update(user);
            return user;
        }
    }
}
