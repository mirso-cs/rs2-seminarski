using Source.net.desktop.Shared;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using System;
using System.Windows.Forms;

namespace Source.net.desktop.Categories
{
    public partial class CategoryForm : Form
    {
        private readonly HttpClient http = new HttpClient("category");
        private readonly int? categoryId;

        public CategoryForm(int? id)
        {
            categoryId = id;
            InitializeComponent();
        }

        private async void submitButton_Click(object sender, System.EventArgs e)
        {
            var request = new CategoryDto();
            request.Name = textName.Text;

            try
            {
                if(string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new Exception("Name is required.");
                }

                if(categoryId.HasValue)
                {
                    await http.Update<CategoryView>(categoryId, request);
                    MessageBox.Show("Category updated. You can close this windown now.");
                }
                else
                {
                    await http.Insert<CategoryView>(request);
                    MessageBox.Show("Category added. You can close this windown now.");
                }

            } catch (Exception ex)
            {
                MessageBox.Show("Failed tosave category. Additional info: " + ex.Message);
            }
        }

        private async void CategoryForm_Load(object sender, System.EventArgs e)
        {
            if(categoryId.HasValue)
            {
                var category = await http.GetById<CategoryView>(categoryId);
                textIdentifier.Text = category.id.ToString();
                textName.Text = category.Name;
            }
        }
    }
}
