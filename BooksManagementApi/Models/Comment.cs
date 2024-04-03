namespace BooksManagementApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
