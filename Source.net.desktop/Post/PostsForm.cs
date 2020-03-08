using Source.net.desktop.Shared;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.net.desktop.Post
{
    public partial class PostsForm : Form
    {
        private readonly HttpClient http = new HttpClient("post");
        private readonly HttpClient categoryHttp = new HttpClient("category");
        private readonly HttpClient tagHttp = new HttpClient("tag");

        public PostsForm()
        {
            InitializeComponent();
        }

        private async void PostsForm_Load(object sender, EventArgs e)
        {

            await LoadPosts();

            var categories = await categoryHttp.Get<List<CategoryView>>();
            foreach (var item in categories)
            {
                selectCategory.Items.Add(item.Name);
            }

            var tags = await tagHttp.Get<List<TagView>>();
            foreach (var item in tags)
            {
                selectTag.Items.Add(item.Name);
            }
        }

        private async void filterButton_Click(object sender, EventArgs e)
        {
            await LoadPosts(new PostFilters()
            {
                Category = (string)selectTag.SelectedValue,
                OnlyPublished = cbxPublished.Checked,
                OnlyUnpublished = cbxUnpublished.Checked,
                Since = dateTimeSince.Value,
                Until = dateTimeUntil.Value,
                Tag = (string)selectTag.SelectedValue,
                Title = textTitle.Text
            });
        }

        private async Task LoadPosts(PostFilters filters = null)
        {
            var posts = await http.Get<List<PostView>>(filters);
            postsGrid.DataSource = postsGrid.DataSource = MapPostsToGrid(posts);
        }

        private void postsGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(postsGrid.SelectedRows[0].Cells[0].Value.ToString());
            ShowModal(id);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ShowModal();
        }

        private void ShowModal(int? id = null)
        {
            var postForm = new PostForm(id);
            postForm.Show();
            postForm.FormClosed += new FormClosedEventHandler(LoadPosts);
        }

        private async void LoadPosts(object sender, EventArgs e)
        {
            var posts = await http.Get<List<PostView>>();
           
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
    }
}
