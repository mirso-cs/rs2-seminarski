using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.services.Mappers;
using Source.net.services.Repositories.Interfaces;
using Source.net.services.Services.Interfaces;
using System.Collections.Generic;

namespace Source.net.services.Services.Implementations
{
    public class TagServiceImp : 
        BaseServiceImp<
            Tag, 
            TagView, 
            TagMapper, 
            TagRepository, 
            TagDto, 
            TagDto, 
            TagFilters
        >,
        TagService
    {
        public TagServiceImp(TagMapper mapper, TagRepository repository): 
            base(mapper, repository)
        {
        }
    }
}
