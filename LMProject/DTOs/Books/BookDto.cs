using LMProject.Models;

namespace LMProject.DTOs.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        //public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<AuthorsModel> Authors { get; set; }
    }
}