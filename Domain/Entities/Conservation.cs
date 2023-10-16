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
        
        [Required(ErrorMessage = "Estado de conservación requerido.")]
        public Name ConservationName { get; set; }

        [Column("Rango de seguridad mínimo")]
        public int MinSecurityRange { get; set; }

        [Column("Rango de seguridad máximo")]
        public int MaxSecurityRange { get; set; }

        public List<Ecosystem>? ConservationEcosystems { get; set; }

        public List<Species>? ConservationSpecies { get; set; }

        public Conservation(Name conservationName, int security)
        {
            ConservationName = conservationName;
            MinSecurityRange = SetMinSecurityRange(conservationName.Value);
            MaxSecurityRange = SetMaxSecurityRange(conservationName.Value);
        }

        public Conservation() { }

        public void Validate()
        {
            //if (string.IsNullOrEmpty(ConservationName.Value)) throw new Exception("El estado de la conservación es requerido.");
            //if (Security < 0 || Security > 100) throw new Exception("Indique un valor entre 0 y 100.");
            //if (ConservationName.Value == "Malo" && Security > 59) throw new Exception("Conservación mala: 0 - 59");
            //if (ConservationName.Value == "Aceptable" && Security < 60 || ConservationName.Value == "Aceptable" && Security > 70)
            //{
            //    throw new Exception("Conservación aceptable: 60 - 70");
            //}
            //if (ConservationName.Value == "Bueno" && Security < 71 || ConservationName.Value == "Bueno" && Security > 94)
            //{
            //    throw new Exception("Conservación aceptable: 71 - 94");
            //}
            //if (ConservationName.Value == "Óptimo" && Security < 95) throw new Exception("Conservación aceptable: 95 - 100");
        }

        public static int SetMinSecurityRange(string conservationName)
        {
            if (conservationName == "Malo") return 0;
            if (conservationName == "Aceptacble") return 60;
            if (conservationName == "Bueno") return 71;
            else return 95;
        }

        public static int SetMaxSecurityRange(string conservationName)
        {
            if (conservationName == "Malo") return 59;
            if (conservationName == "Aceptacble") return 70;
            if (conservationName == "Bueno") return 94;
            else return 100;
        }
    }
}
