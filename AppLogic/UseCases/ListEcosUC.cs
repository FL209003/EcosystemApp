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
    public class ListEcosUC : IListEcosystem
    {
        public IRepositoryEcosystems EcosRepo { get; set; }

        public ListEcosUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }
        
        public List<Ecosystem> List() 
        {
            return EcosRepo.FindAll().ToList();
        }
    }
}