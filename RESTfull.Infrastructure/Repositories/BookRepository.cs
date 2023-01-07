using Microsoft.EntityFrameworkCore;
using RESTfull.Domain;

namespace RESTfull.Infrastructure
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(Context context) : base(context)
        {
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.OrderBy(p => p.Name).ToListAsync();
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            var existBook = await _context.Books.FindAsync(book.Id);
            _context.Entry(existBook)
                .CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
