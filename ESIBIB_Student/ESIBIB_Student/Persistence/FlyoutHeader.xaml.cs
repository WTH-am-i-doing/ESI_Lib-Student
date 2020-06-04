using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIBIB_Student.Persistence
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeader : ContentView
    {
        public FlyoutHeader()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (true) //# If He's Logged In Then Take Him To A Page Where He See His Email And Maybe Change His Password (in The Future)
                //# And Of Course He See The Books He has Taken Last And ONly One Book 
            {
                await PopupNavigation.Instance.PushAsync(new ESIBIB_Student.Views.PopUps.Login());
            }
        }
    }
}