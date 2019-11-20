using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Views;
using Source.net.services.Mappers;
using Source.net.services.Repositories.Interfaces;
using Source.net.services.Services.Interfaces;

namespace Source.net.services.Services.Implementations
{
    public class CategoryServiceImp : 
        BaseServiceImp<Category, CategoryView, CategoryMapper, CategoryRepository, CategoryDto, CategoryDto>,
        CategoryService
    {
        public CategoryServiceImp(CategoryMapper mapper, CategoryRepository repository): 
            base(mapper, repository)
        {
        }
    }
}
