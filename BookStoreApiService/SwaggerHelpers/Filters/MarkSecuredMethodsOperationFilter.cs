using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using Swashbuckle.Swagger;

namespace BookStoreApiService.SwaggerHelpers.Filters
{
    /// <summary>
    ///     This filter enforces authorization header to be applied for Swagger requests automatically
    /// </summary>
    public class MarkSecuredMethodsOperationFilter : IOperationFilter
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
                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var auth = new Dictionary<string, IEnumerable<string>>
                {
                    {"basic", Enumerable.Empty<string>()}
                };

                operation.security.Add(auth);
            }
        }
    }
}