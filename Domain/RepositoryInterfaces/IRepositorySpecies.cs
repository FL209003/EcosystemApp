using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositorySpecies : IRepository<Species>
    {
        object FindByCientificName();
        object FindByDangerOfExtinction();
        object FindByEco();        
        object FindByWeight();
    }
}
