using Microsoft.Extensions.DependencyInjection;
using StandAloneApp.Infra.Proxies;
using StandAloneApp.Infra.Proxies.Middleware;

namespace StandAloneApp.WebApi.Extensions.ServiceCollection
{
    public static class AddCustomHttpClientExtension
    {
        public static void AddCustomHttpClients(this IServiceCollection services)
        {
            services.AddTransient<LoggingRequestHandler>();

            services
                .AddHttpClient<IWebApp2Proxy, WebApp2Proxy>()
                .AddHttpMessageHandler<LoggingRequestHandler>()
                .AddPolicyHandlerFromRegistry(nameof(PolicyEnum.WaitAndRetry));

        }
    }
}
