using LMProject.DTOs.Books;
using LMProject.Helpers;
using LMProject.Interfaces;
using LMProject.Mapper;
using LMProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LMProject.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        private readonly IBookService _service;

        public BookController(
            IBookRepository repo,
            IBookService service)
        {
            _repo = repo;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = await _repo.GetAllAsync(query);

            return Ok(books.Select(s => s.ToBookDTO()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBooksByIdAsync([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _repo.GetById(id);

            if (book == null)
                throw new ArgumentNullException($"book with this {id} id cannot be found!");

            return Ok(book.ToBookDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheBook([FromBody] CreateBookRequest bookDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _service.CreateBookAsync(bookDTO);
            return Ok(book);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTheBook([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _repo.UpdateAsync(id, bookDto);

            if (book == null)
            {
                return NotFound("Book can not be found");
            }

            return Ok(book.ToBookDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _repo.DeleteAsync(id);

            if (book == null)
            {
                return NotFound("Book can not be found");
            }

            return NoContent();
        }
    }
}