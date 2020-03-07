using Source.net.infrastructure.Views;
using System;
using System.Windows.Forms;

namespace Source.net.desktop.User
{
    public partial class UserForm : Form
    {
        private readonly UserHttpClient http = new UserHttpClient("user");
        private readonly int userId;
        private UserView user;

        public UserForm(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            user = await http.GetById<UserView>(userId);

            textName.Text = user.Name;
            textEmail.Text = user.Email;
            textUsername.Text = user.Username;

            cbxActive.Checked = user.Active;
            cbxAdmin.Enabled = !user.isSA();
            cbxAdmin.Checked = user.isAdmin();
        }

        private async void cbxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            var targetRole = cbxAdmin.Checked ? infrastructure.Enums.Role.ADMIN : infrastructure.Enums.Role.USER;
            await http.UpdateRole(userId, targetRole);
        }

        private async void cbxActive_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxActive.Checked)
            {
                await http.Activate(userId);
            } 
            else
            {
                await http.Deactivate(userId);
            }
        }
    }
}
