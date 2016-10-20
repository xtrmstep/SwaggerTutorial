using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using Swashbuckle.Swagger;

namespace BookStoreApiService.SwaggerHelpers.Filters
{
    /// <summary>
    ///     This filter enforces authorization header to be applied for Swagger requests automatically
    /// </summary>
    public class AddResponseCodesOperationFilter : IOperationFilter
    {
        private readonly HttpStatusCode[] _codes;

        /// <summary>
        /// Put response codes to all operations
        /// </summary>
        /// <param name="codes">Response codes</param>
        public AddResponseCodesOperationFilter(params HttpStatusCode[] codes)
        {
            _codes = codes;
        }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            foreach (var code in _codes) {
                var codeNum = ((int)code).ToString();
                var codeName = code.ToString();

                // if the operation allows unauthorized access then 401 is not needed
                if (code == HttpStatusCode.Unauthorized && IsAuthorizedOperation(apiDescription) == false) continue;

                if (operation.responses == null)
                    operation.responses = new Dictionary<string, Response>();
                if (!operation.responses.ContainsKey(codeNum))
                    operation.responses.Add(codeNum, new Response { description = codeName });
            }
        }

        private static bool IsAuthorizedOperation(ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            // check if authorization is required
            var isAuthorized = filterPipeline
                .Select(filterInfo => filterInfo.Instance)
                .Any(filter => filter is IAuthorizationFilter);

            // check if anonymous access is allowed
            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            return isAuthorized && !allowAnonymous;
        }
    }
}