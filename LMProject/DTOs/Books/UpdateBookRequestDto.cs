using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMProject.DTOs.Books
{
    public class UpdateBookRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}