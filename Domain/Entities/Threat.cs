using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Threat
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required int Danger { get; set; }

        public Threat(string description, int danger)
        {
            Description = description;
            Danger = danger;
        }
    }
}
