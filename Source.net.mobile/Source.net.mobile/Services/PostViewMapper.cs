using Source.net.infrastructure.Views;
using Source.net.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source.net.mobile.Services
{
    public class PostViewMapper
    {
        public PostGridItem from(PostView post)
        {
            return new PostGridItem()
            {
                Id = post.id,
                Published = post.Published,
                Subtitle = post.Subtitle,
                Tags = string.Join(", ", post.Tags.Select(x => x.Name).ToArray()),
                Title = post.Title,
                Content = post.Content,
                Thumbnail = post.Thumbnail,
                Category = post.Category,
                Author = post.User
            };
        }
    }
}
