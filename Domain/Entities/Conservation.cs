using Domain.DomainInterfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conservation : IValidate
    {
        public int Id { get; set; }

        [Column("Name")]
        public required Name ConservationName { get; set; }
        public required int Security { get; set; }
        public required string State { get; set; }

        public Conservation(Name name, int security)
        {
            ConservationName = name;
            Security = security;
            State = SetState(security);
        }

        public Conservation() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(State)) throw new Exception("El estado de la conservación es requerido.");
            if (Security < 0) { throw new Exception("El valor no puede ser menor a 0."); }
            if (Security > 100) { throw new Exception("El valor no puede ser mayor a 100."); }
        }

        public static string SetState(int security)
        {
            if (security < 60) { return "Malo"; }
            if (security >= 60 && security <= 70) { return "Aceptable"; }
            if (security > 70 && security < 95) { return "Muy bueno"; }
            else return "Óptimo";
        }
    }
}
