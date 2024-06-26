namespace LMProject.DTOs.Books.Authors
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public List<BookDto> Books { get; set; }
    }
}