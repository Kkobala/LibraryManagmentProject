using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMProject.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        //public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;


        public ICollection<Authors> Authors { get; set; }
    }
}