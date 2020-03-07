using System.Collections.Generic;
using Source.net.infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Source.net.services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Source.net.api.Controllers
{
    public class CRUDController<TEntity, TCreate, TUpdate, TView, TFilter> : ControllerBase where TEntity: class
    {
        protected readonly BaseService<TEntity, TCreate, TUpdate, TView, TFilter> _crudService;
        public CRUDController(BaseService<TEntity, TCreate, TUpdate, TView, TFilter> crudService)
        {
            _crudService = crudService;
        }

        [AllowAnonymous]
        [HttpGet]
        public virtual IEnumerable<TView> Get([FromQuery]TFilter filter)
        {
            if(filter == null)
            {
                return _crudService.GetAll();
            }

            return _crudService.GetAll(filter);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public virtual TView GetById(int id)
        {
            return _crudService.Get(id);
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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