using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Adult : Species
    {
        public decimal Length { get; set; }
        public decimal Weight { get; set; }

        public Adult(string cientificName, string name, string description, decimal length, decimal weight) : base(cientificName, name, description)
        {
            Length = length;
            Weight = weight;
        }
    }
}
