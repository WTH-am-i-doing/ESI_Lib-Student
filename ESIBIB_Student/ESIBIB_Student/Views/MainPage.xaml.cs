using ESIBIB_Student.Views;
using ESIBIB_Student.Views.PopUps;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ESIBIB_Student
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private CarouselItem item = new CarouselItem() { 
            carouselItms= new List<CarouselItm>
            {
                new CarouselItm
                {
                    imgurl="https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/De_La_Salle_College_of_Saint_Benilde_Library.jpg/1200px-De_La_Salle_College_of_Saint_Benilde_Library.jpg",
                    title ="The Whole Library Catalogue",
                    description="If you are looking for a book in the library, Just look it up here instead of going to the actual library"
                },
                new CarouselItm
                {
                    imgurl="https://www.quickenloans.com/blog/wp-content/uploads/2016/01/Young-man-standing-on-the-street-corner-looking-at-cell-phone-e1508770152120.png",
                    title ="Offline Viewing",
                    description="The Books List is Always Available in Your Pocket Whenever You Need It Even if You Are Offline"
                },
                new CarouselItm
                {
                    imgurl="https://images.wisegeek.com/man-looking-at-books-on-shelf-in-store.jpg",
                    title ="Find Any Book You Want",
                    description="You Can Look For The Books You Want"
                }
            }
        };
        public MainPage()
        {
            InitializeComponent();
            BindingContext = item;
            
        }

        private  void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ShellPage();
            //await Navigation.PushAsync(new ShellPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            // Here Goes The Code For Extra Features That Needs The Student To Be Logged In To BE Exact Here Goes The COnnect to google part
            
            await PopupNavigation.Instance.PushAsync(new Login());
        }
    }

    class CarouselItem
    {
        public List<CarouselItm> carouselItms { get; set; }
    }

    internal class CarouselItm
    {
        public string imgurl { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
