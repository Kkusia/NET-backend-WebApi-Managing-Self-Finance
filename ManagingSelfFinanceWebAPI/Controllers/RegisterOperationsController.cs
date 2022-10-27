using ManagingSelfFinanceWebAPI.Models;
using ManagingSelfFinanceWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagingSelfFinanceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterOperationsController : ControllerBase
    {
        public IRepository<RegisterOperation> _repos { get; set; }
        public RegisterOperationsController(IRepository<RegisterOperation> repos)
        {
            _repos = repos;
        }
        [HttpGet]
        public IEnumerable<RegisterOperation> Get()
        {
            return _repos.GetAll();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterOperation value)
        {
            return Ok(await _repos.AddAsync(value));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RegisterOperation value)
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
