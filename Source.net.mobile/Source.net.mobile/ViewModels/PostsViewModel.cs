using Source.net.infrastructure.Views;
using Source.net.mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Source.net.mobile.ViewModels
{
    public class PostsViewModel: BaseViewModel
    {
        private readonly PostHttpClient http = new PostHttpClient("post");
        private readonly PostViewMapper mapper = new PostViewMapper();
        public ICommand LoadCommand { get; set; }
        public ObservableCollection<PostGridItem> Posts { get; set; } = new ObservableCollection<PostGridItem>();
        public ObservableCollection<PostGridItem> PopularPosts { get; set; } = new ObservableCollection<PostGridItem>();
        public PostsViewModel()
        {
            LoadCommand = new Command(async () => { await Load(); });
        }

        public async Task Load()
        {
            var posts = await http.GetAll();
            Posts.Clear();
            foreach(var p in posts)
            {
                Posts.Add(mapper.from(p));
            }

            var popularPosts = await http.GetPopular();
            PopularPosts.Clear();
            foreach (var p in popularPosts)
            {
                PopularPosts.Add(mapper.from(p));
            }

        }
    }
}
