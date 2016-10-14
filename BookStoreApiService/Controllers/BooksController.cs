using System.Collections.Generic;
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
    ///     Represents books
    /// </summary>
    //[Authorize]
    //[BasicAuthenticationFilter]
    [RoutePrefix("api")]
    public class BooksController : ApiController
    {
        /// <summary>
        ///     Returns a list of books
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof (IList<BookReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfBooks = Database<Book>.Read();
            var books = Mapper.Map<List<BookReadModel>>(listOfBooks);
            return Ok(books);
        }

        /// <summary>
        ///     Returns a book
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns></returns>
        [ResponseType(typeof (BookReadModel))]
        public IHttpActionResult Get(int id)
        {
            var bookEntity = Database<Book>.Read(id);
            if (bookEntity == null) return NotFound();

            var book = Mapper.Map<BookReadModel>(bookEntity);
            return Ok(book);
        }

        /// <summary>
        ///     Creates a book
        /// </summary>
        /// <param name="book">Book model</param>
        /// <returns></returns>
        [ResponseType(typeof (BookReadModel))]
        public IHttpActionResult Post([FromUri] BookCreateModel book)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, book, out badRequest)) return badRequest;

            var bookEntity = Mapper.Map<Book>(book);
            Database<Book>.Create(bookEntity);
            var bookReadModel = Mapper.Map<BookReadModel>(bookEntity);
            return CreatedAtRoute("DefaultApi", new {controller = "books", id = bookReadModel.Id}, bookReadModel);
        }

        /// <summary>
        ///     Updates a book
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <param name="book">Book model</param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody] BookUpdateModel book)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, book, out badRequest)) return badRequest;
            try
            {
                var bookEntity = Database<Book>.Read(id);
                if (bookEntity == null) return NotFound();

                Mapper.Map(book, bookEntity);
                Database<Book>.Update(bookEntity);
                return Ok();
            }
            catch (DataNotFoundException) {
                return NotFound();
            }
        }

        /// <summary>
        ///     Deletes a book
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Database<Book>.Delete(id);
                return Ok();
            }
            catch (DataNotFoundException) {
                return NotFound();
            }
        }
    }
}