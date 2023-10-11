using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.DomainInterfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Ecosystem : IValidate
    {
        public int Id { get; set; }

        [Column("Nombre")]
        [Required(ErrorMessage = "Nombre del ecosistema requerido.")]
        public required Name EcosystemName { get; set; }

        [Column("Ubicación")]
        [Required(ErrorMessage = "Ubicación geográfica requerida.")]
        public required string GeoDetails { get; set; }

        [Column("Área")]
        [Required(ErrorMessage = "Área requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "El area no debe ser menor a 1")]
        public required decimal Area { get; set; }

        [Column("Descripción")]
        [Required(ErrorMessage = "Descripción requerida.")]
        [MinLength(50, ErrorMessage = "La descripción debe tener al menos 50 caracteres.")]
        [MaxLength(500, ErrorMessage = "La descripción no puede superer los 500 caracteres.")]
        public required string Description { get; set; }

        // Convertir en VO que tenga ambos values y modificar con ToString() para que se muestre como coordenada.

        //[Required(ErrorMessage = "Latitud requerida.")]
        //[Range(-90 , 90)]
        //public decimal Latitude { get; set; }

        //[Required(ErrorMessage = "Longitud requerida.")]
        //[Range(-180, 180)]
        //public decimal Longitude { get; set; }

        [Column("Imagen")]
        [Display(Name = "Imagen")]
        public string ImgRoute { get; set; }
        public List<Species>? Species { get; set; }
        public List<Threat>? Threats { get; set; }

        [Required(ErrorMessage = "Seleccione al menos un país.")]
        public required List<Country> Countries { get; set; }

        public Ecosystem(Name name, decimal area, string description, string geoDetails, List<Species>? species, List<Threat>? threats)
        {
            EcosystemName = name;
            GeoDetails = geoDetails;
            Area = area;
            Description = description;
            Species = species;
            Threats = threats;
        }

        public Ecosystem() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(GeoDetails)) throw new Exception("Los detalles geográficos son requeridos.");
            if (string.IsNullOrEmpty(Description)) throw new Exception("La descripción del ecosistema es requerida.");
        }
    }
}