using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conservation
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string State { get; set; }

        public Conservation(string name, string state)
        {
            Name = name;
            State = state;
        }
    }
}
