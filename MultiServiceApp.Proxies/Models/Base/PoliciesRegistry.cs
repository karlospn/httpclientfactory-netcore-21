using System.Collections.Generic;
using Polly.Registry;

namespace MultiServiceApp.Proxies.Models.Base
{
    public class PoliciesRegistry
    {
        public IPolicyRegistry<string> registry;
        public IEnumerable<ProxyPolicies> PoliciesToApplies;
    }

}
