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
        [ResponseType(typeof(IList<StoreModel>))]
        public IHttpActionResult Get()
        {
            var listOfStores = Database<Store>.Read();
            var stores = Mapper.Map<List<StoreModel>>(listOfStores);
            return Ok(stores);
        }

        /// <summary>
        /// Returns a store
        /// </summary>
        /// <param name="id">Store identifier</param>
        /// <returns></returns>
        [Route("api/stores/{id}")]
        [ResponseType(typeof(StoreModel))]
        public IHttpActionResult Get(int id)
        {
            var storeEntity = Database<Store>.Read(id);
            if (storeEntity == null) return NotFound();

            var store = Mapper.Map<StoreModel>(storeEntity);
            return Ok(store);
        }

        /// <summary>
        /// Updates a store
        /// </summary>
        /// <param name="store">Store model</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] StoreModel store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            try
            {
                var storeEntity = Mapper.Map<Store>(store);
                Database<Store>.Update(storeEntity);
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
        [ResponseType(typeof(StoreModel))]
        public IHttpActionResult Put([FromBody] StoreCreateModel store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            var storeEntity = Mapper.Map<Store>(store);
            Database<Store>.Create(storeEntity);
            var storeReadModel = Mapper.Map<StoreModel>(storeEntity);
            return CreatedAtRoute("DefaultApi", new { controller= "stores", id = storeReadModel.Id }, storeReadModel);
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