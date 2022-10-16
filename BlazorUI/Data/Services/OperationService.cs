using BlazorUI.Data.Services.Interfaces;
using ManagingSelfFinanceWebAPI.Models;
using Newtonsoft.Json;

namespace BlazorUI.Data.Services
{
    public class OperationService : IService<Operation>
    {
        private readonly IApiService _api;

        public OperationService(IApiService api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api), "Parametr can't be null");
        }

        public async Task CreateAsync(Operation item)
        {
            string url = "api/Operations";
            await _api.CreateAsync(url, item);
        }

        public async Task DeleteAsync(int id)
        {
            string url = $"api/Operations/{id}";
            await _api.DeleteAsync(url);
        }

        public async Task<IEnumerable<Operation>> GetAllAsync()
        {
            string url = "api/Operations";
            string content = await _api.GetContentFromApiAsync(url);
            IEnumerable<Operation> operations = JsonConvert.DeserializeObject<IEnumerable<Operation>>(content);
            return operations ?? new List<Operation>();
        }

        public Task<IEnumerable<Operation>> GetReportAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Operation item)
        {
            string url = "api/Operations";
            await _api.UpdateAsync(url, item);
        }
    }
}
