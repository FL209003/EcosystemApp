using Domain.DomainInterfaces;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Species : IValidate
    {
        public int Id { get; set; }
        public required string CientificName { get; set; }
        public required Name SpeciesName { get; set; }
        [MinLength(50, ErrorMessage = "La descripción debe tener al menos 50 caracteres.")]
        [MaxLength(500, ErrorMessage = "La descripción no puede superer los 500 caracteres.")]
        public required string Description { get; set; }

        public Species(string cientificName, Name name, string description)
        {
            CientificName = cientificName;
            SpeciesName = name;
            Description = description;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(CientificName)) throw new Exception("El nombre científico de la especie es requerido.");
            if (string.IsNullOrEmpty(Description)) throw new Exception("La descripción es requerida.");
        }
    }
}
