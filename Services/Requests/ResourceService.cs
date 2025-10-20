namespace Shop.Services.Requests
{
    public class ResourceService
    {
        public readonly ApiService apiService;

        public ResourceService(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<bool> Verify()
        {
            var result = await apiService.GetAsync("resource/verify");
            return result.IsSuccessStatusCode;
        }
    }
}
