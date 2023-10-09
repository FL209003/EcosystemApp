using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IValidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de usuario requerido.")]
        [Index(nameof(Username), IsUnique = true , ErrorMessage="El nombre de usuario ya esta en uso.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Contraseña requerida.")]
        public required string Password { get; set; }
        public required string Rol { get; set; }

        public User(string username, string password, string rol)
        {
            Username = username;
            Password = password;
            Rol = rol;
        }

        public User() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Rol))
            { throw new Exception("Todos los campos son obligatorios."); }
            if (Username.Length < 6) throw new Exception("El nombre de usuario debe tener al menos 6 caracteres.");
            if (Password.Length < 8) throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            if (string.IsNullOrEmpty(Rol)) throw new Exception("Especifique el rol del usuario.");
        }
    }
}
