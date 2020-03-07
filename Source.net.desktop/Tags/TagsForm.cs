using Source.net.desktop.Shared;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Source.net.desktop.Tags
{
    public partial class TagsForm : Form
    {
        private readonly HttpClient http = new HttpClient("tag");

        public TagsForm()
        {
            InitializeComponent();
        }

        private async void TagsForm_Load(object sender, EventArgs e)
        {
            var tags = await http.Get<List<TagView>>();
            tagsGrid.DataSource = tags;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ShowModal(null);
        }

        private void ShowModal(int? id)
        {
            var tagForm = new TagForm(id);
            tagForm.FormClosed += new FormClosedEventHandler(Reload);
            tagForm.Show();
        }

        private async void Reload(object sender, EventArgs e)
        {
            var tags = await http.Get<List<TagView>>();
            tagsGrid.DataSource = tags;
        }

        private async void filterButton_Click(object sender, EventArgs e)
        {
            var filters = new TagFilters() { Name = textName.Text };
            var tags = await http.Get<List<TagView>>(filters);
            tagsGrid.DataSource = tags;
        }

        private void tagsGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(tagsGrid.SelectedRows[0].Cells[0].Value.ToString());
            ShowModal(id);
        }
    }
}
