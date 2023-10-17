using Domain.DomainInterfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;

namespace Domain.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    public class User : IValidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de usuario requerido.")]
        public required string Username { get; set; }
        
        [Required(ErrorMessage = "Contraseña requerida.")]
        [Range(8, int.MaxValue, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public required string Password { get; set; }

        public required string HashPassword { get; set; }

        [Required(ErrorMessage = "Defina el rol del usuario.")]
        public required string Role { get; set; }

        [Column("Fecha de registro")]
        public required DateTime RegDate { get; set; }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            HashPassword = Hash.ComputeSha256Hash(password);
            Role = role;            
            RegDate = DateTime.Now;
        }

        public User() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Role))
            { throw new Exception("Todos los campos son obligatorios."); }
            if (string.IsNullOrEmpty(HashPassword)) throw new Exception("Password no ha hasheado con éxito.");
            if (Username.Length < 6) throw new Exception("El nombre de usuario debe tener al menos 6 caracteres.");
            if (Password.Length < 8) throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            if (string.IsNullOrEmpty(Role)) throw new Exception("Especifique el rol del usuario.");
        }        
    }
}
