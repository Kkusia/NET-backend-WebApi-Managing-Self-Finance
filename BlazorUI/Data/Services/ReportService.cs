using BlazorUI.Data.Services.Interfaces;
using ManagingSelfFinanceWebAPI.Models;
using Newtonsoft.Json;

namespace BlazorUI.Data.Services
{
    public class ReportService : IService<Report>
    {
        private readonly IApiService _api;

        public ReportService(IApiService api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api), "Parametr can't be null");
        }
        public async Task<IEnumerable<Report>> GetReportAsync(DateTime startDate, DateTime endDate)
        {
            string url = $"api/Reports?startDate={startDate:yyyy.MM.dd}&endDate={endDate:yyyy.MM.dd}";
            string content = await _api.GetContentFromApiAsync(url);
            IEnumerable<Report> report = JsonConvert.DeserializeObject<IEnumerable<Report>>(content);
            return report ?? new List<Report>();
        }

        public Task CreateAsync(Report item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
       
        public Task UpdateAsync(Report item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
