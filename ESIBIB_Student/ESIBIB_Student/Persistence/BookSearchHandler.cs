﻿using ESIBIB_Student.Models;
using ESIBIB_Student.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ESIBIB_Student.Persistence
{
    class BookSearchHandler : SearchHandler
    {
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            FirebaseHelper helper = new FirebaseHelper();
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = (await helper.GetAllBooks()).Where(b =>
                {
                    return string.Concat(b.Title , " ",b.Author, " ",b.Description).ToLower().Contains(newValue.ToLower());
                }).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Note: strings will be URL encoded for navigation (e.g. "Blue Monkey" becomes "Blue%20Monkey"). Therefore, decode at the receiver.
            await (App.Current.MainPage as Xamarin.Forms.Shell).Navigation.PushAsync(new BookView(BooksList._connection,item as Book));
        }
    }
}
