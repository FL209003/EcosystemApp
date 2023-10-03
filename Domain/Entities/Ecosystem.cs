using static System.Runtime.InteropServices.JavaScript.JSType;
using AccessLogic.Repositories;

namespace Domain.Entities
{
    public class Ecosystem : IValidate
    {
        public int Id { get; set; }        
        [MinLength(5), MaxLength(20)]
        [Index(IsUnique=true)]       
        public required string Name { get; set; }
        public required string GeoDetails { get; set; }
        [Range (1, decimal.MaxValue, ErrorMessage="El area no debe ser menor a 1")]
        public required decimal Area { get; set; }
        [MinLength(50, ErrorMessage="La descripción debe tener al menos 50 caracteres.")] 
        [MaxLength(500, ErrorMessage="La descripción no puede superer los 500 caracteres.")]
        public required string Description { get; set; }
        public List<Species>? Species { get; set; }
        public List<Threat>? Threats { get; set; }        

        public Ecosystem(string name, string geoDetails, decimal area, string description, List<Species>? species, List<Threat>? threats)
        {
            Name = name;
            GeoDetails = geoDetails;
            Area = area;
            Description = description;
            Species = species;
            Threats = threats;
        }

        public Ecosystem() {}

        public void IValidate() {
            if (string.IsNullOrEmpty(Name)) throw new Exception("El nombre del ecosistema es requerido.");
            if (string.IsNullOrEmpty(GeoDetails)) throw new Exception("Los detalles geográficos son requeridos.");
            if (area == null) throw new Exception("El area es requerida.");
            if (string.IsNullOrEmpty(Description)) throw new Exception("La descripción del ecosistema es requerido.");
            if (Species == null) throw new Exception("Se requiere al menos una especie en el ecosistema.");
            if (Threats == null) throw new Exception("Se requiere al menos una amenaza en el ecosistema.");
        }
    }
}