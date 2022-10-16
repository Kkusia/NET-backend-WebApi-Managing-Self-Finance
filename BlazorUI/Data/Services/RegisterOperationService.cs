using BlazorUI.Data.Services.Interfaces;
using ManagingSelfFinanceWebAPI.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlazorUI.Data.Services
{
    public class RegisterOperationService : IService<RegisterOperation>
    {
        private readonly IApiService _api;

        public RegisterOperationService(IApiService api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api), "Parametr can't be null");
        }
        public async Task CreateAsync(RegisterOperation item)
        {
            string url = "api/RegisterOperations";
            await _api.CreateAsync(url, item);
        }

        public async Task DeleteAsync(int id)
        {
            string url = $"api/RegisterOperations/{id}";
            await _api.DeleteAsync(url);
        }

        public async Task<IEnumerable<RegisterOperation>> GetAllAsync()
        {
            string url = "api/RegisterOperations";
            string content = await _api.GetContentFromApiAsync(url);
            IEnumerable<RegisterOperation> operations = JsonConvert.DeserializeObject<IEnumerable<RegisterOperation>>(content);
            return operations ?? new List<RegisterOperation>();
        }

        public Task<IEnumerable<RegisterOperation>> GetReportAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(RegisterOperation item)
        {
            string url = "api/RegisterOperations";
            await _api.UpdateAsync(url, item);
        }
    }
}
