using Source.net.desktop.Shared;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Source.net.desktop.Post
{
    public partial class PostsForm : Form
    {
        private readonly HttpClient http = new HttpClient("post");
        public PostsForm()
        {
            InitializeComponent();
        }

        private async void PostsForm_Load(object sender, EventArgs e)
        {
            var posts = await http.Get<List<PostView>>();
            List<PostGridItem> items = new List<PostGridItem>();
            foreach(var post in posts)
            {
                items.Add(new PostGridItem {
                    Published = post.Published,
                    Subtitle = post.Subtitle,
                    Tags = string.Join(", ", post.Tags.Select(x => x.name).ToArray()),
                    Thumbnail = post.Thumbnail,
                    Title = post.Title
                });
            }
            postsGrid.DataSource = items;
        }
    }
}
