using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcosystemApp.Models
{
    public class VMEcosystem
    {

        public  Ecosystem Ecosystem { get; set; }


        public  String EcosystemNameVAL { get; set; }


        public  String EcoDescriptionVAL { get; set; }

        public  String Lat { get; set; }

        public  String Long { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public List<int> IdSelectedCountry { get; set; }

        public  IFormFile ImgEco { get; set; }
    }
}