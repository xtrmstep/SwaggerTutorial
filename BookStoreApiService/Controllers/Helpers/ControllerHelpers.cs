using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using BookStoreApiService.Models;

namespace BookStoreApiService.Controllers.Helpers
{
    public static class ControllerHelpers
    {

        public static bool IsModelValid<T>(this ApiController controller, ModelStateDictionary modelState, T entity, out IHttpActionResult badRequest) where T : Entity
        {
            badRequest = null;
            if (entity == null)
            {
                badRequest = new BadRequestErrorMessageResult("Request has no data.", controller);
                return true;
            }
            if (modelState.IsValid) return true;

            badRequest = new BadRequestErrorMessageResult(modelState.ToString(), controller);
            return false;
        }
    }
}