using System;
using System.Collections.Generic;
using System.Text;

namespace Source.net.services.Repositories.Interfaces
{
    public interface Repository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T model);
        T Update(T model);
        T Delete(int id);
    }
}
