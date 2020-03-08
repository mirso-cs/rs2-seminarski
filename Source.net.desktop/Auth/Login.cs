using System;
using System.Windows.Forms;
using Source.net.desktop.Shared;
using Source.net.infrastructure.Views;

namespace Source.net.desktop.Auth
{
    public partial class Login : Form
    {
        private readonly Authenticator auth = new Authenticator("user");
        public Login()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textEmail.Text;
            string password = textPassword.Text;

            try
            {
                AuthUser user = await auth.Login(email, password);

                if (string.IsNullOrWhiteSpace(user.Token))
                {
                    throw new Exception("Invalid credentials.");
                }

                HttpClient.Token = user.Token;
                HttpClient.RoleId = user.RoleId;
                HttpClient.UserId = user.Id;
                Close();
            } catch (Exception ex) {
                MessageBox.Show("Unable to login. Additional info: " + ex.Message);
            }
        }

        private void openRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Register();
            registerForm.Show();
        }
    }
}
