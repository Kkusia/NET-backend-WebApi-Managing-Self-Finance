namespace BlazorUI.Data.Services.Interfaces
{
    public interface IApiService
    {
        public Task<string> GetContentFromApiAsync(string url);
        public Task<HttpResponseMessage> DeleteAsync(string url);
        public Task<HttpResponseMessage> CreateAsync(string url, object item);
        public Task<HttpResponseMessage> UpdateAsync(string url, object item);
    }
}
