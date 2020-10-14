using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ESI_Admin
{
    class FirebaseHelper
    {
        FirebaseClient firebase= new FirebaseClient("https://esilib.firebaseio.com/");
        public FirebaseHelper()
        {

        }

        // Adding A Book To THe Firebase Database
        public async Task AddBook(Book book)
        {
            await firebase
              .Child("Book")
              .PostAsync(book);
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
        public async Task UpdateBook(string ISBN,Book bk,string key = null)
        {
            if(key == null) { 
                var toUpdateBook = (await firebase
                    .Child("Book")
                    .OnceAsync<Book>()).Where(a => a.Object.ISBN == ISBN).FirstOrDefault();
                key = toUpdateBook.Key;
            }
            await firebase
              .Child("Book")
              .Child(key)
              .PutAsync(bk);
        }

        //public async Task DeleteBook(string ISBN, string Title, Book bk, string key = null)
        //{
        //    QuerySnapshot snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
        //    IReadOnlyList<DocumentSnapshot> documents = snapshot.Documents;
        //    while (documents.Count > 0)
        //    {
        //        foreach (DocumentSnapshot document in documents)
        //        {
        //            Console.WriteLine("Deleting document {0}", document.Id);
        //            await document.Reference.DeleteAsync();
        //        }
        //        snapshot = await collectionReference.Limit(batchSize).GetSnapshotAsync();
        //        documents = snapshot.Documents;
        //    }
        //    Console.WriteLine("Finished deleting all documents from the collection.");
        //}



        // THis Gets All The Requests
        public async Task<List<Request>> GetRequests()
        {

            try
            {
                return (await firebase
               .Child("Book")
               .OnceAsync<Request>()).Select(item => new Request
               {
                   ReqKey = item.Key,
                   BookISBN = item.Object.BookISBN,
                   BookTitle = item.Object.BookTitle,
                   dateTime = item.Object.dateTime,
                   isAccepted = item.Object.isAccepted,
                   UserEmail = item.Object.UserEmail
               }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("GetUsers  Additional information..." + ex, ex);
            }
        }

        public async Task UpdateRequest(string key,bool yesno)
        {
            await firebase
              .Child("Requests")
              .Child(key)
              .Child("isAccepted").PutAsync(yesno);
        }

    }
}
