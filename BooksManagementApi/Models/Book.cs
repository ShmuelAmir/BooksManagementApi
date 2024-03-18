namespace BooksManagementApi.Models
{
    public class Book
    {
        public int ISBN { get; set; }
        public required string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
