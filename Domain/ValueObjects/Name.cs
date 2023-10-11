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
        
        [MinLength(2), MaxLength(50)]
        public string Value { get; private set; }

        public Name(string value)
        {
            Value = value;
            Validate();
        }

        private Name() { }

        public void Validate() 
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("El nombre es requerido.");
        }  
    }
}
