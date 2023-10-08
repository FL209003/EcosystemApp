using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class LoginViewModel
    {
        [Required]        
        public string Username { get; set; }

        [Required]        
        public string Password { get; set; }
    }
}
