using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagingSelfFinanceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        public IRepository<Report> _repos { get; set; }
        public ReportsController(IRepository<Report> repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IEnumerable<Report> Get(DateTime startDate, DateTime endDate)
        {
            if (endDate < new DateTime(1950, 1, 1))
            {
                endDate = startDate;
            }
            IEnumerable<Report> res = _repos.SelectDateAsync(startDate, endDate);
            return res;
        }
    }
}
