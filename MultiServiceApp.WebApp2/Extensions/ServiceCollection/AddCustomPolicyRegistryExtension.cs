using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using MultiServiceApp.Proxies.Models.Base;
using MultiServiceApp.Proxies.Proxies;
using Polly;
using Polly.Registry;

namespace MultiServiceApp.WebApp2.Extensions.ServiceCollection
{
    public static class AddCustomPolicyRegistryExtension
    {
        public static PoliciesRegistry AddCustomRetryPolicyRegistry(this IServiceCollection services)
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


            return SetProxyPolicies(services, registry);
        }


        private static PoliciesRegistry SetProxyPolicies(
            IServiceCollection services,
            IPolicyRegistry<string> registry)
        {
            var reg = new PoliciesRegistry
            {
                registry = registry,
                PoliciesToApplies = new List<ProxyPolicies>
                {
                    new ProxyPolicies
                    {
                        InterfaceType = typeof(IWebApp1Proxy),
                        Policies = new List<string>{ "WaitAndRetry" }
                    }
                }
            };

            return reg;
        }
    }
}
