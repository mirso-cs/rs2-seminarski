using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Source.net.mobile.Services;
using Source.net.mobile.Views;

namespace Source.net.mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
