using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Data;
using LMProject.DTOs.Books;
using LMProject.Interfaces;
using LMProject.Mapper;
using LMProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        private readonly IBookService _service;
        private readonly IAuthorRepository _authRepo;

        public BookController(
            IBookRepository repo,
            IBookService service,
            IAuthorRepository authRepo)
        {
            _repo = repo;
            _service = service;
            _authRepo = authRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var books = await _repo.GetAllAsync();

            var bookDto = books.Select(s => s.ToBookDTO());

            return Ok(bookDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooksWithAuthorsAsync([FromRoute] int id){
            //var book = await _repo.GetById(id);

            var author = await _authRepo.GetByIdAsync(id);

            if (author == null)
                throw new ArgumentNullException($"auhtor with this {id} id cannot be found!");

            var book = await _service.GetBooksWithAuthors(author);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheBook([FromBody] CreateBookRequest bookDTO){

            //var bookModel = bookDTO.ToBookFromCreateDTO();
            //await _repo.CreateAsync(bookModel);

            //return CreatedAtAction(nameof(GetBookById), new { id = bookModel.Id }, bookModel.ToBookDTO());

            var book = await _service.CreateBookAsync(bookDTO);
            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTheBook([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto){
            var book = await _repo.UpdateAsync(id, bookDto);
            
            if(book == null){
                return NotFound("Book can not be found");
            }

            return Ok(book.ToBookDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id){
            var book = await _repo.DeleteAsync(id);

            if(book == null){
                return NotFound("Book can not be found");
            }

            return NoContent();
        }
    }
}