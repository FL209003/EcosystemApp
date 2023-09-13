using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities
{
    public class Ecosystem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GeoDetails { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
        public List<Species>? Species { get; set; }
        public List<Threat>? Threats { get; set; }

        public Ecosystem() { }
        public Ecosystem(string name, string geoDetails, decimal area, string description, List<Species>? species, List<Threat>? threats)
        {
            Name = name;
            GeoDetails = geoDetails;
            Area = area;
            Description = description;
            Species = species;
            Threats = threats;
        }
    }
}