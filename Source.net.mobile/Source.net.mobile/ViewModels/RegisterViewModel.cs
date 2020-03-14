using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Views;
using Source.net.mobile.Services;
using Source.net.mobile.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Source.net.mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly Authenticator authenticator = new Authenticator();
        public RegisterViewModel()
        {
            Submit = new Command(async () => await Register());
        }

        string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string surname = string.Empty;
        public string Surname
        {
            get { return surname; }
            set { SetProperty(ref surname, value); }
        }

        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        
        string confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public ICommand Submit { get; set; }

        async Task Register()
        {
            try
            {
                if(ConfirmPassword != Password)
                {
                    throw new Exception("Passwords do not match.");
                }

                var request = new RegisterDto()
                {
                    Email = Email,
                    Name = Name,
                    Password = Password,
                    Surname = Surname,
                    Username = Username
                };

                await authenticator.Register(request);

                Application.Current.MainPage = new Login();
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid information passed", "OK");
            }
        }
    }
}
