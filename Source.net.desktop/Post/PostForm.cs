using Source.net.desktop.Shared;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.net.desktop.Post
{
    public partial class PostForm : Form
    {
        private readonly int? postId;
        private readonly HttpClient postHttp = new HttpClient("post");
        private readonly HttpClient categoryHttp = new HttpClient("category");

        public PostForm(int? id)
        {
            InitializeComponent();
            postId = id;
        }

        private async void PostForm_Load(object sender, EventArgs e)
        {
            cbxPublished.Visible = HttpClient.RoleId != infrastructure.Enums.Role.USER;

            var categories = await categoryHttp.Get<List<CategoryView>>();
            foreach (var item in categories)
            {
                selectCategory.Items.Add(item);
            }


            if (postId.HasValue)
            {
                var post = await postHttp.GetById<PostView>(postId);
                textTitle.Text = post.Title;
                textSubtitle.Text = post.Subtitle;
                textTags.Text = string.Join(", ", post.Tags.Select(x => x.Name).ToArray());
                textContent.Text = post.Content;

                foreach (CategoryView item in selectCategory.Items)
                {
                    if (item.id == post.CategoryId)
                    {
                        selectCategory.SelectedItem = item;
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(post.Thumbnail))
                {

                    var pic = Convert.FromBase64String(post.Thumbnail);
                    using (MemoryStream ms = new MemoryStream(pic))
                    {
                        thumbnail.Image = Image.FromStream(ms);
                    }
                }
            }

        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            var base64Image = "";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                thumbnail.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = memoryStream.ToArray();
                base64Image = Convert.ToBase64String(imageBytes);
            }

            if (postId.HasValue)
            {
                var updatePostDto = new UpdatePostDto()
                {
                    CategoryId = ((CategoryView)selectCategory.SelectedItem).id,
                    Content = textContent.Text,
                    Subtitle = textSubtitle.Text,
                    Title = textTitle.Text,
                    Tags = textTags.Text.Split(','),
                    Thumbnail = base64Image,
                    Published = cbxPublished.Checked
                };

                await postHttp.Update<PostView>(postId, updatePostDto);
                MessageBox.Show("Post updated.");
            }
            else
            {
                var createPostDto = new CreatePostDto()
                {
                    CategoryId = ((CategoryView)selectCategory.SelectedItem).id,
                    Content = textContent.Text,
                    Subtitle = textSubtitle.Text,
                    Title = textTitle.Text,
                    Tags = textTags.Text.Split(','),
                    Thumbnail = base64Image
                };

                await postHttp.Insert<PostView>(createPostDto);
                MessageBox.Show("Post added.");
            }

            Close();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog
            {
                Filter = "Image files (*.jpg; *.jpeg; *.gif; *.png) | *.jpg; *.jpeg; *.gif; *.png",
                Multiselect = false
            };

            if (Open.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(Open.FileName);
                var bitmap = new Bitmap(image, thumbnail.Width, thumbnail.Height);
                thumbnail.Image = bitmap;
            }
        }
    }
}
