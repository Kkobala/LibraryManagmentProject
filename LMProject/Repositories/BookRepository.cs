using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Data;
using LMProject.DTOs.Books;
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

        public async Task<List<Books>> GetAllAsync()
        {
            return await _db.Books
            .Include(b => b.Authors)
            .ToListAsync();
        }

        public async Task<Books?> GetById(int id /*, int authorId*/)
        {
            var book = await _db.Books
            .Include(a => a.Authors)
            //.Where(a => a.AuthorId == authorId)
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