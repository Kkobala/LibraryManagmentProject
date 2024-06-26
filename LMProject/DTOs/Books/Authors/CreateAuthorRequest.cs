using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMProject.DTOs.Books.Authors
{
    public class CreateAuthorRequest
    {
        //public int Id { get; set; }
        //public int BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}