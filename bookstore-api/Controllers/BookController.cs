using bookstore_migrations.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        public BookController (IBookRepository bookRepository) {
            _repository = bookRepository;
        }

        [HttpGet]
        [Route("ByPage")]
        public async Task<IActionResult> GetBooksByPage([FromQuery] int page = 0, [FromQuery] int skip = 10)
        {
            dynamic response = new ExpandoObject();
            ICollection<Book> books;

            try
            {
                books = await _repository.GetAll(page, skip);
            }
            catch (Exception ex)
            {
                response.Error = ex;
                return Ok(JsonConvert.SerializeObject(response));
            }

            if (books.IsNullOrEmpty())
                return NoContent();

            response.Data = books;

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> GetBookById([FromQuery] int id)
        {
            dynamic response = new ExpandoObject();

            Book? book;

            try
            {
               book = await _repository.Get(id);
            }
            catch (Exception ex)
            {
                response.Error = ex;
                return Ok(JsonConvert.SerializeObject(response));
            }

            if(book == null)
                return NoContent();

            response.Data = book;

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            dynamic response = new ExpandoObject();

            try
            {
                 await _repository.Add(book);
                response.Data = book;
            }catch (Exception ex) {
                response.Error = ex;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateBook([FromQuery] int Id, [FromBody] Book book)
        {
            dynamic response = new ExpandoObject();

            if(book.Id != Id)
                return BadRequest();

            try
            {
                await _repository.Update(book);
                response.Data = book;
            }catch(Exception ex)
            {
                response.Error = ex;
            }

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteBook([FromQuery] int id)
        {
            dynamic? response = new ExpandoObject();

            try
            {
                await _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                response.Error = ex;
            }

            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
