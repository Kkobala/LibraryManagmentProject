using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.DTOs.Books.Authors;
using LMProject.Interfaces;
using LMProject.Mapper;
using LMProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LMProject.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repo;
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorService _service;

        public AuthorController(
            IAuthorRepository repo,
            IBookRepository bookRepo,
            IAuthorService service)
        {
            _repo = repo;
            _bookRepo = bookRepo;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var author = await _repo.GetAllAsync();

            var authorsDto = author.Select(s => s.ToAuthorDto());
            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id){
            var author = await _repo.GetByIdAsync(id);

            if(author == null){
                return NotFound();
            }

            return Ok(author.ToAuthorDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request){

            //var author = request.ToAuthorFromCreateDTO();
            //await _repo.CreateAsync(author);

            //return CreatedAtAction(nameof(GetAuthorById), new {id = author}, author.ToAuthorDto());

            var author = await _service.CreateAuthorAsync(request);
            return Ok(author);
        }
    }
}