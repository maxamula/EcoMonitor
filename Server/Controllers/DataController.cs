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

        [HttpGet("records")]
        public IActionResult GetRecords()
        {
            var records = _context.Records
                .Include(r => r.Pollutant)
                .Include(r => r.Object)
                .OrderBy(r => r.Id)
                .ToList();
            return Ok(records);
        }

        [HttpGet("objects")]
        public IActionResult GetObjects()
        {
            var records = _context.Object
                .OrderBy(r => r.Id)
                .ToList();
            return Ok(records);
        }

        private DatabaseContext _context = new DatabaseContext();
    }
}