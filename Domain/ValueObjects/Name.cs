using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Name : IValidate
    {
        public string Value { get; private set; }
        public static int MinLength { get; set; }
        public static int MaxLength { get; set; }

        public Name(string value)
        {
            Value = value;            
            Validate();
        }

        private Name() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("El nombre es requerido.");
            if (Value.Length < MinLength || Value.Length > MaxLength)
            { throw new Exception("Nombre debe tener entre " + MinLength.ToString() + " y " + MaxLength.ToString() + " caracteres."); }
        }
    }
}
