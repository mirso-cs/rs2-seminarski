using Infrastructure.Entities;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerUserRepository : UserRepository
    {

        private readonly SourceNetContext _db;

        public SqlServerUserRepository(SourceNetContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _db.Users.Find(id);
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
            UpdateUser(user);
            return user;
        }

        public User AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _db.Users.Attach(user);
            _db.Users.Update(user);
            _db.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            return ToggleStatus(id, false);
        }

        public User ActivateUser(int id)
        {
            return ToggleStatus(id, true);
        }

        private User ToggleStatus(int id, bool active)
        {
            var user = GetUser(id);
            user.Active = active;
            user.Token = null;
            UpdateUser(user);
            return user;
        }
    }
}
