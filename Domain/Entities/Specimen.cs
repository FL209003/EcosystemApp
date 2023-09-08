using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Specimen : Species
    {
        public Specimen(string cientificName, string name, string description) : base(cientificName, name, description)
        {
        }
    }
}
