using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain;
using RESTfull.Infrastructure;

namespace RESTfull.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorController(Context context)
        {
            _authorRepository = new AuthorRepository(context);
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
        {
            return await _authorRepository.GetAllAsyncDTO();
        }

        // GET: api/Author/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return new AuthorDTO(author);
        }

        // PUT: api/Author/3
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAuthor(int id, AuthorDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _authorRepository.UpdateAsync(new Author(dto));
            return NoContent();
        }

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO dto)
        {
            var author = new Author(dto);
            await _authorRepository.AddAsync(author);
            return CreatedAtAction("GetAuthor", new { id = author.Id }, new AuthorDTO(author));
        }

        // DELETE: api/Author/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
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