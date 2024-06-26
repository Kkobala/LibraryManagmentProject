using System.ComponentModel.DataAnnotations;

namespace LMProject.Models
{
    public class AuthorsModel
    {
        [Key]
        public int Id { get; set; }
        //public int BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public List<Books> Books { get; set; } = [];
        public List<JoinTables> AuthorsBooks { get; set; } = [];
    }
}