using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
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
        [ResponseType(typeof(StoreReadModel))]
        public IHttpActionResult Post([FromBody] StoreWriteModel store)
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
        [Route("api/stores/{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody] StoreWriteModel store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            try
            {
                var storeEntity = Mapper.Map<Store>(store);
                storeEntity.Id = id;
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
        [Route("api/stores/{id}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            Database<Store>.Delete(id);
            return Ok();
        }
    }
}