using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class GeoUbication : IValidate
    {
        [Required(ErrorMessage = "Latitud requerida.")]
        [Range(-90, 90, ErrorMessage = "Rango de -90 a 90.")]
        public decimal Latitude { get; private set; }

        [Required(ErrorMessage = "Longitud requerida.")]
        [Range(-180, 180, ErrorMessage = "Rango de -180 a 180.")]
        public decimal Longitude { get; private set; }

        [Required(ErrorMessage = "Longitud requerida.")]
        public string GeoDetails { get; private set; }

        public GeoUbication(decimal latitude, decimal longitude)
        {
            GeoDetails = SetGeoDetails(latitude, longitude);
            Validate();
        }

        public GeoUbication() { }

        private static string SetGeoDetails(decimal latitude, decimal longitude)
        {
            string lat = latitude.ToString();
            string lon = longitude.ToString();
            string ubication = "Latitud: " + lat + "Longitud: " + lon;
            return ubication;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }        
    }
}
