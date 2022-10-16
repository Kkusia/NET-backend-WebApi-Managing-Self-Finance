
namespace BlazorUI.Data.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task CreateAsync(T item);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T item);
        public Task<IEnumerable<T>> GetReportAsync(DateTime startDate, DateTime endDate);
    }
}
