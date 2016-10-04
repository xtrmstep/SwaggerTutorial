using System.Collections.Generic;
using BookStoreApiService.Models;
using System.Web.Http;
using BookStoreApiService.Data;

namespace BookStoreApiService.Controllers
{
    [Route("authors")]
    public class AuthorsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfAuthors = Database<Author>.Read();
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