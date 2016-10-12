using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace BookStoreApiService.SwaggerHelpers
{
    /// <summary>
    /// Placeholder for action conflict resolvers
    /// </summary>
    public static class ConflictingActionsResolver
    {
        /// <summary>
        /// Merges conflicting action into one
        /// </summary>
        /// <returns></returns>
        public static Func<IEnumerable<ApiDescription>, ApiDescription> MergeConflictingActions()
        {
            // the resolver will merge all conflicting actions in one
            // their parameters will be optional regardless to action's signature
            // you should take care about returning types if they are different,
            // since the documentation will show only for the 1st one
            return apiDescriptions =>
            {
                var descriptions = apiDescriptions as ApiDescription[] ?? apiDescriptions.ToArray();
                var first = descriptions.First(); // the first item will represent all
                var parameters = descriptions.SelectMany(d => d.ParameterDescriptions).ToList();

                first.ParameterDescriptions.Clear();
                foreach (var parameter in parameters)
                    if (first.ParameterDescriptions.All(x => x.Name != parameter.Name))
                    {
                        first.ParameterDescriptions.Add(new ApiParameterDescription
                        {
                            Documentation = parameter.Documentation,
                            Name = parameter.Name,
                            ParameterDescriptor = new OptionalHttpParameterDescriptor((ReflectedHttpParameterDescriptor) parameter.ParameterDescriptor),
                            Source = parameter.Source
                        });
                    }

                return first;
            };
        }

        /// <summary>
        /// The wrapper class to override IsOptional property of HTTP parameter
        /// </summary>
        public class OptionalHttpParameterDescriptor : ReflectedHttpParameterDescriptor
        {
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="parameterDescriptor"></param>
            public OptionalHttpParameterDescriptor(ReflectedHttpParameterDescriptor parameterDescriptor)
                : base(parameterDescriptor.ActionDescriptor, parameterDescriptor.ParameterInfo)
            {
            }

            /// <summary>
            /// Gets a value that indicates whether the parameter is optional.
            /// </summary>
            /// <returns>
            /// true if the parameter is optional; otherwise false.
            /// </returns>
            public override bool IsOptional => true;
        }
    }
}