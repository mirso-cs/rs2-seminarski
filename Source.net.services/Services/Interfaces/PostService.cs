using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System.Collections.Generic;

namespace Source.net.services.Services.Interfaces
{
    public interface PostService : 
        BaseService<Post, CreatePostDto, UpdatePostDto, PostView, PostFilters>
    {
        PostView Add(CreatePostDto dto, int userId);
        IEnumerable<PostView> GetPopular();
        IEnumerable<PostView> GetLatest();
        IEnumerable<PostView> GetSuggested(UserPostFilters filters);
        IEnumerable<PostView> GetAllForUser(int userId, PostFilters filters);
    }
}
