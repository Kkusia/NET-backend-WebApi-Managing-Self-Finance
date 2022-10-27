using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagingSelfFinanceWebAPI.Repository
{
    public class OperationRepository : IRepository<Operation>
    {
        private readonly AppDBContext _db;

        public OperationRepository(AppDBContext db)
        {
            _db = db;
        }
        public IEnumerable<Operation> GetAll()
        {
            if(_db.Operations == null)
            {
                throw new ArgumentNullException("Not found");
            }
            return _db.Operations.AsEnumerable();
        }

        public async Task<Operation> AddAsync(Operation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException("Wrong data");
            }
            _db.Operations.Add(operation);
            await _db.SaveChangesAsync();
            return operation;
        }

        public async Task<Operation> DeleteAsync(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("Operation not found");
            }
            Operation operation = _db.Operations.Find(id);
            _db.Operations.Remove(operation);
            await _db.SaveChangesAsync();
            return operation;
        }

        public IEnumerable<Operation> SelectDateAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Operation> UpdateAsync(Operation operation)
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
