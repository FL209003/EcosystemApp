using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMSpecies
    {
        [Required]
        public Species Species { get; set; }

        [Required]
        public String SpeciesNameVAL { get; set; }
    }
}
