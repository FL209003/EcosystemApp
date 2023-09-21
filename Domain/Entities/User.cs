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

        public string Username { get; set; }

        public string Password { get; set; }

        public string Rol {  get; set; }

        public User(string username, string password, string rol)
        {
            Username = username;
            Password = password;
            Rol = rol;
        }

        public User() { }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Rol))
            { throw new Exception("Todos los campos son obligatorios."); }
        }
    }
}
