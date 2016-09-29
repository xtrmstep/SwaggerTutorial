using System.Collections.Generic;
using System.Web.Http;
using BookStoreApiService.Models;

namespace BookStoreApiService.Controllers
{
    [Route("stores")]
    public class StoresController : ApiController
    {
        public IHttpActionResult Get()
        {
            var listOfStores = new List<Store>(new[]
            {
                new Store {Name = "Store 1", Address = "Address 1"},
                new Store {Name = "Store 2", Address = "Address 2"},
                new Store {Name = "Store 3", Address = "Address 3"}
            });
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