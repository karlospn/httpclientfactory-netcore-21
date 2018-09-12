using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ProxyLibrary.Proxies.Middleware
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
            if(_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError($"Request to {request.RequestUri}: {request.Content}");
            }
            
            var response = await base.SendAsync(request, cancellationToken);

            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError($"Response from {request.RequestUri}: {response.Content}");
            }

            return response;
        }
    }
}
