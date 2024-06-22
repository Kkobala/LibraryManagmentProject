namespace LMProject.Models
{
    public class BooksAuthors
    {
        public int BookId { get; set; }
        public Books Book { get; set; }

        public int AuthorId { get; set; }
        public Authors Author { get; set; }
    }
}