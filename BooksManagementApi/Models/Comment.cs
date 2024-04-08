namespace BooksManagementApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }

        public int BookId { get; set; }
    }
}
