using Infrastructure.Entities;
using Source.net.api.Database;
using Source.net.api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.net.api.Repositories.Implementations
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

        public User SetToken(string username, string token)
        {
            var user = GetUserByUsername(username);
            if (user is null)
            {
                return null;
            }
            user.Token = token;
            _db.Users.Attach(user);
            _db.Users.Update(user);
            _db.SaveChanges();
            return user;
        }


    }
}
