using LMProject.DTOs.Books.Authors;

namespace LMProject.Services
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorRequest request);
        Task<AuthorDto> GetAuthorsWithBooks(int id);
    }
}
