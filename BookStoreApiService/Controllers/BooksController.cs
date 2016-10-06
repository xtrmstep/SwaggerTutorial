using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Models;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    [Route("")]
    [Route("books")]
    public class BooksController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfBooks = Database<Book>.Read();
            return Ok(listOfBooks);
        }

        public IHttpActionResult Post(Book book)
        {
            IHttpActionResult badRequest;
            if (this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

            try
            {
                Database<Book>.Update(book);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put(Book book)
        {
            IHttpActionResult badRequest;
            if (this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

            Database<Book>.Create(book);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Database<Book>.Delete(id);
            return Ok();
        }
    }
}