using System.Text;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace BookStoreApiService.Controllers.Helpers
{
    /// <summary>
    ///     Helper for controllers
    /// </summary>
    public static class ControllerHelpers
    {
        /// <summary>
        ///     Returns true if the model is valid. If not, the out parameter <paramref name="badRequest" /> will have value of
        ///     appropriate BadRequest result.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="controller"></param>
        /// <param name="modelState"></param>
        /// <param name="entity"></param>
        /// <param name="badRequest"></param>
        /// <returns></returns>
        public static bool IsModelValid<T>(this ApiController controller, ModelStateDictionary modelState, T entity, out IHttpActionResult badRequest) where T : class
        {
            badRequest = null;
            if (entity == null)
            {
                badRequest = new BadRequestErrorMessageResult("Required data is null.", controller);
                return true;
            }
            if (modelState.IsValid) return true;

            var errorMessage = modelState.GetModelStateErrors();
            badRequest = new BadRequestErrorMessageResult(errorMessage, controller);
            return false;
        }

        /// <summary>
        ///     Returns plain text which represents model sate errors
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetModelStateErrors(this ModelStateDictionary modelState)
        {
            if (modelState == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var errorInfo in modelState.Values)
                foreach (var error in errorInfo.Errors)
                {
                    if (!string.IsNullOrWhiteSpace(error.ErrorMessage))
                        sb.AppendFormat("\"{0}\", ", error.ErrorMessage);
                    else if (error.Exception != null)
                        sb.AppendFormat("\"{0}\", ", error.Exception.Message);
                }
            sb.Remove(sb.Length - 2, 2); // remove last pair of characters ", "
            return sb.ToString();
        }
    }
}