namespace Saas.Admin.Web.Services
{
    public class TenantService : ITenantService
    {
        private readonly HttpClient _httpClient;

        public TenantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddItemAsync(Tenant item)
        {
            var uri = API.Tenant.AddTenant(_httpClient.BaseAddress.ToString());

            var tenantContent = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, tenantContent);

            response.EnsureSuccessStatusCode();
        }


        public async Task DeleteItemAsync(Guid id)
        {
            var uri = API.Tenant.DeleteTenant(_httpClient.BaseAddress.ToString(), id.ToString());

            var response = await _httpClient.DeleteAsync(uri);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Tenant> GetItemAsync(Guid id)
        {
            var uri = API.Tenant.GetTenant(_httpClient.BaseAddress.ToString(), id.ToString());

            var responseString = await _httpClient.GetStringAsync(uri);

            var tenant = JsonSerializer.Deserialize<Tenant>(responseString);

            return tenant;
        }

        public async Task<IEnumerable<Tenant>> GetItemsAsync()
        {
            var uri = API.Tenant.GetTenants(_httpClient.BaseAddress.ToString());

            var responseString = await _httpClient.GetStringAsync(uri);

            var tenants = JsonSerializer.Deserialize<IEnumerable<Tenant>>(responseString);
            return tenants;
        }

        public async Task UpdateItemAsync(Tenant item)
        {
            var uri = API.Tenant.UpdateTenant(_httpClient.BaseAddress.ToString(), item.Id.ToString());

            var tenantContent = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, tenantContent);

            response.EnsureSuccessStatusCode();
        }
    }
}

