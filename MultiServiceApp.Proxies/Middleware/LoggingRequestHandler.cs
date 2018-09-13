using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MultiServiceApp.Proxies.Middleware
{
    public class LoggingRequestHandler : DelegatingHandler
    {
        private readonly ILogger<LoggingRequestHandler> _logger;

        public LoggingRequestHandler(ILogger<LoggingRequestHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (_logger.IsEnabled(LogLevel.Error) &&
                request != null &&
                request.Content != null)
            {
                var content = await request?.Content?.ReadAsStringAsync();
                _logger.LogError($"Request to {request.RequestUri}: {content}");
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (_logger.IsEnabled(LogLevel.Error) &&
                response != null &&
                response.Content != null)
            {
                var content = await response?.Content?.ReadAsStringAsync();
                _logger.LogError($"Response from {request.RequestUri}: {response}");
            }

            return response;
        }
    }
}
