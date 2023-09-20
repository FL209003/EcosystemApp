using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMUser
    {
        [Required]
        public GenericUser User { get; set; }

        [Required] 
        public string VerificationPass { get; set; }
    }
}
