using bookstore_migrations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore_migrations.Services
{
    //service that would handle any additional logic/data manipulation that needs to be done
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository) {
            _repository = repository;
        }

        public async Task Add(Book book)
        {
            await _repository.Add(book);
        }

        public async Task<ICollection<Book>> GetAllBooks(int page, int skip)
        {
            return await _repository.GetAll(page, skip);
        }

        public async Task<Book> GetBook(int id)
        {
            return await _repository.Get(id);
        }

        public async Task Update(Book book)
        {
            await _repository.Update(book);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
