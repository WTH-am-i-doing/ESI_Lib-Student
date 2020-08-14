using ESIBIB_Student.Models;
using ESIBIB_Student.Persistence;
using Firebase.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIBIB_Student.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksList : ContentPage
    {
        private ObservableCollection<Book> _books;
        public static SQLiteAsyncConnection _connection;

        internal ObservableCollection<Book> Books { get => _books; set => _books = value; }

        FirebaseHelper firebaseHelper = new FirebaseHelper();


        public BooksList()
        {
            InitializeComponent();
            bookList_Refreshing(null, null);
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _connection.CreateTableAsync<Book>();
            var books = await _connection.Table<Book>().ToListAsync();
            _books = new ObservableCollection<Book>(books);
            bookList.ItemsSource = _books;
        }

        private async void bookList_Refreshing(object sender, EventArgs e)
        {
            try { 
                var allBOOKs = await firebaseHelper.GetAllBooks();
                //# var favs = _books.Where(b => b.isFavorite);
                await _connection.DropTableAsync<Book>();
                await _connection.CreateTableAsync<Book>();
                await _connection.InsertAllAsync(allBOOKs);
                bookList.ItemsSource = allBOOKs;
            }
            catch
            {
                await DisplayAlert("Problem", "Currently you Don't Have An Internet Connexion So We Won't Able To Laod New Books, When You Connect Please Reload The App. Thankfully You Will Be able to See The Saved Books", "Ok");
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            Book book = item.CommandParameter as Book;
            book.isFavorite = true;
            await _connection.UpdateAsync(book);
        }


        private async void bookList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Book;
            await Shell.Current.Navigation.PushAsync(new BookView(_connection,book));
        }

        private async void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var book = e.CurrentSelection.First() as Book;
            await Shell.Current.Navigation.PushAsync(new BookView(_connection, book));
        }
    }
}