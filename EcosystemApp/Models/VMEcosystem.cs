using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMEcosystem
    {
        [Required]
        public Ecosystem Ecosystem { get; set; }

        [Required(ErrorMessage = "Nombre del ecosistema requerido.")]
        public String EcosystemNameVAL { get; set; }

        [Required(ErrorMessage = "Descripción del ecosistema requerida.")]
        public String EcoDescriptionVAL { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public int IdSelectedCountry { get; set; }

        [Required(ErrorMessage = "Imagen del ecosistema requerida.")]
        public IFormFile ImgEco { get; set; }
    }
}