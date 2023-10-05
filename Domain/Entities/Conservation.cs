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
    public class Conservation : IValidate
    {
        public int Id { get; set; }              
        public required Name ConservationName { get; set; }        
        public required string State { get; set; }

        public Conservation(Name name, string state)
        {
            ConservationName = name;
            State = state;
        }

        public void Validate() {            
            if (string.IsNullOrEmpty(State)) throw new Exception("El estado de la conservación es requerido.");
        }
    }
}
