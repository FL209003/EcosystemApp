using Domain.DomainInterfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : IValidate
    {
        public int Id { get; set; }
        public required Name CountryName { get; set; }
        public required string Alpha3 { get; set; }

        public Country(Name name, string alpha3)
        {
            CountryName = name;
            Alpha3 = alpha3;
        }

        public Country() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Alpha3)) throw new Exception("El codigo alfanumérico del país es requerido.");
        }
    }
}
