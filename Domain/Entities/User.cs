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
    public abstract class User : IValidate
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            { throw new Exception("Todos los campos son obligatorios."); }
        }
    }
}
