using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMonitor.Shared
{
    public class PostMessageUpdateRecord
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int Year { get; set; }
    }

    public class PostMessageAddRecord
    {
        public int ObjectId { get; set; }
        public int PollutantId { get; set; }
        public float Value { get; set; }
        public int Year { get; set; }
    }

    public class PostMessageAddFactory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
