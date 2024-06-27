using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMProject.DTOs.Books
{
    public class CreateBookRequest
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be over 5 characters")]
        [MaxLength(100, ErrorMessage = "Title cannot be over 100 characters")]
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}