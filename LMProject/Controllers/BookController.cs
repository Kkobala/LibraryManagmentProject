using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Data;
using LMProject.DTOs.Books;
using LMProject.Interfaces;
using LMProject.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMProject.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var books = await _repo.GetAllAsync();

            var bookDto = books.Select(s => s.ToBookDTO());

            return Ok(bookDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id){
            var book = await _repo.GetById(id);

            if(book == null){
                return NotFound();
            }

            return Ok(book.ToBookDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheBook([FromBody] CreateBookRequest bookDTO){
            var bookModel = bookDTO.ToBookFromCreateDTO();
            await _repo.CreateAsync(bookModel);

            return CreatedAtAction(nameof(GetBookById), new { id = bookModel.Id }, bookModel.ToBookDTO());
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