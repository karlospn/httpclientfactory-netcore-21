using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MultiServiceApp.Proxies.Models.Base;

namespace MultiServiceApp.Proxies.Extensions
{
    public static class HttpClientBuilderExtensions
    {
        public static void TryAddRetryPolicies<TInterface>(
            this IHttpClientBuilder builder,
            PoliciesRegistry policies)
        {
            var policyEntity = policies?.PoliciesToApplies?.FirstOrDefault(x => x.InterfaceType == typeof(TInterface));

            if (policyEntity != null
                && policies.registry != null
                && policyEntity.Policies.Any())
            {
                foreach (var plcy in policyEntity.Policies)
                {
                    //TODO VALIDATE POLICY IS IN REGISTRY
                    builder.AddPolicyHandlerFromRegistry(plcy);
                }
            }
        }
    }
}
