using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagingSelfFinanceWebAPI.Repository
{
    public class ReportRepository : IRepository<Report>
    {
        private readonly AppDBContext _db;

        public ReportRepository(AppDBContext db)
        {
            _db = db;
        }
        public IEnumerable<Report> SelectDateAsync(DateTime startDate, DateTime endDate)
        {
            decimal sumExp = 0;
            decimal sumInc = 0;

            var regInc = (from rt in _db.RegisterOperations
                          join nt in _db.Operations
                          on rt.OperationId equals nt.Id
                          join tt in _db.TypeOperations
                          on nt.TypeOperation equals tt.Id
                          where rt.Date >= startDate & rt.Date <= endDate & nt.TypeOperation == 1
                          select new
                          {
                              rt.Id,
                              rt.Date,
                              nt.Name,
                              tt.Type,
                              rt.Amount,
                          }).AsEnumerable()
                          .Select(an => new Report
                          {
                              Id = an.Id,
                              Date = an.Date,
                              Name = an.Name,
                              Type = an.Type,
                              Amount = an.Amount,
                          }).ToList();

            var regExp = (from rt in _db.RegisterOperations
                          join nt in _db.Operations
                          on rt.OperationId equals nt.Id
                          join tt in _db.TypeOperations
                          on nt.TypeOperation equals tt.Id
                          where rt.Date >= startDate & rt.Date <= endDate & nt.TypeOperation == 2
                          select new
                          {
                              rt.Id,
                              rt.Date,
                              nt.Name,
                              tt.Type,
                              rt.Amount,
                          }).AsEnumerable()
                          .Select(an => new Report
                          {
                              Id = an.Id,
                              Date = an.Date,
                              Name = an.Name,
                              Type = an.Type,
                              Amount = an.Amount,
                          }).ToList();

            sumInc = regInc.Sum(u => u.Amount);
            regInc.Add(new Report { Id = 0, Date = DateTime.Now, Name = "Total Income for the date:", Type = "income", Amount = sumInc });

            sumExp = regExp.Sum(u => u.Amount);
            foreach (var n in regExp)
            {
                regInc.Add(n);
            }
            regInc.Add(new Report { Id = 0, Date = DateTime.Now, Name = "Total Expenses for the date:", Type = "expense", Amount = sumExp });

            return regInc;
        }
        public Task<Report> AddAsync(Report entity)
        {
            throw new NotImplementedException();
        }
        public Task<Report> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Report> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Report> UpdateAsync(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}
