using Source.net.desktop.Shared;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.net.desktop.User
{

    public partial class UsersForm : Form
    {
        private readonly HttpClient http = new UserHttpClient("user");

        public UsersForm()
        {
            InitializeComponent();
        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async void buttonFilter_Click(object sender, EventArgs e)
        {
            var filters = new UserFilters();
            filters.Username = textUsername.Text;
            filters.Email = textEmail.Text;
            await LoadUsers(filters);
        }

        private async Task LoadUsers(UserFilters filters = null)
        {
            try
            {
                var users = await http.Get<List<UserView>>(filters);
                usersGrid.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void usersGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(usersGrid.SelectedRows[0].Cells[0].Value.ToString());
            var userForm = new UserForm(id);
            userForm.Show();
        }
    }
}
