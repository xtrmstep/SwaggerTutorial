using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI;
using AutoMapper;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Models;
using BookStoreApiService.Controllers.Helpers;
using BookStoreApiService.Controllers.TransferObjects;

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
        [ResponseType(typeof(IList<BookModel>))]
        public IHttpActionResult Get()
        {
            var listOfBooks = Database<Book>.Read();
            var books = Mapper.Map<List<BookModel>>(listOfBooks);
            return Ok(books);
        }

        /// <summary>
        /// Returns a book
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns></returns>
        [Route("api/books/{id}")]
        [ResponseType(typeof(BookModel))]
        public IHttpActionResult Get(int id)
        {
            var bookEntity = Database<Book>.Read(id);
            if (bookEntity == null) return NotFound();

            var book = Mapper.Map<BookModel>(bookEntity);
            return Ok(book);
        }

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="book">Book model</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] BookModel book)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

            try
            {
                var bookEntity = Mapper.Map<Book>(book);
                Database<Book>.Update(bookEntity);
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
        [ResponseType(typeof(BookModel))]
        public IHttpActionResult Put([FromBody]BookCreateModel book)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

            var bookEntity = Mapper.Map<Book>(book);
            Database<Book>.Create(bookEntity);
            var bookReadModel = Mapper.Map<BookModel>(bookEntity);
            return CreatedAtRoute("DefaultApi", new { controller = "books", id = bookReadModel.Id }, bookReadModel);
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