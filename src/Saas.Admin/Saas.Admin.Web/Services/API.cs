namespace Saas.Admin.Web.Services
{
    public static class API
    {
        public static class Tenant
        {
            public static string GetTenants(string baseUri) => $"{baseUri}";
            public static string GetTenant(string baseUri, string tenantId) => $"{baseUri}/{tenantId}";
            public static string AddTenant(string baseUri) => $"{baseUri}";
            public static string UpdateTenant(string baseUri, string tenantId) => $"{baseUri}/{tenantId}";
            public static string DeleteTenant(string baseUri, string tenantId) => $"{baseUri}/{tenantId}";
        }
    }
}

