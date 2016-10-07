using System.Collections.Generic;
using BookStoreApiService.Models;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Http.Validation;
using AutoMapper;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;
using BookStoreApiService.Controllers.TransferObjects;

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
        [ResponseType(typeof(IList<AuthorReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfAuthors = Database<Author>.Read();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors);
            return Ok(authors);
        }

        /// <summary>
        /// Returns an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns></returns>
        [Route("api/authors/{id}")]
        [ResponseType(typeof(AuthorReadModel))]
        public IHttpActionResult Get(int id)
        {
            var authorEntity = Database<Author>.Read(id);
            if (authorEntity == null) return NotFound();

            var author = Mapper.Map<AuthorReadModel>(authorEntity);
            return Ok(author);
        }

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="author">Author model</param>
        /// <returns></returns>
        [ResponseType(typeof(AuthorReadModel))]
        public IHttpActionResult Post([FromBody] AuthorCreateModel author)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

            var authorEntity = Mapper.Map<Author>(author);
            Database<Author>.Create(authorEntity);
            var authorReadModel = Mapper.Map<AuthorReadModel>(authorEntity);
            return CreatedAtRoute("DefaultApi", new { controller = "author", id = authorReadModel.Id }, authorReadModel);
        }

        /// <summary>
        /// Updates an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <param name="author">Author model</param>
        /// <returns></returns>
        [Route("api/authors/{id}")]
        public IHttpActionResult Put(int id, [FromBody] AuthorUpdateModel author)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, author, out badRequest)) return badRequest;

            try
            {
                var authorEntity = Database<Author>.Read(id);
                if (authorEntity == null) return NotFound();

                Mapper.Map(author, authorEntity);
                Database<Author>.Update(authorEntity);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns></returns>
        [Route("api/authors/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Database<Author>.Delete(id);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }
    }
}