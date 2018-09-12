using Microsoft.Extensions.DependencyInjection;
using ProxyLibrary.Proxies.Middleware;
using ProxyLibrary.Proxies.Proxies;

namespace ProxyLibrary.Proxies.Module
{
    public static class ProxiesModule
    {
        public static IServiceCollection RegisterProxies(this IServiceCollection services)
        {
            services.AddTransient<LoggingRequestHandler>();

            services.AddHttpClient<IWebApp1Proxy, WebApp1Proxy>()
                .AddHttpMessageHandler<LoggingRequestHandler>();

            services.AddHttpClient<IWebApp2Proxy, WebApp2Proxy>()
                .AddHttpMessageHandler<LoggingRequestHandler>();

            return services;
        }
    }
}
