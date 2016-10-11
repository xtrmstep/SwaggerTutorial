using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Swashbuckle.Swagger;

namespace BookStoreApiService.SwaggerHelpers.Filters
{
    public class SchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            int i = 0;
        }
    }
}