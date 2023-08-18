using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore_migrations.Services
{
    public interface IBookService
    {
        public Task Add(Book book);
        public Task Update(Book book);
        public Task Delete(int id);
        public Task<Book> GetBook(int id);
        public Task<ICollection<Book>> GetAllBooks(int page = 0, int skip = 10);
    }
}
