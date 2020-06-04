namespace ESI_Admin
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Available { get; set; }
        public string Coverurl { get; set; }
        public string ISBN { get; set; }

        
        public override string ToString()
        {
            return $"{Title} - by {Author} --- {ISBN}";
        }
    }
}