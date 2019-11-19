using Source.net.services.Database;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class MutatorRepository<T> where T: class
    {
        protected readonly SourceNetContext _db;

        public MutatorRepository(SourceNetContext db)
        {
            _db = db;
        }

        public T Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public virtual T Delete(int id)
        {
            var entity = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
            return entity;

        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}
