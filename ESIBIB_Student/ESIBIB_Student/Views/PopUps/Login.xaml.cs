using ESIBIB_Student.Models;
using ESIBIB_Student.Persistence;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIBIB_Student.Views.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : PopupPage
    {
        LoginViewModel viewModel;
        IFirebaseAuthentication auth;

        public Login()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuthentication>();
            BindingContext = viewModel = new LoginViewModel();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            
            await PopupNavigation.Instance.PushAsync(new Register());
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
        string token = await auth.LoginWithEmailAndPassword(viewModel.Username, viewModel.Password);
            if (token != string.Empty)
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                ShowError();
            }
             async void ShowError()
            {
                await DisplayAlert("Authentication Failed", "Email or password are incorrect. Try again!", "OK");
            }
        }
    }
}