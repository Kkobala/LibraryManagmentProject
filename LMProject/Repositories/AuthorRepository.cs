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
            return await _db.Authors
                .Include(ab => ab.AuthorsBooks)
                .ThenInclude(b => b.Book)
                .ToListAsync();
        }

        public async Task<AuthorsModel?> GetByIdAsync(int id)
        {
            return await _db.Authors
                .Include(ab => ab.AuthorsBooks)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}