using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore_migrations.Repositories
{
    //would handle actual data retrieval operations from db context
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task Add(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Book? book = await _context.Books.FindAsync(id);

            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Book> Get(int id)
        {
            Book book = await _context.Books.FindAsync(id);

            return book;
        }

        public async Task<ICollection<Book>> GetAll(int page = 0, int skip = 10)
        {
            ICollection<Book> books;
            books = await _context.Books.Skip(skip*page).Take(skip).ToListAsync();

            return books;
        }

        public async Task Update(Book book)
        {
            if(book != null) {
                _context.Update(book);
            }

            await _context.SaveChangesAsync();
        }
    }
}
