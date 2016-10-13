using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace BookStoreApiService.Controllers.ActionFilters
{
    public class BasicAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        private const string ALLOWED_SCHEME = "Basic";
        private const string USER_NAME = "Swagger";
        private const string PASSWORD = "Test";
        private const string MISSING_CREDENTIALS = "Missing credentials";
        private const string INVALID_CREDENTIALS = "Invalid credentials";
        private const string INVALID_USER_OR_PASSWORD = "Invalid user or password";

        /// <summary>
        ///     Gets or sets a value indicating whether more than one instance of the indicated attribute can be specified for a
        ///     single program element.
        /// </summary>
        /// <returns>
        ///     true if more than one instance is allowed to be specified; otherwise, false. The default is false.
        /// </returns>
        public bool AllowMultiple => false; // note: I don't know why it is False. Saw on some examples.

        /// <summary>
        ///     Authenticates the request.
        /// </summary>
        /// <returns>
        ///     A Task that will perform authentication.
        /// </returns>
        /// <param name="context">The authentication context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            // allow only for Basic authorization schema
            if (authorization == null || authorization.Scheme != ALLOWED_SCHEME)
                return Task.CompletedTask;

            #region authorization parameters must exist

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult(MISSING_CREDENTIALS, request);
                return Task.CompletedTask;
            }

            #endregion

            #region try to get credentials

            var credentials = GetCredentials(authorization.Parameter);
            if (credentials == null)
            {
                context.ErrorResult = new AuthenticationFailureResult(INVALID_CREDENTIALS, request);
                return Task.CompletedTask;
            }

            #endregion

            #region validate credentials

            var userName = credentials.Item1;
            var password = credentials.Item2;
            if (string.Compare(userName, USER_NAME, StringComparison.InvariantCultureIgnoreCase) != 0
                || string.Compare(password, PASSWORD, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                context.ErrorResult = new AuthenticationFailureResult(INVALID_USER_OR_PASSWORD, request);
                return Task.CompletedTask;
            }

            #endregion

            context.Principal = new GenericPrincipal(new GenericIdentity(userName), null);
            return Task.CompletedTask;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue(ALLOWED_SCHEME);
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.CompletedTask;
        }

        private Tuple<string, string> GetCredentials(string parameter)
        {
            var userAndPassword = Encoding.Default.GetString(Convert.FromBase64String(parameter));
            var tokens = userAndPassword.Split(':');
            return tokens.Length == 2
                ? new Tuple<string, string>(tokens[0], tokens[1])
                : null;
        }
    }
}