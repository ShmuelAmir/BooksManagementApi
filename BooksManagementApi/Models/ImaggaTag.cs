namespace BooksManagementApi.Models
{
    public class ImaggaTag
    {
        public int Id { get; set; }
        public required string Tag { get; set; }
        public double Confidence { get; set; }

        public virtual List<Book> Books { get; } = [];
    }
}
