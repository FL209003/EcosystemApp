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

        [Column("Descripción")]
        public required Description SpeciesDescription { get; set; }

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

        public Species(string cientificName, Name name, Description description, decimal weightRangeMin, decimal weightRangeMax, decimal longRangeAdultMin, decimal longRangeAdultMax, string imgRoute, List<Ecosystem>? ecosystems, List<Threat>? threats)
        {
            CientificName = cientificName;
            SpeciesName = name;
            SpeciesDescription = description;
            WeightRangeMin = weightRangeMin;
            WeightRangeMax = weightRangeMax;
            LongRangeAdultMin = longRangeAdultMin;
            LongRangeAdultMax = longRangeAdultMax;
            ImgRoute = imgRoute;
            Ecosystems = ecosystems;
            Threats = threats;
        }
        public Species() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(CientificName)) throw new Exception("El nombre científico de la especie es requerido.");            
            if (WeightRangeMin <= 0 || WeightRangeMax <= 0 || LongRangeAdultMin <= 0 || LongRangeAdultMax <= 0) {
                throw new Exception("Los rangos no pueden ser menores a 1.");
            }            
        }
    }
}
