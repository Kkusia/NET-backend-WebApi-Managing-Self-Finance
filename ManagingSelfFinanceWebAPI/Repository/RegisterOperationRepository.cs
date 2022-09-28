using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagingSelfFinanceWebAPI.Repository
{
    public class RegisterOperationRepository : IRepository<RegisterOperation>
    {
        private readonly AppDBContext _db;

        public RegisterOperationRepository(AppDBContext db)
        {
            _db = db;
        }
        public IEnumerable<RegisterOperation> GetAll()
        {
            if(_db.RegisterOperations == null)
            {
                throw new ArgumentNullException("Not found");
            }
            return _db.RegisterOperations.AsEnumerable();
        }
        public async Task<RegisterOperation> AddAsync(RegisterOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException("Wrong data");
            }
            _db.RegisterOperations.Add(operation);
            await _db.SaveChangesAsync();
            return operation;
        }
        public async Task<RegisterOperation> DeleteAsync(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("Operation not found");
            }
            RegisterOperation operation = _db.RegisterOperations.Find(id);
            _db.RegisterOperations.Remove(operation);
            await _db.SaveChangesAsync();
            return operation;
        }
        public IEnumerable<RegisterOperation> SelectDateAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
        public async Task<RegisterOperation> UpdateAsync(RegisterOperation operation)
        {
            if(operation == null)
            {
                throw new Exception("Wrong operation data");
            }
            _db.Update(operation);
            await _db.SaveChangesAsync();
            return operation;
        }
    }
}
