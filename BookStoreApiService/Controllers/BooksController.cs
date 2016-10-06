using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Models;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    /// <summary>
    /// Represents books
    /// </summary>
    [Route("api/books")]
    public class BooksController : ApiController
    {
        /// <summary>
        /// Returns a list of books
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var listOfBooks = Database<Book>.Read();
            return Ok(listOfBooks);
        }

        /// <summary>
        /// Returns a book
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns></returns>
        [Route("api/books/{id}")]
        public IHttpActionResult Get(int id)
        {
            var book = Database<Book>.Read(id);
            return Ok(book);
        }

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="book">Book model</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] Book book)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

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

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="book">Book model</param>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody]Book book)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

            Database<Book>.Create(book);
            return CreatedAtRoute("DefaultApi", new { controller = "books", id = book.Id }, book);
        }

        /// <summary>
        /// Deletes a book
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns></returns>
        public IHttpActionResult Delete([FromBody] int id)
        {
            Database<Book>.Delete(id);
            return Ok();
        }
    }
}