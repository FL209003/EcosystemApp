using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Species
    {
        public required string CientificName { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public Species(string cientificName, string name, string description)
        {
            CientificName = cientificName;
            Name = name;
            Description = description;
        }

        
    }
}
