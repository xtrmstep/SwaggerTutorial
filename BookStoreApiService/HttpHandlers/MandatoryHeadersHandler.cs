using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApiService.HttpHandlers
{
    public class MandatoryHeadersHandler : DelegatingHandler
    {
        private readonly string[] _mandatoryHeaders = {"X-Org", "X-Version", "X-UserId"};

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_mandatoryHeaders.All(request.Headers.Contains) == false)
                return BadRequestAsync("Missing required headers");

            var xOrg = request.Headers.GetValues("X-Org").First();
            var xVersion = request.Headers.GetValues("X-Version").First();
            var xUserId = request.Headers.GetValues("X-UserId").First();

            if(xOrg != "SwaggerTest")
                return BadRequestAsync("Wrong X-Org value. It should be 'SwaggerTest'.");

            if (xVersion != "1")
                return BadRequestAsync("Wrong X-Version value. It should be '1'.");

            if (xUserId != "Test")
                return BadRequestAsync("Wrong X-UserId value. It should be 'Test'.");

            return base.SendAsync(request, cancellationToken);
        }

        private static Task<HttpResponseMessage> BadRequestAsync(string message)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(message)
            };
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}