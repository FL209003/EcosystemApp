using Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User, IValidate
    {
        public Admin(string username, string password) : base(username, password)
        {
        }

        public override void Validate()
        {
            base.Validate();
        }
    }
}
