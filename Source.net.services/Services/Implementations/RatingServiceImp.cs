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
    public class RatingServiceImp : 
        BaseServiceImp<
            Rating, 
            RatingView, 
            RatingMapper, 
            RatingRepository, 
            RatingDto,
            RatingDto,
            RatingFilters
        >,
        RatingService
    {
        public RatingServiceImp(RatingMapper mapper, RatingRepository repository): 
            base(mapper, repository)
        {
        }
    }
}
