using Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESI_Admin
{
    class Isbn
    {
        private const string url = "https://www.googleapis.com/books/v1/volumes?q=isbn:";


        public static async Task<Book> GetBook(string isbn)
        {
            using (var httpClient = new HttpClient())
            {
                string uri = url + isbn;
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);

                var test = response;

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            var _elet = JsonConvert.DeserializeObject<Rootobject>(json);
                            var book = _elet.items[0].volumeInfo;
                            Book bk = new Book { Title = book.title, Description = book.description, Author = book.authors[0], ISBN = isbn, Coverurl = _elet.items[0].volumeInfo.imageLinks.thumbnail };
                            return bk;
                        }
                        catch
                        {
                            Console.Write("Couldn't Find The Books");
                        }
                    }

                }
                return null;
            }
        }
    }

    public class Rootobject
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public string selfLink { get; set; }
        public Volumeinfo volumeInfo { get; set; }
        public Saleinfo saleInfo { get; set; }
        public Accessinfo accessInfo { get; set; }
        public Searchinfo searchInfo { get; set; }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string[] authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public Industryidentifier[] industryIdentifiers { get; set; }
        public Readingmodes readingModes { get; set; }
        public int pageCount { get; set; }
        public string printType { get; set; }
        public string maturityRating { get; set; }
        public bool allowAnonLogging { get; set; }
        public string contentVersion { get; set; }
        public Panelizationsummary panelizationSummary { get; set; }
        public Imagelinks imageLinks { get; set; }
        public string language { get; set; }
        public string previewLink { get; set; }
        public string infoLink { get; set; }
        public string canonicalVolumeLink { get; set; }
    }

    public class Readingmodes
    {
        public bool text { get; set; }
        public bool image { get; set; }
    }

    public class Panelizationsummary
    {
        public bool containsEpubBubbles { get; set; }
        public bool containsImageBubbles { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }

    public class Industryidentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public class Saleinfo
    {
        public string country { get; set; }
        public string saleability { get; set; }
        public bool isEbook { get; set; }
    }

    public class Accessinfo
    {
        public string country { get; set; }
        public string viewability { get; set; }
        public bool embeddable { get; set; }
        public bool publicDomain { get; set; }
        public string textToSpeechPermission { get; set; }
        public Epub epub { get; set; }
        public Pdf pdf { get; set; }
        public string webReaderLink { get; set; }
        public string accessViewStatus { get; set; }
        public bool quoteSharingAllowed { get; set; }
    }

    public class Epub
    {
        public bool isAvailable { get; set; }
    }

    public class Pdf
    {
        public bool isAvailable { get; set; }
    }

    public class Searchinfo
    {
        public string textSnippet { get; set; }
    }

}
