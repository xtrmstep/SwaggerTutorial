using System.Collections.Generic;
using BookStoreApiService.Models;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Validation;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfAuthors = Database<Author>.Read();
            return Ok(listOfAuthors);
        }

        [Route("api/authors/{id}")]
        public IHttpActionResult Get(int id)
        {
            var author = Database<Author>.Read(id);
            return Ok(author);
        }

        public IHttpActionResult Post([FromBody] Author author)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

            try
            {
                Database<Author>.Update(author);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Put([FromBody] Author author)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

            Database<Author>.Create(author);
            return CreatedAtRoute("DefaultApi", new { controller = "author", id = author.Id }, author);
        }

        public IHttpActionResult Delete(int id)
        {
            Database<Author>.Delete(id);
            return Ok();
        }
    }
}