using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMEcosystem
    {
        [Required]
        public Ecosystem Ecosystem { get; set; }

        [Required]
        public String EcosystemNameVAL { get; set; }
    }
}