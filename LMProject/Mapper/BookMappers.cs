using LMProject.DTOs.Books;
using LMProject.Models;

namespace LMProject.Mapper
{
    public static class BookMappers
    {
        public static BookDto ToBookDTO(this Books booksModel)
        {
            return new BookDto
            {
                Id = booksModel.Id,
                Title = booksModel.Title,
                PublishedDate = booksModel.PublishedDate,
                Description = booksModel.Description,
               // Authors = booksModel.Authors.Select(a => a.ToAuthorDto()).ToList()
            };
        }

        public static Books ToBookFromCreateDTO(this CreateBookRequest request)
        {
            return new Books
            {
                Title = request.Title,
                Description = request.Description,
                PublishedDate = request.PublishedDate,
                //AuthorsModel = request.AuthorIds.Select(id => new AuthorsModel { Id = id }).ToList()
            };
        }
    }
}