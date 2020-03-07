using Source.net.desktop.Shared;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Source.net.desktop.Categories
{
    public partial class CategoriesForm : Form
    {
        private readonly HttpClient http = new HttpClient("category");

        public CategoriesForm()
        {
            InitializeComponent();
        }

        private async void CategoriesForm_Load(object sender, EventArgs e)
        {
            var categories = await http.Get<List<CategoryView>>();
            categoriesGrid.DataSource = categories; 
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ShowModal(null);
        }

        private void ShowModal(int? id)
        {
            var categoryForm = new CategoryForm(id);
            categoryForm.FormClosed += new FormClosedEventHandler(Reload);
            categoryForm.Show();
        }

        private async void Reload(object sender, EventArgs e)
        {
            var categories = await http.Get<List<CategoryView>>();
            categoriesGrid.DataSource = categories;
        }

        private async void filterButton_Click(object sender, EventArgs e)
        {
            var filters = new CategoryFilter() { Name = textName.Text };
            var categories = await http.Get<List<CategoryView>>(filters);
            categoriesGrid.DataSource = categories;
        }

        private void categoriesGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(categoriesGrid.SelectedRows[0].Cells[0].Value.ToString());
            ShowModal(id);
        }
    }
}
