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
               Authors = booksModel.AuthorsBooks
                   .Select(ab => ab.Author.ToAuthorDto())
                   .ToList()
           };
        }

        public static Books ToBookFromCreateDTO(this CreateBookRequest request, int authorId)
        {
            return new Books
            {
                Title = request.Title,
                PublishedDate = request.PublishedDate,
                Description = request.Description,
                AuthorId = authorId,
                AuthorsBooks = new List<JoinTables>
                {   
                    new JoinTables
                    {
                      AuthorId = authorId
                    }
                }
            };
        }
    }
}