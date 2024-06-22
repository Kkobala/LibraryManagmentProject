using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMProject.DTOs.Books
{
    public class CreateBookRequest
    {
        //public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<int> AuthorIds { get; set; }
    }
}