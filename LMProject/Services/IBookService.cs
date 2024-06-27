using LMProject.DTOs.Books;
using LMProject.Models;

namespace LMProject.Services
{
    public interface IBookService
    {
        Task<BookDto> CreateBookAsync(CreateBookRequest request);
    }
}
