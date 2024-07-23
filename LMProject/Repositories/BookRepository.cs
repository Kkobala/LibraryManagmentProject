using LMProject.Data;
using LMProject.DTOs.Books;
using LMProject.Helpers;
using LMProject.Interfaces;
using LMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<bool> BookExist(int id)
        {
            return _db.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<Books> CreateAsync(Books booksModel)
        {
            await _db.Books.AddAsync(booksModel);
            await _db.SaveChangesAsync();
            return booksModel;
        }

        public async Task<Books?> DeleteAsync(int id)
        {
            var book = await _db.Books
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                throw new ArgumentNullException($"Book with {id} ID cannot be found");
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<List<Books>> GetAllAsync(QueryObject query)
        {
            var book = _db.Books.Include(b => b.AuthorsBooks).ThenInclude(a => a.Author).AsQueryable();

            //to search books with title
            if(!string.IsNullOrWhiteSpace(query.Title)){
                book = book.Where(b => b.Title.Contains(query.Title));
            }

            //sort books by title
            if(!string.IsNullOrWhiteSpace(query.SortBy)){
                if(query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase)){
                    book = query.IsDescending ? book.OrderByDescending(b => b.Title) : book.OrderBy(b => b.Title); 
                }
            }

            //pagination
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await book.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Books?> GetById(int id)
        {
            var book = await _db.Books
            .Include(a => a.AuthorsBooks)
            .ThenInclude(ab => ab.Author)
            .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                throw new ArgumentNullException($"Book with {id} ID cannot be found");
            }

            return book;
        }

        public async Task<Books?> UpdateAsync(int id, UpdateBookRequestDto bookDto)
        {
            var book = await _db.Books
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                throw new ArgumentNullException($"Book with {id} ID cannot be found");
            }

            book.Description = bookDto.Description;
            book.Title = bookDto.Title;
            book.PublishedDate = bookDto.PublishedDate;

            await _db.SaveChangesAsync();
            return book;
        }
    }
}