using LMProject.Data;
using LMProject.DTOs.Books;
using LMProject.Interfaces;
using LMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;
        private readonly IBookRepository _repo;

        public BookService(
            IBookRepository repo,
            ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookRequest request)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId);

            var bookDto = new Books
            {
                Title = request.Title,
                PublishedDate = request.PublishedDate,
                Description = request.Description,
                AuthorId = request.AuthorId,
                AuthorsBooks = new List<JoinTables>
                {
                    new JoinTables
                    {
                        AuthorId = author!.Id
                    }
                }
            };

            await _repo.CreateAsync(bookDto);

            return new BookDto
            {
                Id = bookDto.Id,
                Title = request.Title,
                PublishedDate = request.PublishedDate,
                Description = request.Description,
                Authors = new List<AuthorsModel> { author }
            };
        }
    }
}
