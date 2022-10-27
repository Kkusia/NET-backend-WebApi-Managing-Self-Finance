using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagingSelfFinanceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOperationsController : ControllerBase
    {
        public IRepository<TypeOperation> _repos { get; set; }
        public TypeOperationsController(IRepository<TypeOperation> repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IEnumerable<TypeOperation> Get()
        {
            return _repos.GetAll();
        }

    }
}
