using Microsoft.Extensions.DependencyInjection;
using MultiServiceApp.Proxies.Extensions;
using MultiServiceApp.Proxies.Middleware;
using MultiServiceApp.Proxies.Models.Base;
using MultiServiceApp.Proxies.Proxies;

namespace MultiServiceApp.Proxies.Module
{
    public static class ProxiesModule
    {
        //TODO: It should expose a more fine granular method instead of a single method that registers 
        //everything. If we have 4 proxies we should expose 4 methods.
        public static IServiceCollection RegisterProxies(
            this IServiceCollection services, 
            PoliciesRegistry policies = null)
        {
            services.AddTransient<LoggingRequestHandler>();

            services
                .AddHttpClient<IWebApp1Proxy, WebApp1Proxy>()
                .AddHttpMessageHandler<LoggingRequestHandler>()
                .TryAddRetryPolicies<IWebApp1Proxy>(policies);

            services
                .AddHttpClient<IWebApp2Proxy, WebApp2Proxy>()
                .AddHttpMessageHandler<LoggingRequestHandler>()
                .TryAddRetryPolicies<IWebApp2Proxy>(policies);

            return services;
        }
    }

}
