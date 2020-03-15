using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.mobile.Services;
using Source.net.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Source.net.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Post : ContentPage
    {
        private readonly PostViewModel viewModel;
        PostHttpClient http = new PostHttpClient("post");
        PostViewMapper mapper = new PostViewMapper();

        public Post(PostViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0f);
            viewModel.Rating = (int)(newStep * 1);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is null)
            {
                return;
            }

            var post = await http.GetById<PostView>((e.Item as PostGridItem).Id);

            var filters = new PostFilters()
            {
                Category = post.Category,
                OnlyPublished = true,
            };
            var suggestedPosts = await http.Get<IEnumerable<PostView>>(filters);

            suggestedPosts = suggestedPosts.Take(3);

            var mappedSuggestedPosts = new List<PostGridItem>();
            foreach (var item in suggestedPosts)
            {
                mappedSuggestedPosts.Add(mapper.from(item));
            }

            await Navigation.PushAsync(new Post(
                new PostViewModel(
                    mapper.from(post),
                    mappedSuggestedPosts
                )
            ));
        }
    }
}