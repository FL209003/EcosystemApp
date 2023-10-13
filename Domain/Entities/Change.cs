using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Change : IValidate
    {
        public int Id { get; set; }
        public int UserId { get; set; }        
        public DateTime ChangeDate { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
