using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagingSelfFinanceWebAPI.Repository
{
    public class TypeOperationRepository : IRepository<TypeOperation>
    {
        private readonly AppDBContext _db;

        public TypeOperationRepository(AppDBContext db)
        {
            _db = db;
        }
        public IEnumerable<TypeOperation> GetAll()
        {
            if(_db.TypeOperations == null)
            {
                throw new ArgumentNullException("Not found");
            }
            return _db.TypeOperations.AsEnumerable();
        }

        public async Task<TypeOperation> AddAsync(TypeOperation type)
        {
            if(type == null)
            {
                throw new ArgumentNullException("Wrong data");
            }
            _db.TypeOperations.Add(type);
            await _db.SaveChangesAsync();
            return type;
        }

        public Task<TypeOperation> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TypeOperation> UpdateAsync(TypeOperation type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeOperation> SelectDateAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
