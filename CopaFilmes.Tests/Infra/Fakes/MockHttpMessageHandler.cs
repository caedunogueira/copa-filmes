using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Infra.Fakes
{
    internal class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;

        internal MockHttpMessageHandler(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            => new HttpResponseMessage { StatusCode = _statusCode, Content = new StringContent(_response) };
    }
}
