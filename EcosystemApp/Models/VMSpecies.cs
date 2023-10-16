using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMSpecies
    {
        [Required]
        public Species Species { get; set; }

        [Required(ErrorMessage = "Nombre de la especie requerido.")]
        public String SpeciesNameVal { get; set; }

        [Required(ErrorMessage = "Descripción de la especie requerida.")]
        public String SpeciesDescriptionVal { get; set; }

        public IEnumerable<Threat>? Threats { get; set; }

        public int IdSelectedThreat { get; set; }

        [Required(ErrorMessage = "Imagen de la especie requerida.")]
        public IFormFile ImgSpecies { get; set; }
    }
}
