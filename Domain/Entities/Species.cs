using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Species : IValidate
    {
        public int Id { get; set; }
        public required string CientificName { get; set; }
        [MinLength(5), MaxLength(20)]
        [Index(IsUnique=true)]
        public required string Name { get; set; }
        [MinLength(50, ErrorMessage="La descripción debe tener al menos 50 caracteres.")] 
        [MaxLength(500, ErrorMessage="La descripción no puede superer los 500 caracteres.")]
        public required string Description { get; set; }

        public Species(string cientificName, string name, string description)
        {
            CientificName = cientificName;
            Name = name;
            Description = description;
        }

        public void IValidate() {
            if (string.IsNullOrEmpty(CientificName)) throw new Exception("El nombre científico de la especie es requerido.");
            if (string.IsNullOrEmpty(Name)) throw new Exception("El nombre de la especie es requerido.");
            if (string.IsNullOrEmpty(Description)) throw new Exception("La descripción es requerida.");
        }
    }
}
