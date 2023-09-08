using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country
    {
        public required string Name { get; set; }
        public required string Alpha3 { get; set; }

        public Country(string name, string alpha3)
        {
            Name = name;
            Alpha3 = alpha3;
        }
    }
}
