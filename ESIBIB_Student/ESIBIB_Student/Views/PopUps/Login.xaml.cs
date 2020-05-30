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
        public Login()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            try { 
            //await PopupNavigation.Instance.RemovePageAsync(this);
            }
            catch
            {

            }
            await PopupNavigation.Instance.PushAsync(new Register());
        }
    }
}