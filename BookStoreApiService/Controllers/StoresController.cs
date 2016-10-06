using System.Collections.Generic;
using System.Web.Http;
using BookStoreApiService.Models;
using BookStoreApiService.Data;
using BookStoreApiService.Data.Exceptions;
using BookStoreApiService.Controllers.Helpers;

namespace BookStoreApiService.Controllers
{
    [Route("stores")]
    public class StoresController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfStores = Database<Store>.Read();
            return Ok(listOfStores);
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
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Database<Store>.Delete(id);
            return Ok();
        }
    }
}