using Microsoft.EntityFrameworkCore;
using RESTfull.Domain;

namespace RESTfull.Infrastructure
{
    public class AuthorRepository : BaseRepository
    {
        public AuthorRepository(Context context) : base(context)
        {
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.OrderBy(p => p.Name).ToListAsync();
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
