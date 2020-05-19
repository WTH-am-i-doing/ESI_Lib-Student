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
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            // Try And Send An Email To The User's Email And When He Enters The Email He Gets Added 
            // To The Firebase Database
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            await PopupNavigation.Instance.PushAsync(new Login());
        }
    }
}