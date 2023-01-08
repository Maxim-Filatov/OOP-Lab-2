using Microsoft.EntityFrameworkCore;
using RESTfull.Domain;

namespace RESTfull.Infrastructure
{
    public class AuthorRepository : BaseRepository
    {
        public AuthorRepository(Context context) : base(context)
        {
        }

        public async Task<List<AuthorDTO>> GetAllAsyncDTO()
        {
            return await _context.Authors
                .OrderBy(a => a.Name)
                .Select(a => new AuthorDTO(a))
                .ToListAsync();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.OrderBy(a => a.Name).ToListAsync();
        }
        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Author author)
        {
            var existAuthor = await _context.Authors.FindAsync(author.Id);
            _context.Entry(existAuthor)
                .CurrentValues.SetValues(author);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Author author = await _context.Authors.FindAsync(id);
            _context.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
