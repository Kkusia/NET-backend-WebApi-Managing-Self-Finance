using BlazorUI.Data.Services.Interfaces;

namespace BlazorUI.Data.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _urlApi;
        public ApiService(HttpClient urlApi)
        {
            _urlApi = urlApi;
        }

        public async Task<string> GetContentFromApiAsync(string url)
        {
            HttpResponseMessage response = await _urlApi.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _urlApi.DeleteAsync(url);
        }
        public async Task<HttpResponseMessage> CreateAsync(string url, object item)
        {
            return await _urlApi.PostAsJsonAsync(url, item);
        }

        public async Task<HttpResponseMessage> UpdateAsync(string url, object item)
        {
            return await _urlApi.PutAsJsonAsync(url, item);
        }
    }
}
