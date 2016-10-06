using System.Collections.Generic;
using System.Web.Http;
using BookStoreApiService.Models;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    [Route("api/stores")]
    public class StoresController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfStores = Database<Store>.Read();
            return Ok(listOfStores);
        }

        [Route("api/stores/{id}")]
        public IHttpActionResult Get(int id)
        {
            var store = Database<Store>.Read(id);
            return Ok(store);
        }

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

        public IHttpActionResult Put([FromBody] Store store)
        {
            IHttpActionResult badRequest;
            if (!this.IsModelValid(ModelState, store, out badRequest)) return badRequest;

            Database<Store>.Create(store);
            return CreatedAtRoute("DefaultApi", new { controller= "stores", id = store.Id }, store);
        }

        public IHttpActionResult Delete([FromBody] int id)
        {
            Database<Store>.Delete(id);
            return Ok();
        }
    }
}