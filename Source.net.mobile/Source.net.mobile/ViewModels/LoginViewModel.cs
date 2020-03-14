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
    public class LoginViewModel : BaseViewModel
    {
        private readonly Authenticator authenticator = new Authenticator();
        public LoginViewModel()
        {
            Submit = new Command(async () => await Login());
            OnRegister = new Command(() =>
            {
                Application.Current.MainPage = new Register();
            });
        }

        string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public ICommand Submit { get; set; }
        public ICommand OnRegister { get; set; }
        async Task Login()
        {
            try
            {
                AuthUser user = await authenticator.Login(username, password);

                if (string.IsNullOrWhiteSpace(user.Token))
                {
                    throw new Exception("Invalid credentials.");
                }

                HttpClient.Token = user.Token;
                HttpClient.RoleId = user.RoleId;
                HttpClient.UserId = user.Id;
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "OK");
            }
        }
    }
}
