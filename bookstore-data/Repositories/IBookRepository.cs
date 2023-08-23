using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore_migrations.Repositories
{
    public interface IBookRepository
    {

        Task<ICollection<Book>> GetAll(int page = 0, int skip = 10);
        Task<Book> Get(int id);
        Task Add(Book book);
        Task Update(Book book);
        Task Delete(int id);

    }
}
