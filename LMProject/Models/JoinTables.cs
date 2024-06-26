namespace LMProject.Models
{
    public class JoinTables
    {
        public int BookId { get; set; }
        public Books Book { get; set; } = null;

        public int AuthorId { get; set; }
        public AuthorsModel Author { get; set; } = null;
    }
}