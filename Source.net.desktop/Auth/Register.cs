using Source.net.infrastructure.Dtos;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Source.net.desktop.Auth
{
    public partial class Register : Form
    {
        private readonly Authenticator authenticator = new Authenticator("user");

        public Register()
        {
            InitializeComponent();
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            var request = new RegisterDto()
            {
                Name = textName.Text,
                Surname = textSurname.Text,
                Email = textEmail.Text,
                Username = textUsername.Text,
                Password = textPassword.Text
            };

            try
            {
                await authenticator.Register(request);
                MessageBox.Show("Registration successful. Please use credentials to login.");
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to register. Additional info: " + ex.Message);
            }
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textName,
                string.IsNullOrWhiteSpace(textName.Text) ? Properties.Resources.required : null
            );
        }

        private void textSurname_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textSurname,
                string.IsNullOrWhiteSpace(textSurname.Text) ? Properties.Resources.required : null
            );
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            var validator = new EmailAddressAttribute();

            if (string.IsNullOrWhiteSpace(textEmail.Text))
            {
                errorProvider.SetError(
                    textEmail,
                    Properties.Resources.required
                );
            }
            else if (!validator.IsValid(textEmail.Text))
            {
                errorProvider.SetError(
                    textEmail,
                    Properties.Resources.email_format
                );
            }
            else
            {
                errorProvider.SetError(textEmail, null);
            }
        }

        private void textUsername_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textUsername,
                string.IsNullOrWhiteSpace(textUsername.Text) ? Properties.Resources.required : null
            );
        }

        private void textPassword_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(
                textPassword,
                string.IsNullOrWhiteSpace(textPassword.Text) ? Properties.Resources.required : null
            );
        }

        private void textPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                errorProvider.SetError(
                    textPasswordConfirm,
                    Properties.Resources.required
                );
            }
            else if (!string.IsNullOrWhiteSpace(textPassword.Text) && textPassword.Text != textPasswordConfirm.Text)
            {
                errorProvider.SetError(
                    textPasswordConfirm,
                    Properties.Resources.password_confirm
                );
            } else
            {
                errorProvider.SetError(textPasswordConfirm, null);
            }
        }
    }
}
