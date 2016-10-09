using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStoreApiService.Controllers.ActionFilters;
using BookStoreApiService.Models;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;
using BookStoreApiService.Controllers.TransferObjects;

namespace BookStoreApiService.Controllers
{
    /// <summary>
    /// Represents stores
    /// </summary>
    [Authorize]
    [BasicAuthenticationFilter]
    [Route("api/stores")]
    public class StoresController : ApiController
    {
        /// <summary>
        /// Returns a list of stores
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(IList<StoreReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfStores = Database<Store>.Read();
            var stores = Mapper.Map<List<StoreReadModel>>(listOfStores);
            return Ok(stores);
        }

        /// <summary>
        /// Returns a store
        /// </summary>
        /// <param name="id">Store identifier</param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found: store with the identifier is not found</response>
        [Route("api/stores/{id}")]
        [ResponseType(typeof(StoreReadModel))]
        public IHttpActionResult Get(int id)
        {
            var storeEntity = Database<Store>.Read(id);
            if (storeEntity == null) return NotFound();

            var store = Mapper.Map<StoreReadModel>(storeEntity);
            return Ok(store);
        }

        /// <summary>
        /// Creates a store
        /// </summary>
        /// <param name="store">Store model</param>
        /// <returns></returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request: the sent data is not valid</response>
        [ResponseType(typeof(StoreReadModel))]
        public IHttpActionResult Post([FromBody] StoreCreateModel store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            var storeEntity = Mapper.Map<Store>(store);
            Database<Store>.Create(storeEntity);
            var storeReadModel = Mapper.Map<StoreReadModel>(storeEntity);
            return CreatedAtRoute("DefaultApi", new { controller = "stores", id = storeReadModel.Id }, storeReadModel);
        }

        /// <summary>
        /// Updates a store
        /// </summary>
        /// <param name="id">Store identifier</param>
        /// <param name="store">Store model</param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request: the sent data is not valid</response>
        /// <response code="404">Not Found: store with the identifier is not found</response>
        [Route("api/stores/{id}")]
        public IHttpActionResult Put(int id, [FromBody] StoreUpdateModel store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            try
            {
                var storeEntity = Database<Store>.Read(id);
                if (storeEntity == null) return NotFound();

                Mapper.Map(store, storeEntity);
                Database<Store>.Update(storeEntity);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes store
        /// </summary>
        /// <param name="id">Store identifier</param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found: store with the identifier is not found</response>
        [Route("api/stores/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Database<Store>.Delete(id);
                return Ok();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }
    }
}