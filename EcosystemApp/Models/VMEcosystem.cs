using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMEcosystem
    {
        [Required]
        public required Ecosystem Ecosystem { get; set; }

        [Required(ErrorMessage = "Nombre del ecosistema requerido")]
        public required String EcosystemNameVAL { get; set; }

        [Required(ErrorMessage = "Imagen del ecosistema requerida.")]
        public required IFormFile ImgEco { get; set; }
    }
}