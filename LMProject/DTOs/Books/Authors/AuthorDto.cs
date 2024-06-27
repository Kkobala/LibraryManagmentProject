using System.ComponentModel.DataAnnotations;

namespace LMProject.DTOs.Books.Authors
{
    public record AuthorDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot be over 20 Characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Name cannot be over 30 Characters")]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public List<BookDto> Books { get; set; } = [];
    }
}