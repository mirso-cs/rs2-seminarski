using System.Collections.Generic;

namespace Source.net.services.Services.Interfaces
{
    public interface BaseService<TEntity, TCreate, TUpdate, TView, TFilter> where TEntity: class
    {
        IEnumerable<TView> GetAll();
        IEnumerable<TView> GetAll(TFilter filter);
        TView Get(int id);
        TView Add(TCreate dto);
        TView Update(int id, TUpdate dto);
        TView Delete(int id);
    }
}
