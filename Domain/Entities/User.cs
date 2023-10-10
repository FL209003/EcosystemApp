using Domain.DomainInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    public class User : IValidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de usuario requerido.")]        
        public required string Username { get; set; }

        [Required(ErrorMessage = "Contraseña requerida.")]
        public required string Password { get; set; }
        public required string Role { get; set; }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Role))
            { throw new Exception("Todos los campos son obligatorios."); }
            if (Username.Length < 6) throw new Exception("El nombre de usuario debe tener al menos 6 caracteres.");
            if (Password.Length < 8) throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            if (string.IsNullOrEmpty(Role)) throw new Exception("Especifique el rol del usuario.");
        }
    }
}
