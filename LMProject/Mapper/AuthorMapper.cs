using LMProject.DTOs.Books.Authors;
using LMProject.Models;

namespace LMProject.Mapper
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Authors authorsModel)
        {
            return new AuthorDto
            {
                Id = authorsModel.Id,
                Name = authorsModel.Name,
                LastName = authorsModel.LastName,
                DateOfBirth = authorsModel.DateOfBirth,
                //Books = authorsModel.Books
                //.Select(b => b.ToBookDTO())
                //.ToList()
            };
        }

        public static Authors ToAuthorFromCreateDTO(this CreateAuthorRequest request)
        {
            return new Authors
            {
                Name = request.Name,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };
        }
    }
}