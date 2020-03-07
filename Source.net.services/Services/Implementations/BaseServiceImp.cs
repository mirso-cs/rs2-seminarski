using Source.net.services.Mappers;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;

namespace Source.net.services.Services.Implementations
{
    public class BaseServiceImp<TEntity, TView, TMapper, TRepo, TCreate, TUpdate, TFilter> 
        where TEntity : class 
        where TMapper : Mapper<TEntity, TView, TCreate, TUpdate>
        where TRepo : Repository<TEntity, TFilter>
    {
        protected readonly TMapper _mapper;
        protected readonly TRepo _repo;

        public BaseServiceImp(TMapper mapper, TRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public virtual TView Add(TCreate dto)
        {
            var entity = _mapper.To(dto);
            _repo.Add(entity);
            return _mapper.From(entity);
        }

        public virtual TView Delete(int id)
        {
            return _mapper.From(_repo.Delete(id));
        }

        public virtual TView Get(int id)
        {
            return _mapper.From(_repo.Get(id));
        }

        public virtual IEnumerable<TView> GetAll()
        {
            List<TView> views = new List<TView>();
            var entities = _repo.GetAll();
            foreach (var entity in entities)
            {
                views.Add(_mapper.From(entity));
            }
            return views;
        }

        public virtual IEnumerable<TView> GetAll(TFilter filters)
        {
            List<TView> views = new List<TView>();
            var entities = _repo.GetAll(filters);
            foreach (var entity in entities)
            {
                views.Add(_mapper.From(entity));
            }
            return views;
        }

        public virtual TView Update(int id, TUpdate dto)
        {
            var entity = _repo.Get(id);
            return _mapper.From(_repo.Update(_mapper.To(dto, entity)));
        }
    }
}
