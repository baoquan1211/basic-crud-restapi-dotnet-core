using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.DTOs;
using BookManagement.Services.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            var authors = await _service.GetAll();
            if (authors is null)
            {
                return NotFound();
            }
            if (authors.Count == 0)
            {
                return NoContent();
            }
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AuthorDto>>> Get(int id)
        {
            var author = await _service.Get(id);
            if (author is null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(AuthorRequestDto newAuthor)
        {
            var result = await _service.Create(newAuthor);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok("Author is added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, AuthorRequestDto newAuthor)
        {
            var result = await _service.Update(id, newAuthor);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok("Author is updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result) 
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}