using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagingSelfFinanceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        public IRepository<Operation> _repos { get; set; }
        public OperationsController(IRepository<Operation> repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IEnumerable<Operation> Get()
        {
            return _repos.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Operation value)
        {
            return Ok(await _repos.AddAsync(value));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Operation value)
        {
            return Ok(await _repos.UpdateAsync(value));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repos.DeleteAsync(id));
        }
    }
}
