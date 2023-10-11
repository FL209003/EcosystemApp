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

        [Column("Nombre")]
        public Name ThreatName { get; set; }

        [Required(ErrorMessage = "Descripción requerida.")]
        [MinLength(50, ErrorMessage = "La descripción debe tener al menos 50 caracteres.")]
        [MaxLength(500, ErrorMessage = "La descripción no puede superer los 500 caracteres.")]

        [Column("Descripción")]
        public required string Description { get; set; }

        [Column("Nivel de peligrosidad")]
        public required int Danger { get; set; }
        public Threat(Name name, string description, int danger)
        {
            ThreatName = name;
            Description = description;
            Danger = danger;
        }

        public Threat() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Description)) throw new Exception("La descripción es requerida.");
        }
    }
}
