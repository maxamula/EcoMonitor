using EcoMonitor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcoMonitor.Server.Controllers
{
    [ApiController]
    [Route("api/pollution")]
    public class DataController : ControllerBase
    {
        public class UpdateRecordModel
        {
            public int Id { get; set; }
            public float Value { get; set; }
            public int Year { get; set; }
        }

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

        [HttpGet("pollutants")]
        public IActionResult GetPollutants()
        {
            var records = _context.Pollutant
                .OrderBy(r => r.DangerClass)
                .ToList();
            return Ok(records);
        }


        [HttpPost("updaterecord")]
        public IActionResult PostUpdate([FromBody] UpdateRecordModel model)
        {
            var record = _context.Records.Find(model.Id);
            if (record == null)
                return NotFound();

            record.PollutionValue = model.Value;
            record.RecordYear = model.Year;
            _context.SaveChanges();

            return Ok();
        }



        private DatabaseContext _context = new DatabaseContext();
    }
}