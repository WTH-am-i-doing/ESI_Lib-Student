using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    class FirebaseHelper
    {
        FirebaseClient firebase= new FirebaseClient("https://esilib.firebaseio.com/");
        public FirebaseHelper()
        {

        }

        // Adding A Book To THe Firebase Database
        public async Task AddBook(string Title, string Writer, string Description,string isbn,int available,string coverurl)
        {
            await firebase
              .Child("Book")
              .PostAsync(new Book() { Title = Title, Author = Writer, Description = Description ,Available = available,Coverurl = coverurl,ISBN=isbn});
        
        }


        // Getting All The Books That Are Saved in The Database
        public async Task<List<Book>> GetAllBooks()
        {

            try
            {
                return (await firebase
               .Child("Book")
               .OnceAsync<Book>()).Select(item => new Book
               {
                   Title = item.Object.Title,
                   Author = item.Object.Author,
                   Description = item.Object.Description,
                   ISBN = item.Object.ISBN,
                   Coverurl = item.Object.Coverurl,
                   Available= item.Object.Available,
               }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("GetUsers  Additional information..." + ex, ex);
            }
        }


        // Getting A Book By Its ISBN Number
        public async Task<Book> GetBook(string ISBN)
        {
            var allBooks = await GetAllBooks();
            await firebase
              .Child("Book")
              .OnceAsync<Book>();
            return allBooks.Where(a => a.ISBN == ISBN).FirstOrDefault();
        }



        // Updating A Book 
        public async Task UpdateBook(string ISBN,Book bk)
        {
            var toUpdateBook = (await firebase
              .Child("Book")
              .OnceAsync<Book>()).Where(a => a.Object.ISBN == ISBN).FirstOrDefault();

            await firebase
              .Child("Book")
              .Child(toUpdateBook.Key)
              .PutAsync(bk);
        }

    }
}
