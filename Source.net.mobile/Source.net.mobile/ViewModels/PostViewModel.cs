using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using Source.net.mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Source.net.mobile.ViewModels
{
    public class PostViewModel: BaseViewModel
    {
        private readonly HttpClient ratingHttp = new HttpClient("rating");
        public PostGridItem Post { get; set; }
        public IEnumerable<PostGridItem> SuggestedPosts { get; set; }
        public ICommand RateCommand { get; set; }

        int rating = 0;
        public int Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        public PostViewModel(PostGridItem post, IEnumerable<PostGridItem> suggestedPosts = null)
        {
            Post = post;
            SuggestedPosts = suggestedPosts is null ? new List<PostGridItem>() : suggestedPosts;
            Rating = 0;
            RateCommand = new Command(async () => await Rate());
        }

        async Task Rate()
        {
            var request = new RatingDto()
            {
                PostId = Post.Id,
                userId = HttpClient.UserId,
                Rating = Rating
            };
            await ratingHttp.Insert<RatingView>(request);
            await Application.Current.MainPage.DisplayAlert("asd", Rating.ToString(), "asd");
        }
    }
}
