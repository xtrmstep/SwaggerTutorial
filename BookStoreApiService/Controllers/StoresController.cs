using System.Collections.Generic;
using System.Web.Http;
using BookStoreApiService.Models;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    /// <summary>
    /// Represents stores
    /// </summary>
    [Route("api/stores")]
    public class StoresController : ApiController
    {
        /// <summary>
        /// Returns a list of stores
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var listOfStores = Database<Store>.Read();
            return Ok(listOfStores);
        }

        /// <summary>
        /// Returns a store
        /// </summary>
        /// <param name="id">Store identifier</param>
        /// <returns></returns>
        [Route("api/stores/{id}")]
        public IHttpActionResult Get(int id)
        {
            var store = Database<Store>.Read(id);
            return Ok(store);
        }

        /// <summary>
        /// Updates a store
        /// </summary>
        /// <param name="store">Store model</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] Store store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            try
            {
                Database<Store>.Update(store);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a store
        /// </summary>
        /// <param name="store">Store model</param>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody] Store store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            Database<Store>.Create(store);
            return CreatedAtRoute("DefaultApi", new { controller= "stores", id = store.Id }, store);
        }

        /// <summary>
        /// Deletes store
        /// </summary>
        /// <param name="id">Store identifier</param>
        /// <returns></returns>
        public IHttpActionResult Delete([FromBody] int id)
        {
            Database<Store>.Delete(id);
            return Ok();
        }
    }
}