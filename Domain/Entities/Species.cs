using Domain.DomainInterfaces;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Species : IValidate
    {
        public int Id { get; set; }

        [Column("Cientific name")]
        [Required(ErrorMessage = "Nombre científico requerido.")]
        public required string CientificName { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Nombre del espécimen requerido.")]
        public required Name SpeciesName { get; set; }

        [Required(ErrorMessage = "Descripción requerida.")]
        [MinLength(50, ErrorMessage = "La descripción debe tener al menos 50 caracteres.")]
        [MaxLength(500, ErrorMessage = "La descripción no puede superer los 500 caracteres.")]
        public required string Description { get; set; }

        [Column("Min weight")]
        [Required(ErrorMessage = "Peso mínimo requerido.")]
        public decimal WeightRangeMin { get; set; }

        [Column("Max weight")]
        [Required(ErrorMessage = "Peso máximo requerido.")]
        public decimal WeightRangeMax { get; set; }

        [Column("Min length")]
        [Required(ErrorMessage = "Largo mínimo del adulto requerido.")]
        public decimal LongRangeAdultMin { get; set; }

        [Column("Max length")]
        [Required(ErrorMessage = "Largo máximo del adulto requerido.")]
        public decimal LongRangeAdultMax { get; set; }

        [Column("Image")]
        [Display(Name = "Imagen")]        
        public string ImgRoute { get; set; }
        public List<Ecosystem>? Ecosystems { get; set; }
        public List<Threat>? Threats { get; set; }

        public Species(string cientificName, Name name, string description, decimal weightRangeMin, decimal weightRangeMax, decimal longRangeAdultMin, decimal longRangeAdultMax, List<Ecosystem>? ecosystems, List<Threat>? threats)
        {
            CientificName = cientificName;
            SpeciesName = name;
            Description = description;
            WeightRangeMin = weightRangeMin;
            WeightRangeMax = weightRangeMax;
            LongRangeAdultMin = longRangeAdultMin;
            LongRangeAdultMax = longRangeAdultMax;
            Ecosystems = ecosystems;
            Threats = threats;
        }
        public Species() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(CientificName)) throw new Exception("El nombre científico de la especie es requerido.");
            if (string.IsNullOrEmpty(Description)) throw new Exception("La descripción es requerida.");
            if (WeightRangeMin <= 0 || WeightRangeMax <= 0 || LongRangeAdultMin <= 0 || LongRangeAdultMax <= 0) {
                throw new Exception("Los rangos no pueden ser menores a 1.");
            }            
        }
    }
}
