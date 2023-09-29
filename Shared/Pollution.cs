using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMonitor.Shared
{
    public class Object
    {
        [Key]
        public int Id { get; set; }

        public string ObjectName { get; set; }
        public string ObjectDesc { get; set; }
        public float CoordLat { get; set; }
        public float CoordLng { get; set; }
    }

    public class Pollutant
    {
        [Key]
        public int Id { get; set; }
        public string PollutantName { get; set; }
        public int DangerClass { get; set; }
        public int MaxAmount { get; set; }
    }

    public class Record
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Objects")]
        public int ObjectId { get; set; }

        public Object Object { get; set; }

        [ForeignKey("Pollutant")]
        public int PollutantId { get; set; }

        public Pollutant Pollutant { get; set; }

        public float PollutionValue { get; set; }
        public int RecordYear { get; set; }
    }
}
