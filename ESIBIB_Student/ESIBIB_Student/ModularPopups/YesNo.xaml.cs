using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIBIB_Student.ModularPopups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YesNo : PopupPage
    {
        public YesNo(string text,bool yes)
        { // Not Finished
            InitializeComponent();
            Text.Text = text;
        }

        private void Button_Clicked_0(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}