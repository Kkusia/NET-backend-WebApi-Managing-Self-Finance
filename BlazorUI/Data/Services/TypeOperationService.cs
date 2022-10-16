using BlazorUI.Data.Services.Interfaces;
using ManagingSelfFinanceWebAPI.Models;
using Newtonsoft.Json;

namespace BlazorUI.Data.Services
{
    public class TypeOperationService : IService<TypeOperation>
    {
        private readonly IApiService _api;

        public TypeOperationService(IApiService api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api), "Parametr can't be null");
        }

        public async Task CreateAsync(TypeOperation item)
        {
            string url = "api/TypeOperations";
            await _api.CreateAsync(url, item);
        }

        public async Task DeleteAsync(int id)
        {
            string url = $"api/TypeOperations/{id}";
            await _api.DeleteAsync(url);
        }

        public async Task<IEnumerable<TypeOperation>> GetAllAsync()
        {
            string url = "api/TypeOperations";
            string content = await _api.GetContentFromApiAsync(url);
            IEnumerable<TypeOperation> operations = JsonConvert.DeserializeObject
                <IEnumerable<TypeOperation>>(content);
            return operations ?? new List<TypeOperation>();
        }

        public Task<IEnumerable<TypeOperation>> GetReportAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TypeOperation item)
        {
            string url = "api/TypeOperations";
            await _api.UpdateAsync(url, item);
        }
    }
}
