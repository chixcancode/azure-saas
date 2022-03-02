using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Saas.Admin.Web.Policies
{
    public static class CircuitBreakerPolicy
    {
        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }
    }
}