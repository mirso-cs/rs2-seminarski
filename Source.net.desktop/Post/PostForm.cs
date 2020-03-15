using Source.net.desktop.Shared;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Enums;
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
        private readonly ImageEncoder imageEncoder = new Base64ImageEncoder();

        public PostForm(int? id)
        {
            InitializeComponent();
            postId = id;
        }

        private async void PostForm_Load(object sender, EventArgs e)
        {
            cbxPublished.Visible = HttpClient.RoleId != Role.USER && postId.HasValue;

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
                    thumbnail.Image = imageEncoder.Decode(post.Thumbnail);
                }
            }

        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            try
            {

                var base64Image = thumbnail.Image != null ? imageEncoder.Encode(thumbnail.Image) : "";

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
            catch
            {
                MessageBox.Show("Invalid parameters sent.");
            }

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

        private void textTitle_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textTitle,
                string.IsNullOrWhiteSpace(textTitle.Text) ? Properties.Resources.required : null
            );
        }

        private void textSubtitle_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textSubtitle,
                string.IsNullOrWhiteSpace(textSubtitle.Text) ? Properties.Resources.required : null
            );
        }

        private void selectCategory_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                selectCategory,
                selectCategory.SelectedIndex == -1 ? Properties.Resources.required : null
            );
        }

        private void textContent_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textContent,
                string.IsNullOrWhiteSpace(textContent.Text) ? Properties.Resources.required : null
            );
        }
    }
}
