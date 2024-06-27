using LMProject.DTOs.Books;
using LMProject.DTOs.Books.Authors;
using LMProject.Models;

namespace LMProject.Mapper
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this AuthorsModel authorsModel)
        {
            return new AuthorDto
            {
                Id = authorsModel.Id,
                Name = authorsModel.Name,
                LastName = authorsModel.LastName,
                DateOfBirth = authorsModel.DateOfBirth,
                Books = authorsModel.AuthorsBooks.Select(ab => new BookDto
                {
                    Id = ab.Book.Id,
                    Title = ab.Book.Title,
                    PublishedDate = ab.Book.PublishedDate,
                    Description = ab.Book.Description
                }).ToList()
            };
        }

        public static AuthorsModel ToAuthorFromCreateDTO(this CreateAuthorRequest request)
        {
            return new AuthorsModel
            {
                Name = request.Name,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };
        }

        public static AuthorDto ShowCreatedAuthorDto(this AuthorsModel authorsModel)
        {
            return new AuthorDto
            {
                Id = authorsModel.Id,
                Name = authorsModel.Name,
                LastName = authorsModel.LastName,
                DateOfBirth = authorsModel.DateOfBirth
            };
        }
    }
}