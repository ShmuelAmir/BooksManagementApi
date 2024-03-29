namespace BooksManagementApi.Models
{
    public class Book
    {
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public string Cover { get; set; } = string.Empty;
        public int Pages { get; set; }
        public float Rating { get; set; }
    }
}
