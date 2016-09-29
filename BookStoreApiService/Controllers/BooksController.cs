using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI;
using BookStoreApiService.Models;

namespace BookStoreApiService.Controllers
{
    [Route("")]
    [Route("books")]
    public class BooksController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfBooks = new List<Book>(new[]
            {
                new Book {Title = "Book 1"},
                new Book {Title = "Book 2"},
                new Book {Title = "Book 3"}
            });
            return Ok(listOfBooks);
        }

        public IHttpActionResult Post()
        {
            return Ok();
        }

        public IHttpActionResult Put()
        {
            return Ok();
        }

        public IHttpActionResult Delete()
        {
            return Ok();
        }
    }
}