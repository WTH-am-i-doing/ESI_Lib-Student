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
    public partial class Register : PopupPage
    {
        IFirebaseAuthentication auth;
        public Register()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuthentication>();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var token = auth.SignUp(email.Text, password.Text);
            if (token == null)
            {
                await DisplayAlert("Success","Your Account Has Been Created, You Can Now Login","ok");
                await PopupNavigation.Instance.PopAsync();
            }
            else
                await DisplayAlert("Error", "There Has Been An Error, Try Again", "ok");
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}