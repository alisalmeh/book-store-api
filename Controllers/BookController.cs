using System.Threading.Tasks;
using AliBookStoreApi.Interfaces;
using AliBookStoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AliBookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class BookController : ControllerBase
    {
        private readonly IBookRepository _booksRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookRepository booksRepository,
            ILogger<BookController> logger)
        {
            _booksRepository = booksRepository;
            _logger = logger;
        }

        // route: /api/book
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _booksRepository.GetAllBooks();
            return Ok(books);
        }

        // route: /api/book/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookDetailsById(int id)
        {
            var book = await _booksRepository.GetBookDetailsById(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // route: /api/book
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto model)
        {
            var id = await _booksRepository.CreateBook(model);
            return Ok(id);
        }

        // route: /api/book/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto model)
        {
            var result = await _booksRepository.UpdateBook(id, model);

            if (!result)
            {
                return BadRequest("This book id does not exist!");
            }
            return Ok(result);
        }

        // route: /api/book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await _booksRepository.RemoveBook(id);

            if (!result)
            {
                return BadRequest("This book id does not exist!");
            }
            return Ok(result);
        }
    }
}
