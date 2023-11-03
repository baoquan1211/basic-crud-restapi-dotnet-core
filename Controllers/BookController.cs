using BookManagement.DTOs;
using BookManagement.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            var books = await _service.GetAll();
            if (books is null || books.Count() == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<BookDto>>> Get(int id)
        {
            var book = await _service.Get(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(BookRequestDto newBook)
        {
            var result = await _service.Create(newBook);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok("Book is added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, BookRequestDto newBook)
        {
            var result = await _service.Update(id, newBook);
            if (!result) 
            {
                return BadRequest();
            }
            return Ok("Book is updated successfully.");
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