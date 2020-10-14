using ESIBIB_Student.Models;
using ESIBIB_Student.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ESIBIB_Student.Persistence
{
    class BookSearchHandler : SearchHandler
    {
        public static SQLiteAsyncConnection _connection;
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            await _connection.CreateTableAsync<Book>();
            var books = await _connection.Table<Book>().ToListAsync();
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = books.Where(b =>
                {
                    return string.Concat(b.Title , " ",b.Author, " ",b.Description).ToLower().Contains(newValue.ToLower());
                }).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await (App.Current.MainPage as Xamarin.Forms.Shell).Navigation.PushAsync(new BookView(BooksList._connection,item as Book));
        }
    }
}
