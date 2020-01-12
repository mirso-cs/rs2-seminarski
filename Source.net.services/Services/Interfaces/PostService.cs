using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.Views;

namespace Source.net.services.Services.Interfaces
{
    public interface PostService : 
        BaseService<Post, CreatePostDto, UpdatePostDto, PostView>
    {
        PostView Add(CreatePostDto dto, int userId);
    }
}
