﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.DomainInterfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Ecosystem : IValidate
    {
        public int Id { get; set; }
                
        [Column("Nombre")]
        public Name EcosystemName { get; set; }

        [Column("Ubicación")]
        [Required(ErrorMessage = "Ubicación geográfica requerida.")]
        public string GeoDetails { get; set; }

        [Column("Área")]
        [Required(ErrorMessage = "Área requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "El area no debe ser menor a 1.")]
        public decimal Area { get; set; }

        [Column("Descripción")]
        public Description EcoDescription { get; set; }

        [Column("Estado de conservación")]
        [Required(ErrorMessage = "Estado de conservación requerido.")]
        public Conservation EcoConservation { get; set; }

        [Column("Imagen")]
        [Required(ErrorMessage = "Se requiere una imagen.")]
        [Display(Name = "Imagen")]
        public string ImgRoute { get; set; }

        [Column("Seguridad")]
        public int Security { get; set; }
        public List<Species>? Species { get; set; }
        public List<Threat>? Threats { get; set; }

        [Required(ErrorMessage = "Seleccione al menos un país.")]
        public List<Country> Countries { get; set; }

        public Ecosystem(Name name, decimal area, Description description, string geoDetails, Conservation ecoConservation, string imgRoute, List<Species>? species, List<Threat>? threats, List<Country> countries, int security)
        {
            EcosystemName = name;
            GeoDetails = geoDetails;
            Area = area;
            EcoDescription = description;
            EcoConservation = ecoConservation;
            ImgRoute = imgRoute;
            Species = species;
            Threats = threats;
            Countries = countries;
            Security = security;
        }

        public Ecosystem() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(GeoDetails)) throw new Exception("Los detalles geográficos son requeridos.");
            if (Area < 1) throw new Exception("El área no debe ser menor a 1 km cuadrado.");
            if (string.IsNullOrEmpty(ImgRoute)) throw new Exception("Imagen del ecosistema requerida.");
            if (Countries == null) throw new Exception("El ecosistema debe estar en al menos un país.");
            if (Security < 0 || Security > 100) throw new Exception("Indique un valor entre 0 y 100.");
            if (EcoConservation.ConservationName.Value == "Malo" && Security > 59) throw new Exception("Conservación mala: 0 - 59");
            if (EcoConservation.ConservationName.Value == "Aceptable" && Security < 60 ||
                EcoConservation.ConservationName.Value == "Aceptable" && Security > 70)
            { throw new Exception("Conservación aceptable: 60 - 70"); }
            if (EcoConservation.ConservationName.Value == "Bueno" && Security < 71 ||
                EcoConservation.ConservationName.Value == "Bueno" && Security > 94)
            { throw new Exception("Conservación aceptable: 71 - 94"); }
            if (EcoConservation.ConservationName.Value == "Óptimo" && Security < 95)
            { throw new Exception("Conservación aceptable: 95 - 100"); }
        }
    }
}