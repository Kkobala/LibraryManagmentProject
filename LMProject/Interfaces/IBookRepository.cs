using LMProject.DTOs.Books;
using LMProject.Helpers;
using LMProject.Models;

namespace LMProject.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Books>> GetAllAsync(QueryObject query);
        Task<Books?> GetById(int id);
        Task<Books> CreateAsync(Books booksModel);
        Task<Books?> UpdateAsync(int id, UpdateBookRequestDto bookDto);
        Task<Books?> DeleteAsync(int id);
        Task<bool> BookExist(int id);
    }
}