using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeTheHero.Model
{
    public class Incident
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Guid Ong_id { get; set; }
    }
}
