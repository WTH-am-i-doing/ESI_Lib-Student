﻿using ESIBIB_Student.Models;
using ESIBIB_Student.Persistence;
using ESIBIB_Student.Views.PopUps;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIBIB_Student.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookView : ContentPage
    {
        private readonly SQLiteAsyncConnection connection;
        private readonly Book bk;
        private FirebaseHelper FirebaseHelper = new FirebaseHelper();

        public BookView(SQLiteAsyncConnection _connection,Book bk)
        {
            if (bk == null)
                throw new ArgumentNullException();
            InitializeComponent();
            if (bk.isFavorite)
                Fav.TextColor = Color.Red;
            else
                Fav.TextColor = Color.Gray;
            if(bk.Available == 0)
            {
                Requesting.IsVisible = false;
            }
            BindingContext = bk;
            connection = _connection;
            this.bk = bk;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Fav_Clicked(object sender, EventArgs e)
        {
            bk.isFavorite = !bk.isFavorite;
            await connection.UpdateAsync(bk);
            if (bk.isFavorite)
                Fav.TextColor = Color.Red;
            else
                Fav.TextColor = Color.Gray;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool loggedin = true;// Here Put The Boolean Method that Checks If He's Logged In
            if (loggedin)
            {
                bool yesno = await DisplayAlert("Sending Request", "Are You Sure You Want To Request This Book ?", "Yes", "No");// Depending On His Answer
                if (yesno)
                {
                    var Req = new Request() {
                        UserEmail = "EMAIL",
                        BookISBN = bk.ISBN,
                        BookTitle = bk.Title,
                        dateTime = DateTime.Now,
                    };
                    await FirebaseHelper.AddRequest(Req);
                    await DisplayAlert("Success", "Your Request Has Been Sent", "Ok");
                }
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new Login());
            }
        }
    }
}