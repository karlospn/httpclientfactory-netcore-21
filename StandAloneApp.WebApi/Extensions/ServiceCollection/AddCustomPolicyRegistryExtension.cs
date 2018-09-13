using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using StandAloneApp.Infra.Proxies.Middleware;

namespace StandAloneApp.WebApi.Extensions.ServiceCollection
{
    public static class AddCustomPolicyRegistryExtension
    {
        public static void AddCustomRetryPolicyRegistry(this IServiceCollection services)
        {
            var registry = services.AddPolicyRegistry();

            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(10));

            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(30));

            var waitAndRetry = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(10, _ => TimeSpan.FromMilliseconds(600));

            registry.Add(nameof(PolicyEnum.Timeout), timeout);
            registry.Add(nameof(PolicyEnum.LongTimeout), longTimeout);
            registry.Add(nameof(PolicyEnum.WaitAndRetry), waitAndRetry);

        }
    }
}
