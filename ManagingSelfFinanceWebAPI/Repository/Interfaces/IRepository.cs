namespace ManagingSelfFinanceWebAPI.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> DeleteAsync(int id);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public IEnumerable<TEntity> SelectDateAsync(DateTime startDate, DateTime endDate);
    }
}
