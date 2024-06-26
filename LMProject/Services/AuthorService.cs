using LMProject.Data;
using LMProject.DTOs.Books.Authors;
using LMProject.Interfaces;
using LMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _repo;
        private readonly ApplicationDbContext _db;

        public AuthorService(
            IAuthorRepository repo,
            ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        //var books = await _db.Books.Where(b => b.Id == request.BookId).ToListAsync();
        //Books = books
        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorRequest request)
        {
            var author = new AuthorsModel
            {
                Name = request.Name,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
            };

            await _repo.CreateAsync(author);

            return new AuthorDto
            {
                Id= author.Id,
                Name = request.Name,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };
        }
    }
}
