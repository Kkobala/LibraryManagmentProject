using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.DTOs.Books;
using LMProject.Models;

namespace LMProject.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Books>> GetAllAsync();
        Task<Books?> GetById(int id);
        Task<Books> CreateAsync(Books booksModel);
        Task<Books?> UpdateAsync(int id, UpdateBookRequestDto bookDto);
        Task<Books?> DeleteAsync(int id);
        Task<bool> BookExist(int id);
    }
}