using Domain.DomainInterfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Threat : IValidate
    {
        public int Id { get; set; }
        
        public Name ThreatName { get; set; }

        [Required(ErrorMessage = "Descripción requerida.")]

        [Column("Descripción")]
        public required Description ThreatDescription { get; set; }

        [Column("Nivel de peligrosidad")]
        public required int Danger { get; set; }
        public Threat(Name name, Description description, int danger)
        {
            ThreatName = name;
            ThreatDescription = description;
            Danger = danger;
        }

        public Threat() { }

        public void Validate() { }
    }
}
