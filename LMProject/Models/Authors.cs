using System.ComponentModel.DataAnnotations;

namespace LMProject.Models
{
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        //public int BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public ICollection<Books> Books { get; set; }
    }
}