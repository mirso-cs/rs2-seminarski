using Microsoft.AspNetCore.Mvc;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using Source.net.services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Source.net.infrastructure.SearchFilters;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Super user")]
    public class CategoryController : 
        CRUDController<
            Category, 
            CategoryDto, 
            CategoryDto, 
            CategoryView, 
            CategoryFilters
        >
    {
        public CategoryController(CategoryService service) :
            base(service)
        {

        }
    }
}