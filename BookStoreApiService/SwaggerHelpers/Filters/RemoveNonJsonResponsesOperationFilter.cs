using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace BookStoreApiService.SwaggerHelpers.Filters
{
    public class RemoveNonJsonResponsesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.produces != null)
            {
                var mimeTypes = operation.produces.Where(p => p.Contains("json")).ToArray();
                operation.produces.Clear();
                foreach (var mime in mimeTypes)
                    operation.produces.Add(mime);
            }
        }
    }
}