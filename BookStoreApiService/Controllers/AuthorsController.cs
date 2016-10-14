using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStoreApiService.Controllers.Helpers;
using BookStoreApiService.Controllers.TransferObjects;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Models;

namespace BookStoreApiService.Controllers
{
    /// <summary>
    ///     Represents authors
    /// </summary>
    //[Authorize]
    //[BasicAuthenticationFilter]
    [RoutePrefix("api")]
    public class AuthorsController : ApiController
    {
        /// <summary>
        ///     Returns a list of authors
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof (IList<AuthorReadModel>))]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var listOfAuthors = Database<Author>.Read();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors);
            return Ok(authors);
        }

        /// <summary>
        ///     Returns a list of authors
        /// </summary>
        /// <param name="count">Number of items to return</param>
        /// <param name="descending">If True the items will be sorted in the reverse alphabetic order</param>
        /// <returns></returns>
        [ResponseType(typeof (IList<AuthorReadModel>))]
        [AllowAnonymous]
        public IHttpActionResult Get(int count, bool descending)
        {
            var listOfAuthors = Database<Author>.Read();
            var authors = Mapper.Map<List<AuthorReadModel>>(listOfAuthors).Take(count);
            if (descending)
                authors = authors.OrderByDescending(a => a.Name);
            return Ok(authors.ToList());
        }

        /// <summary>
        ///     Returns an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns></returns>
        [ResponseType(typeof (AuthorReadModel))]
        public IHttpActionResult Get(int id)
        {
            var authorEntity = Database<Author>.Read(id);
            if (authorEntity == null) return NotFound();

            var author = Mapper.Map<AuthorReadModel>(authorEntity);
            return Ok(author);
        }

        /// <summary>
        ///     Creates an author
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
            return CreatedAtRoute("DefaultApi", new {controller = "author", id = authorReadModel.Id}, authorReadModel);
        }

        /// <summary>
        ///     Updates an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <param name="author">Author model</param>
        /// <returns></returns>
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
            catch (DataNotFoundException) {
                return NotFound();
            }
        }

        /// <summary>
        ///     Deletes an author
        /// </summary>
        /// <param name="id">Author identifier</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Database<Author>.Delete(id);
                return Ok();
            }
            catch (DataNotFoundException) {
                return NotFound();
            }
        }
    }
}