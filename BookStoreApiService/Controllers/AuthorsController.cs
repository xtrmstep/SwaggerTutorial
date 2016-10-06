using System.Collections.Generic;
using BookStoreApiService.Models;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Http.Validation;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    /// <summary>
    /// Represents authors
    /// </summary>
    [Route("api/authors")]
    public class AuthorsController : ApiController
    {
        /// <summary>
        /// Returns a list of authors
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(IList<Author>))]
        public IHttpActionResult Get()
        {
            var listOfAuthors = Database<Author>.Read();
            return Ok(listOfAuthors);
        }

        /// <summary>
        /// Returns an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns></returns>
        [Route("api/authors/{id}")]
        [ResponseType(typeof(Author))]
        public IHttpActionResult Get(int id)
        {
            var author = Database<Author>.Read(id);
            return Ok(author);
        }

        /// <summary>
        /// Updates an author
        /// </summary>
        /// <param name="author">Author model</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="author">Author model</param>
        /// <returns></returns>
        [ResponseType(typeof(Author))]
        public IHttpActionResult Put([FromBody] Author author)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

            Database<Author>.Create(author);
            return CreatedAtRoute("DefaultApi", new { controller = "author", id = author.Id }, author);
        }

        /// <summary>
        /// Deletes an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns></returns>
        public IHttpActionResult Delete([FromBody] int id)
        {
            Database<Author>.Delete(id);
            return Ok();
        }
    }
}