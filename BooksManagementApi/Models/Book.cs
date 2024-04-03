namespace BooksManagementApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public string Cover { get; set; } = string.Empty;
        public int Pages { get; set; }
        public float Rating { get; set; }
        public List<ImaggaTag> Tags { get; } = [];
        public List<Comment> Comments { get; } = [];
    }
}
