using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Description
    {        
        [Required(ErrorMessage = "Descripción requerida.")]
        public string Value { get; private set; }
        public static int MinLength { get; set; }
        public static int MaxLength { get; set; }

        public Description(string value)
        {
            Value = value;            
            Validate();
        }

        private Description() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Value)) throw new Exception("Descripción es requerida.");
            if (Value.Length < MinLength || Value.Length > MaxLength)
            { throw new Exception("Descripción debe tener entre " + MinLength + " y " + MaxLength + " caracteres."); }
        }
    }
}
