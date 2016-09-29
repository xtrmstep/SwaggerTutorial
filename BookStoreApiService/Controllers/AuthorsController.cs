using System.Collections.Generic;
using BookStoreApiService.Models;
using System.Web.Http;

namespace BookStoreApiService.Controllers
{
    [Route("authors")]
    public class AuthorsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfAuthors = new List<Author>(new[]
            {
                new Author {Name = "Author 1"},
                new Author {Name = "Author 2"},
                new Author {Name = "Author 3"}
            });
            return Ok(listOfAuthors);
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