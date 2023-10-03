using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conservation : IValidate
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(20)]
        [Index(IsUnique=true)]
        public required string Name { get; set; }        
        public required string State { get; set; }

        public Conservation(string name, string state)
        {
            Name = name;
            State = state;
        }

        public void IValidate() {
            if (string.IsNullOrEmpty(Name)) throw new Exception("El nombre del estado de conservación es requerido.");
            if (string.IsNullOrEmpty(State)) throw new Exception("El estado de la conservación es requerido.");
        }
    }
}
