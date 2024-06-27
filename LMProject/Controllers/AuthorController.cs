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
        private readonly IAuthorService _service;

        public AuthorController(
            IAuthorRepository repo,
            IAuthorService service)
        {
            _repo = repo;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = await _repo.GetAllAsync();
            return Ok(author);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = await _service.GetAuthorsWithBooks(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = await _service.CreateAuthorAsync(request);
            return Ok(author);
        }
    }
}