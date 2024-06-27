using LMProject.DTOs.Books.Authors;
using LMProject.Interfaces;
using LMProject.Mapper;

namespace LMProject.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repo;

        public AuthorService(
            IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorRequest request)
        {
            var author = request.ToAuthorFromCreateDTO();

            await _repo.CreateAsync(author);

            return author.ShowCreatedAuthorDto();
        }

        public async Task<AuthorDto> GetAuthorsWithBooks(int id)
        {
            var author = await _repo.GetByIdAsync(id);

            if (author == null)
                throw new ArgumentNullException($"Author with ID {id} not found!");

            return author.ToAuthorDto();
        }
    }
}
