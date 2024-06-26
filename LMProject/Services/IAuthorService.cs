using LMProject.DTOs.Books.Authors;

namespace LMProject.Services
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorRequest request);
    }
}
