using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using Swashbuckle.Swagger;

namespace BookStoreApiService.SwaggerHelpers.OperationFilters
{
    /// <summary>
    /// This filter enforces authorization header to be applied for Swagger requests automatically
    /// </summary>
    public class AddAuthResponseCodes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            // check if authorization is required
            var isAuthorized = filterPipeline
                .Select(filterInfo => filterInfo.Instance)
                .Any(filter => filter is IAuthorizationFilter);

            // check if anonymous access is allowed
            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (isAuthorized && !allowAnonymous)
            {
                #region add 401 response code to secured methods
                if (operation.responses == null)
                    operation.responses = new Dictionary<string, Response>();
                if (!operation.responses.ContainsKey("401"))
                    operation.responses.Add("401", new Response { description = "Unauthorized" }); 
                #endregion
            }
        }
    }
}