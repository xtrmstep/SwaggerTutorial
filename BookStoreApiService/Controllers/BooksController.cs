using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI;
using BookStoreApiService.Data;
using BookStoreApiService.Models;

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