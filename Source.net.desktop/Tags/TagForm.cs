using Source.net.desktop.Shared;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using System;
using System.Windows.Forms;

namespace Source.net.desktop.Tags
{
    public partial class TagForm : Form
    {
        private readonly int? tagId;
        private readonly HttpClient http = new HttpClient("tag");

        public TagForm(int? id)
        {
            InitializeComponent();
            tagId = id;
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            var request = new TagDto();

            request.Name = textName.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new Exception("Name is required");
                }

                if (tagId.HasValue)
                {
                    await http.Update<TagView>(tagId, request);
                    MessageBox.Show("Tag updated. You can close this modal now.");
                }
                else
                {
                    await http.Insert<TagView>(request);
                    MessageBox.Show("Tag added. You can close this modal now.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save. Additional info: " + ex.Message);
            }
        }

        private async void TagForm_Load(object sender, EventArgs e)
        {
            if (tagId.HasValue)
            {
                var tag = await http.GetById<TagView>(tagId);

                textIdentifier.Text = tag.Id.ToString();
                textName.Text = tag.Name;
            }
        }
    }
}
