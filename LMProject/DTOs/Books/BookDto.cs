using System.ComponentModel.DataAnnotations;
using LMProject.DTOs.Books.Authors;
using LMProject.Models;

namespace LMProject.DTOs.Books
{
    public record BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<AuthorDto> Authors { get; set; } = [];
    }
}