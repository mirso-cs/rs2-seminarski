using Source.net.desktop.Post;
using Source.net.desktop.Shared;
using Source.net.infrastructure.Enums;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.net.desktop.Dashboard
{
    public partial class UserDashboardForm : Form
    {
        private readonly StatisticsHttpClient http = new StatisticsHttpClient("statistics");
        private readonly int id;
        public UserDashboardForm()
        {
            InitializeComponent();
            this.id = HttpClient.UserId;
        }

        private async void UserDashboardForm_Load(object sender, EventArgs e)
        {
            var totalPosts = await http.GetTotalCountForType("post/" + id);
            var avgRating = await http.GetAverageUserRating(id);
            var posts = await http.GetUserBestPosts(id);

            textPostCount.Text = totalPosts.Count.ToString();
            textAvgRating.Text = avgRating.Value.ToString();
            textAccType.Text = HttpClient.RoleId == Role.USER ? "User" : "Admin";

            postsGrid.DataSource = MapPostsToGrid(posts);
        }

        private List<PostGridItem> MapPostsToGrid(List<PostView> posts)
        {
            List<PostGridItem> items = new List<PostGridItem>();
            foreach (var post in posts)
            {
                items.Add(new PostGridItem
                {
                    Id = post.id,
                    Published = post.Published,
                    Subtitle = post.Subtitle,
                    Tags = string.Join(", ", post.Tags.Select(x => x.Name).ToArray()),
                    Title = post.Title,
                    Category = post.Category,
                    Author = post.User
                });
            }

            return items;
        }

        private void postsGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(postsGrid.SelectedRows[0].Cells[0].Value.ToString());
            var postForm = new PostForm(id);
            postForm.Show();
            postForm.FormClosed += new FormClosedEventHandler(LoadPosts);
        }

        private async void LoadPosts(object sender, EventArgs e)
        {
            var posts = await http.GetUserBestPosts(id);

            postsGrid.DataSource = MapPostsToGrid(posts);
        }
    }
}
