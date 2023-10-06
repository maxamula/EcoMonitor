using EcoMonitor.Shared;
using ExcelDataReader;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;
using System.Text;

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

        [HttpGet("pollutants")]
        public IActionResult GetPollutants()
        {
            var records = _context.Pollutant
                .OrderBy(r => r.DangerClass)
                .ToList();
            return Ok(records);
        }


        [HttpPost("updaterecord")]
        public IActionResult PostUpdateRecord([FromBody] PostMessageUpdateRecord model)
        {
            var record = _context.Records.Find(model.Id);
            if (record == null)
                return NotFound();

            record.PollutionValue = model.Value;
            record.RecordYear = model.Year;
            _context.SaveChanges();

            return Ok();
        }


        [HttpPost("deleterecord")]
        public IActionResult PostDeleteRecord([FromBody] int id)
        {
            var record = _context.Records.Find(id);
            _context.Records.Remove(record);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("addrecord")]
        public IActionResult PostAddRecord([FromBody] PostMessageAddRecord model)
        {
            _context.Records.Add(new Record() { ObjectId = model.ObjectId, PollutantId = model.PollutantId, PollutionValue = model.Value, RecordYear = model.Year});
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("uploadImport")]
        public async Task Save(IList<IFormFile> chunkFile, IList<IFormFile> UploadFiles)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                foreach (var file in UploadFiles)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration() { FallbackEncoding = Encoding.UTF8 }))
                        {
                            string factory = null;
                            int factoryId = -1;
                            while (reader.Read())
                            {
                                string temp = reader.GetString(0);
                                if (temp != null)
                                {
                                    factory = temp;
                                    var factoryObject = _context.Object.FirstOrDefault(x => x.ObjectName == factory);
                                    if (factoryObject != null)
                                        factoryId = factoryObject.Id;
                                    else
                                        throw new KeyNotFoundException($"Factory {factory} not found");
                                }
                                string pollutant = reader.GetString(1);
                                double pollution = reader.GetDouble(2);
                                int pollutantId = -1;
                                var pollutantObject = _context.Pollutant.FirstOrDefault(x => x.PollutantName == pollutant);
                                if (pollutantObject != null)
                                    pollutantId = pollutantObject.Id;
                                else
                                    throw new KeyNotFoundException($"Pollutant {pollutant} not found");

                                if (pollutantId != -1)
                                {
                                    _context.Records.Add(new Record() { ObjectId = factoryId, PollutantId = pollutantId, PollutionValue = (float)pollution, RecordYear = 2025 });
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }


        private DatabaseContext _context = new DatabaseContext();
    }
}