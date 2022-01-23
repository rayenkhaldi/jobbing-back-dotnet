using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public string Nom { get; set; }
        public string Date { get; set; }
        public string Region { get; set; }
        public int Price { get; set; }
    }
}
