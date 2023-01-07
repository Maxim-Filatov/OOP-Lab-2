using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain;
using RESTfull.Infrastructure;
using System;

namespace RESTfull.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly Context _context;
        private readonly AuthorRepository _authorRepository;


        public AuthorController(Context context)
        {
            _context = context;
            _authorRepository = new AuthorRepository(context);
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _authorRepository.GetAllAsync();
        }

        // GET: api/Author/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        // PUT: api/Author/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            await _authorRepository.UpdateAsync(author);
            return NoContent();
        }

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            await _authorRepository.AddAsync(author);
            return CreatedAtAction("GetPerson", new { id = author.Id }, author);
        }

        // DELETE: api/Author/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await _authorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}