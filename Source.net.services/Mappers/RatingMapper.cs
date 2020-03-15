using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Views;

namespace Source.net.services.Mappers
{
    public class RatingMapper : Mapper<Rating, RatingView, RatingDto, RatingDto>
    {
        public RatingView From(Rating entity)
        {
            return new RatingView()
            {
                Id = entity.id,
                Rating = entity.rating
            };
        }

        public Rating To(RatingDto dto)
        {
            return new Rating()
            {
                rating = dto.Rating,
                PostId = dto.PostId,
                UserId = dto.userId,
            };
        }

        public Rating To(RatingView view)
        {
            return new Rating()
            {
                id = view.Id,
                rating = view.Rating
            };
        }

        public Rating To(RatingDto dto, Rating entity)
        {
            entity.rating = dto.Rating;

            return entity;
        }
    }
}