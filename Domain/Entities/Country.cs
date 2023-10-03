using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : IValidate
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(20)]
        [Index(IsUnique=true)]
        public required string Name { get; set; }
        public required string Alpha3 { get; set; }

        public Country(string name, string alpha3)
        {
            Name = name;
            Alpha3 = alpha3;
        }

        public void IValidate() {
            if (string.IsNullOrEmpty(Name)) throw new Exception("El nombre del país es requerido.");
            if (string.IsNullOrEmpty(Alpha3)) throw new Exception("El codigo alfanumérico del país es requerido.");
        }
    }
}
