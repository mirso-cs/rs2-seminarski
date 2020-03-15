using Stripe;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Source.net.mobile.Services;
using Source.net.mobile.Views;

namespace Source.net.mobile.ViewModels
{
    public class PaymentViewModel: BaseViewModel
    {
        private readonly PaymentHttpClient http = new PaymentHttpClient();
        public string CreditCardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string CVC { get; set; }
        private string StripeToken { get; set; }
        public ICommand PayCommand { get; set; }

        public PaymentViewModel()
        {
            PayCommand = new Command(async () => await Pay());
        }

        async Task Pay()
        {
            CreateToken();
            var user = await http.Pay(new infrastructure.Dtos.PaymentDto() { Token = StripeToken });
            HttpClient.Package = user.Package;
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Information", "Payment processed. Please navigate back.", "Ok");
        }

        void CreateToken()
        {
            StripeConfiguration.ApiKey = "pk_test_XQITpnlgCReQTLJhXjyRvGWg00BlI4nWtg";

            var tokenOptions = new TokenCreateOptions()
            {
                Card = new CreditCardOptions()
                {
                    Number = CreditCardNumber,
                    ExpYear = ExpiryYear,
                    ExpMonth = ExpiryMonth,
                    Cvc = CVC,
                    Currency = "EUR"
                }
            };

            var tokenService = new TokenService();
            Token stripeToken = tokenService.Create(tokenOptions);

            StripeToken = stripeToken.Id;
        }
    }
}
