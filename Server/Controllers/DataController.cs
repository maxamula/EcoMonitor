using EcoMonitor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcoMonitor.Server.Controllers
{
    [ApiController]
    [Route("api/pollution")]
    public class DataController : ControllerBase
    {
        public DataController()
        {
            
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var records = _context.Records
                .OrderBy(r => r.Id)
                .ToList();
            return Ok(records);
        }

        private DatabaseContext _context = new DatabaseContext();
    }
}