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
    [Route("authors")]
    public class AuthorsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfAuthors = Database<Author>.Read();
            return Ok(listOfAuthors);
        }

        public IHttpActionResult Post(Author author)
        {
            IHttpActionResult badRequest;
            if (this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

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

        public IHttpActionResult Put(Author author)
        {
            IHttpActionResult badRequest;
            if (this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

            Database<Author>.Create(author);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Database<Author>.Delete(id);
            return Ok();
        }
    }
}