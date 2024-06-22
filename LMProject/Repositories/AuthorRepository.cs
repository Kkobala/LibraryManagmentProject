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

        public async Task<Authors> CreateAsync(Authors authorsModel){
            await _db.Authors.AddAsync(authorsModel);
            await _db.SaveChangesAsync();

            return authorsModel;
        }

        public async Task<List<Authors>> GetAllAsync()
        {
            return await _db.Authors.ToListAsync();
        }

        public async Task<Authors?> GetByIdAsync(int id)
        {
            return await _db.Authors
                .Include(b => b.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}