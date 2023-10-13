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

        [Column("Estado")]
        [Required(ErrorMessage = "Estado de conservación requerido.")]        
        public required Name ConservationName { get; set; }       

        [Column("Rango de conservación mínimo")]
        [Range(0, 100, ErrorMessage = "El valor debe ser entre 0 y 100.")]
        public required int MinSecurityRange { get; set; }   

        [Column("Rango de conservación máximo")]
        [Range(0, 100, ErrorMessage = "El valor debe ser entre 0 y 100.")]
        public required int MaxSecurityRange { get; set; }        

        public Conservation(Name conservationName,int minSecurity, int maxSecurity)
        {
            ConservationName = conservationName;
            MinSecurityRange = minSecurity;   
            MaxSecurityRange = maxSecurity;              
        }

        public Conservation() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(ConservationName.Value)) throw new Exception("El estado de la conservación es requerido.");
            if (MinSecurityRange < 0 || MaxSecurityRange < 0 || MinSecurityRange > 100 || MaxSecurityRange > 100) 
            { throw new Exception("Debe ser un valor entre 0 y 100."); }
            if (MaxSecurityRange <= MinSecurityRange) 
            { throw new Exception("El rango de conservación mínimo debe ser menor al máximo y visceversa."); }
            if (ConservationName.Value == "Malo" && MaxSecurityRange >= 60) throw new Exception("Rango de conservación Mala: 0 - 59.");
            if (ConservationName.Value == "Aceptable" && MinSecurityRange < 60 || 
                ConservationName.Value == "Aceptable" && MaxSecurityRange > 70) 
            { throw new Exception("Rango de conservación Aceptable: 60 - 70."); }
            if (ConservationName.Value == "Bueno" && MinSecurityRange < 71 || 
                ConservationName.Value == "Bueno" && MaxSecurityRange > 94) 
            { throw new Exception("Rango de conservación Bueno: 71 - 94."); }
            if (ConservationName.Value == "Óptimo" && MinSecurityRange < 95 || 
                ConservationName.Value == "Óptimo" && MaxSecurityRange > 100) 
            { throw new Exception("Rango de conservación Óptimo: 95 - 100."); }
        }        
    }
}
