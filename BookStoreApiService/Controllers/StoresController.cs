using System.Collections.Generic;
using System.Web.Http;
using BookStoreApiService.Models;
using BookStoreApiService.Data;

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

        public IHttpActionResult Post()
        {
            return Ok();
        }

        public IHttpActionResult Put()
        {
            return Ok();
        }

        public IHttpActionResult Delete()
        {
            return Ok();
        }
    }
}