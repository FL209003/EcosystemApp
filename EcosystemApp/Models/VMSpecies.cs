using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMSpecies
    {
        [Required]
        public Species Species { get; set; }

        [Required(ErrorMessage = "Nombre de la especie requerido.")]
        public String SpeciesNameVAL { get; set; }

        [Required(ErrorMessage = "Imagen de la especie requerida.")]
        public IFormFile ImgSpecies { get; set; }
    }
}
