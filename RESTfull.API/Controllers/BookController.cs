using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain;
using RESTfull.Infrastructure;

namespace RESTfull.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController(Context context)
        {
            _bookRepository = new BookRepository(context);
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAuthors()
        {
            return await _bookRepository.GetAllAsyncDTO();
        }

        // GET: api/Book/3
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return new BookDTO(book);
        }

        // PUT: api/Book/3
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, BookDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _bookRepository.UpdateAsync(new Book(dto));
            return NoContent();
        }

        // POST: api/Book
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO dto)
        {
            var book = new Book(dto);
            await _bookRepository.AddAsync(book);
            return CreatedAtAction("GetBook", new { id = book.Id }, new BookDTO(book));
        }

        // DELETE: api/Book/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var author = await _bookRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await _bookRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}