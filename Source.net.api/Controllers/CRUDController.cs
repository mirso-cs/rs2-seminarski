using System.Collections.Generic;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Source.net.services.Services.Interfaces;

namespace Source.net.api.Controllers
{
    public class CRUDController<TEntity, TCreate, TUpdate, TView> : ControllerBase where TEntity: class
    {
        protected readonly BaseService<TEntity, TCreate, TUpdate, TView> _crudService;
        public CRUDController(BaseService<TEntity, TCreate, TUpdate, TView> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public virtual IEnumerable<TView> Get()
        {
            return _crudService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public virtual TView GetById(int id)
        {
            return _crudService.Get(id);
        }

        [HttpPost]
        public virtual TView Add(TCreate dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }
        
            return _crudService.Add(dto);
        }

        [HttpPatch]
        [Route("{id}")]
        public virtual TView Update(int id, TUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _crudService.Update(id, dto);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual TView Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Invalid Request");
            }

            return _crudService.Delete(id);
        }

    }
}