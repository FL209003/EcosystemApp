using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class AddEcoUC : IAddEcosystem
    {
        
        public IRepositoryEcosystems EcosRepo { get; set; }

        public AddEcoUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }
        public void Add(Ecosystem eco)
        {
            EcosRepo.Add(eco);
        }
    }
}
