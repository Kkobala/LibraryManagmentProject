using LMProject.Data;
using LMProject.Interfaces;
using LMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;   
        }

        public async Task<AuthorsModel> CreateAsync(AuthorsModel authorsModel){
            await _db.Authors.AddAsync(authorsModel);
            await _db.SaveChangesAsync();

            return authorsModel;
        }

        public async Task<List<AuthorsModel>> GetAllAsync()
        {
            return await _db.Authors.ToListAsync();
        }

        public async Task<AuthorsModel?> GetByIdAsync(int id)
        {
            return await _db.Authors
                .Include(b => b.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<AuthorsModel>> GetAuthorWithBooks(Books books)
        {
            return await _db.JoinedTables
                .Where(b => b.BookId == books.Id)
                .Select(author => new AuthorsModel
                {
                    Id = author.AuthorId,
                    Books = author.Author.Books,
                    Name = author.Author.Name,
                    LastName = author.Author.LastName,
                    DateOfBirth = author.Author.DateOfBirth,
                }).ToListAsync();
        }
    }
}