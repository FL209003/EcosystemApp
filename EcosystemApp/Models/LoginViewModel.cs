using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class LoginViewModel
    {
        [Required]
        public required User User { get; set; }        
    }
}
